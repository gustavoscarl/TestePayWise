namespace TestesPaywise.Models
{
    public class CartaoDebito : Cartao
    {
        public Conta? Conta { get; set; } // Adicione uma propriedade para representar a conta associada ao cartão de débito

        public override double EfetuarPagamento(double valor)
        {
            if (Conta != null)
            {
                Conta.Saldo -= valor;
                return valor;
            }
            else
            {
                throw new InvalidOperationException("Conta não associada ao cartão de débito.");
            }
        }
    }
}