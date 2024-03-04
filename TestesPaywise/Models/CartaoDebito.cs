namespace TestesPaywise.Models
{
    public class CartaoDebito : Cartao
    {
        public Conta? Conta { get; set; }

        public override double EfetuarPagamento(double valor, Cliente cliente)
        {
            Conta? Conta = cliente.Conta;
            if (Conta != null)
            {
                Conta.Saldo -= valor;
                cliente.HistoricoTransacoes.Transacoes.Add(new Transacao() { Valor = valor, Tipo = Enums.TipoTransacao.Debito, Data = DateTime.Now });
                return valor;
            }
            else
            {
                throw new InvalidOperationException("Conta não associada ao cartão de débito.");
            }
        }
    }
}