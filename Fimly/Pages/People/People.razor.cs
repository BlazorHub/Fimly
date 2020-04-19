using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Pages.People
{
    [Authorize]
    public partial class People : ComponentBase
    {
        [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] UserManager<AppUser> UserManager { get; set; }
        [Inject] ConfigService ConfigService { get; set; }
        [Inject] PersonService PersonService { get; set; }

        private AppUser CurrentUser;
        private Config UserConfig;
        private List<Person> PersonList;

        private string CardColSizeCssClass => PersonList.Count() > 1 ? "col-xl-6" : "col";

        private double AnimationDelay = 0.2;

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
