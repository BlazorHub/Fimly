using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Fimly.Pages.Expenses
{
    [Authorize]
    public partial class Expenses : ComponentBase
    {
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private UserManager<AppUser> UserManager { get; set; }
        [Inject] private ConfigService ConfigService { get; set; }
        [Inject] private PersonService PersonService { get; set; }
        [Inject] private ExpenseTypeService ExpenseTypeService { get; set; }

        private AppUser CurrentUser;
        private Config UserConfig;
        private List<Person> People;
        private List<ExpenseType> ExpenseTypes;
        private double AnimationDelay = 0.2;
        private string[] Months = DateTimeFormatInfo.CurrentInfo.MonthNames;
        private string FilterMonth;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);
            UserConfig = await ConfigService.GetUserConfigAsync(CurrentUser.Id);
            People = await PersonService.GetPeopleAndSharedAsync(CurrentUser.Id);
            ExpenseTypes = await ExpenseTypeService.GetExpenseTypesAsync();
            FilterMonth = DateTime.UtcNow.ToString("MMMM");

            if (People.Count <= 2)
            {
                People.RemoveAll(p => p.IsSharedPerson);
            }
        }

        private async void StateChanged()
        {
            People = await PersonService.GetPeopleAndSharedAsync(CurrentUser.Id);

            if (People.Count <= 2)
            {
                People.RemoveAll(p => p.IsSharedPerson);
            }

            StateHasChanged();
        }
    }
}
