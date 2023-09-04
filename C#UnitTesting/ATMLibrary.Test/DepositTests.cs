using ATMLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Test
{
    public class DepositTests
    {
        [Theory]
        [InlineData(3000, 2000, 5000)]
        [InlineData(1000, 7000.5325, 8000.5325)]
        [InlineData(100, 50, 150)]
        [InlineData(10000, 50.000000001, 10050.000000001)]
        //[InlineData(decimal.MaxValue, 5, decimal.MaxValue)] //MaxValue on Decimal is reaonly, therefore not possible to test like this
        public void AddToBalance_ShouldWork(decimal startAmount, decimal addingAmount, decimal expected)
        {
            Deposit deposit = new Deposit("", "", startAmount);

            deposit.AddToBalance(addingAmount);

            decimal actual = deposit.balance;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddToBalance_MaxValueShouldFail()
        {
            decimal expected = decimal.MaxValue;

            Deposit deposit = new Deposit("", "", 5000);
            Assert.Throws<OverflowException>(() => deposit.AddToBalance(decimal.MaxValue));
        }

        [Theory]
        [InlineData(500, -700)]
        [InlineData(100, -50)]
        public void AddToBalance_NegativeShouldFail(decimal startAmount, decimal addingAmount)
        {
            Deposit deposit = new Deposit("", "", startAmount);

            var caughtException = Assert.Throws<Exception>(() => deposit.AddToBalance(addingAmount));

            Assert.Equal("NegativeAmount", caughtException.Message);
        }

        [Theory]
        [InlineData(3000, 2000, 1000)]
        [InlineData(7000.5325, 7000, 0.5325)]
        [InlineData(100, 50, 50)]
        [InlineData(10000, 50.000000001, 9949.999999999)]
        public void RemoveFromBalance_ShouldWork(decimal startAmount, decimal withdrawAmount, decimal expected)
        {
            Deposit deposit = new Deposit("", "", startAmount);

            deposit.RemoveFromBalance(withdrawAmount);

            decimal actual = deposit.balance;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(500, -700)]
        [InlineData(100, -50)]
        public void RemoveFromBalance_NegativeShouldFail(decimal startAmount, decimal withdrawAmount)
        {
            Deposit deposit = new Deposit("", "", startAmount);

            var caughtException = Assert.Throws<Exception>(() => deposit.RemoveFromBalance(withdrawAmount));

            Assert.Equal("NegativeAmount", caughtException.Message);
        }

        [Theory]
        [InlineData(500, 700)]
        [InlineData(100, 5000)]
        public void RemoveFromBalance_WithdrawTooHighShouldFail(decimal startAmount, decimal withdrawAmount)
        {
            Deposit deposit = new Deposit("", "", startAmount);

            var caughtException = Assert.Throws<Exception>(() => deposit.RemoveFromBalance(withdrawAmount));

            Assert.Equal("WithdrawTooHigh", caughtException.Message);
        }

    }
}
