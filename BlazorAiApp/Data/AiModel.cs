using System.ComponentModel.DataAnnotations;

namespace BlazorAiApp.Data
{
    public class AiModel
    {
        public int Id { get; set; }
  
        public string Name { get; set; }
        [Required]
        public string ModelRepo { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string[] ChatHistory { get; set; }
        public List<string> ChatHistory_List { get; set; }
        public DateTime CreateDate { get; set; }
        public int Number { get; set; }

    }
}
