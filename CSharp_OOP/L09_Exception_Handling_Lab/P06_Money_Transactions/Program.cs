namespace P06_Money_Transactions
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Account> accounts = new Dictionary<int, Account>();

            accounts = PopulateAccounts();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] commandData = input.Split();
                string command = commandData[0];
                int accountNumber = int.Parse(commandData[1]);
                double amount = double.Parse(commandData[2]);

                try
                {
                    if (command != "Deposit" && command != "Withdraw")
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    if (!accounts.ContainsKey(accountNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (command == "Deposit")
                    {
                        accounts[accountNumber].DepositAmount(amount);
                        Console.WriteLine(accounts[accountNumber].AccountUpdatedBalance());
                    }
                    else if (command == "Withdraw")
                    {
                        accounts[accountNumber].WithdrawAmount(amount);
                        Console.WriteLine(accounts[accountNumber].AccountUpdatedBalance());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                Console.WriteLine("Enter another command");

            }

        }

        private static Dictionary<int, Account> PopulateAccounts()
        {
            Dictionary<int, Account> accounts = new Dictionary<int, Account>();

            string[] accountsInput = Console.ReadLine().Split(',');

            foreach (var accountData in accountsInput)
            {
                string[] accountDetails = accountData.Split('-');
                int accountNumber = int.Parse(accountDetails[0]);
                double accountBalance = double.Parse(accountDetails[1]);

                Account newAccount = new Account(accountNumber, accountBalance);

                accounts.Add(accountNumber, newAccount);
            }

            return accounts;
        }
    }

    public class Account
    {
        public Account(int accountNumber, double accountBalance)
        {
            this.AccountNumber = accountNumber;
            this.AccountBalance = accountBalance;
        }

        public  int AccountNumber { get; private set; }
        public double AccountBalance { get; set; }

        public void DepositAmount(double amount)
        {
            this.AccountBalance += amount;
        }

        public void WithdrawAmount(double amount)
        {
            if(amount > this.AccountBalance)
            {
                throw new InvalidOperationException("Insufficient balance!");
            }

            this.AccountBalance -= amount;
        }

        public string AccountUpdatedBalance()
        {
            return $"Account {this.AccountNumber} has new balance: {this.AccountBalance:f2}";
        }

    }
}
