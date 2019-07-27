using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Metodos : IAulaItem
    {
        public void Executar()
        {
            Retangulo retangulo = new Retangulo(12, 10);

            Console.WriteLine(retangulo.GetArea());
            Console.WriteLine();
            
            //-------------------------------------------------------

            Retangulo outroRetangulo = new Retangulo(10, 10);

            Console.WriteLine(retangulo.Semelhante(
                    outroRetangulo.Altura, outroRetangulo.Largura)); // false
            Console.WriteLine();

            //-------------------------------------------------------

            outroRetangulo = new Retangulo(5, 6);

            // Quando passamos o parametro para um método, quer dizer que estamos
            // passando um ARGUMENTO
            // Console.WriteLine(retangulo.Semelhante(outroRetangulo));
            Console.WriteLine(Retangulo.Semelhante(retangulo, outroRetangulo));
            // chamada ao método estatico da classe retangulo
            Console.WriteLine();

            //-------------------------------------------------------





        }

    }

    /*
     . construtor é um bloco de codigo muito parecido com um método,
     porém não retorna nenhum valor e tem sempre o nome da classe onde 
     ele é declarado.
     
        . método: tem o objeto de agrupar blocos de código.
        . public: 
        . internal: só pode acessar o método a partir do mesmo projeto;
        . protected (+internal): 
        . private (+internal): você só pode acessar o método de dentro da propria classe;

         */

    class Retangulo
    {
        public double Altura { get; set; }
        public double Largura { get; set; }

        public Retangulo(double altura, double largura)
        {
            Altura = altura;
            Largura = largura;

            Console.WriteLine($"altura: {altura}, largura: {largura}");
        }

        public double GetArea()
        {
            return Altura * Largura;
        }

        // Quando não tem o public/private ... o compilador assume que esse
        // método tem a visibilidade 'private'

        internal bool Semelhante(double outroRetanguloAltura, double outroRetanguloLargura)
        {
            return
                ((Largura / Altura) == /*proporção deste retângulo*/
                (outroRetanguloLargura / outroRetanguloAltura)) /*proporção do outro retângulo*/
                ||
                ((Altura / Largura) == /*compara a proporção inversa*/
                (outroRetanguloLargura / outroRetanguloAltura));
        }

        // SOBRECARGA DE MÉTODO - variação de parametros para um mesmo método
        // A assinatura envolve o tipo de retorno e os parametros.

        // STATIC - permitir acessar o método não a partir da instancia do Retangulo,
        // mas sim a partir da própia classe
        internal static bool Semelhante(Retangulo retangulo, 
                Retangulo outroRetangulo)
        {
            return
                ((retangulo.Largura / retangulo.Altura) == /*proporção deste retângulo*/
                (outroRetangulo.Largura / outroRetangulo.Altura)) /*proporção do outro retângulo*/
                ||
                ((retangulo.Altura / retangulo.Largura) == /*compara a proporção inversa*/
                (outroRetangulo.Largura / outroRetangulo.Altura));
        }

        /*
         internal bool Semelhante(Retangulo outroRetangulo)
        {
            return
                ((Largura / Altura) == /*proporção deste retângulo* /
                (outroRetangulo.Largura / outroRetangulo.Altura)) /*proporção do outro retângulo* /
                ||
                ((Altura / Largura) == /*compara a proporção inversa* /
                (outroRetangulo.Largura / outroRetangulo.Altura));
        }
         */
    }
}
