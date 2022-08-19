using System.Runtime.Serialization;
using System.Reflection.Emit;
using System.Data;
//using Internal;
using System.Linq.Expressions;
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

            BankAccount invalidAccount;  
            try 
            {
                invalidAccount = new BankAccount("INVALID", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance.");
                Console.WriteLine(e.ToString());
                return;
            }

            Console.WriteLine(account.Balance);
            account.MakeDeposite(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
        }
    }
}
