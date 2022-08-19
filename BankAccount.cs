using System;
using System.Collections.Generic;

namespace Classes
{
    public class BankAccount
    {
        //Properties
        private static int accountNumberSeed = 1234567890; //Private means only accessible here. 
                                                           //Static means it's shared by all BankAccount objects.  Basically a global var.

        public string Number { get; } 
        public string Owner { get; set; }
        public decimal Balance { 
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount; 
                }

                return balance;
            } 
        }

        //Constructor -- What we call when we want to make a new object using this class.  
        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString(); 
            accountNumberSeed++; 

            this.Owner = name; 
            MakeDeposite(initialBalance, DateTime.Now, "Initial Balance");
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        //Methods
        public void MakeDeposite(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposite must be positive.");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be greater than 0.");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawl.");
            }
            var withdrawl = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawl);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();//Get the transaction history 
            //Print it.  
        }
    }
}

/*
The this qualifier is only required when a local variable or parameter has the same name as that field or property. The this qualifier is omitted throughout the remainder of this article unless it's necessary.
*/


