using Blazored.Toast.Services;
using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fimly.Pages.Expenses
{
    public partial class EditExpense : ComponentBase
    {
        [Parameter]
        public string ExpenseId { get; set; }

        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private UserManager<AppUser> UserManager { get; set; }
        [Inject] private ConfigService ConfigService { get; set; }
        [Inject] private ExpenseService ExpenseService { get; set; }
        [Inject] private ExpenseTypeService ExpenseTypeService { get; set; }
        [Inject] private PersonService PersonService { get; set; }
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IJSRuntime Js { get; set; }

        private AppUser CurrentUser;
        private Config UserConfig;
        private List<ExpenseType> ExpenseTypes;
        private List<Person> People;
        private Expense Expense;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);
            UserConfig = await ConfigService.GetUserConfigAsync(CurrentUser.Id);
            People = await PersonService.GetPeopleAndSharedAsync(CurrentUser.Id);
            ExpenseTypes = await ExpenseTypeService.GetExpenseTypesAsync();

            Expense = await ExpenseService.GetExpenseAsync(Guid.Parse(ExpenseId));
        }

        private async Task HandleValidSubmitAsync()
        {
            Expense.Icon = IconService.GuessExpenseIcon(Expense.Name);

            try
            {
                await ExpenseService.UpdateExpenseAsync(Expense);

                ToastService.ShowSuccess($"The '{ Expense.Name }' expense has been updated successfully.", "Expense Updated");

                NavigationManager.NavigateTo("expenses");
            }
            catch
            {
                ToastService.ShowError($"Something went wrong updating the '{ Expense.Name }' expense.", "Update Error");
            }
        }

        private async Task DeleteExpenseAsync()
        {
            if (await Js.InvokeAsync<bool>("confirm",
                "Are you sure you want to delete this expense? " +
                "This action cannot be undone."))
            {
                await ExpenseService.DeleteExpense(Expense.Id);

                ToastService.ShowSuccess($"The '{ Expense.Name }' expense has been sucessfully deleted.", "Expense Deleted");

                NavigationManager.NavigateTo("expenses");
            }
        }
    }
}
