namespace task1
{
    public class SavingsAccount:Account
    {
        public double InterestRate { get; set; }
        public SavingsAccount(string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            this.InterestRate = interestRate;
        }
        public override bool Deposit(double amount)
        {
            if (amount <= 0) return false;
           
            return base.Deposit(amount + (amount * (InterestRate/100.0)));
        }
        public override string ToString()
        {
            return $"[SavingsAccount: balance={GetBalance()}, Interest Rate: {InterestRate}%]";
        }
    }
}