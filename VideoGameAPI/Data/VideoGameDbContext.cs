using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameAPI.Models;

namespace VideoGameAPI.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        public DbSet<VideoGameDetails> VideoGamesDetails => Set<VideoGameDetails>();

        // ------------------------------------------------//
        // Publisher, Developer, Genre and GenreVideoGame  //
        // are not included but it still works             // 
        // ------------------------------------------------//

        // ============================
        // Joining table GenreVideoGame
        // ============================

        //   SQL:
        //   SELECT
        //   GenreVideoGame.VideoGamesId,
        //   VideoGames.Title,
        //   GenreVideoGame.GenreId,
        //   Genre.Name AS NameGenre
        //   FROM GenreVideoGame
        //   INNER JOIN Genre ON Genre.Id = GenreVideoGame.GenreId
        //   INNER JOIN VideoGames ON VideoGames.Id = GenreVideoGame.VideoGamesId
        //   ORDER BY
        //   GenreVideoGame.VideoGamesId,
        //   GenreVideoGame.GenreId

        // Result:
        // x------------x------------x---------x-----------x
        // VideoGamesId | Title      | GenreId | NameGenre |
        // x------------x------------x---------x-----------x
        // x    1       | Spider-Man |   1	   | Action    |
        // x    1	    | Spider-Man |   2	   | Fantasy   |
        // x------------x------------x---------x-----------x

        // LINQ:
        //[HttpGet]
        //public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        //{
        //    return Ok(await _context.VideoGames
        //        .Include(g => g.VideoGameDetails)
        //        .Include(g => g.Publisher)
        //        .Include(g => g.Developer)
        //        .Include(g => g.Genre)
        //        .ToListAsync());
        //}

        // Result:
        //{

        //  -- the VideoGame
        //  "id": 1,
        //  "title": "Spider-Man 2",
        //  "platform": "PS5",
        //  "developerId": 1,

        // -- One-to-Many, one of the videogames developed by Insomniac
        //  "developer": {
        //    "id": 1,
        //    "name": "Insomniac"
        //  },

        // -- One-to-Many, on of the videogames published by Sony
        //  "publisherId": 1,
        //  "publisher": {
        //    "id": 1,
        //    "name": "Sony"
        //  },

        //  -- One-to-one --, more in detail about the game in question
        //  "videoGameDetails": {
        //    "id": 1,
        //    "description": "Over een jochie dat superheld wordt na een spinnenbeet",
        //    "releaseDate": "1962-03-02T00:00:00",
        //    "videoGameId": 1
        //  },

        //  -- One-To-Many - Joining table GenreVideoGame -- the videogame falls in several genres
        //  "genre": [
        //    {
        //      "id": 1,
        //      "name": "Action"
        //    },
        //    {
        //      "id": 2,
        //      "name": "Fantasy"
        //    }
        //  ]
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adds seed data to this entity type. It is used to generate data motion migrations.
            modelBuilder.Entity<VideoGame>().HasData(
            new VideoGame
            {
                Id = 1,
                Title = "Spider-Man 2",
                Platform = "PS5"
                //Developer = "Insomniac Games",
                //Publisher = "Sony Interactive Entertainment"
            },
            new VideoGame
            {
                Id = 2,
                Title = "The Legend of Zelda: Breath of the Wild",
                Platform = "Nintendo Switch"
                //Developer = "Nintendo EPO",
                //Publisher = "Nintendo"
            },
            new VideoGame
            {
                Id = 3,
                Title = "Cyberpunk 2077",
                Platform = "PC"
                //Developer = "CD Projekt Red",
                //Publisher = "CD Projekt"
            });
        }
    }
}
