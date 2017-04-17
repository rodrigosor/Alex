using System.Collections.Generic;

namespace Alex
{
    public class Alfabeto : List<char>
    {
        /// <summary>
        /// Cria um novo alfabeto para os simbolos informados.
        /// </summary>
        public Alfabeto(string simbolos)
        {
            foreach (var caractere in simbolos)
            {
                if (!Contains(caractere))
                {
                    Add(caractere);
                }
            }
        }
    }
}
