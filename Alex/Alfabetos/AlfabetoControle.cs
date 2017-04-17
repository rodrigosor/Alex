using Alex.Artefatos;
using System;

namespace Alex.Alfabetos
{
    /// <summary>
    /// Alfabeto dos caracteres de controle.
    /// </summary>
    public class AlfabetoControle : Alfabeto
    {
        public AlfabetoControle() : base(string.Concat(Convert.ToChar(ASCII.SPACE), Convert.ToChar(ASCII.HT)))
        { }
    }
}
