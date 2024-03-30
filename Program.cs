using System;

namespace Assignment
{
    public class bank_acc
    {
        public string acc_num { get; set; }
        public double balance { get; private set; }
        public string Type { get; set; }

        public bank_acc(string accNumber, double initialBalance = 0.0, string type = "checking")
        {
            acc_num = accNumber;
            balance = initialBalance;
            Type = type;
        }

        public void deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please enter the deposit amount in positive.");
                return;
            }

            balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${balance}.");
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please enter the withdraw amount in positive.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine(" You have Insufficient funds in you account.");
                return;
            }

            balance -= amount;
            Console.WriteLine($"Withdrew ${amount}. New balance: ${balance}.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Roshan Bank Of Canada");

            Console.Write(" Please enter account number: ");
            var accountNumber = Console.ReadLine();

            Console.Write("Please enter initial balance (or leave blank for $0): ");
            var balanceInput = Console.ReadLine();
            double initialBalance;
            if (string.IsNullOrEmpty(balanceInput) || !double.TryParse(balanceInput, out initialBalance))
            {
                initialBalance = 0;
            }

            Console.Write(" Please enter account type (checking/saving): ");
            var type = Console.ReadLine()?.ToLower() == "saving" ? "saving" : "checking";

            var account = new bank_acc(accountNumber, initialBalance, type);

            bool continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option (1-3): ");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Write("Please enter deposit amount: ");
                        var depositAmount = double.Parse(Console.ReadLine());
                        account.deposit(depositAmount);
                        break;
                    case "2":
                        Console.Write("Please enter withdrawal amount: ");
                        var withdrawalAmount = double.Parse(Console.ReadLine());
                        account.Withdraw(withdrawalAmount);
                        break;
                    case "3":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter the correct option");
                        break;
                }
            }

            Console.WriteLine("Thank you for using the Roshan Bank of Canada. Have a good day");
        }
    }
}
