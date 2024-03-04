namespace TestesPaywise.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public List<Cartao>? listaCartoes { get; set; }
        public Conta? Conta { get; set; }

        public Cliente(int id, string nome)
        {
            Nome = nome;
            Id = id;
            listaCartoes = new List<Cartao>();
        }
    }
}
