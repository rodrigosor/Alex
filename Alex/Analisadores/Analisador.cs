using Alex.Alfabetos;

namespace Alex.Analisadores
{
    public abstract class Analisador
    {
        /// Alfabeto das letras
        /// </summary>
        public Alfabeto Letras { get; private set; }

        /// <summary>
        /// Alfabeto dos dígitos
        /// </summary>
        public Alfabeto Digitos { get; private set; }

        /// <summary>
        /// Alfabeto dos símbolos
        /// </summary>
        public Alfabeto Simbolos { get; private set; }

        /// <summary>
        /// Alfabeto dos símbolos de controle.
        /// </summary>
        public Alfabeto Controles { get; private set; }
    }
}
