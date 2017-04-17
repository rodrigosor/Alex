using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alex
{
    public class Analisador
    {
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
            Letra = new Alfabeto("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");
            Digito = new Alfabeto("0123456789");
            Simbolo = new Alfabeto("'!@#$%¨&(),:><_ ");
            CodigoFonte = new CodigoFonte(arquivo);
            _resultado = new StringBuilder();
        }

        private void Reconhecer(ref string lexema, Token token)
        {
            _resultado.Append(
                    string.Format("<{0}, {1}> ", token.ToString(), lexema)
                );

            lexema = "";
        }

        private void NaoReconhecer(ref string lexema, char caractere)
        {
            if (lexema.Length > 0)
            {
                Reconhecer(ref lexema, Token.NaoReconhecido);
            }

            lexema += caractere;
        }

        public void ProcessarAnaliseLexica()
        {
            // guarda o lexema em análise.
            var lexema = string.Empty;

            // configura um estado inicial.
            var token = Token.NaoReconhecido;

            for (int i = 0; i < CodigoFonte.TextoConcatenado.Length; ++i)
            {
                var caractere = CodigoFonte.TextoConcatenado[i];

                switch (token)
                {
                    case Token.NaoReconhecido:

                        if (caractere.Simbolo(this))
                        {
                            lexema += caractere;
                            token = Token.NaoReconhecido;
                        }
                        else if (caractere.Letra(this))
                        {
                            NaoReconhecer(ref lexema, caractere);
                            token = Token.ID;
                        }
                        else if (caractere.Digito(this))
                        {
                            NaoReconhecer(ref lexema, caractere);
                            token = Token.ConstInteira;
                        }
                        else if (caractere.AspasDuplas())
                        {
                            NaoReconhecer(ref lexema, caractere);
                            token = Token.ConstString;
                        }

                        break;

                    // Deve iniciar com uma letra seguida de 0 ou mais produções de letras, dígitos e/ou caracteres _.
                    case Token.ID:

                        if (caractere.LetraDigitoSublinhado(this))
                        {
                            lexema += caractere;
                            token = Token.ID;
                        }
                        else
                        {
                            if (!caractere.Simbolo(this))
                            {
                                Reconhecer(ref lexema, Token.ID);
                            }

                            --i;
                            token = Token.NaoReconhecido;
                        }

                        break;

                    // Cadeia numérica contendo 1 ou mais produções de dígitos.
                    case Token.ConstInteira:

                        if (caractere.Digito(this))
                        {
                            lexema += caractere;
                            token = Token.ConstInteira;
                        }
                        else if (caractere.Ponto())
                        {
                            lexema += caractere;
                            token = Token.ConstReal;
                        }
                        else
                        {
                            if (!caractere.Simbolo(this))
                            {
                                Reconhecer(ref lexema, Token.ConstInteira);
                            }

                            --i;
                            token = Token.NaoReconhecido;
                        }

                        break;

                    // Cadeia numérica contendo 1 ou mais produções de dígitos, 
                    // tendo em seguida um símbolo de ponto à frente de 0 ou mais produções de dígitos.
                    case Token.ConstReal:

                        if (caractere.Digito(this))
                        {
                            lexema += caractere;
                            token = Token.ConstReal;
                        }
                        else
                        {
                            if (!caractere.Simbolo(this))
                            {
                                Reconhecer(ref lexema, Token.ConstReal);
                            }

                            --i;
                            token = Token.NaoReconhecido;
                        }

                        break;

                    // Deve iniciar e finalizar com o caractere " (aspas) contendo entre esses 
                    // uma sequênciade 0 ou mais produções de letras, dígitos e/ou símbolos.
                    case Token.ConstString:

                        if (caractere.LetraDigitoSimbolo(this))
                        {
                            lexema += caractere;
                            token = Token.ConstString;
                        }
                        else if (caractere.AspasDuplas())
                        {
                            Reconhecer(ref lexema, Token.ConstString);
                            token = Token.NaoReconhecido;
                        }

                        break;
                }
            }

            if (lexema.Length > 0)
            {
                Reconhecer(ref lexema, Token.NaoReconhecido);
            }
        }
    }
}
