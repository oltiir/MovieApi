namespace MovieApi.Dtos
{
    public class UpdateMovie
    {
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
    }
}