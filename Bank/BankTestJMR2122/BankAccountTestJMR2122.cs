using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
