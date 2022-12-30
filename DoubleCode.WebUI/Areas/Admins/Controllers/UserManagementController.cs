using DoubleCode.Application.Interfaces.IUserManagement;
using DoubleCode.Application.ViewModels.UserManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DoubleCode.WebUI.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _service;

        public UserManagementController(IUserManagementService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int pageId = 1, string FilterEmail = "", string FilterUserName = "")
        {

            return View(await _service.GetAllToShowAsync(pageId, FilterEmail, FilterUserName));

        }
        public async Task<IActionResult> Add()
        {
            return View("AddOrEdit", new UserManagementCreateOrEditViewModel());
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(UserManagementCreateOrEditViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View("AddOrEdit", user);
        }
        //GET
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _service.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _service.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("AddOrEdit", user);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserManagementCreateOrEditViewModel user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.EditAsync(user);
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View("AddOrEdit", user);
        }

        // GET
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _service.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


