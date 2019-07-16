using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Objetos : IAulaItem
    {
        public void Executar()
        {
            int pontuacao = 10; // tipo de valor
            Console.WriteLine($"Pontuacao: {pontuacao}");
            Console.WriteLine();

            // veremos como declarar e atribuir o valor da pontuação
            // para o TIPO OBJETO

            object meuObjeto;
            meuObjeto = pontuacao;

            Console.WriteLine("OBJECT COM VALOR PRIMITIVO");
            Console.WriteLine($"MeuObjeto: {meuObjeto}");   // armazenando um tipo de valor
            Console.WriteLine($"meuObjeto.GetType(): {meuObjeto.GetType()}"); // System.Int32
            Console.WriteLine();

            // O objeto é o tipo mais basico do C# e pode conter qualquer outro 
            // tipo do .NET/C#, pois qualquer outro tipo derivam do tipo object.

            // exemplo armazenando um tipo de referência
            Console.WriteLine("OBJECT COM REFERENCIA DE OBJETO");
            
            meuObjeto = new Jogador();
            
            Jogador classeRef;

            /*
            classeRef = meuObjeto; == o compilador reclama!
            Pois, não podemos fazer esse tipo de atribuição, porque o 'classRef'
            é mais especifico do que o tipo object. - erro de conversão implicita
            */

            // atribuição explicita
            classeRef = (Jogador)meuObjeto; // (Jogador) - cast

            Console.WriteLine($"classRef.Pontuacao: {classeRef.Pontuacao}");

        }
    }

    class Jogador
    {
        public int Pontuacao { get; set; } = 10;
    }
}
