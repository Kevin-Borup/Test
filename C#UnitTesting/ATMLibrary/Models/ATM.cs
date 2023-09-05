using ATMLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Models
{
    public class ATM
    {
        public List<string> valutas = new List<string>();
        IDataAccess _dataAccess;

        Card? insertedCard = null;
        public bool Inserted
        {
            get
            {
                return insertedCard != null;
            }
            private set
            {
                Inserted = value;
            }
        }

        bool unlocked = false;

        public bool Unlocked
        {
            get
            {
                return unlocked;
            }
            private set
            {
                unlocked = value;
            }
        }

        public ATM(IDataAccess dataAccess) 
        { 
            this._dataAccess = dataAccess;

            valutas = new List<string>() { "DKK", "SEK", "EUR" };
        }

        public List<Card> GetAllCards()
        {
            return _dataAccess.GetAllCards();
        }

        public void InsertCard(Card card)
        {
            if (Inserted) throw new Exception("ATMAlreadyContainsCard");

            insertedCard = card;
        }

        public bool UnlockCard(string pinCode)
        {
            if (!Inserted) throw new Exception("CardNotInserted");
            unlocked = insertedCard.ValidatePinCode(pinCode);

            return unlocked;
        }

        public void RemoveCard()
        {
            if (!Inserted) throw new Exception("NoCardInATM");

            insertedCard = null;
            unlocked = false;
        }

        public decimal WithdrawFromCard(decimal amount, string valuta)
        {
            if (!Inserted) throw new Exception("NoCardInATM");
            if (!unlocked) throw new Exception("CardNotUnlocked");

            var accountId = insertedCard.AccountId;
            Account account = _dataAccess.GetAccount(accountId);
            Deposit deposit = account.GetDeposit(insertedCard.DepositId);

            var convertedAmount = ConvertToValuta(amount, valuta, true);

            deposit.RemoveFromBalance(convertedAmount);

            _dataAccess.UpdateDepositBalance(accountId, deposit);

            return convertedAmount;
        }

        public void DepositToCard(decimal amount, string valuta) 
        {
            if (!Inserted) throw new Exception("NoCardInATM");
            if (!unlocked) throw new Exception("CardNotUnlocked");

            var accountId = insertedCard.AccountId;
            Account account = _dataAccess.GetAccount(accountId);
            Deposit deposit = account.GetDeposit(insertedCard.DepositId);

            var convertedAmount = ConvertToValuta(amount, valuta, false);

            deposit.AddToBalance(convertedAmount);

            _dataAccess.UpdateDepositBalance(accountId, deposit);
        }

        public decimal ConvertToValuta(decimal amount, string valuta, bool withdraw)
        {
            if (withdraw)
            {
                switch (valuta)
                {
                    case "DKK":
                        return amount;
                    case "SEK":
                        return amount * (decimal)1.60;
                    default:
                        return amount * (decimal)0.13;
                }
            }
            else
            {
                switch (valuta)
                {
                    case "DKK":
                        return amount;
                    case "SEK":
                        return amount * (decimal)0.63;
                    default:
                        return amount * (decimal)7.45;
                }
            }
        }

        public (string accountName, string depositName, string depositBalance) GetCardDetails()
        {
            if(Inserted && unlocked)
            {
                Account account = _dataAccess.GetAccount(insertedCard.AccountId);
                Deposit deposit = account.GetDeposit(insertedCard.DepositId);


                return (insertedCard.AccountName, insertedCard.DepositName, deposit.balance.ToString());
            } 
            else
            {
                return ("", "", "");
            }
        }
    }
}
