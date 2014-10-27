using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Custumer custumer, decimal balance, decimal interestRate)
            : base(custumer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestRate(decimal numberOfMonths)
        {
            if (this.CustumerClient is Individual)
            {
                if (numberOfMonths > 6)
                {
                    return this.MonthlyInterestRate * (numberOfMonths - 6);
                }
                else
                {
                    return 0;
                }
            }

            else if (this.CustumerClient is Company)
            {
                if (numberOfMonths > 12)
                {
                    return (12 * (this.MonthlyInterestRate / 2)) + ((numberOfMonths - 12) * this.MonthlyInterestRate);
                }
                else
                {
                    return numberOfMonths * (this.MonthlyInterestRate / 2);
                }
            }
            return 0;
        }

        public decimal DepositMoney(decimal amount)
        {
            return this.Balance += amount;
        }
    }
}
