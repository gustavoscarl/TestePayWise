namespace TestesPaywise.Models
{
    public class Conta
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }

        public List<Transacao> Transacoes { get; set; }

        public double Depositar(double valor)
        {
            return Saldo += valor;
        }

        public double Sacar(double valor)
        {
            return Saldo -= valor;
        }

        public double GetSaldo() {
            return Saldo;
        }
    }
}
