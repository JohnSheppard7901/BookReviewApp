using BookReviewApp.Dtos.UserDtos;
using BookReviewApp.Services;
using Microsoft.AspNetCore.Mvc;
namespace BookReviewApp.ControllersMvc;

public class UsersMvcController: Controller
{
    private readonly IUserService _userService;

    public UsersMvcController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAllAsync();
        return View("UserList", users); // liefert IEnumerable<UserResponseDto> an die Razor View
    }


    [HttpPost, ActionName("UpdateUser")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateUser(Guid id, UserUpdateDto dto)
    {
        if(!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        var result = await _userService.UpdateAsync(id, dto);

        if(result == null)
            return NotFound();

        return RedirectToAction(nameof(Index));
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
