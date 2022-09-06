namespace WAD_DATABASE.ViewModels
{
    public class CreateGamesViewModel
    {
        public int Id { get; set; }
        public string? GamesName { get; set; }

        public string? Description { get; set; }
        public IFormFile Image { get; set; }

        public string? AppUserId { get; set; }


    }
}
