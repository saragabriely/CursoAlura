namespace ConsoleApp1
{
    public class Produto
    {
        public int    Id             { get; internal set; }
        public string Nome           { get; internal set; }
        public string Categoria      { get; internal set; }
        public double PrecoUnitario  { get; internal set; } // Preco
        public string Unidade        { get; internal set; }

        public override string ToString()
        {
            return $"Produto: {this.Nome}, {this.Categoria}, " +
                   $"{this.PrecoUnitario}, {this.Id}";
        }

        #region Comentário - Chamar a classe sem o método ToString() declarado
        // Ao tentar mostrar o que tem no banco de dados através do código abaixo,
        // sem declarar o método ToString() nesta classe, o resultado será:
        // ConsoleApp1.Produto
        // ConsoleApp1.Produto

        // using(var contexto = new LojaContext())
        // {
        //     var produtos = contexto.Produtos.ToList();
        //     foreach (var p in produtos)
        //     {
        //         Console.WriteLine(p); 
        //      }
        // }
        #endregion

        // Instalar 'Install-Package Microsoft.EntityFrameworkCore.Tools'
        // para utilizar o Migration - administra as alterações da tabela, ou seja
        // Esse pacote sincroniza o que foi definido na classe e o que está
        // no banco de dados.

        // Console do Gerenciador de Pacotes - Comando: get-help EntityFramework
        // . Mostra os comandos/ferramentas disponiveis para o EntityFrameworkCore
        #region Comandos do EntityFrameworkCore
        /*
          Cmdlet                      Description
        --------------------------  ---------------------------------------------------
        Add-Migration               Adds a new migration.
        Drop-Database               Drops the database.
        Get-DbContext               Gets information about a DbContext type.
        Remove-Migration            Removes the last migration.
        Scaffold-DbContext          Scaffolds a DbContext and entity types for a database.
                                    Esse comando é utilizado para criar uma classe que 
                                    estende de DbContext, além de classes que 
                                    representam as tabelas do banco.
        Script-Migration            Generates a SQL script from migrations.
        Update-Database             Updates the database to a specified migration.

        SEE ALSO
            Add-Migration
            Drop-Database
            Get-DbContext
            Remove-Migration
            Scaffold-DbContext
            Script-Migration
            Update-Database
         */
        #endregion

        // Migração: Registrar a migração ('tenho  uma nova versão para sincronizar').
        // e criar script para atualização/migração do banco de dados.

        /* Console:
         Add-Migration Unidade -> Nome da versão da migração
         Ao clicar em ENTER, será criada uma pasta chamada 'Migration' no projeto.
         ...
         */

        #region Migração
        /*
         A migração é feita em dois passos. O primeiro passo é executarmos o 
         comando Add-Migration.

        Já o segundo passo pode ser feitas de duas maneiras diferentes, sendo a 
        primeira gerando um script de linguagem DDL com o comando Script-Migration.
        Esse cenário é mais utilizado quando existe uma equipe de banco de dados 
        separada da equipe de desenvolvimento.

        A outra maneira é usarmos o comando Update-Database, onde o Entity pega 
        a nova versão que foi registrada e executa diretamente no banco de dados.
        Vamos utilizar essa segunda forma.

        Começaremos executando o comando para adicionar a migração, passando o 
        nome para ela. Como estamos adicionando uma nova coluna Unidade, daremos 
        o nome da migração de Unidade. O comando ficará:

        Add-Migration Unidade

        Não obtivemos nenhum resultado relevante no Console, mas olhando o projeto 
        podemos ver que uma pasta chamada Migrations foi criada, contendo duas 
        classes.

        A classe que usaremos possui o nome do arquivo com um Timestamp, que é a
        data e hora que o arquivo foi gerado. O nome do arquivo ainda tem a 
        separação por underscore e escrito Unidade.

        Abrindo o arquivo que possui o Timestamp, vemos que é a classe Unidade. 
        A classe Unidade herda de Migration, que nos fornece uma API que fará 
        essa sincronização. Também possui dois métodos, Up que serve para atualizar
        para a versão mais nova das tabelas, e o Down que serve para voltar para 
        uma versão anterior.

        Executaremos o comando para atualizar a tabela, passando o parâmetro 
        -Verbose para que o Console apresente todas as operações. O comando ficará
        da seguinte maneira:

        Update-Database -Verbose

        Após executar o comando, receberemos um erro informando que a tabela 
        Produtos já existe no banco de dados:

        There is already an object named 'Produtos' in the database

        Porém o Entity criou uma tabela chamada __EFMigrationHistory, que é 
        utilizada para manter o histórico de migrações e o Entity utilizará para 
        controlar as versões executadas no banco de dados.*/
        #endregion

        #region Corrigindo problemas e aplicando as migrações no banco
        /*
         No vídeo anterior vimos como trabalhar com a ferramenta de migração do 
         Entity. Criamos uma Migration representando a evolução da classe Produto. 
         Porém quando tentamos executar a migração, recebemos um erro informando 
         que a tabela já existia.

        Esse problema foi porque colocamos a criação da tabela e a evolução na 
        mesma execução. Para resolvermos, nós teríamos que separar a criação da 
        evolução da tabela.

        Começaremos excluindo a tabela __EFMigrationsHistory do banco, e também 
        a pasta Migrations do projeto. Além disso, voltaremos a classe produto 
        para a sua forma inicial:

        namespace Alura.Loja.Testes.ConsoleApp
        {
            internal class Produto
            {
                public int Id { get; internal set; }
                public string Nome { get; internal set; }
                public string Categoria { get; internal set; }
                public double Preco { get; internal set; }

                public override string ToString()
                {
                    return $"Produto: {this.Id}, {this.Nome}, {this.Categoria}, 
                    {this.Preco}";
                }
            }
        }
        Executaremos o comando:

        PM> Add-Migration Inicial

        Agora que já criamos a Migration inicial, voltaremos a colocar a evolução 
        da classe, que ficará da seguinte maneira:

        namespace Alura.Loja.Testes.ConsoleApp
        {
            internal class Produto
            {
                public int Id { get; internal set; }
                public string Nome { get; internal set; }
                public string Categoria { get; internal set; }
                public double PrecoUnitario { get; internal set; }
                public string Unidade { get; set; };

                public override string ToString()
                {
                    return $"Produto {this.Id}, {this.Nome}, {this.Categoria}, 
                    {this.PrecoUnitario}";
                }
            }
        }
        Criaremos um nova migração que chamaremos de Unidade. O comando será:

        Add-Migration Unidade

        Acessando a classe de migração Unidade, veremos que ela está bem diferente, 
        refletindo apenas as informações de evolução da tabela. Dentro do método 
        Up() temos a instrução de renomear a coluna Preco para PrecoUnitario, e 
        adicionar uma nova coluna Unidade. Já no método Down, temos a instrução 
        de deletar a coluna Unidade e renomear PrecoUnitario para Preco.

        Tentando executar o comando Update-Database receberemos o mesmo erro 
        informando que a tabela já foi criada. A função da tabela 
        __EFMigrationsHistory é apenas registrar quais migrações foram executadas
        no banco de dados. Ao acessá-la, veremos que nenhuma migração foi 
        executada.

        Levando isso em consideração, ao tentarmos efetuar a migração, ele 
        executará todas as migrações que estão na pasta Migrations, inclusive 
        a migração Inicial.

        Fingiremos para o banco que a migração Inicial já foi executada. 
        Entraremos da classe de migração Inicial e comentaremos todo o conteúdo 
        do método Up(), em seguida executaremos Update-Database Inicial. Isso 
        executará apenas a migração com o nome Inicial e irá criar uma linha na 
        tabela de histórico de migração.

        Agora podemos executar tirar os comentários da classe Inicial e executar 
        o comando Update-Database, dessa vez sem passarmos o nome da classe. 
        A sincronização foi efetuada com sucesso.

        Acessando o banco de dados, veremos que a coluna Preco foi renomeada para
        PrecoUnitario e a coluna Unidade foi criada.
         */
        #endregion


    }

}