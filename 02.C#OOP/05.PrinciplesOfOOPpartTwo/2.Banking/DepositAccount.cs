using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class DepositAccount : Account, IDepositable, IDrawable
    {
        public DepositAccount(Custumer custumer, decimal balance, decimal interestRate)
            : base(custumer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestRate(decimal numberOfMonths)
        {
            if (this.Balance < 1000 && this.Balance > 0)
            {
                return 0;
            }
            else
            {
                return this.MonthlyInterestRate * numberOfMonths;

            }
        }

        public decimal DepositMoney(decimal amount)
        {
            return this.Balance += amount;
        }

        public decimal WithDrawMoney(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("Not enough money in the Balance to withdraw!");
            }
            else
            {
                return this.Balance -= amount;
            }
        }
    }
}
