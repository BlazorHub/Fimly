using Fimly.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fimly.Services
{
    public static class FinanceService
    {
        public static decimal GetTotalMonthlyIncome(List<Person> people)
        {
            return people.Sum(i => i.Income);
        }

        public static decimal GetTotalYearlyIncome(List<Person> people)
        {
            decimal monthlyIncome = GetTotalMonthlyIncome(people);

            return monthlyIncome * 12;
        }

        public static decimal GetTotalMonthlyExpenditure(List<Expense> expenses)
        {
            return expenses.Sum(i => i.Cost);
        }

        public static string GetPercentageOfMonthlyExpenditure(Expense expense, List<Expense> expenses)
        {
            decimal monthlyExpenditure = GetTotalMonthlyExpenditure(expenses);

            decimal percentageOfMonthlyExpenditure = (expense.Cost / monthlyExpenditure) * 100;

            return $"{ percentageOfMonthlyExpenditure }%";
        }

        public static decimal GetApproxWeeklyIncome(decimal montlyIncome)
        {
            return montlyIncome / 4;
        }

        public static decimal GetApproxYearlyIncome(decimal montlyIncome)
        {
            return montlyIncome * 12;
        }

        public static string FormatToConfigCurrency(Config userConfig, decimal currency)
        {
            return $"{ userConfig.Currency.Symbol }{ string.Format("{0:N}", currency) }";
        }
    }
}
