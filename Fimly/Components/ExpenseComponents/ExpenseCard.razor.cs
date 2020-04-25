using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Components.ExpenseComponents
{
    public partial class ExpenseCard : ComponentBase
    {
        [CascadingParameter] Config UserConfig { get; set; }
        [CascadingParameter] List<ExpenseType> ExpenseTypes { get; set; }

        [Parameter]
        public Person Person { get; set; }

        [Parameter]
        public Action StateChanged { get; set; }

        List<Expense> Expenses => Person.Expenses.OrderByDescending(e => e.Cost).ToList();

        List<Expense> ExpensesByCategory =>
            (from ol in Person.Expenses
             group ol by ol.ExpenseType.Name
                into category
             select new Expense
             {
                 Name = category.Select(ex => ex.ExpenseType.Name).FirstOrDefault(),
                 Cost = category.Sum(ex => ex.Cost)
             }).ToList();

        string CurrentMonth => DateTime.Now.ToString("MMMM");
    }
}
