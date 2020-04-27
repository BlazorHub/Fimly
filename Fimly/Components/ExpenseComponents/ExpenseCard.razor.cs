using Blazored.Toast.Services;
using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        [Inject] ExpenseService ExpenseService { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] IJSRuntime Js { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        List<Expense> Expenses => Person.Expenses.OrderByDescending(e => e.Cost).ToList();

        List<Expense> ExpensesByCategory =>
            (from ol in Person.Expenses
             group ol by ol.ExpenseType.Name
                into category
             select new Expense
             {
                 Name = category.Select(ex => ex.ExpenseType.Name).FirstOrDefault(),
                 Cost = category.Sum(ex => ex.Cost),
                 Icon = category.Select(ex => ex.ExpenseType.Icon).FirstOrDefault()
             }).OrderByDescending(e => e.Cost).ToList();

        string CurrentMonth => DateTime.Now.ToString("MMMM");

        private void EditExpense(Guid expenseId)
        {
            NavigationManager.NavigateTo($"expenses/edit/{ expenseId }");
        }

        private async Task DeleteExpenseAsync(Expense expense)
        {
            if (await Js.InvokeAsync<bool>("confirm",
                "Are you sure you want to delete this expense? " +
                "This action cannot be undone."))
            {
                await ExpenseService.DeleteExpense(expense.Id);

                ToastService.ShowSuccess($"The '{ expense.Name }' expense has been sucessfully deleted.", "Expense Deleted");

                StateChanged?.Invoke();
            }
        }
    }
}
