namespace GameZone.Controllers
{
    using GameZone.Data;
    using GameZone.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Security.Claims;

    using static GameZone.Constants.ModelConstants;


    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext context;

        public GameController(GameZoneDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await context.Games
                .Where(g => g.IsDeleted == false)
                .Select(g => new GameInfoViewModel()
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleaseDateFormat),
                    Title = g.Title
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameViewModel();
            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            DateTime releasedOn;
            if (DateTime.TryParseExact(model.ReleasedOn, GameReleaseDateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out releasedOn) == false)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid date format");
                model.Genres = await GetGenres();

                return View(model);
            }

            Game game = new Game()
            {
                Description = model.Description,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                PublisherId = GetCurrentUserId() ?? string.Empty,
                ReleasedOn = releasedOn,
                Title = model.Title
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id && g.IsDeleted == false  )
                .AsNoTracking()
                .Select(g => new GameViewModel()
                {
                    Description = g.Description,
                    GenreId = g.GenreId,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleaseDateFormat),
                    Title = g.Title,
                })
                .FirstOrDefaultAsync();

            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameViewModel model, int id)
        {
            if (ModelState.IsValid == false)
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            DateTime releasedOn;
            if (DateTime.TryParseExact(model.ReleasedOn, GameReleaseDateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out releasedOn) == false)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid date format");
                model.Genres = await GetGenres();

                return View(model);
            }

            Game? entity = await context.Games.FindAsync(id);

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid entity Id");
            }

            string currUserId = GetCurrentUserId() ?? string.Empty;
            if(entity.PublisherId != currUserId)
            {
                RedirectToAction(nameof(All));
            }

            entity.Description = model.Description;
            entity.GenreId = model.GenreId;
            entity.ImageUrl = model.ImageUrl;
            entity.PublisherId = GetCurrentUserId() ?? string.Empty;   // or   = currUserId; or skip it as it is checked in the upper if()
            entity.ReleasedOn = releasedOn;
            entity.Title = model.Title;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));

        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            string currUserId = GetCurrentUserId() ?? string.Empty;

            var model = await context.Games
                .Where(g => g.IsDeleted == false)
                .Where(g => g.GamersGames.Any(gg => gg.GamerId == currUserId))
                .Select(g => new GameInfoViewModel()
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.Publisher.UserName ?? string.Empty,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleaseDateFormat),
                    Title = g.Title
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            Game? entity = await context.Games
                .Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid entity Id");
            }

            string currUserId = GetCurrentUserId() ?? string.Empty;

            if(entity.GamersGames.Any(gg => gg.GamerId == currUserId))
            {
                return RedirectToAction(nameof(All));
            }
             
            entity.GamersGames.Add(new GamerGame()
            {
                GameId = entity.Id,
                GamerId = currUserId
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            Game? entity = await context.Games
                .Where(g => g.Id == id)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync();

            if (entity == null || entity.IsDeleted)
            {
                throw new ArgumentException("Invalid entity Id");
            }

            string currUserId = GetCurrentUserId() ?? string.Empty;

            GamerGame? gamerGame = entity.GamersGames
                .FirstOrDefault(gg => gg.GamerId == currUserId);

            if (gamerGame != null)
            {
                entity.GamersGames.Remove(gamerGame);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id && g.IsDeleted == false)
                .AsNoTracking()
                .Select(g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    ImageUrl = g.ImageUrl,
                    Title = g.Title,
                    Description = g.Description,
                    Genre = g.Genre.Name, 
                    ReleasedOn = g.ReleasedOn.ToString(GameReleaseDateFormat),
                    Publisher = g.Publisher.UserName ?? string.Empty
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Games
                .Where(g => g.Id == id && g.IsDeleted == false)
                .AsNoTracking()
                .Select(g => new DeleteViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Publisher = g.Publisher.UserName ?? string.Empty
                })
                .FirstOrDefaultAsync();

            return View(model);  
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteViewModel model)
        {
            Game? game = await context.Games
                .Where(g => g.Id == model.Id)
                .Where(g => g.IsDeleted == false)
                .FirstOrDefaultAsync();

            if(game != null)
            {
                game.IsDeleted = true;             //   Soft Delete
                
                //  context.Games.Remove(game);    //   Hard Delete

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }


        //  ------------------

        private string? GetCurrentUserId()
        {
            // return User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }


        private async Task<List<Genre>> GetGenres()
        {
            return await context.Genres.ToListAsync();
        }

    }
}
