﻿using Alex.Analisadores;
using System;

namespace Alex
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    var analisador = new AnalisadorLexico(args[0]);
                    analisador.Processar();

                    Console.WriteLine(analisador.Resultado);
                }
                else
                {
                    Console.WriteLine("A execução do analisador deve ser: \"alex <fonte>\"\nonde <fonte> é o caminho do arquivo a ser analisado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
