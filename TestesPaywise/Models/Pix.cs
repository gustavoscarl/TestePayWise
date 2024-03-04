using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesPaywise.Models
{
    public class Pix
    {
        public Conta? Conta { get; set; }
        public string Chave { get; set; }

        public bool Enviar(double valor, string chaveDestino, Cliente cliente)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor inválido");
            }
            if (valor >= Conta.Saldo)
            {
                throw new Exception("Saldo insuficiente");
            }
            if (chaveDestino == Chave)
            {
                throw new Exception("Não é possível enviar para a mesma conta");
            }
            else
            {
                Conta.Saldo -= valor;
                cliente.HistoricoTransacoes.Transacoes.Add(new Transacao() { Valor = valor, Tipo = Enums.TipoTransacao.Pix, Data = DateTime.Now });
                return true;
            }
        }
    }
}
