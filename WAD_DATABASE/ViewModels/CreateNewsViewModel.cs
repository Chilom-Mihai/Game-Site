namespace WAD_DATABASE.ViewModels
{
    public class CreateNewsViewModel
    {
        public int Id { get; set; }
        public string? NewsName { get; set; }

        public string? Description { get; set; }
        public IFormFile Image { get; set; }

        public string? AppUserId { get; set; }
    }
}