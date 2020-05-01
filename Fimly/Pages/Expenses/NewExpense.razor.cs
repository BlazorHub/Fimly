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
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private UserManager<AppUser> UserManager { get; set; }
        [Inject] private ConfigService ConfigService { get; set; }
        [Inject] private ExpenseService ExpenseService { get; set; }
        [Inject] private ExpenseTypeService ExpenseTypeService { get; set; }
        [Inject] private PersonService PersonService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IToastService ToastService { get; set; }

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

            if (People.Count <= 1)
            {
                NavigationManager.NavigateTo("expenses");
            }

            Expense = new Expense
            {
                Name = "",
                IsRecurring = true,
                ExpenseTypeId = ExpenseTypes.FirstOrDefault(e => e.Name == "General").Id,
                PersonId = People.Count > 2 ? People.FirstOrDefault(p => p.Name == "Shared").Id : People.FirstOrDefault(p => p.Name != "Shared").Id,
                UserId = CurrentUser.Id
            };
        }

        private async void HandleValidSubmitAsync()
        {
            Expense.DateAdded = DateTime.UtcNow;
            Expense.Icon = IconService.GuessExpenseIcon(Expense.Name);

            await ExpenseService.CreateExpenseAsync(Expense);

            ToastService.ShowSuccess($"The '{ Expense.Name }' expense has been added successfully.", "Expense Added");

            NavigationManager.NavigateTo("expenses");
        }
    }
}
