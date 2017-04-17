namespace Alex
{
    public static class CaractereExtensao
    {
        public static bool Letra(this char caractere, Analisador analisador)
        {
            return analisador.Letra.Contains(caractere);
        }

        public static bool Digito(this char caractere, Analisador analisador)
        {
            return analisador.Digito.Contains(caractere);
        }

        public static bool Simbolo(this char caractere, Analisador analisador)
        {
            return analisador.Simbolo.Contains(caractere);
        }

        public static bool LetraDigitoSublinhado(this char caractere, Analisador analisador)
        {
            return caractere.Letra(analisador) || caractere.Digito(analisador) || (caractere.Equals(95));
        }

        public static bool LetraDigitoSimbolo(this char caractere, Analisador analisador)
        {
            return caractere.Letra(analisador) || caractere.Digito(analisador) || caractere.Simbolo(analisador);
        }

        public static bool AspasDuplas(this char caractere)
        {
            return caractere.Equals('"');
        }

        public static bool Ponto(this char caractere)
        {
            return caractere.Equals('.');
        }

    }
}
