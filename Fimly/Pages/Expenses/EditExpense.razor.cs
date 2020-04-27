using Blazored.Toast.Services;
using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Pages.Expenses
{
    public partial class EditExpense : ComponentBase
    {
        [Parameter]
        public string ExpenseId { get; set; }

        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] UserManager<AppUser> UserManager { get; set; }
        [Inject] ConfigService ConfigService { get; set; }
        [Inject] ExpenseService ExpenseService { get; set; }
        [Inject] ExpenseTypeService ExpenseTypeService { get; set; }
        [Inject] PersonService PersonService { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        AppUser CurrentUser;
        Config UserConfig;
        List<ExpenseType> ExpenseTypes;
        List<Person> People;
        Expense Expense;

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
    }
}
