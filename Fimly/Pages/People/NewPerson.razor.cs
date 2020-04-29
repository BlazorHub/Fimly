using Blazored.Toast.Services;
using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Fimly.Pages.People
{
    [Authorize]
    public partial class NewPerson : ComponentBase
    {
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private UserManager<AppUser> UserManager { get; set; }
        [Inject] private ConfigService ConfigService { get; set; }
        [Inject] private PersonService PersonService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private IToastService ToastService { get; set; }

        protected AppUser CurrentUser;
        protected Config UserConfig;
        private Person Person;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);
            UserConfig = await ConfigService.GetUserConfigAsync(CurrentUser.Id);

            Person = new Person
            {
                UserId = CurrentUser.Id
            };
        }

        private async void HandleValidSubmitAsync()
        {
            await PersonService.CreatePersonAsync(Person);

            ToastService.ShowSuccess($"{ Person.Name } has been added successfully.", "Person Added");

            NavigationManager.NavigateTo("people");
        }
    }
}
