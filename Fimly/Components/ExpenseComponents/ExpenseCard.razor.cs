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
        [CascadingParameter] private Config UserConfig { get; set; }

        [Parameter]
        public Person Person { get; set; }

        [Parameter]
        public Action StateChanged { get; set; }

        [Parameter]
        public string SelectedMonth { get; set; }

        [Inject] private ExpenseService ExpenseService { get; set; }
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private IJSRuntime Js { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private List<Expense> Expenses => Person.Expenses.OrderByDescending(e => e.Cost).ToList();

        private List<Expense> ExpensesByCategory =>
            (from ol in Person.Expenses
             group ol by ol.ExpenseType.Name
                into category
             select new Expense
             {
                 Name = category.Select(ex => ex.ExpenseType.Name).FirstOrDefault(),
                 Cost = category.Sum(ex => ex.Cost),
                 Icon = category.Select(ex => ex.ExpenseType.Icon).FirstOrDefault()
             }).OrderByDescending(e => e.Cost).ToList();

        private Guid ExpenseRowId;

        private void EditExpense(Guid expenseId)
        {
            NavigationManager.NavigateTo($"expenses/edit/{expenseId}");
        }

        private async Task DeleteExpenseAsync(Expense expense)
        {
            if (await Js.InvokeAsync<bool>("confirm",
                "Are you sure you want to delete this expense? " +
                "This action cannot be undone."))
            {
                await ExpenseService.DeleteExpense(expense.Id);

                ToastService.ShowSuccess($"The '{ expense.Name }' expense has been sucessfully deleted.", "Expense Deleted");

                Expenses.Remove(expense);
            }
        }

        private void ShowButtons(Guid expenseId)
        {
            ExpenseRowId = expenseId;
        }

        private void HideButtons()
        {
            ExpenseRowId = Guid.Empty;
        }

        private string GetButtonCss(Guid expenseId)
        {
            if (ExpenseRowId == expenseId)
            {
                return string.Empty;
            }
            else
            {
                return "d-none";
            }
        }

        private string HidePercentage(Guid expenseId)
        {
            if (ExpenseRowId == expenseId)
            {
                return "d-none";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
