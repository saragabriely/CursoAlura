using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class PropriedadesIndexadas : IAulaItem
    {
        public void Executar()
        {
            var sala = new Sala();
            //sala.SetReserva("D01", new ClienteCinema("Maria de Souza"));
            //sala.SetReserva("D02", new ClienteCinema("José da Silva"));

            // É possível utilizar a propriedade indexada dessa forma:
            sala["D01"] = new ClienteCinema("Maria de Souza");
            sala["D02"] = new ClienteCinema("José da Silva");

            sala.ImprimirReservas();
        }
    }

    class ClienteCinema
    {
        public ClienteCinema(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }

    class Sala
    {
        private readonly IDictionary<string, ClienteCinema> reservas
            = new Dictionary<string, ClienteCinema>();

        /*
        public ClienteCinema GetReserva(string codigoAssento)
        {
            return reservas[codigoAssento];
        }

        public void SetReserva(string codigoAssento, ClienteCinema cliente)
        {
            reservas[codigoAssento] = cliente;
        }*/ 

        // Propriedade indexada: entre [] será armazenado o tipo do codigo do dicionário
        // A propriedade indexada nãõ tem um nome!!
        // Como será acessada?? 

        public ClienteCinema this[string codigoAssento] // public ClienteCinema  Reserva
        {
            get
            {
                return reservas[codigoAssento];
            }
            set
            {
                reservas[codigoAssento] = value;
            }
        }

        public void ImprimirReservas()
        {
            Console.WriteLine("Assentos Reservados");
            Console.WriteLine("===================");
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"{reserva.Key} - {reserva.Value}");
            }
        }
    }
}
