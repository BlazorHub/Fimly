using Blazored.Toast.Services;
using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Pages.Expenses
{
    [Authorize]
    public partial class NewExpense : ComponentBase
    {
        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] UserManager<AppUser> UserManager { get; set; }
        [Inject] ConfigService ConfigService { get; set; }
        [Inject] ExpenseService ExpenseService { get; set; }
        [Inject] ExpenseTypeService ExpenseTypeService { get; set; }
        [Inject] PersonService PersonService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IToastService ToastService { get; set; }

        private AppUser CurrentUser;
        private Config UserConfig;
        private List<ExpenseType> ExpenseTypes;
        private List<Person> People;

        Expense Expense = new Expense();

        private bool ShowPersonSelect = true;
        private string PersonSelectCssClass => ShowPersonSelect ? null : "d-none";

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);
            UserConfig = await ConfigService.GetUserConfigAsync(CurrentUser.Id);
            People = await PersonService.GetPeopleAsync(CurrentUser.Id);
            ExpenseTypes = await ExpenseTypeService.GetExpenseTypesAsync();

            Expense.IsRecurring = true;
        }

        private async void HandleValidSubmitAsync()
        {
            if (People.Count == 1)
            {
                Expense.PersonId = People.FirstOrDefault().Id;
            }

            Expense.DateAdded = DateTime.UtcNow;
            Expense.UserId = CurrentUser.Id;

            await ExpenseService.CreateExpenseAsync(Expense);

            ToastService.ShowSuccess($"Expense has been added successfully.", "Expense Added");

            NavigationManager.NavigateTo("expenses");
        }

        private void TogglePersonSelect(ChangeEventArgs e)
        {
            if ((bool)e.Value == true)
            {
                Expense.IsShared = true;
                ShowPersonSelect = false;
            }
            else
            {
                ShowPersonSelect = true;
            }
        }
    }
}
