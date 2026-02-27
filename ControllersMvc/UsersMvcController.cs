using BookReviewApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace BookReviewApp.ControllersMvc;

public class UsersMvcController: Controller
{
    private readonly UserService _userService;

    public UsersMvcController(UserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllAsync();
        return View("UserList", users); // liefert IEnumerable<UserResponseDto> an die Razor View
    }

    // POST: /UsersMvc/Delete/5
    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _userService.DeleteAsync(id); // User löschen
        return RedirectToAction(nameof(Index)); // zurück zur User-Liste
    }

}
