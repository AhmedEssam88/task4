namespace task1
{
    public class TrustAccount:Account
    {
        public double InterestRate { get; set; }
        double Bouns = 5000.0;
        double BounsAmount = 50.0;
        int MaxWithdraw = 3;
        double Precent = 0.20;
        private int Count = 0;
        public TrustAccount(string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0)
                    : base(name, balance)
        {
            this.InterestRate = interestRate;
        }

        public override bool Deposit(double amount)
        {
            if (amount <= 0) return false;
            double total = amount + (amount * (InterestRate / 100.0));
            if (amount >= Bouns) total += BounsAmount;
            return base.Deposit(total);
        }

        public override bool Withdraw(double amount)
        {
            if (amount <= 0) return false;
            if (Count >= MaxWithdraw) return false;

            double maxAllowed = GetBalance() * Precent;
            if (amount > maxAllowed) return false;

           bool status = base.Withdraw(amount);
            if (status) Count++;
            return status;
        }

        public override string ToString()
            => $"[TrustAccount: balance={GetBalance()}, rate={InterestRate}%, withdrawalsLeft={MaxWithdraw - Count}]";
    }
}