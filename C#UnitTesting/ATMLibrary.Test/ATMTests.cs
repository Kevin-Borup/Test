using ATMLibrary.Models;
using Autofac.Extras.Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.Test
{
    public class ATMTests
    {
        [Fact]
        public void InsertCard_ShouldFail()
        {
            ATM atm = new ATM(null);
            Card card = new Card("1", "test", "2", "test", "1234");
            Card card2 = new Card("1", "test", "2", "test", "1234");

            atm.InsertCard(card);

            var caughtException = Assert.Throws<Exception>(() => atm.InsertCard(card2));

            Assert.Equal("ATMAlreadyContainsCard", caughtException.Message);
        }

        [Fact]
        public void RemoveCard_ShouldWork()
        {
            ATM atm = new ATM(null);
            Card card = new Card("1", "test", "2", "test", "1234");

            atm.InsertCard(card);
            atm.RemoveCard();

            var caughtException = Assert.Throws<Exception>(() => atm.UnlockCard("1234"));

            Assert.Equal("CardNotInserted", caughtException.Message);
        }

        [Fact]
        public void RemoveCard_ShouldFail()
        {
            ATM atm = new ATM(null);

            var caughtException = Assert.Throws<Exception>(() => atm.RemoveCard());

            Assert.Equal("NoCardInATM", caughtException.Message);
        }

        [Theory]
        [InlineData("3000")]
        [InlineData("5325")]
        [InlineData("5150")]
        [InlineData("0001")]
        public void PinCode_ShouldWork(string pinCode)
        {
            ATM atm = new ATM(null);
            Card card = new Card("1", "test", "2", "test", pinCode);

            atm.InsertCard(card);
            Assert.True(atm.UnlockCard(pinCode));
        }

        [Fact]
        public void Withdraw_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x => x.GetAccount("a1"))
                    .Returns(GetSampleAccount());

                var expectedAccount = GetSampleAccount();
                var atm = mock.Create<ATM>();

                var card = GetSampleCard();

                atm.InsertCard(card);
                atm.UnlockCard("1234");

                decimal amountInHand = atm.WithdrawFromCard(4999, "DKK");

                // If this fails, then the previous withdrawal worked.
                var caughtException = Assert.Throws<Exception>(() => atm.WithdrawFromCard(2, "DKK"));

                Assert.Equal("WithdrawTooHigh", caughtException.Message);
            }
        }

        [Fact]
        public void Withdraw_ShouldFail() 
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x => x.GetAccount("a1"))
                    .Returns(GetSampleAccount());

                var expectedAccount = GetSampleAccount();
                var atm = mock.Create<ATM>();

                var card = GetSampleCard();

                atm.InsertCard(card);
                atm.UnlockCard("1234");

                var caughtException = Assert.Throws<Exception>(() => atm.WithdrawFromCard(10002, "DKK"));

                Assert.Equal("WithdrawTooHigh", caughtException.Message);
            }
        }

        [Fact]
        public void Deposit_ShouldWork()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x => x.GetAccount("a1"))
                    .Returns(GetSampleAccount());

                var expectedAccount = GetSampleAccount();
                var atm = mock.Create<ATM>();

                var card = GetSampleCard();

                atm.InsertCard(card);
                atm.UnlockCard("1234");

                atm.DepositToCard(5001, "DKK");

                // If this succeeds, then the balance was increased by the previous statement.
                atm.WithdrawFromCard(10000, "DKK");
            }
        }

        [Fact]
        public void Deposit_ShouldFail() 
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccess>()
                    .Setup(x => x.GetAccount("a1"))
                    .Returns(GetSampleAccount());

                var expectedAccount = GetSampleAccount();
                var atm = mock.Create<ATM>();

                var card = GetSampleCard();

                atm.InsertCard(card);
                atm.UnlockCard("1234");


                var caughtException = Assert.Throws<Exception>(() => atm.DepositToCard(-200, "DKK"));

                Assert.Equal("NegativeAmount", caughtException.Message);
            }
        }

        private Account GetSampleAccount()
        {
            return new Account(
                    "a1",
                    "Southbank Account",
                    new List<Deposit>()
                    {
                        new Deposit(
                            "a1-b1",
                            "Savings",
                            5000)
                    });


        }

        private Card GetSampleCard()
        {
            return new Card("a1", "Southbank Account", "a1-b1", "Savings", "1234");
        }
    }
}
