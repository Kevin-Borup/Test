using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ATMLibrary.Models
{
    public class Card
    {
        public string Id { get; private set; }
        public string AccountId { get; private set; }
        public string DepositId { get; private set; }

        private string code;

        public Card(string accountId, string depositId, string pinCode) 
        {
            this.AccountId = accountId;
            this.DepositId = depositId;
            this.code = pinCode;
        }

        public void UpdatePinCode(string pinCode)
        {
            ApprovePinCode(pinCode);
            this.code = pinCode;
        }

        public bool ValidatePinCode(string pinCode)
        {
            ApprovePinCode(pinCode);
            return this.code.Equals(pinCode);
        }

        private void ApprovePinCode(string pinCode)
        {
            if (pinCode.Length < 4) throw new Exception("PinCodeTooShort");
            if (pinCode.Length > 4) throw new Exception("PinCodeTooLong");
        }

    }
}