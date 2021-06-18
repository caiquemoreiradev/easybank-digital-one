using System;

namespace easy_bank {
    public class Account {

        private AccountType accountType { get; set; }
        private double funds { get; set; }
        private int agency { get; set; }
         private int account { get; set; }
        private string holder { get; set; }

        public Account(AccountType accountType, double funds, int agency, int account, string holder) {
            this.accountType = accountType;
            this.funds = funds;
            this.agency = agency;
            this.account = account;
            this.holder = holder;
        }

        public bool Sacar(double withdrawalValue) {

            //Validação se o saldo em nossa conta é suficiente para o saque
            if(this.funds < withdrawalValue) {
                Console.WriteLine("Insufficient funds");
                return false;
            }

            //Realizando saque
            else {  
                this.funds -= withdrawalValue;
                Console.WriteLine("Current balance: {0}", this.funds);
                return true;
            }
        }

        public void Deposit(double depositValue) {

            //Depositando valor
            this.funds += depositValue;

            //Retorno para o cliente
            Console.WriteLine("Deposit successful!!");
            Console.ReadLine();
            Console.WriteLine("Current Balance: {0}", this.funds);
        }

        public void Transferir(Account destinyAccount, double transferValue) {
            
            //Verificar se o saldo é suficiente para transferência
            if(this.funds >= transferValue) {
                this.Sacar(transferValue);
                destinyAccount.Deposit(transferValue);

                //Retorno para o cliente
                Console.WriteLine("Pronto Easybanker, a transferência foi concluída com sucesso!!");
                Console.ReadLine();
                Console.WriteLine("O valor da transferência foi de {0}", transferValue);
                Console.ReadLine();
                Console.WriteLine("Saldo atual: {0}", this.funds);
            }
        }

        public void ConsultaDados(Account account) {

            Console.WriteLine("Holder Account: {0}", account.holder);
            Console.ReadLine();
            Console.WriteLine("Agency: {0}", account.agency);
            Console.ReadLine();
            Console.WriteLine("Account: {0}", account.account);
            Console.ReadLine();
            Console.WriteLine("Cuurent balance: {0}", account.funds);
        }
    }
}