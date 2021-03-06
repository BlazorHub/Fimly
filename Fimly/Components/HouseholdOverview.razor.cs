﻿using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fimly.Components
{
    public partial class HouseholdOverview : ComponentBase
    {
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private UserManager<AppUser> UserManager { get; set; }
        [Inject] private ConfigService ConfigService { get; set; }
        [Inject] private ExpenseService ExpenseService { get; set; }
        [Inject] private PersonService PersonService { get; set; }

        private AppUser CurrentUser;
        private Config UserConfig;
        private List<Person> People;
        private List<Expense> Expenses;

        private decimal MonthlyIncome;
        private decimal MonthlyExpenditure;
        private decimal MonthlyNet;

        private bool SpendingWarning = false;
        private string SpendingWarningCssClass => SpendingWarning ? "text-danger" : "text-success";

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);
            UserConfig = await ConfigService.GetUserConfigAsync(CurrentUser.Id);
            Expenses = await ExpenseService.GetAllExpensesAsync(CurrentUser.Id);
            People = await PersonService.GetPeopleAndSharedAsync(CurrentUser.Id);

            MonthlyIncome = FinanceService.GetTotalMonthlyIncome(People);
            MonthlyExpenditure = FinanceService.GetTotalMonthlyExpenditure(Expenses);
            MonthlyNet = MonthlyIncome - MonthlyExpenditure;


            if (MonthlyIncome <= MonthlyExpenditure)
            {
                SpendingWarning = true;
            }
        }
    }
}
