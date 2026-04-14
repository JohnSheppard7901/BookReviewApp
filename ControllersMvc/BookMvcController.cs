using BookReviewApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.ControllersMvc
{
    public class BookMvcController : Controller
    {
        private readonly IBookService _bookService;

        public BookMvcController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View("BookOverview", books);
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var book = await _bookService.GetAsync(id);
            return View("BookDetails", book);
        }

    }
}
