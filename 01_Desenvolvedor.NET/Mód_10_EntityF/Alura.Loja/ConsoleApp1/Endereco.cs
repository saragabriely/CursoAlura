namespace ConsoleApp1
{
    public class Endereco
    {

        // public int    Id            { get; set; }
        // No caso de relacionamentos um para um, a classe dependente da classe 
        // principal, irá assumir como chave primária, a chave da classe principal.
        // Logo, a classe dependente não terá o Id.

        // A chave primária será criada no método OnModelCreating no LojaContext.

        public int     Numero        { get; internal set; }
        public string  Logradouro    { get; internal set; }
        public string  Complemento   { get; internal set; }
        public string  Bairro        { get; internal set; }
        public string  Cidade        { get; internal set; }
        public Cliente Cliente       { get; set; }



    }
}