using BlazorAiApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorAiApp.Components.Pages.AiModelPages
{
    public partial class Details
    {
        AiModel? aimodel;

        [SupplyParameterFromQuery]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            aimodel = await DB.AiModel.FirstOrDefaultAsync(m => m.Id == Id);

            if (aimodel is null)
            {
                NavigationManager.NavigateTo("notfound");
            }
        }
    }
}