using System.Text.Json.Serialization;

namespace VideoGameAPI.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Many-to-many
        // Several Videogames can have several Genres
        // To prevent circular reference - VideoGame is already shown
        [JsonIgnore]
        public List<VideoGame>? VideoGames { get; set; }
    }
}
