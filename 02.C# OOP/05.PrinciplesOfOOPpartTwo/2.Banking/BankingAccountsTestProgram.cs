using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class BankingAccountsTestProgram
    {
        static void Main()
        {
            DepositAccount depAccInd = new DepositAccount(new Individual("Asparuh Milenkov", "1234567891"), 300, 30);
            DepositAccount depAccComp = new DepositAccount(new Company("IliqnciOOD", "12345678"), 3000, 300);

            LoanAccount loanAccInd = new LoanAccount(new Individual("Nikodim Naumov", "1111111111"), 100, 10);
            LoanAccount loanAccComp = new LoanAccount(new Company("OremQko", "78978978"), 12223, 129);

            MortgageAccount mortAccInd = new MortgageAccount(new Individual("Stamen Krantev", "5555555555"), 10000, 200);
            MortgageAccount mortAccComp = new MortgageAccount(new Company("NqmaPari", "77777777"), 20, 10);

            List<Account> listOfAllAccounts = new List<Account>() { depAccInd, depAccComp, loanAccComp, loanAccInd, mortAccComp, mortAccInd };

            //foreach (var acc in listOfAllAccounts)
            //{
            //    Console.WriteLine("Type of account: {0} \nCompany/Individual: {1} \nInterestRate: {2} \nBalance: {3} \nCalculateInterestRateFor15Months: {4}",
            //        acc.GetType(), acc.CustumerClient, acc.MonthlyInterestRate, acc.Balance, acc.CalculateInterestRate(15));
            //    Console.WriteLine(new string('-', 50));
            //}

            Console.WriteLine("Deposit account before deposit and withdraw: \nBalance: {0}", depAccInd.Balance);
            depAccInd.DepositMoney(1000);
            depAccInd.WithDrawMoney(100);

            Console.WriteLine("Deposit Account after deposit(1000) and withdraw(100): \nCurrent balance: {0}, \nInterest for 2 months is: {1:F2}",
            depAccInd.Balance, depAccInd.CalculateInterestRate(2));

        }
    }
}
