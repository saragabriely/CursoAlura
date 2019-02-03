using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class ClasseTeste
    {
        // Testar o acesso aos modificadores de acesso
        public ClasseTeste()
        {

            ModificadoresTeste teste = new ModificadoresTeste();

            teste.MetodoPublico(); // OK

            // teste.MetodoPrivado(); // Não permite

            // teste.MetodoProtegido(); // não permite

            teste.MetodoInterno(); // ok (pois está dentro do mesmo projeto)

        }
    }

    class ClasseDerivada : ModificadoresTeste
    {
        public ClasseDerivada()
        {
            MetodoProtegido(); // é permitida a utilização, pois é uma classe derivada
        }
    }

    public class ModificadoresTeste
    {
        public void MetodoPublico()
        {
            // visivel fora da classe "ModificadoresTeste"
        }

        private void MetodoPrivado()
        {
            // Visivel apenas na classe "ModificadoresTeste"
        }

        protected void MetodoProtegido()
        {
            // Visivel apenas na classe "ModificadoresTeste" e derivados 
        }

        internal void MetodoInterno()
        {
            // visivel apenas para o projeto 'Modelos'
        }
    }
}
