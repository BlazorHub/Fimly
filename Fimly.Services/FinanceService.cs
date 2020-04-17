using Fimly.Data.Models;
using System.Collections.Generic;

namespace Fimly.Services
{
    public static class FinanceService
    {
        public static decimal GetTotalMonthlyIncome(List<Person> people)
        {
            decimal totalIncome = 0;

            for (int i = 0; i < people.Count; i++)
            {
                totalIncome += people[i].Income;
            }

            return totalIncome;
        }

        public static decimal GetTotalYearlyIncome(List<Person> people)
        {
            decimal monthlyIncome = GetTotalMonthlyIncome(people);

            decimal yearlyIncome = monthlyIncome * 12;

            return yearlyIncome;
        }

        public static string FormatToCurrency(Config userConfig, decimal currency)
        {
            return $"{ userConfig.Currency.Symbol }{ string.Format("{0:N}", currency) }";
        }
    }
}
