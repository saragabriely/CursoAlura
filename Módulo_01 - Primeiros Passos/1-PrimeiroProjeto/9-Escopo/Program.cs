using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_Escopo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando condicionais");

            int    idade             = 20;
            bool   acompanhado       = false;
            string mensagemAdicional;// = "";

            // Mensagem adicional
            if (acompanhado == true)
            {
                mensagemAdicional = "João está acompanhado.";
            }
            else
            {
                mensagemAdicional = "João não está acompanhado.";
            }

            // Verificação
            if (idade >= 18 && acompanhado)
            {
                Console.WriteLine("Pode entrar.");
                Console.WriteLine(mensagemAdicional);
            }
            else
            {
                Console.WriteLine("Não pode entrar.");
            }

            Console.ReadLine();
        }
    }
}
