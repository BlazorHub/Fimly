using System;
using System.Collections.Generic;

namespace Fimly.Services
{
    public static class IconService
    {
        private static readonly Dictionary<string, string> _expenseIcons =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "phone", "fa-mobile-alt" },
            { "mobile", "fa-mobile-alt" },
            { "rent", "fa-home" },
            { "mortgage", "fa-home" },
            { "house", "fa-home" },
            { "flat", "fa-home" },
            { "apartment", "fa-home" },
            { "gas","fa-burn" },
            { "util", "fa-burn" },
            { "electric", "fa-bolt" },
            { "power", "fa-bolt" },
            { "diesel", "fa-gas-pump" },
            { "fuel", "fa-gas-pump" },
            { "petrol", "fa-gas-pump" },
            { "food", "fa-utensils" },
            { "groceries", "fa-utensils" },
            { "eat", "fa-utensils" },
            { "takeaway","fa-utensils" },
            { "takeaways","fa-utensils" },
            { "takeout", "fa-utensils" },
            { "takeouts", "fa-utensils" },
            { "water", "fa-shower" },
            { "car", "fa-car" },
            { "van", "fa-car" },
            { "internet", "fa-wifi" },
            { "network", "fa-wifi" },
            { "spotify", "fa-spotify" },
            { "bus", "fa-bus" },
            { "coach", "fa-bus" },
            { "charity", "fa-hand-holding-heart" },
            { "donation", "fa-hand-holding-heart" },
            { "aws", "fa-aws" }
        };

        public static string GuessExpenseIcon(string input)
        {
            string[] inputWords = input.Split();

            foreach (string word in inputWords)
            {
                if (_expenseIcons.TryGetValue(word, out string expenseIcon))
                {
                    return $"fas { expenseIcon }";
                }
            }

            return "fas fa-money-bill-alt";
        }
    }
}
