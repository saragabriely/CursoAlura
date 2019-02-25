using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class AutenticaHelper
    {
        // class AutenticaHelper ou internal class AutenticaHelper

        // Uma classe INTERNAL é de uso interno da biblioteca apenas (não é publica)

        // Essa classe passa a ser inacessível fora da biblioteca, logo, sistemas
        // externos não podem acessá-la diretamente

        public bool CompararSenhas (string senhaVerdadeira, string senhaTentativa)
        {
            // Apenas compara as senhas
            return senhaVerdadeira == senhaTentativa;
        }

        /*
         Classe criada para evitar a duplicação do código abaixo em ParceiroComercial e 
         FuncionarioAutenticavel.

         public bool Autenticar(string senha)
         {
            return Senha == senha;
         }   */

        /*
         Se trocarmos a assinatura de uma classe pública e existe uma biblioteca externa
         que está fazendo uso da classe; quando um sistema paralelo fizer uma atualização
         da nossa biblioteca e perceber que AutenticacaoHelper não existe mais, ou que o 
         método CompararSenha mudou a assinatura, os projetos que fazem uso da biblioteca 
         vão deixar de compilar. Isto ocorrerá porque o método não existe mais.
         */

    }
}
