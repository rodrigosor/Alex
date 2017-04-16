using System.Collections.Generic;

namespace Alex
{
    public class Alfabeto : List<char>
    {
        /// <summary>
        /// Cria um novo alfabeto utilizando os simbolos.
        /// </summary>
        /// <param name="simbolos"><see cref="string"/> contento os símbolos que compões o alfabeto.</param>
        public Alfabeto(string simbolos)
        {
            var caracteres = simbolos.ToCharArray();

            foreach (var caractere in caracteres)
            {
                if (!Contains(caractere))
                {
                    Add(caractere);
                }
            }
        }
    }
}
