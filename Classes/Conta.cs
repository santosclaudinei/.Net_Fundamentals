using System;

namespace projeto_banco
{
    public class Conta
    {
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.TipoConta = tipoConta;
                this.Saldo = saldo;
                this.Credito = credito;
                this.Nome = nome;
               
        }
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque > this.Credito * -1){
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("O saldo atualizado da conta de {0} é {1}.", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("O saldo atualizado da conta de {0} é {1}.", this.Nome, this.Saldo);

        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);

            }

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " \n ";
            retorno += "Nome: " + this.Nome + " \n ";
            retorno += "Saldo: " + this.Saldo + " \n ";
            retorno += "Crédito: " + this.Credito + " \n ";
            return retorno;
        }

    }
}