using TestesPaywise.Enums;

namespace TestesPaywise.Models
{
    public class Transacao
    {
        public int Id { get; private set; }
        public double Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        public DateTime Data { get; set; }
    }
}
