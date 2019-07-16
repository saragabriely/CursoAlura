using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Interfaces : IAulaItem
    {
        public void Executar()
        {
            // É possível atribuir a variavel IEletrodomestico qualquer classe
            // que implemente essa interface!
            IEletrodomestico eletro1 = new Televisao();

            eletro1.Ligar(); // ligar a televisão
            
            eletro1 = new Abajur();
            // as classes 'Televisao' e 'Abajur' são diferentes (não tem 
            // nenhuma relacao entre si), mas possuem os métodos Ligar e Desligar


        }
    }

    interface IEletrodomestico
    {
        void Desligar();
        void Ligar();
    }

    interface IIluminacao
    {
       double PotenciaDaLampada { get; set; }
    }

    class Televisao : IEletrodomestico
    {
        public void Desligar()
        {

        }

        public void Ligar()
        {

        }
    }

    class Abajur : IEletrodomestico, IIluminacao
    {
        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {

        }

        public void Ligar()
        {

        }
    }

    class Lanterna : IEletrodomestico, IIluminacao
    {
        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {

        }

        public void Ligar()
        {

        }
    }

    class Radio : IEletrodomestico
    {
        public void Desligar()
        {

        }

        public void Ligar()
        {

        }
    }
}
