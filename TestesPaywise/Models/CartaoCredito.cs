namespace TestesPaywise.Models
{
    public class CartaoCredito : Cartao
    {
        public double Fatura { get; set; }

        public double Limite { get; set; }

        public override double EfetuarPagamento(double valor)
        {
            if (Fatura + valor > Limite)
            {
                throw new Exception("Limite excedido");
            }
            else
            {
                return Fatura += valor;
            }
        }

        public void GerarFatura() {
            Console.WriteLine($"A fatura é de R$ {Fatura}");
        }
    }
}
