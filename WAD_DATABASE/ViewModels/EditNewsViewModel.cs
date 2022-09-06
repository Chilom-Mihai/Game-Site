
namespace WAD_DATABASE.ViewModels
{
    public class EditNewsViewModel
    {
        public int Id { get; set; }
        public string? NewsName { get; set; }
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
    }
}