using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alex
{
    /// <summary>
    /// Provê uma série de métodos para estender a classe <see cref="Char"/>.
    /// </summary>
    public static class Lexemas
    {
        /// <summary>
        /// Verifica se um determinado caractere faz parte do alfabeto.
        /// </summary>
        /// <param name="alfabeto">O alfabeto a ser pesquisado.</param>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere faz parte do alfabeto.</returns>
        public static bool Contem(this Alfabeto alfabeto, char caractere)
        {
            return alfabeto.Contains(caractere);
        }

        /// <summary>
        /// Determina se o caractere em questão faz parte do alfabeto de letras.
        /// </summary>
        /// <param name="automato">Automato que possui o alfabeto de letras.</param>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere faz parte do alfabeto de letras.</returns>
        public static bool Letra(this Automato automato, char caractere)
        {
            return automato.Letra.Contem(caractere);
        }

        /// <summary>
        /// Determina se o caractere em questão faz parte do alfabeto de dígitos.
        /// </summary>
        /// <param name="automato">Automato que possui o alfabeto de dígitos.</param>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere faz parte do alfabeto de dígitos.</returns>
        public static bool Digito(this Automato automato, char caractere)
        {
            return automato.Digito.Contem(caractere);
        }

        /// <summary>
        /// Determina se o caractere em questão faz parte do alfabeto de operadores.
        /// </summary>
        /// <param name="automato">Automato que possui o alfabeto de operadores.</param>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere faz parte do alfabeto de operadores.</returns>
        public static bool Operador(this Automato automato, char caractere)
        {
            return automato.Operador.Contem(caractere);
        }

        /// <summary>
        /// Determina se o caractere em questão faz parte do alfabeto de símbolos.
        /// </summary>
        /// <param name="automato">Automato que possui o alfabeto de símbolos.</param>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere faz parte do alfabeto de símbolos.</returns>
        public static bool Simbolo(this Automato automato, char caractere)
        {
            return automato.Simbolo.Contem(caractere);
        }

        /// <summary>
        /// Determina se o caractere em questão faz parte do alfabeto de letras ou dígitos.
        /// </summary>
        /// <param name="automato">Automato que possui o alfabeto de letras ou dígitos.</param>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere faz parte do alfabeto de letras ou dígitos.</returns>
        public static bool LetraOuDigito(this Automato automato, char caractere)
        {
            return automato.Letra.Contem(caractere) || automato.Digito.Contem(caractere);
        }

        /// <summary>
        /// Determina se o caractere em questão faz parte do alfabeto de letras, dígitos ou símbolos.
        /// </summary>
        /// <param name="automato">Automato que possui o alfabeto de letras, dígitos ou símbolos.</param>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere faz parte do alfabeto de letras, dígitos ou símbolos.</returns>
        public static bool LetraDigitoOuSimbolo(this Automato automato, char caractere)
        {
            return automato.Letra.Contem(caractere) || automato.Digito.Contem(caractere) || automato.Simbolo.Contem(caractere);
        }

        /// <summary>
        /// Determina se o caractere em questão é aspas duplas. 
        /// </summary>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere é aspas duplas.</returns>
        public static bool AspasDuplas(this char caractere)
        {
            return (caractere.Equals("\""));
        }

        /// <summary>
        /// Determina se o caractere em questão é ponto final. 
        /// </summary>
        /// <param name="caractere">O caractere a ser pesquisado.</param>
        /// <returns>Um <see cref="bool"/> determinando se o caractere é aspas ponto final.</returns>
        public static bool PontoFinal(this char caractere)
        {
            return (caractere.Equals("\."));
        }
    }
}
