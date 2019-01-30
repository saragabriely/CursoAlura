using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ContaCorrente conta = new ContaCorrente(0, 0);
            }
            catch(ArgumentException ex) // tratando exeções de argumento
            {
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException!");
                Console.WriteLine("Argumento com problema: " + ex.ParamName);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            /*
             ContaCorrente conta = new ContaCorrente(5656, 562336);
             conta.Agencia = 5252; // dará erro, pois os SETTERS são privados / leitura apenas
             */

            #region Try/catch 01

            /*
            try
            {
                Metodo();
            }
            catch (DivideByZeroException e) // Divisão por 0
            {
                Console.WriteLine("Aconteceu um erro!");
                Console.WriteLine("Não é possível dividir por zero.");
            }
            catch (Exception e)  // Exception: Trata todas as exceções
            {
                Console.WriteLine("Aconteceu um erro!");
                Console.WriteLine(e.Message);
            } */
            #endregion

            // TODA EXCEÇÃO DERIVA DA CLASSE 'Exception'

            #region CATCH comentado
            /*
            catch(NullReferenceException e)  // Referencia nula
            {
                Console.WriteLine("Aconteceu um erro!");
                Console.WriteLine(e.Message);
               //  Console.WriteLine(e.StackTrace); //- Rastro da pilha de chamadas
            }
            catch (DivideByZeroException e) // Divisão por 0
            {
                Console.WriteLine("Aconteceu um erro!");
                Console.WriteLine(e.Message);
            } */
            #endregion

            Console.ReadLine();
        }

        // Teste com a cadeia de chamada:
        // Método -> TestaDivisao -> Dividir 
        private static void Metodo()
        {
            TestaDivisao(0);

            Console.WriteLine(); // Pula linha

           // TestaDivisao(2);
        }
        
        private static void TestaDivisao(int divisor)
        {
            try
            {
                int resultado = Dividir(10, divisor);

                Console.WriteLine("Resultado da divisão de 10 por: " + divisor +
                            " - resultado: " + resultado);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Aconteceu um erro!");
                Console.WriteLine(e.Message);
                // Console.WriteLine("Não é possível fazer divisão por 0");
            }
        }

        private static int Dividir(int numero, int divisor)
        {
            // ContaCorrente conta = null; // essa referência não aponta para nenhum lugar
            // Console.WriteLine(conta.Saldo);

            try
            {
                return numero / divisor;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Exceção com numero '" + numero +
                                  "' e divisor igual '" + divisor + "'.");

                throw;  // lança adiante a exceção que o bloco 'catch' pegou
                        // controle de fluxo // sai do método 

                // colocando 'return -1;', o método MAIN não saberá que ocorreu uma exceção
            }
        }

        ///-----------------------------------------------------------------///

        #region Código Inicial

        /*
         
        static void Main(string[] args)
        {
            //  ContaCorrente conta = new ContaCorrente(7480, 874150);
            // Console.WriteLine("Taxa de Operação: " + ContaCorrente.TaxaOperacao);

            Metodo();

            
            Console.ReadLine();
        }

        // Teste com a cadeia de chamada:
        // Método -> TestaDivisao -> Dividir 
        private static void Metodo()
        {
            TestaDivisao(0);

            Console.WriteLine(); // Pula linha

            TestaDivisao(2);
        }
        
        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            
            Console.WriteLine("Resultado da divisão de 10 por: " + divisor +
                            " - resultado: " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            return numero / divisor;
        }
         */

        #endregion

        #region Primeiro código alterado

        /*
         
        static void Main(string[] args)
        {
            //  ContaCorrente conta = new ContaCorrente(7480, 874150);
            // Console.WriteLine("Taxa de Operação: " + ContaCorrente.TaxaOperacao);

            int resultado = Metodo();

            if(resultado == -2)
            {
                Console.WriteLine("Ocorreu um erro!");
            }

            Console.ReadLine();
        }

        // Teste com a cadeia de chamada:
        // Método -> TestaDivisao -> Dividir /// void
        private static int Metodo()
        {
            int resultadoDivisao = TestaDivisao(0);

            if(resultadoDivisao == -2)
            {
                return -2;
            }

            Console.WriteLine(); // Pula linha

            int resultado2 = TestaDivisao(20);

            if(resultado2 == -2)
            {
                return -2;
            }

            return 0;
        }

        // void
        private static int TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);

            
            if (resultado == -2)
            {
                return -2;
            }
            else if(resultado == -1)
            {
                Console.WriteLine("Não é possível fazer divisão por 0");
            }
            else
            {
                Console.WriteLine("Resultado da divisão de 10 por: " + divisor +
                              " - resultado: " + resultado);
            }

            return 0;
        }

        private static int Dividir(int numero, int divisor)
        {
            if(divisor == 0) // Erro
            {
                return -1;
            }
            if(divisor > numero)
            {
                return -2;
            }
            else
            {
                return numero / divisor;
            }
        }

         */

        #endregion

    }
}
