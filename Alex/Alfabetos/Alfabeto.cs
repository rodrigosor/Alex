using System.Collections.Generic;

namespace Alex.Alfabetos
{
    /// <summary>
    /// Manipula um alfabeto.
    /// </summary>
    public abstract class Alfabeto : List<char>
    {
        /// <summary>
        /// Cria um novo alfabeto para os símbolos informados.
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
