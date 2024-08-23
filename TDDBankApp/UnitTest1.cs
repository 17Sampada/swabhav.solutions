namespace TDDBankApp
{
    public class Tests
    {

        BankAccount _account;
        BankAccount _toAccount;


        [SetUp]
        public void Setup()
        {
            _account = new BankAccount();
            _toAccount = new BankAccount();
        }

        [Test]

        public void CheckTheValidDepositAmountIncreaseBalance()
        {
            double depositAmount = 1000;
            _account.Deposit(depositAmount);
            Assert.AreEqual(depositAmount, _account.GetBalance());

        }

        [Test]
        public void DepositInvalidAmountException()
        {
            double invalidAmount = -10;

            Assert.Throws<ArgumentException>(() => _account.Deposit(invalidAmount));

        }


        [Test]

        public void CheckTheValidWithdrawalAmountDecreasesBalance()
        {
            double depositAmount = 1000;
            double withdrawAmount = 500;
            _account.Deposit(depositAmount);


            _account.Withdraw(withdrawAmount);

            Assert.AreEqual(500, _account.GetBalance());
        }

        [Test]
        public void WithdrawInvalidAmountThrowsException()
        {
            double invalidAmount = -500;

            Assert.Throws<ArgumentException>(() => _account.Withdraw(invalidAmount));

        }

        [Test]
        public void WithdrawAmountExceedingBalanceThrowsException()
        {
            double depositAmount = 500;
            double withdrawAmount = 1000;
            _account.Deposit(depositAmount);
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(withdrawAmount));
        }


        [Test]
        public void CheckTheValidInvalidTransferAmount()
        {
            double depositAmount = 1000;
            double transferAmount = 500;
            _account.Deposit(depositAmount);

            _account.Transfer(_toAccount, transferAmount);
            Assert.AreEqual(500, _account.GetBalance());
            Assert.AreEqual(transferAmount, _toAccount.GetBalance());
        }

        [Test]
        public void TransferInvalidAmountThrowsException()
        {
            double transferAmount = 500;

            Assert.Throws<ArgumentNullException>(() => _account.Transfer(null, 500));
        }

    }
}