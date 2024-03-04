using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesPaywise.Models
{
    public abstract class Cartao
    {
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }

        public virtual double EfetuarPagamento(double valor) {
            return valor;
        }


    }
}
