﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;

namespace ATMLibrary.Models
{
    public class Card
    {
        public string AccountId { get; private set; }
        public string AccountName { get; private set; }
        public string DepositId { get; private set; }
        public string DepositName { get; private set; }

        private string code;

        public Card(string accountId, string accountName, string depositId, string depositName, string pinCode) 
        {
            this.AccountId = accountId;
            this.AccountName = accountName;
            this.DepositId = depositId;
            this.DepositName = depositName;
            this.code = pinCode;
        }

        public override string ToString()
        {
            return $"{AccountName} - {DepositName}";
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