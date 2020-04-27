using System;
using System.Collections.Generic;

namespace Fimly.Services
{
    public static class IconService
    {
        private static readonly Dictionary<string, string> _expenseIcons =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "phone", "fas fa-mobile-alt" },
                { "mobile", "fas fa-mobile-alt" },
                { "rent", "fas fa-home" },
                { "mortgage", "fas fa-home" },
                { "house", "fas fa-home" },
                { "flat", "fas fa-home" },
                { "apartment", "fas fa-home" },
                { "gas","fas fa-burn" },
                { "util", "fas fa-burn" },
                { "electric", "fas fa-bolt" },
                { "power", "fas fa-bolt" },
                { "diesel", "fas fa-gas-pump" },
                { "fuel", "fas fa-gas-pump" },
                { "petrol", "fas fa-gas-pump" },
                { "food", "fas fa-utensils" },
                { "groceries", "fas fa-utensils" },
                { "eat", "fas fa-utensils" },
                { "takeaway","fas fa-utensils" },
                { "takeaways","fas fa-utensils" },
                { "takeout", "fas fa-utensils" },
                { "takeouts", "fas fa-utensils" },
                { "water", "fas fa-shower" },
                { "car", "fas fa-car" },
                { "van", "fas fa-car" },
                { "internet", "fas fa-wifi" },
                { "network", "fas fa-wifi" },
                { "spotify", "fas fa-spotify" },
                { "bus", "fas fa-bus" },
                { "coach", "fas fa-bus" },
                { "charity", "fas fa-hand-holding-heart" },
                { "donation", "fas fa-hand-holding-heart" },
                { "aws", "fas fa-aws" },
                { "amazon", "fab fa-amazon" },
                { "plex", "fas fa-film" },
                { "video", "fas fa-film" },
                { "movies", "fas fa-film" },
                { "server", "fas fa-server" },
                { "union", "fas fa-briefcase" },
                { "microsoft", "fab fa-microsoft" },
                { "github", "fab fa-github" },
                { "xbox", "fab fa-xbox" },
                { "playstation", "fab fa-playstation" },
                { "ps4", "fab fa-playstation" }
            };

        public static string GuessExpenseIcon(string input)
        {
            string[] inputWords = input.Split();

            foreach (string word in inputWords)
            {
                if (_expenseIcons.TryGetValue(word, out string expenseIcon))
                {
                    return expenseIcon;
                }
            }

            return "fas fa-money-bill-alt";
        }
    }
}
