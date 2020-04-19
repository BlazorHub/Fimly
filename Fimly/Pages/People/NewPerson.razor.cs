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
        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] UserManager<AppUser> UserManager { get; set; }
        [Inject] ConfigService ConfigService { get; set; }
        [Inject] PersonService PersonService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IToastService ToastService { get; set; }

        protected AppUser CurrentUser;
        protected Config UserConfig;

        Person Person = new Person();

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);
            UserConfig = await ConfigService.GetUserConfigAsync(CurrentUser.Id);
        }

        private async void HandleValidSubmitAsync()
        {
            Person.UserId = CurrentUser.Id;

            await PersonService.CreatePersonAsync(Person);

            ToastService.ShowSuccess($"{ Person.Name } has been added successfully.", "Person Added");

            NavigationManager.NavigateTo("people");
        }
    }
}
