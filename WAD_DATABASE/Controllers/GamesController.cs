using Microsoft.AspNetCore.Mvc;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Controllers
{
    public class GamesController : Controller
    {
        
        private readonly IGamesRepository _gamesRepository;
        private readonly IPhotoService _photoService;
        

        public GamesController(IGamesRepository gamesRepository, IPhotoService photoService)
        {

            _gamesRepository = gamesRepository;
            _photoService = photoService;//
            
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Games> Games = await _gamesRepository.GetAll();
            return View(Games);
        }

        public IActionResult Create()
        {
            var CreateGamesViewModel = new CreateGamesViewModel();
            return View(CreateGamesViewModel);

        }
            
        [HttpPost]
        public async Task<IActionResult> Create(CreateGamesViewModel GamesVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(GamesVM.Image);
                var Games = new Games
                {
                    GamesName = GamesVM.GamesName,
                    Description = GamesVM.Description,
                    Image = result.Url.ToString(),
                    AppUserId = GamesVM.AppUserId,
                };
                TempData["success"] = "Game created succesfuly";
                _gamesRepository.Add(Games);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed!");
            }
            return View(GamesVM);

           
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var Games = await _gamesRepository.GetByIdAsync(id);
            if (Games == null) return View("Error");
            var GamesVM = new EditGamesViewModel
            {
                GamesName = Games.GamesName,
                Description = Games.Description,
                URL = Games.Image,
                

            };
            return View(GamesVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditGamesViewModel GamesVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit game");
                return View("Edit", GamesVM);
            }

            var userGame = await _gamesRepository.GetByIdAsyncNoTracking(id);

            if (userGame == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(GamesVM.Image);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(GamesVM);
            }

            if (!string.IsNullOrEmpty(userGame.Image))
            {
                _ = _photoService.DeletePhotoAsync(userGame.Image);
            }

            var Games = new Games
            {
                Id = id,
                GamesName = GamesVM.GamesName,
                Description = GamesVM.Description,
                Image = photoResult.Url.ToString(),
            };

            _gamesRepository.Update(Games);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Detail = await _gamesRepository.GetByIdAsync(id);
            if (Detail == null) return View("Error");
            return View(Detail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteGames(int id)
        {
            var GamesDetails = await _gamesRepository.GetByIdAsync(id);

            if (GamesDetails == null)
            {
                return View("Error");
            }
            TempData["success"] = "Game deleted succesfuly";

            _gamesRepository.Delete(GamesDetails);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Games Games = await _gamesRepository.GetByIdAsync(id);
            return Games == null ? NotFound() : View(Games);
            
        }

        public async Task<IActionResult> Play(int id)
        {
            Games Games = await _gamesRepository.GetByIdAsync(id);
            return Games == null ? NotFound() : View(Games);

        }
    }
}