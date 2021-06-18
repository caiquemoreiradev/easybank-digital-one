using System;
using System.Collections.Generic;

namespace easy_bank
{
    class Program
    {
        static List<Account> accountsList= new List<Account>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, easybanker!");
            Console.ReadLine();

            string userOption = getUserOption();

            while(userOption.ToUpper() != "X") {
                switch(userOption) {
                    case "1":
                        Console.WriteLine("Listing Accounts...");
                        Console.ReadLine();
                        ListAccounts();
                    break;

                    case "2":
                        Console.WriteLine("Register your account...");
                        Console.ReadLine();
                        InsertAccount();
                    break;

                    case "3":
                        Console.WriteLine("Transfering funds...");
                    break;

                    case "4":
                        Console.WriteLine("Whitdraw funds...");
                        Console.ReadLine();
                        Sacar();
                    break;

                    case "5":
                        Console.WriteLine("Exiting...");
                    break;

                    default:
                        userOption = getUserOption();
                    break;
                }

                userOption = getUserOption();
            }

            Console.WriteLine("Great, thank you to use our services");
            Console.WriteLine("Have a great day....");
            Console.ReadLine();

        }


        private static string getUserOption()
        {
            Console.WriteLine("Easybank is here to you!");
            Console.ReadLine();
            Console.WriteLine("How can we help you today?");
            Console.ReadLine();

            Console.WriteLine("1 - List accounts");
            Console.WriteLine("2 - Register new account");
            Console.WriteLine("3 - Tranfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("X - Exit");

            string userOption = Console.ReadLine().ToUpper();
            return userOption;
        }

        private static void InsertAccount() {

            Console.WriteLine("Great, c'mon register a new easybanker");

            Console.WriteLine("How will is the account type?");
            Console.WriteLine("Digit 1 to a personal account and 2 to a enterprise account");
            int accountType = int.Parse(Console.ReadLine());

            if(accountType == 1) {
            Console.WriteLine("Ok, a Personal Account");
            }
            else if(accountType == 2) {
            Console.WriteLine("Ok, a Enterprise Account");
            }

            Console.ReadLine();

            Console.WriteLine("Which agency?");
            int agencyNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Now, who is the holder of this account?");
            string holderAccount = Console.ReadLine();

            Console.WriteLine("And the current balance, how much?");
            double currentBalance = double.Parse(Console.ReadLine());

            Random randomNumber = new Random();
            int accountNumber = randomNumber.Next(2000, 4000);


            Account newAccount = new Account(accountType: (AccountType)accountType,
                                             funds: currentBalance,
                                             agency: agencyNumber,
                                             holder: holderAccount,
                                             account: accountNumber);

            accountsList.Add(newAccount);

            Console.WriteLine("Awensome, your account is registred");
            Console.ReadLine();

            Console.WriteLine("Holder Account: {0}", holderAccount);
            Console.ReadLine();
            Console.WriteLine("Agency: {0}", agencyNumber);
            Console.ReadLine();
            Console.WriteLine("Account: {0}", accountNumber);
            Console.ReadLine();
            Console.WriteLine("Cuurent balance: {0}", currentBalance);

            Console.WriteLine("Thanks to believe us!!");

        }

        private static void Depositar()
		{
			Console.Write("Digite account number: ");
			int accountIndex = int.Parse(Console.ReadLine());

			Console.Write("Digit the value to deposit: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            accountsList[accountIndex].Deposit(valorDeposito);
		}

        private static void ListAccounts() {

            if(accountsList.Count == 0) {
                Console.WriteLine("No accounts in system");
                return;
            }

            for(int i = 0; i < accountsList.Count; i++) {

                Account account = accountsList[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void Sacar() {

            Console.WriteLine("Digit number of your account: ");
            int indexAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Digit whtidraw value: ");
            double whtidrawValue = double.Parse(Console.ReadLine());

            accountsList[indexAccount].Sacar(whtidrawValue);
        }

        private static void Transferir()
		{
			Console.Write("Digit origin account: ");
			int originAccountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digit destiny account: ");
			int destinyAccountIndex = int.Parse(Console.ReadLine());

			Console.Write("Digit value: ");
			double transferValue = double.Parse(Console.ReadLine());

            accountsList[originAccountIndex].Transferir(accountsList[destinyAccountIndex], transferValue);
		}
    }
}

