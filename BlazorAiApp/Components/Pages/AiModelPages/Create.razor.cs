using BlazorAiApp.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorAiApp.Components.Pages.AiModelPages
{
    public partial class Create
    {
      


        [SupplyParameterFromForm]
        public AiModel _aiModel { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task AddAiModel()
        {
            _aiModel.ChatHistory = ["someting"];
            _aiModel.ChatHistory_List= new List<string>();

            



            await SaveToDb();
        }
        private async Task SaveToDb()
        {
            DB.AiModel.Add(_aiModel);
            await DB.SaveChangesAsync();
            NavigationManager.NavigateTo("/aimodels");
        }
    }

}