using TestesPaywise.Models;

namespace TestesPaywise
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            List<Cliente> lista = new List<Cliente>();
            while (continuar)
            {
                Console.WriteLine("== Menu ==");
                Console.WriteLine("Digite 1 para criar um cliente");
                Console.WriteLine("Digite 2 para adicionar uma conta para um cliente");
                Console.WriteLine("Digite 3 para criar um cartão de crédito");
                Console.WriteLine("Digite 4 para criar um cartão de débito");
                Console.WriteLine("Digite 5 para efetuar um pagamento com Cartão de Débito");
                Console.WriteLine("Digite 6 para efetuar um pagamento com Cartão de Crédito");
                Console.WriteLine("Digite 7 para gerar fatura");
                Console.WriteLine("Digite 8 para listar cartões de um cliente");
                Console.WriteLine("Digite 9 para ver saldo da conta");
                Console.WriteLine("Digite 10 para listar transações");
                Console.WriteLine("Digite 0 para sair");
                Console.Write("Digite a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine());
                Console.WriteLine("=========");

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("== Criar Cliente ==");
                        Console.Write("Digite o ID do cliente: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome do cliente: ");
                        string nome = Console.ReadLine();
                        Cliente cliente = new Cliente(id, nome);
                        lista.Add(cliente);
                        break;
                    case 2:
                        Console.WriteLine("== Adicionar Conta ==");   
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteConta = int.Parse(Console.ReadLine());
                        Console.Write("Digite o número da conta: ");
                        int numeroConta = int.Parse(Console.ReadLine());
                        Console.Write("Digite o saldo da conta: ");
                        double saldo = double.Parse(Console.ReadLine());
                        Conta conta = new Conta();
                        conta.Numero = numeroConta;
                        conta.Saldo = saldo;
                        Cliente getClienteConta = lista.Find(c => c.Id == idClienteConta);
                        getClienteConta.Conta = conta;
                        getClienteConta.HistoricoTransacoes.Transacoes.Add(new Transacao() { Valor = saldo, Tipo = Enums.TipoTransacao.Deposito, Data = DateTime.Now });
                        break;
                    case 3:
                        Console.WriteLine("==Adicionar Cartão de Crédito==");
                        Console.Write("Digite o ID do cliente: ");
                        int idCliente = int.Parse(Console.ReadLine());
                        Console.Write("Digite o número do cartão: ");
                        int numero = int.Parse(Console.ReadLine());
                        Console.Write("Digite o limite do cartão: ");
                        double limite = double.Parse(Console.ReadLine());
                        CartaoCredito cartaoCredito = new CartaoCredito();
                        cartaoCredito.Numero = numero;
                        cartaoCredito.Limite = limite;
                        Cliente getCliente = lista.Find(c => c.Id == idCliente);
                        getCliente.ListaCartoes.Add(cartaoCredito);
                        break;
                    case 4:
                        Console.WriteLine("==Adicionar Cartão de Débito==");
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteDebito = int.Parse(Console.ReadLine());
                        Console.Write("Digite o número do cartão: ");
                        int numeroDebito = int.Parse(Console.ReadLine());
                        CartaoDebito cartaoDebito = new CartaoDebito();
                        cartaoDebito.Numero = numeroDebito;
                        Cliente getClienteDebito = lista.Find(c => c.Id == idClienteDebito);
                        getClienteDebito.ListaCartoes.Add(cartaoDebito);
                        break;
                    case 5:
                        Console.WriteLine("==Efetuar Pagamento Debito==");
                        Console.Write("Digite o ID do cliente: ");
                        int idClientePagar = int.Parse(Console.ReadLine());
                        Console.Write("Digite o número do cartão: ");
                        int numeroCartao = int.Parse(Console.ReadLine());
                        Console.Write("Digite o valor do pagamento: ");
                        double valor = double.Parse(Console.ReadLine());
                        Cliente cliente1 = lista.Find(c => c.Id == idClientePagar);
                        CartaoDebito cartaoDebitoPagar = (CartaoDebito)cliente1.ListaCartoes.Find(c => c.Numero == numeroCartao);
                        cartaoDebitoPagar.EfetuarPagamento(valor, cliente1);
                        break;
                    case 6:
                        Console.WriteLine("==Efetuar Pagamento Credito==");
                        Console.Write("Digite o número do cartão: ");
                        int numeroCartaoCredito = int.Parse(Console.ReadLine());
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteCredito = int.Parse(Console.ReadLine());
                        Console.Write("Digite o valor do pagamento: ");
                        double valorCredito = double.Parse(Console.ReadLine());
                        var getClienteCredito = lista.Find(c => c.Id == idClienteCredito);
                        CartaoCredito cartaoCreditoPagar = (CartaoCredito)getClienteCredito.ListaCartoes.Find(c => c.Numero == numeroCartaoCredito);
                        cartaoCreditoPagar.EfetuarPagamento(valorCredito, getClienteCredito);
                        break;

                    case 7:
                        Console.WriteLine("==Gerar Fatura==");
                        Console.Write("Digite o número do cartão: ");
                        int numeroCartaoFatura = int.Parse(Console.ReadLine());
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteFatura = int.Parse(Console.ReadLine());
                        Cliente getClienteFatura = lista.Find(c => c.Id == idClienteFatura);
                        CartaoCredito cartaoFatura = (CartaoCredito)getClienteFatura.ListaCartoes.Find(c => c.Numero == numeroCartaoFatura);
                        cartaoFatura.GerarFatura();
                        break;
                    case 8:
                        Console.WriteLine("==Listar Cartões==");
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteListar = int.Parse(Console.ReadLine());
                        Cliente getClienteListar = lista.Find(c => c.Id == idClienteListar);

                        if (getClienteListar != null && getClienteListar.ListaCartoes != null)
                        {
                            foreach (Cartao item in getClienteListar.ListaCartoes)
                            {
                                Console.WriteLine("-----------------------");
                                Console.WriteLine($"Número: {item.Numero}");

                                // Verifica se o cartão é do tipo CartaoCredito
                                if (item is CartaoCredito cartaoCreditoObj)
                                {
                                    Console.WriteLine($"Limite: {cartaoCreditoObj.Limite}");
                                }
                                Console.WriteLine("-----------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado ou não possui cartões.");
                        }
                        break;
                    case 9:
                        Console.WriteLine("==Histórico Transações==");    
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteSaldo = int.Parse(Console.ReadLine());
                        Cliente getClienteSaldo = lista.Find(c => c.Id == idClienteSaldo);
                        Console.WriteLine($"Saldo: {getClienteSaldo.Conta.Saldo}");
                        break;
                    case 10:
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteTransacoes = int.Parse(Console.ReadLine());
                        Console.WriteLine("== Transações ==");
                        Cliente getClienteTransacoes = lista.Find(c => c.Id == idClienteTransacoes);
                        getClienteTransacoes.HistoricoTransacoes.ListarTransacoes();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }


        }
    }
}