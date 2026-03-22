namespace VideoGameAPI.Models
{
    public class VideoGameDetails
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        // Foreign Key: VideoGameDetails.VideoGameId  <=> Primary Key: VideoGame.Id
        public int VideoGameId { get; set; }

    }
}
