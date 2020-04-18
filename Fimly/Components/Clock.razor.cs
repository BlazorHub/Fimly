using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Fimly.Components
{
    public partial class Clock : ComponentBase
    {
        private string Time { get; set; }

        protected override void OnInitialized()
        {
            var timer = new System.Threading.Timer((_) =>
            {
                Time = DateTime.UtcNow.ToLocalTime().ToString();
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }, null, 0, 1000);
            base.OnInitialized();
        }
    }
}
