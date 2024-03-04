namespace TestesPaywise.Models
{
    public class HistoricoTransacoes
    {
        public List<Transacao> Transacoes { get; set; }


        // Adicionar ou remover transações é realmente válido para esta classe?
        public void ListarTransacoes()
        {
            foreach (var transacao in Transacoes)
            {
                Console.WriteLine($"Transação: {transacao.Id} - Valor: {transacao.Valor} - Tipo: {transacao.Tipo} - Data: {transacao.Data}");
            }
        }
        public List<Transacao> GetTransacaoPorData(DateTime data)
        {
            return Transacoes.Where(t => t.Data == data).ToList();
        }

        public HistoricoTransacoes()
        {
            Transacoes = new List<Transacao>();
        }
    }
}
