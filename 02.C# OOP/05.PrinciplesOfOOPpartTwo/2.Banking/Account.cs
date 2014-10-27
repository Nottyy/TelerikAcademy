using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public abstract class Account
    {
        // Fields
        private Custumer custumer;
        private decimal balance;
        private decimal monthlyInterestRate;

        // Properties
        public Custumer CustumerClient
        {
            get { return this.custumer; }
            set { this.custumer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal MonthlyInterestRate
        {
            get { return this.monthlyInterestRate; }
            set { this.monthlyInterestRate = value; }
        }

        // Constructors
        public Account(Custumer custumer, decimal balance, decimal interestRate)
        {
            this.CustumerClient = custumer;
            this.Balance = balance;
            this.MonthlyInterestRate = interestRate;
        }

        // Methods
        public virtual decimal CalculateInterestRate(decimal numberOfMonths)
        {
            return numberOfMonths * this.MonthlyInterestRate;
        }
    }
}
