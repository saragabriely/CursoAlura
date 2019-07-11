using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Estruturas : IAulaItem
    {
        public void Executar()
        {
            // Declarar estrutura para representar 

            // Poderiamos agrupar a Latitude e a Longitude 1 e 2 em uma outra
            // entidade/estrutura, para manter as informações centralizadas.

            double Latitude1 = 13.78;
            double Longitude1 = 29.51;
            double Latitude2 = 40.23;
            double Longitude2 = 17.4;
            Console.WriteLine($" Latitude1  = {Latitude1}  ");
            Console.WriteLine($" Longitude1 = {Longitude1} ");
            Console.WriteLine($" Latitude2  = {Latitude2}  ");
            Console.WriteLine($" Longitude2 = {Longitude2} ");

            PosicaoGPS posicao1;
            posicao1.Latitude = 13.78;
            posicao1.Longitude = 29.51;
            // ou
           // posicao1 = new PosicaoGPS() { Latitude = 13.78, Longitude = 29.51 };
            posicao1 = new PosicaoGPS(13.78, 29.51);

            Console.WriteLine();
            Console.WriteLine(posicao1);
            
            /*
             Não é possível criar uma estrutura base e uma estrutura derivada a 
             partir dela (não é possível criar herança).

            É possível criar estruturas que implementem interfaces.

            Uma estrutura, diferente de uma classe, uma variavel estrutura é 
            um tipo de valor e não tipo de referencia. Logo, quando copiamos uma 
            estrutura para outra, ambas as variaveis/estruturas ficam independentes
            , diferente do que acontece em uma classe.

            Quando for utilizar algo muito simples, utilize uma estrutura ao
            invés de uma classe.

             */
        }

        // Todas as estruturas ou classes que implementarem essa interface,
        // precisam obrigatoriamente implementar um método para saber se uma 
        // localização está ou não no hemifério norte, por exemplo.

        interface IGPS
        {
            bool EstaNoHemisferioNorte();
        }

        struct PosicaoGPS : IGPS
        {
            public double Latitude;
            public double Longitude;


            // Os structs não podem ter construtor sem parâmetro!!
            /*
            public PosicaoGPS()
            {
            } */

            public PosicaoGPS(double latitude, double longitude)
            {
                Latitude  = latitude;
                Longitude = longitude;
            }

            public bool EstaNoHemisferioNorte()
            {
                // se a latitude for maior que zero, estará no hemisfério norte
                return Latitude > 0;
            }

            public override string ToString()
            {
                return $"Latitude: {Latitude} - Longitude: {Longitude}";
            }
        }
    }
}
