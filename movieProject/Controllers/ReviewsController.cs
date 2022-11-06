using Microsoft.AspNetCore.Mvc;
using movieProject.Models.Movie;
using movieProject.Models.Reviews;

namespace movieProject.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewsRepository repo;
        public ReviewsController(IReviewsRepository repo)
        {
            this.repo = repo;
        }





        public IActionResult Index()
        {
            return View();
        }
    }
}
