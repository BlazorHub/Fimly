using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Fimly.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] private UserManager<AppUser> UserManager { get; set; }
        [Inject] private PersonService PersonService { get; set; }

        private AppUser CurrentUser;
        private int peopleCount;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            CurrentUser = await UserManager.GetUserAsync(user);

            if (CurrentUser != null)
            {
                peopleCount = PersonService.GetPeopleCount(CurrentUser.Id);
            }
        }
    }
}
