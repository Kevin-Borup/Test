using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMLibrary.Models;

namespace ATMLibrary.Test
{
    public class CardTests
    {
        [Theory]
        [InlineData("3000")]
        [InlineData("5325")]
        [InlineData("5150")]
        [InlineData("0001")]
        //[InlineData(decimal.MaxValue, 5, decimal.MaxValue)] //MaxValue on Decimal is reaonly, therefore not possible to test like this
        public void UpdatePinCode_ShouldWork(string newPinCode)
        {
            Card card = new Card("1", "Test", "2", "Test", "1234");
            card.UpdatePinCode(newPinCode);

            Assert.True(card.ValidatePinCode(newPinCode));
        }

        [Theory]
        [InlineData("1")]
        [InlineData("8")]
        [InlineData("50")]
        [InlineData("000")]
        public void UpdatePinCode_TooShortShouldFail(string newPinCode)
        {
            Card card = new Card("1", "Test", "2", "Test", "1234");

            var caughtException = Assert.Throws<Exception>(() => card.UpdatePinCode(newPinCode));

            Assert.Equal("PinCodeTooShort", caughtException.Message);
        }

        [Theory]
        [InlineData("30030")]
        [InlineData("5312325")]
        [InlineData("511111150")]
        [InlineData("00101")]
        public void UpdatePinCode_TooLongShouldFail(string newPinCode)
        {
            Card card = new Card("1", "Test", "2", "Test", "1234");

            var caughtException = Assert.Throws<Exception>(() => card.UpdatePinCode(newPinCode));

            Assert.Equal("PinCodeTooLong", caughtException.Message);
        }

        [Theory]
        [InlineData("3000")]
        [InlineData("5325")]
        [InlineData("5150")]
        [InlineData("0001")]
        public void ValidatePinCode_ShouldWork(string newPinCode)
        {
            Card card = new Card("1", "Test", "2", "Test", newPinCode);

            Assert.True(card.ValidatePinCode(newPinCode));
        }

        [Theory]
        [InlineData("3")]
        [InlineData("535")]
        [InlineData("51")]
        [InlineData("1")]
        public void ValidatePinCode_TooShortShouldFail(string newPinCode)
        {
            Card card = new Card("1", "Test", "2", "Test", "1234");

            var caughtException = Assert.Throws<Exception>(() => card.UpdatePinCode(newPinCode));

            Assert.Equal("PinCodeTooShort", caughtException.Message);
        }

        [Theory]
        [InlineData("30020")]
        [InlineData("5321115")]
        [InlineData("515320")]
        [InlineData("000132333331")]
        public void ValidatePinCode_TooLongShouldFail(string newPinCode)
        {
            Card card = new Card("1", "Test", "2", "Test", "1234"); 

            var caughtException = Assert.Throws<Exception>(() => card.UpdatePinCode(newPinCode));

            Assert.Equal("PinCodeTooLong", caughtException.Message);
        }
    }
}
