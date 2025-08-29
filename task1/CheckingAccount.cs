namespace task1
{
    public class CheckingAccount: Account
    {
        public double Fee { get; set; }
        public CheckingAccount(string name = "Unnamed Account", double balance = 0.0, double fee = 1.5)
            : base(name, balance)
        {
            Fee = fee;
        }
        public override bool Withdraw(double amount)
        {
            return base.Withdraw(amount + Fee);
        }
        public override string ToString()
        {
            return $"[CheckingAccount: balance={GetBalance()}, Fee: {Fee}]";
        }

    }
}