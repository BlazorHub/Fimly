using Blazored.Toast.Services;
using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fimly.Components.PersonComponents
{
    public partial class PersonCard : ComponentBase
    {
        [CascadingParameter] private List<Person> People { get; set; }
        [CascadingParameter] private Config UserConfig { get; set; }

        [Parameter]
        public Person Person { get; set; }

        [Parameter]
        public Action StateChanged { get; set; }

        [Inject] private PersonService PersonService { get; set; }
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private IJSRuntime Js { get; set; }

        private Person PersonToUpdate;

        private bool IsEditing = false;
        private string EditButtonCssClass => IsEditing ? "text-danger" : string.Empty;

        private decimal WeeklyIncome => FinanceService.GetApproxWeeklyIncome(Person.Income);
        private decimal YearlyIncome => FinanceService.GetApproxYearlyIncome(Person.Income);

        private void OnEditClick()
        {
            if (IsEditing)
            {
                IsEditing = false;
            }
            else
            {
                IsEditing = true;

                PersonToUpdate = Person;
            }
        }

        private async Task UpdatePersonAsync()
        {
            await PersonService.UpdatePersonAsync(PersonToUpdate);

            ToastService.ShowSuccess($"{ Person.Name } has been updated successfully.", "Person Updated");

            IsEditing = false;
            StateChanged?.Invoke();
        }

        private async Task DeletePersonAsync(Person person)
        {
            if (await Js.InvokeAsync<bool>("confirm",
                "Are you sure you want to delete this person? " +
                "This will also remove all of their expenses and also any shared expenses on this account. " +
                "This action cannot be undone."))
            {
                await PersonService.DeletePersonAsync(person.Id);

                ToastService.ShowSuccess("A person and all of their expenses have been sucessfully deleted.", "Person Deleted");

                StateChanged?.Invoke();
            }
        }
    }
}
