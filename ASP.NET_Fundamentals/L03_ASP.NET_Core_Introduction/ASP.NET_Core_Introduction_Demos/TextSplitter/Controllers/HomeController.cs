namespace TextSplitter.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TextSplitter.ViewModels;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(TextSplitViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Split(TextSplitViewModel textViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index", textViewModel);
                
            }

            string[] words = textViewModel.Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string splitText = String.Join(Environment.NewLine, words);
            textViewModel.SplitText = splitText;

            return this.RedirectToAction("Index", textViewModel);
        }

       
    }
}  