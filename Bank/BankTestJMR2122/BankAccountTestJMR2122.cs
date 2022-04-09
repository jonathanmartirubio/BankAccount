using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;

namespace BankTestJMR2122
{
    [TestClass]
    public class BankAccountTestJMR2122
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        // unit test code
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // preparación del caso de prueba
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccountJMR2122 account = new BankAccountJMR2122("Mr. Bryan Walton",
            beginningBalance);
            // acción a probar
            account.Debit(debitAmount);
            // afirmación de la prueba (valor esperado Vs. Valor obtenido)
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WithMinimumLimit_UpdateJMR2122()
        {
            double beginningBalance = 11.99;
            double debitAmount = 0;
            double expected = 11.99;
            
            BankAccountJMR2122 account = new BankAccountJMR2122("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
            double actual = account.Balance;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Debit_WithMaximumLimit_UpdateJMR2122()
        {
            double beginningBalance = 11.99;
            double debitAmount = 11.99;
            double expected = 0;

            BankAccountJMR2122 account = new BankAccountJMR2122("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
            double actual = account.Balance;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Debit_WithValidLimit_UpdateJMR2122()
        {
            double beginningBalance = 11.99;
            double debitAmount = 5.71;
            double expected = 6.28;

            BankAccountJMR2122 account = new BankAccountJMR2122("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
            double actual = account.Balance;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Debit_WhenBankAccountIsFrezee_ShouldThrowException()
        {
            // preparación del caso de prueba
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccountJMR2122 account = new BankAccountJMR2122("Mr. Bryan Walton", beginningBalance);
            account.FreezeAccount();
            // acción a probar
            account.Debit(debitAmount);
            // la afirmación es manejado por el atributo ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsNegative_ShouldThrowException()
        {
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccountJMR2122 account = new BankAccountJMR2122("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowException()
        {
            double beginningBalance = 11.99;
            double debitAmount = 200;
            BankAccountJMR2122 account = new BankAccountJMR2122("Mr. Bryan Walton", beginningBalance);
            account.Debit(debitAmount);
        }
    }
}
