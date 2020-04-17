using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Components.PersonComponents
{
    public partial class PersonCard : ComponentBase
    {
        [CascadingParameter] List<Person> People { get; set; }
        [CascadingParameter] Config UserConfig { get; set; }

        [Parameter]
        public Person Person { get; set; }

        [Parameter]
        public Action StateChanged { get; set; }

        [Inject] PersonService PersonService { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] IModalService Modal { get; set; }

        private Person PersonToUpdate;

        private bool IsEditing = false;
        private string EditButtonCssClass => IsEditing ? "text-danger" : string.Empty;
        private string CardColSizeCssClass => People.Count() > 1 ? "col-sm-6" : "col";

        void OnEditClick()
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

        async Task UpdatePersonAsync()
        {
            await PersonService.UpdatePersonAsync(PersonToUpdate);

            ToastService.ShowSuccess($"{ Person.Name } has been updated successfully.", "Person Updated");

            IsEditing = false;
            StateChanged?.Invoke();
        }

        async void DeletePerson(Person person)
        {

        }
    }
}
