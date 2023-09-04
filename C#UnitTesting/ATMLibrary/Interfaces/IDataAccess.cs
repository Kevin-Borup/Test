using ATMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Interfaces
{
    public interface IDataAccess
    {
        //Accounts
        Account GetAccount(string accountId);
        List<Account> GetAllAccounts();

        //Deposits
        void UpdateDepositBalance(string accountId, Deposit deposit);

        //Cards
        List<Card> GetAllCards();
    }
}
