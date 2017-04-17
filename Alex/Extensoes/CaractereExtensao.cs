using Alex.Analisadores;

namespace Alex
{
    public static class CaractereExtensao
    {
        public static bool Letra(this char caractere, AnalisadorLexico analisador)
        {
            return analisador.Letra.Contains(caractere);
        }

        public static bool Digito(this char caractere, AnalisadorLexico analisador)
        {
            return analisador.Digito.Contains(caractere);
        }

        public static bool Simbolo(this char caractere, AnalisadorLexico analisador)
        {
            return analisador.Simbolo.Contains(caractere);
        }

        public static bool LetraDigitoSublinhado(this char caractere, AnalisadorLexico analisador)
        {
            return caractere.Letra(analisador) || caractere.Digito(analisador) || (caractere.Equals('_'));
        }

        public static bool LetraDigitoSimbolo(this char caractere, AnalisadorLexico analisador)
        {
            return caractere.Letra(analisador) || caractere.Digito(analisador) || caractere.Simbolo(analisador);
        }

        public static bool LetraDigitoSimboloEspaco(this char caractere, AnalisadorLexico analisador)
        {
            return caractere.Letra(analisador) || caractere.Digito(analisador) || caractere.Simbolo(analisador) || (caractere.Equals(' '));
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
