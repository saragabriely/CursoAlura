using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class MetodosDeExtensao : IAulaItem
    {
        public void Executar()
        {
            Impressora impressora = new Impressora("Este é\r\no meu documento");
            impressora.ImprimirDocumento();

            ImprimirDocumentoHTML(impressora.Documento);

            impressora.ImprimirDocumentoHTML();


        }

        void ImprimirDocumentoHTML(string documento)
        {
            Console.WriteLine($"<HTML><BODY>{documento}</BODY></HTML>");
            Console.WriteLine();
        }

    }

    class Impressora
    {
        public string Documento { get; }

        public Impressora(string documento)
        {
            this.Documento = documento;
        }

        public void ImprimirDocumento()
        {
            Console.WriteLine();
            Console.WriteLine(Documento);
        }

        //public void ImprimirDocumentoHTML()
        //{
        //    Console.WriteLine($"<HTML><BODY>{Documento}</BODY></HTML>");
        //    Console.WriteLine();
        //}
    }

    // Extensão da classe Impressora:
    // A classe deve ser declarada como 'static';
    // os métodos também devem ser estaticos;
    static class ImpressoraExtensions
    {
        // O 'THIS' indica que está extendendo a classe Impressora com o método abaixo
        public static void ImprimirDocumentoHTML(this Impressora impressora)
        {
            Console.WriteLine($"<HTML><BODY>{impressora.Documento}</BODY></HTML>");
            Console.WriteLine();
        }
    }

    // É possível criar uma biblioteca de métodos de extensão para a classe Impressora,
    // para imprimir o mesmo documento com resumo, com cabeçalho/rodapé ... 
    // entre outras variações.
}


