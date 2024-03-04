namespace TestesPaywise.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public List<Cartao>? ListaCartoes { get; set; }

        public Conta? Conta { get; set; }
        public HistoricoTransacoes HistoricoTransacoes { get; set; } // Adicionando o histórico de transações

        public Cliente(int id, string nome)
        {
            Nome = nome;
            Id = id;
            ListaCartoes = new List<Cartao>();
            HistoricoTransacoes = new HistoricoTransacoes(); // Inicializando o histórico de transações
        }
    }
}
