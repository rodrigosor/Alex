using System;
using System.IO;
using System.Text;

namespace Alex.Artefatos
{
    public class CodigoFonte
    {
        /// <summary>
        /// Código da tabela ASCII para o caractere de tabulação.
        /// </summary>
        private const int TAB = 9;

        /// <summary>
        /// Código da tabela ASCII para o caractere de nova linha (LF).
        /// </summary>
        private const int NOVA_LINHA = 10;

        /// <summary>
        /// Código da tabela ASCII para o caractere de qubra de linha (CR).
        /// </summary>
        private const int QUEBRA_LINHA = 13;

        /// <summary>
        /// Código da tabela ASCII para o caractere de espaço em branco.
        /// </summary>
        private const int ESPACO_BRANCO = 32;

        /// <summary>
        /// O texto do código fonte.
        /// </summary>
        public string Texto { get; private set; }

        /// <summary>
        /// O texto do código fonte sem caracteres TAB, LF, CR e espaço.
        /// </summary>
        public string TextoConcatenado { get; private set; }

        /// <summary>
        /// Cria uma nova instancia de codigo fonte fazendo a remoção de caracteres TAB, LF, CR e espaço.
        /// </summary>
        /// <param name="arquivo">Caminho do arquivo.</param>
        public CodigoFonte(string arquivo)
        {
            if (!string.IsNullOrWhiteSpace(arquivo) || !File.Exists(arquivo))
            {
                Texto = File.ReadAllText(arquivo);

                var buffer = new StringBuilder();

                foreach (var caractere in Texto)
                {
                    if (caractere != TAB && caractere != NOVA_LINHA && caractere != QUEBRA_LINHA && caractere != ESPACO_BRANCO)
                    {
                        buffer.Append(caractere);
                    }
                }

                TextoConcatenado = buffer.ToString();
            }
            else
            {
                throw new NullReferenceException("Nome de arquivo nulo ou inválido.");
            }
        }

        /// <summary>
        /// Representação string do objeto.
        /// </summary>
        /// <returns>A epresentação string do objeto</returns>
        public override string ToString()
        {
            return TextoConcatenado;
        }
    }
}
