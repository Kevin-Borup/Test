using ATMLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Models
{
    public class ATM
    {
        IDataAccess _dataAccess;

        Card? insertedCard = null;
        bool unlocked = false;

        public ATM(IDataAccess dataAccess) 
        { 
            this._dataAccess = dataAccess;
        }

        public List<Card> GetAllCards()
        {
            return _dataAccess.GetAllCards();
        }

        public void InsertCard(Card card)
        {
            if (insertedCard != null) throw new Exception("ATMAlreadyContainsCard");

            insertedCard = card;
        }

        public bool UnlockCard(string pinCode)
        {
            if (insertedCard == null) throw new Exception("CardNotInserted");
            unlocked = insertedCard.ValidatePinCode(pinCode);

            return unlocked;
        }

        public void RemoveCard()
        {
            if (insertedCard == null) throw new Exception("NoCardInATM");

            insertedCard = null;
            unlocked = false;
        }

        public decimal WithdrawFromCard(decimal amount)
        {
            if (insertedCard == null) throw new Exception("NoCardInATM");
            if (unlocked == false) throw new Exception("CardNotUnlocked");

            var accountId = insertedCard.AccountId;
            Account account = _dataAccess.GetAccount(accountId);
            Deposit deposit = account.GetDeposit(insertedCard.DepositId);

            deposit.RemoveFromBalance(amount);

            _dataAccess.UpdateDepositBalance(accountId, deposit);

            return amount;
        }

        public void DepositToCard(decimal amount) 
        {
            if (insertedCard == null) throw new Exception("NoCardInATM");
            if (unlocked == false) throw new Exception("CardNotUnlocked");

            var accountId = insertedCard.AccountId;
            Account account = _dataAccess.GetAccount(accountId);
            Deposit deposit = account.GetDeposit(insertedCard.DepositId);

            deposit.AddToBalance(amount);

            _dataAccess.UpdateDepositBalance(accountId, deposit);
        }
    }
}
