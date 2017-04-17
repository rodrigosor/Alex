using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alex
{
    public class Analisador
    {
        /// <summary>
        /// Cursor para navegação entre caracteres do fonte em análise.
        /// </summary>
        private int _cursor;

        /// <summary>
        /// Lexema em análise.
        /// </summary>
        public string Lexema { get; private set; }

        /// <summary>
        /// Manipula o possível token do lexema em análise.
        /// </summary>
        public Token Token { get; private set; }

        /// <summary>
        /// Buffer para o resultado da análise.
        /// </summary>
        private StringBuilder _resultado;

        /// <summary>
        /// Alfabeto das letras
        /// </summary>
        public Alfabeto Letra { get; private set; }

        /// <summary>
        /// Alfabeto dos dígitos
        /// </summary>
        public Alfabeto Digito { get; private set; }

        /// <summary>
        /// Alfabeto dos símbolos
        /// </summary>
        public Alfabeto Simbolo { get; private set; }

        /// <summary>
        /// Código fonte a ser analisado.
        /// </summary>
        public CodigoFonte CodigoFonte { get; private set; }

        /// <summary>
        /// Resultado da analise léxica.
        /// </summary>
        public string Resultado
        {
            get
            {
                return _resultado.ToString().Trim();
            }
        }

        /// <summary>
        /// Cria um analisador lexico para o aqruivo.
        /// </summary>
        /// <param name="arquivo">Caminho do arquivo.</param>
        public Analisador(string arquivo)
        {
            Lexema = string.Empty;
            Token = Token.NaoReconhecido;
            Letra = new Alfabeto("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");
            Digito = new Alfabeto("0123456789");
            Simbolo = new Alfabeto("'!@#$%¨&(),:><_ ");
            CodigoFonte = new CodigoFonte(arquivo);
            _resultado = new StringBuilder();
        }

        private void TestarToken(Token token)
        {
            Token = token;
        }

        private void TestarProximoCaractereComo(Token token, char caractere)
        {
            Lexema += caractere;
            TestarToken(token);
        }

        private void TokenNaoReconhecido()
        {
            --_cursor;
            TestarToken(Token.NaoReconhecido);
        }

        private void GravarResultadoComo(Token token, char caractere)
        {
            if (!caractere.Simbolo(this))
            {
                GravarReconhecimento(token);
            }

            TokenNaoReconhecido();
        }

        private void GravarReconhecimento(Token token)
        {
            _resultado.Append(
                    string.Format("<{0}, {1}> ", token.ToString(), Lexema)
                );
            Lexema = "";
        }

        private void GravarReconhecimentoEFinalizar(Token token, char caractere)
        {
            Lexema += caractere;
            GravarReconhecimento(Token);
            TestarToken(Token.NaoReconhecido);
        }

        private void GravarPadraoNaoReconhecido()
        {
            if (Lexema.Length > 0)
            {
                GravarReconhecimento(Token.NaoReconhecido);
            }
        }

        private void TestarPadraoNaoReconhecido(char caractere)
        {
            GravarPadraoNaoReconhecido();
            Lexema += caractere;
        }

        public void ProcessarAnaliseLexica()
        {
            for (_cursor = 0; _cursor < CodigoFonte.TextoConcatenado.Length; ++_cursor)
            {
                var caractere = CodigoFonte.TextoConcatenado[_cursor];

                switch (Token)
                {
                    case Token.NaoReconhecido:

                        if (caractere.Simbolo(this))
                        {
                            TestarProximoCaractereComo(Token.NaoReconhecido, caractere);
                        }
                        else if (caractere.Letra(this))
                        {
                            TestarPadraoNaoReconhecido(caractere);
                            TestarToken(Token.ID);
                        }
                        else if (caractere.Digito(this))
                        {
                            TestarPadraoNaoReconhecido(caractere);
                            TestarToken(Token.ConstInteira);
                        }
                        else if (caractere.AspasDuplas())
                        {
                            TestarPadraoNaoReconhecido(caractere);
                            TestarToken(Token.ConstString);
                        }

                        break;

                    // Deve iniciar com uma letra seguida de 0 ou mais produções de letras, dígitos e/ou caracteres _.
                    case Token.ID:

                        if (caractere.LetraDigitoSublinhado(this))
                        {
                            TestarProximoCaractereComo(Token.ID, caractere);
                        }
                        else
                        {
                            GravarResultadoComo(Token.ID, caractere);
                        }

                        break;

                    // Cadeia numérica contendo 1 ou mais produções de dígitos.
                    case Token.ConstInteira:

                        if (caractere.Digito(this))
                        {
                            TestarProximoCaractereComo(Token.ConstInteira, caractere);
                        }
                        else if (caractere.Ponto())
                        {
                            TestarProximoCaractereComo(Token.ConstReal, caractere);
                        }
                        else
                        {
                            GravarResultadoComo(Token.ConstInteira, caractere);
                        }

                        break;

                    // Cadeia numérica contendo 1 ou mais produções de dígitos, 
                    // tendo em seguida um símbolo de ponto à frente de 0 ou mais produções de dígitos.
                    case Token.ConstReal:

                        if (caractere.Digito(this))
                        {
                            TestarProximoCaractereComo(Token.ConstReal, caractere);
                        }
                        else
                        {
                            GravarResultadoComo(Token.ConstReal, caractere);
                        }

                        break;

                    // Deve iniciar e finalizar com o caractere " (aspas) contendo entre esses 
                    // uma sequênciade 0 ou mais produções de letras, dígitos e/ou símbolos.
                    case Token.ConstString:

                        if (caractere.LetraDigitoSimbolo(this))
                        {
                            TestarProximoCaractereComo(Token.ConstString, caractere);
                        }
                        else if (caractere.AspasDuplas())
                        {
                            GravarReconhecimentoEFinalizar(Token.ConstString, caractere);
                            //GravarReconhecimento(Token.ConstString);
                            //TestarToken(Token.NaoReconhecido);
                        }

                        break;
                }
            }

            GravarPadraoNaoReconhecido();
        }
    }
}
