using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATMLibrary.Models
{
    public class Deposit
    {
        public string id { get; private set; }
        public string name { get; private set; }

        public decimal balance { get; private set; }

        public Deposit(string id, string name, decimal startBalance = 0)
        {
            this.id = id;
            this.name = name;
            this.balance = startBalance;
        }

        public void AddToBalance(decimal amount)
        {
            if(amount < 0) throw new Exception("NegativeAmount");
            balance += amount;
        }

        public void RemoveFromBalance(decimal amount)
        {
            if (amount < 0) throw new Exception("NegativeAmount");
            if (amount > balance) throw new Exception("WithdrawTooHigh");

            balance -= amount;
        }
    }
}
