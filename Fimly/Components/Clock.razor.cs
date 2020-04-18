using Microsoft.AspNetCore.Components;
using System;

namespace Fimly.Components
{
    public partial class Clock : ComponentBase
    {
        private string Time { get; set; }

        protected override void OnInitialized()
        {
            var timer = new System.Threading.Timer((_) =>
            {
                Time = DateTime.UtcNow.ToLocalTime().ToString("g");
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }, null, 0, 1000);

            base.OnInitialized();
        }
    }
}
