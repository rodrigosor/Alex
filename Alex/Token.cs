namespace Alex
{
    public enum Token
    {
        NaoReconhecido,

        /// <summary>
        /// Deve iniciar com uma letra seguida de 0 ou mais produções de letras, dígitos e/ou caracteres _.
        /// </summary>
        ID,

        /// <summary>
        /// Cadeia numérica contendo 1 ou mais produções de dígitos.
        /// </summary>
        ConstInteira,

        /// <summary>
        /// Cadeia numérica contendo 1 ou mais produções de dígitos, 
        /// tendo em seguida um símbolo de ponto à frente de 0 ou mais produções de dígitos.
        /// </summary>
        ConstReal,

        /// <summary>
        /// Deve iniciar e finalizar com o caractere " (aspas) contendo entre esses 
        /// uma sequênciade 0 ou mais produções de letras, dígitos e/ou símbolos.
        /// <para>Os símbolos referidos na constante String (ConstString) indica qualquer caractere ASCII.</para>
        /// </summary>
        ConstString
    }
}
