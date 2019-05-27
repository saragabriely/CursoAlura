using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.MVC
{
    public class RoteamentoPadrao
    {
        public static Task TratamentoPadrao(HttpContext context)
        {
            // Rota padrão: /<classe>Logica/Metodo
            // {classe}/{metodo}

            var classe = Convert.ToString(context.GetRouteValue("classe"));

            var nomeMetodo = Convert.ToString(context.GetRouteValue("metodo"));

            var nomeCompleto = $"Alura.ListaLeitura.App.Logica.{classe}Logica";

            var tipo = Type.GetType(nomeCompleto); // (classe)

            var metodo = 
                    tipo.GetMethods().Where(a => a.Name == nomeMetodo).First();

            var requestDelegate = (RequestDelegate)
                    Delegate.CreateDelegate(typeof(RequestDelegate), metodo);

            return requestDelegate.Invoke(context);

        }

    }
}
