namespace TestesPaywise.Models
{
    public class CartaoCredito : Cartao
    {
        public double Fatura { get; set; }
        public double Limite { get; set; }

        public override double EfetuarPagamento(double valor, Cliente cliente)
        {
            if (Fatura + valor > Limite)
            {
                throw new Exception("Limite excedido");
            }
            else
            {
                if (cliente != null && cliente.HistoricoTransacoes != null)
                {
                    cliente.HistoricoTransacoes.Transacoes.Add(new Transacao() { Valor = valor, Tipo = Enums.TipoTransacao.Credito, Data = DateTime.Now });
                }
                else
                {
                    throw new Exception("Histórico de transações do cliente não inicializado.");
                }

                return Fatura += valor;
            }
        }

        public void GerarFatura()
        {
            Console.WriteLine($"A fatura é de R$ {Fatura}");
        }
    }
}