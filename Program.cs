using System;
using System.Collections.Generic;

namespace projeto_banco
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        
        static void Main(string[] args)
        {
            string obterUsuario = OpcaoObterUsuario();

            while (obterUsuario.ToUpper() != "X")
            {
                switch (obterUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        AbrirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }

                obterUsuario = OpcaoObterUsuario();
            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços.");
            Console.ReadLine();

        }

        private static void Transferir()
        {
            Console.Write("Informe o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Informe o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor a ser transferido: ");
            double valorTranferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTranferencia, listaContas[indiceContaDestino]);
            
        }
        private static void Sacar()
        {
            Console.Write("Informe o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Informe o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }


        private static void AbrirContas()
        {
            Console.WriteLine("Abrir nova conta");
            Console.WriteLine();
            Console.WriteLine("Informe 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Informe o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Informe o crédito desejado: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
            saldo: entradaSaldo, 
            credito: entradaCredito,
            nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Não existem contas cadastradas.");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string OpcaoObterUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Banco - O seu banco");
            Console.WriteLine();
            Console.WriteLine("Escolha uma das opções abaixo:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Abrir uma nova conta");
            Console.WriteLine("3 - Transferência de Valores");
            Console.WriteLine("4 - Saque de valores");
            Console.WriteLine("5 - Deposito de valores");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair ");
            Console.WriteLine();

            string obterUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return obterUsuario;
        }
    }
}
