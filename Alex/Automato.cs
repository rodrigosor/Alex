using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alex
{
    public class Automato
    {
        /// <summary>
        /// Alfabeto de letras.
        /// </summary>
        public Alfabeto Letra { get; private set; }

        /// <summary>
        /// Alfabeto de dígitos.
        /// </summary>
        public Alfabeto Digito { get; private set; }

        /// <summary>
        /// Alfabeto de símbolos.
        /// </summary>
        public Alfabeto Simbolo { get; private set; }

        /// <summary>
        /// Alfabeto de operadores.
        /// </summary>
        public Alfabeto Operador { get; private set; }

        /// <summary>
        /// Representa o estado atual do automato.
        /// </summary>
        private Estado estado;

        /// <summary>
        /// Texto a ser analisado pelo automato.
        /// </summary>
        private string texto;

        public Automato()
        {

        }
    }
}
