namespace VideoGameAPI.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Platform { get; set; }

        // public string? Developer { get; set; }
        // A Developer is unique but develops several VideoGames
        // One-to-many-relationship with a Developer
        // Foreign Key <=> primary key Developer.Id
        public int? DeveloperId { get; set; }
        // Navigation property:
        public Developer? Developer { get; set; }

        // public string? Publisher { get; set; }
        // A Publisher is unique but publishes several VideoGames
        // One-to-many-relationship with a Publisher
        // Foreign Key <=> primary key Publisher.Id
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }   

        // Navigation property
        // One-to-one-relationship with VideoGameDetails
        public VideoGameDetails? VideoGameDetails { get; set; }

        // Many-to-many
        // Several Videogames can have several Genres
        public List<Genre>? Genre { get; set; }

    }
}
