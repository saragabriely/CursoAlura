using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P13_ForEncadeado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando Projeto 13 - For Encadeado");

            //*
            //**
            //***
            //****
            //*****
            //******

            // Fazendo desenho de asterisco com break
            for(int contadorLinha = 0; contadorLinha < 10; contadorLinha++)
            {
                for(int contadorColuna = 0; contadorColuna < 10; contadorColuna++)
                {
                    Console.Write("*");
                    
                    if(contadorColuna >= contadorLinha)
                    {
                        break; // para a execução
                    }
                }

                // Pula linha
                Console.WriteLine();
            }

            // Uma forma diferente de fazer o desenho de asterisco
            for (int contadorLinha = 0; contadorLinha < 10; contadorLinha++)
            {
                for (int contadorColuna = 0; contadorColuna <= contadorLinha; contadorColuna++)
                {
                    Console.Write("*");
                }

                // Pula linha
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
