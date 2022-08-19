using System;
using Classes;

namespace dougr
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Doug", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            Console.WriteLine(account.Balance);
            account.MakeDeposite(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
        }
    }
}
