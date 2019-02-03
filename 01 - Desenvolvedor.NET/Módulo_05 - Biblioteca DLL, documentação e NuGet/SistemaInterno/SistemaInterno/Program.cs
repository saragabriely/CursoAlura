using ByteBank;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInterno
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateFimPagamento  = new DateTime(2019, 08, 17);

            DateTime dataCorrente      = DateTime.Now;

            // TimeSpan - Diferença entre datas
            TimeSpan diferenca = TimeSpan.FromMinutes(60); //dateFimPagamento - dataCorrente;


            // string mensagem = "Vencimento em " + GetIntervaloDeTempoLegivel(diferenca);

            string mensagem = "Vencimento em " + 
                                TimeSpanHumanizeExtensions.Humanize(diferenca);


            Console.WriteLine("Data Pagamento: " + dateFimPagamento);
            Console.WriteLine("Data Atual:     " + dataCorrente);
            Console.WriteLine(mensagem);
            

            Console.ReadLine();
        }

        
        #region static string GetIntervaloDeTempoLegivel(TimeSpan timeSpan)
        /*
        static string GetIntervaloDeTempoLegivel(TimeSpan timeSpan)
        {

            if(timeSpan.Days > 30)
            {
                int quantidadeMeses = timeSpan.Days / 30;

                if (quantidadeMeses == 1)
                {
                    return "1 mês";
                }
                else
                {
                    return quantidadeMeses + " meses";
                }
            }
            else if(timeSpan.Days > 7)
            {
                int quantidadeSemanas = timeSpan.Days / 7;
                
            }
            return timeSpan.Days + " dias";
        }
        */
        #endregion

    }
}
