﻿namespace task1
{
    public class Account
    {
        public string Name { get;private set; }
        public double Balance { get; private set; }
        

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            Name = name;
            Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetBalance()
        {
            return Balance;
        }

        public override string ToString()
        {
            return $"[Account: {Name}: {Balance}]";
        }

    }
}