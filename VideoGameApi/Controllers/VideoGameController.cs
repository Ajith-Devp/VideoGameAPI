using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame
            {
                Id = 1,
                Title = "Spider-Man 2",
                Platform = "PS-5",
                Developer =  "Sony Games",
                Publisher = "Sony Interactive Entertainment"
            },
            new VideoGame
            {
                Id = 2,
                Title = "Elden Ring",
                Platform = "Multi-platform",
                Developer = "FromSoftware",
                Publisher = "Bandai Namco"
            },
             new VideoGame
             {
                Id = 3,
                Title = "The Legend of Zelda: Tears of the Kingdom",
                Platform = "Nintendo Switch",
                Developer = "Nintendo EPD",
                Publisher = "Nintendo"
             },
             new VideoGame
             {
                Id = 4,
                    Title = "Halo Infinite",
                    Platform = "Xbox Series X",
                    Developer = "343 Industries",
                    Publisher = "Xbox Game Studios"
            },
            new VideoGame
            {
                Id = 5,
                Title = "Baldur's Gate 3",
                Platform = "PC",
                Developer = "Larian Studios",
                Publisher = "Larian Studios"
            }
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames); //Response 200 Ok
        }

        [HttpGet]
        [Route("{Id}")]
        public ActionResult<List<VideoGame>>GetVideoGamesId(int Id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == Id);
            if (game is null)
                return NotFound(); //Response 404 Not Found

            return Ok(game);

        }

        [HttpPost]
        public ActionResult<List<VideoGame>>AddVideoGame(VideoGame newgame)
        {
            if (newgame is null)
                return BadRequest();

           newgame.Id = videoGames.Max(g => g.Id) + 1;
           videoGames.Add(newgame);

            return CreatedAtAction(nameof(GetVideoGamesId), new { Id = newgame.Id }, newgame);
            //Status code 201 Created response
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateGame(int id, VideoGame updatedGame)
        {
           var game = videoGames.FirstOrDefault(g => id == g.Id);
           if (game is null)
                return NotFound();

            game.Title = updatedGame.Title;
            game.Publisher = updatedGame.Publisher;
            game.Developer = updatedGame.Developer;
            game.Platform = updatedGame.Platform;

            return NoContent();  
        }

        [HttpDelete("{Id}")]

        public IActionResult DeleteVideoGame(int Id)
        {
            var game = videoGames.FirstOrDefault(g => Id == g.Id);
            if (game is null)
                return NotFound();

            videoGames.Remove(game);
            return NoContent();
        }
    }

}
