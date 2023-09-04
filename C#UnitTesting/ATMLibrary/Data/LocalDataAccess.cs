using ATMLibrary.Interfaces;
using ATMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Data
{
    internal class LocalDataAccess : IDataAccess
    {
        private List<Account> accounts = new List<Account>();
        private List<Card> cards = new List<Card>();

        public LocalDataAccess()
        {
            accounts = new List<Account>()
            {
                new Account(
                    "a1",
                    "Southbank Account",
                    new List<Deposit>()
                    {
                        new Deposit(
                            "a1-b1",
                            "Savings",
                            5000)
                    }),
                new Account(
                    "a2",
                    "Sparecase Account",
                    new List<Deposit>()
                    {
                        new Deposit(
                            "a2-b1",
                            "Savings",
                            10000),
                        new Deposit(
                            "a2-b2",
                            "Budget",
                            2000)
                    }),
            };

            cards = new List<Card>()
            {
                new Card("a1", "a1-b1", "1234"),
                new Card("a2", "a2-b1", "4321"),
                new Card("a2", "a2-b2", "1111")
            };
        }

        public List<Account> GetAllAccounts()
        {
            return accounts;
        }

        public List<Card> GetAllCards()
        {
            return cards;
        }

        public Account GetAccount(string accountId)
        {
            return accounts.Where(a => a.id.Equals(accountId)).First();
        }

        public void UpdateDepositBalance(string accountId, Deposit deposit)
        {
            var account = accounts.Where(a => a.id.Equals(accountId)).First();

            var index = accounts.IndexOf(account);

            account.UpdateDeposit(deposit);

            accounts.RemoveAt(index);
            accounts.Insert(index, account);
        }
    }
}
