using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fimly.Pages
{
    [Authorize]
    public partial class People : ComponentBase
    {
        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] UserManager<AppUser> UserManager { get; set; }
        [Inject] ConfigService ConfigService { get; set; }
        [Inject] PersonService PersonService { get; set; }

        protected AppUser CurrentUser;
        protected Config UserConfig;
        protected List<Person> PersonList;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);
            UserConfig = await ConfigService.GetUserConfigAsync(CurrentUser.Id);
            PersonList = await PersonService.GetPeopleAsync(CurrentUser.Id);
        }

        protected async void StateChanged()
        {
            PersonList = await PersonService.GetPeopleAsync(CurrentUser.Id);
            StateHasChanged();
        }
    }
}
