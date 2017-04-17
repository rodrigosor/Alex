namespace Alex.Artefatos
{
    public static class ASCII
    {
        /// <summary>
        /// Caractere nulo.
        /// </summary>
        public const int NULL = 0;

        /// <summary>
        /// Início do cabeçalho.
        /// </summary>
        public const int SOH = 1;

        /// <summary>
        /// Início do texto.
        /// </summary>
        public const int STX = 2;

        /// <summary>
        /// Fim do texto.
        /// </summary>
        public const int ETX = 3;

        /// <summary>
        /// Fim da transmissão.
        /// </summary>
        public const int EOT = 4;

        /// <summary>
        /// Inquérito.
        /// </summary>
        public const int ENQ = 5;

        /// <summary>
        /// Reconhecimento.
        /// </summary>
        public const int ACK = 6;

        /// <summary>
        /// Sino.
        /// </summary>
        public const int BELL = 7;

        /// <summary>
        /// Retrocesso (backspace).
        /// </summary>
        public const int BS = 8;

        /// <summary>
        /// Tabulação.
        /// </summary>
        public const int HT = 9;

        /// <summary>
        /// Alimentação de linha.
        /// </summary>
        public const int LF = 10;

        /// <summary>
        /// Guia Vertical.
        /// </summary>
        public const int VT = 11;

        /// <summary>
        /// Feed de formulário.
        /// </summary>
        public const int FF = 12;

        /// <summary>
        /// Retorno de carro.
        /// </summary>
        public const int CR = 13;

        /// <summary>
        /// Deslocar para fora / X-On.
        /// </summary>
        public const int SO = 14;

        /// <summary>
        /// Shift In / X-Off.
        /// </summary>
        public const int SI = 15;

        /// <summary>
        /// Escape da linha de dados.
        /// </summary>
        public const int DLE = 16;

        /// <summary>
        /// Dispositivo de Controle 1 (OFT XON).
        /// </summary>
        public const int DC1 = 17;

        /// <summary>
        /// Controle do dispositivo 2.
        /// </summary>
        public const int DC2 = 18;

        /// <summary>
        /// Controle de Dispositivo 3 (freqüentemente XOFF).
        /// </summary>
        public const int DC3 = 19;

        /// <summary>
        /// Controle do dispositivo 4.
        /// </summary>
        public const int DC4 = 20;

        /// <summary>
        /// Confirmação Negativa.
        /// </summary>
        public const int NAK = 21;

        /// <summary>
        /// Sincronismo Ocioso.
        /// </summary>
        public const int SYN = 22;

        /// <summary>
        /// Fim do Bloco de Transmissão.
        /// </summary>
        public const int ETB = 23;

        /// <summary>
        /// Cancelar.
        /// </summary>
        public const int CAN = 24;

        /// <summary>
        /// Fim do Médio.
        /// </summary>
        public const int EM = 25;

        /// <summary>
        /// Substituto.
        /// </summary>
        public const int SUB = 26;

        /// <summary>
        /// Escapar (escape).
        /// </summary>
        public const int ESC = 27;

        /// <summary>
        /// Arquivo Separador.
        /// </summary>
        public const int FS = 28;

        /// <summary>
        /// Separador de grupo.
        /// </summary>
        public const int GS = 29;

        /// <summary>
        /// Separador de Registros.
        /// </summary>
        public const int RS = 30;

        /// <summary>
        /// Separador de Unidade.
        /// </summary>
        public const int US = 31;

        /// <summary>
        /// Espaço em branco.
        /// </summary>
        public const int SPACE = 32;

        /// <summary>
        /// Excluir (delete).
        /// </summary>
        public const int DELETE = 127;
    }
}