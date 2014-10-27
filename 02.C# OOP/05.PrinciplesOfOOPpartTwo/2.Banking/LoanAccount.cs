using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Custumer custumer, decimal balance, decimal interestRate)
            : base(custumer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestRate(decimal numberOfMonths)
        {
            if ((this.CustumerClient is Individual) && (numberOfMonths > 3))
            {
                return this.MonthlyInterestRate * (numberOfMonths - 3);
            }
            else if ((this.CustumerClient is Company) && (numberOfMonths > 2))
            {
                return this.MonthlyInterestRate * (numberOfMonths - 2);
            }
            else
            {
                return 0;
            }
        }

        public decimal DepositMoney(decimal amount)
        {
            return this.Balance += amount;
        }
    }
}
