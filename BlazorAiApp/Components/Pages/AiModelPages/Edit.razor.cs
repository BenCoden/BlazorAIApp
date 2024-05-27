using BlazorAiApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorAiApp.Components.Pages.AiModelPages
{
    public partial class Edit
    {
        [SupplyParameterFromQuery]
        public int Id { get; set; }

        [SupplyParameterFromForm]
        public AiModel? AiModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AiModel ??= await DB.AiModel.FirstOrDefaultAsync(m => m.Id == Id);

            if (AiModel is null)
            {
                NavigationManager.NavigateTo("notfound");
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task UpdateAiModel()
        {
            DB.Attach(AiModel!).State = EntityState.Modified;

            try
            {
                await DB.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AiModelExists(AiModel!.Id))
                {
                    NavigationManager.NavigateTo("notfound");
                }
                else
                {
                    throw;
                }
            }

            NavigationManager.NavigateTo("/aimodels");
        }

        bool AiModelExists(int id)
        {
            return DB.AiModel.Any(e => e.Id == id);
        }
    }
}