
namespace WAD_DATABASE.ViewModels
{
    public class EditGamesViewModel
    {
        public int Id { get; set; }
        public string? GamesName { get; set; }
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
    }
}

   