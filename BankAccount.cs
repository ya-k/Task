using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksApp
{
    public class BankAccount
    {
        private decimal balance = 0;
        private object balanceLock = new object();

        public decimal Balance => balance;

        public void Deposit(decimal amount)
        {
            lock (balanceLock)
            {
                balance += amount;
                Console.WriteLine($"Deposit: {amount}. Balance: {balance}");
            }
        }

        public void Withdraw(decimal amount)
        {
            lock (balanceLock)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    Console.WriteLine($"Withdrawal: {amount}. Balance: {balance}");
                }
                else
                {
                    Console.WriteLine($"Insufficient balance. Cannot withdraw {amount}. Balance: {balance}");
                }
            }
        }
    }
}
