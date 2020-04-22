using Fimly.Data.Models;
using Fimly.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fimly.Components.ExpenseComponents
{
    public partial class ExpenseCard : ComponentBase
    {
        [CascadingParameter] Config UserConfig { get; set; }
        [CascadingParameter] List<ExpenseType> ExpenseTypes { get; set; }

        [Parameter]
        public List<Expense> SharedExpenses { get; set; }

        [Parameter]
        public Person Person { get; set; }

        [Parameter]
        public Action StateChanged { get; set; }
    }
}
