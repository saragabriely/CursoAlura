using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Classes : IAulaItem
    {
        public void Executar()
        {
            #region Comentario
            /*
             Inicialmente deu o erro na 'posicao1.Latitude  = 13.78;' - 
             "Uso de variavel não atribuida "posicao1""
             
             Diferente de uma struct, não é possível utilizar a instancia de uma
             classe sem instanciar (sem ter uma referente do objeto que tenha
             o posicao1).
             Logo, tem que instanciar o objeto ou atribuir a 'posicao1' o 
             valor de um objeto já existente em memória.

            ClassePosicaoGPS posicao1;
            posicao1.Latitude  = 13.78;
            posicao1.Longitude = 29.51;
             */
            #endregion
            
            ClassePosicaoGPS posicao1 = new ClassePosicaoGPS()
            {
                Latitude  = 13.78,
                Longitude = 29.51
            };
            
            posicao1 = new ClassePosicaoGPS(13.78, 29.51);

            Console.WriteLine(posicao1);
            Console.WriteLine();

            PosicaoGPSComLeitura posicao2 = new PosicaoGPSComLeitura(13.78, 29.51,
                DateTime.Now);

            Console.WriteLine(posicao2);

        }
    }

    class ClassePosicaoGPS : IGPS
    {
        public double Latitude;
        public double Longitude;

        // A struct não permite construtor sem parametros
        public ClassePosicaoGPS() { }

        public ClassePosicaoGPS(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public bool EstaNoHemisferioNorte()
        {
            return Latitude > 0;
        }

        public override string ToString()
        {
            return $"Latitude: {Latitude}, Longitude: {Longitude}";
        }
    }

    /*
     Classes podem ser derivadas, diferentes das estruturas!

     Os métodos são os 'comportamentos' da classe - é onde o código de uma classe
     realmente acontece - e podem receber ou não parametros.

     A classe tem o modificador de acessibilidade - adicionando um modificador,
     como exemplo, é colocado o nome 'internal' antes de 'class'.
     - Internal - a classe será acessível/visivel apenas para código que esteja 
     dentro do mesmo projeto.
     - sem o 'internal' (apenas o 'class') - o compilador interpreta que a 
     acessibilidade é o internal.
     - para tornar a classe publica, deve colocar o 'public' - a classe é acessível
     pelas classes do mesmo projeto e de projetos externos.
     - 'private' - a classe só pode ser acessada pela classe que ela estiver contida.
     - 'protected' -  
         
         */

    class PosicaoGPSComLeitura : ClassePosicaoGPS
    {
        // Adicionar uma nova informação - Data da leitura
        private readonly DateTime DataLeitura;

        public PosicaoGPSComLeitura(double latitude, double longitude, DateTime dataLeitura) 
            : base(latitude, longitude)
        {
            this.DataLeitura = dataLeitura;
        }

        public override string ToString()
        {
            return $"Latitude: {Latitude} - Longitude: {Longitude} " +
                $"- DataLeitura: {DataLeitura}";
        }
    }
}
