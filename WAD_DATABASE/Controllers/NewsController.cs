using Microsoft.AspNetCore.Mvc;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Controllers
{
    public class NewsController : Controller
    {

        private readonly INewsRepository _newsRepository;
        private readonly IPhotoService _photoService;
    
        public NewsController(INewsRepository newsRepository, IPhotoService photoService)
        {

            _newsRepository = newsRepository;
            _photoService = photoService;
           
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<News> News = await _newsRepository.GetAll();
            return View(News);
        }

        public IActionResult Create()
        {
            var CreateNewsViewModel = new CreateNewsViewModel();
            return View(CreateNewsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsViewModel NewsVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(NewsVM.Image);
                var News = new News
                {
                    NewsName = NewsVM.NewsName,
                    Description = NewsVM.Description,
                    Image = result.Url.ToString(),
                    AppUserId = NewsVM.AppUserId
                };
                _newsRepository.Add(News);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed!");
            }
            return View(NewsVM);

        }


        public async Task<IActionResult> Edit(int id)
        {
            var News = await _newsRepository.GetByIdAsync(id);
            if (News == null) return View("Error");
            var NewsVM = new EditNewsViewModel
            {
                NewsName = News.NewsName,
                Description = News.Description,
                URL = News.Image

            };
            return View(NewsVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditNewsViewModel NewsVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit News");
                return View("Edit", NewsVM);
            }

            var userNews = await _newsRepository.GetByIdAsyncNoTracking(id);

            if (userNews == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(NewsVM.Image);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(NewsVM);
            }

            if (!string.IsNullOrEmpty(userNews.Image))
            {
                _ = _photoService.DeletePhotoAsync(userNews.Image);
            }

            var News = new News
            {
                Id = id,
                NewsName = NewsVM.NewsName,
                Description = NewsVM.Description,
                Image = photoResult.Url.ToString()
            };

            _newsRepository.Update(News);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Detail = await _newsRepository.GetByIdAsync(id);
            if (Detail == null) return View("Error");
            return View(Detail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var NewsDetails = await _newsRepository.GetByIdAsync(id);

            if (NewsDetails == null)
            {
                return View("Error");
            }

            _newsRepository.Delete(NewsDetails);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            News News = await _newsRepository.GetByIdAsync(id);
            return View(News);
        }
    }
}