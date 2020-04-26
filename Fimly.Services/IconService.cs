namespace Fimly.Services
{
    public static class IconService
    {
        public static string GuessExpenseIcon(string input)
        {
            string expenseName = input.ToLower();
            string expenseIcon;

            switch (expenseName)
            {
                case string a when a.Contains("phone"):
                case string b when b.Contains("mobile"):
                    expenseIcon = "fas fa-mobile-alt";
                    break;

                case string a when a.Contains("rent"):
                case string b when b.Contains("mortgage"):
                case string c when c.Contains("house"):
                case string d when d.Contains("flat"):
                case string e when e.Contains("apartment"):
                    expenseIcon = "fas fa-home";
                    break;

                case string a when a.Contains("gas"):
                case string b when b.Contains("util"):
                    expenseIcon = "fas fa-burn";
                    break;

                case string a when a.Contains("electric"):
                case string b when b.Contains("power"):
                    expenseIcon = "fas fa-bolt";
                    break;

                case string a when a.Contains("petrol"):
                case string b when b.Contains("diesel"):
                case string c when c.Contains("fuel"):
                    expenseIcon = "fas fa-gas-pump";
                    break;

                case string a when a.Contains("food"):
                case string b when b.Contains("groceries"):
                case string c when c.Contains("eat"):
                case string d when d.Contains("take"):
                    expenseIcon = "fas fa-utensils";
                    break;

                case string a when a.Contains("water"):
                    expenseIcon = "fas fa-shower";
                    break;

                case string a when a.Contains("car"):
                case string b when b.Contains("van"):
                    expenseIcon = "fas fa-car";
                    break;

                case string a when a.Contains("internet"):
                case string b when b.Contains("network"):
                    expenseIcon = "fas fa-wifi";
                    break;

                default:
                    expenseIcon = "fas fa-money-bill-alt";
                    break;
            }

            return expenseIcon;
        }
    }
}
