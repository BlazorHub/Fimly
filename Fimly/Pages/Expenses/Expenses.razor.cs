using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fimly.Pages.Expenses
{
    [Authorize]
    public partial class Expenses : ComponentBase
    {
        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] UserManager<AppUser> UserManager { get; set; }
        [Inject] ConfigService ConfigService { get; set; }
        [Inject] PersonService PersonService { get; set; }
        [Inject] ExpenseService ExpenseService { get; set; }
        [Inject] ExpenseTypeService ExpenseTypeService { get; set; }

        private AppUser CurrentUser;
        private Config UserConfig;
        private List<Person> People;
        private List<Expense> SharedExpenses;
        private List<ExpenseType> ExpenseTypes;

        private double AnimationDelay = 0.2;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);
            UserConfig = await ConfigService.GetUserConfigAsync(CurrentUser.Id);
            People = await PersonService.GetPeopleAsync(CurrentUser.Id);
            SharedExpenses = await ExpenseService.GetSharedExpenses(CurrentUser.Id);
            ExpenseTypes = await ExpenseTypeService.GetExpenseTypesAsync();
        }

        private async void StateChanged()
        {
            People = await PersonService.GetPeopleAsync(CurrentUser.Id);
            SharedExpenses = await ExpenseService.GetSharedExpenses(CurrentUser.Id);

            StateHasChanged();
        }
    }
}
