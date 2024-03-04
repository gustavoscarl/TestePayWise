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
                Console.WriteLine("Digite 1 para criar um cliente");
                Console.WriteLine("Digite 2 para adicionar uma conta para um cliente");
                Console.WriteLine("Digite 3 para criar um cartão de crédito");
                Console.WriteLine("Digite 4 para criar um cartão de débito");
                Console.WriteLine("Digite 5 para efetuar um pagamento");
                Console.WriteLine("Digite 6 para gerar fatura");
                Console.WriteLine("Digite 7 para listar cartões de um cliente");
                Console.WriteLine("Digite 8 para ver saldo da conta");
                Console.WriteLine("Digite 9 para sair");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o ID do cliente: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome do cliente: ");
                        string nome = Console.ReadLine();
                        Cliente cliente = new Cliente(id, nome);
                        lista.Add(cliente);
                        break;
                    case 2:
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
                        break;
                    case 3:
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
                        getCliente.listaCartoes.Add(cartaoCredito);
                        break;
                    case 4:
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteDebito = int.Parse(Console.ReadLine());
                        Console.Write("Digite o número do cartão: ");
                        int numeroDebito = int.Parse(Console.ReadLine());
                        CartaoDebito cartaoDebito = new CartaoDebito();
                        cartaoDebito.Numero = numeroDebito;
                        Cliente getClienteDebito = lista.Find(c => c.Id == idClienteDebito);
                        getClienteDebito.listaCartoes.Add(cartaoDebito);
                        break;
                    case 5:
                        Console.Write("Digite o ID do cliente: ");
                        int idClientePagar = int.Parse(Console.ReadLine());
                        Console.Write("Digite o número do cartão: ");
                        int numeroCartao = int.Parse(Console.ReadLine());
                        Console.Write("Digite o valor do pagamento: ");
                        double valor = double.Parse(Console.ReadLine());
                        Cliente getClientePagar = lista.Find(c => c.Id == idClientePagar);
                        CartaoDebito cartaoDebitoPagar = getClientePagar.listaCartoes.Find(c => c.Numero == numeroCartao) as CartaoDebito;
                        cartaoDebitoPagar.Conta = getClientePagar.Conta;
                        cartaoDebitoPagar.EfetuarPagamento(valor);
                        break;
                    case 6:
                        Console.Write("Digite o número do cartão: ");
                        int numeroCartaoFatura = int.Parse(Console.ReadLine());
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteFatura = int.Parse(Console.ReadLine());
                        Cliente getClienteFatura = lista.Find(c => c.Id == idClienteFatura);
                        CartaoCredito cartaoFatura = (CartaoCredito)getClienteFatura.listaCartoes.Find(c => c.Numero == numeroCartaoFatura);
                        cartaoFatura.GerarFatura();
                        break;
                    case 7:
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteListar = int.Parse(Console.ReadLine());
                        Cliente getClienteListar = lista.Find(c => c.Id == idClienteListar);

                        if (getClienteListar != null && getClienteListar.listaCartoes != null)
                        {
                            foreach (Cartao item in getClienteListar.listaCartoes)
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
                    case 8:
                        Console.Write("Digite o ID do cliente: ");
                        int idClienteSaldo = int.Parse(Console.ReadLine());
                        Cliente getClienteSaldo = lista.Find(c => c.Id == idClienteSaldo);
                        Console.WriteLine($"Saldo: {getClienteSaldo.Conta.Saldo}");
                        break;
                    case 9:
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