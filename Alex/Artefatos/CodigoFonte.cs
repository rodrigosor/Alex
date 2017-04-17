using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Alex.Artefatos
{
    public class CodigoFonte
    {
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
                    if (caractere != ASCII.HT && caractere != ASCII.LF && caractere != ASCII.CR)
                    {
                        buffer.Append(caractere);
                    }
                }

                TextoConcatenado = buffer.ToString();
                //TextoConcatenado = Regex.Replace(TextoConcatenado, @"\s+", " ");
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
