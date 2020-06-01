using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TerugbelnotitiesApp.Models;
using TerugbelnotitiesApp.Repositories;

namespace TerugbelnotitiesApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly INotesRepo repo;

        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger, INotesRepo repo, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.repo = repo;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            NotitiesViewModel model = new NotitiesViewModel();
            model.notes = await repo.getNotes();
            return View(model);
        }

        public IActionResult Add()
        {
            NotitieViewModel model = new NotitieViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(NotitieViewModel model)
        {
            model.AssigningUserName = userManager.GetUserName(HttpContext.User);
            model.AssigningUserId = userManager.GetUserId(HttpContext.User);
            //model.Id = 239;
            model.AssignedUserId = userManager.GetUserId(HttpContext.User); //userManager.GetUserId(userManager.FindByNameAsync(model.AssignedUserName));
            model.Timestamp = DateTime.Now;
            model.Processed = false;

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            repo.addNote(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            repo.deleteNote(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(NotitiesViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            repo.editNote(id, model.editedNote);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditProcessed(NotitiesViewModel model, int id)
        {
            Debug.WriteLine(model.editedProcessed);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            repo.editNoteProcessed(id, model.editedProcessed);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
