using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusinessVenture.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BusinessVenture.Repositories;
using Microsoft.AspNetCore.Http;
using System;

namespace BusinessVenture.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public HomeController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public IActionResult Index()
        {
            var userProfileId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userProfile = _userProfileRepository.GetById(userProfileId);
            return View(userProfile);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details()
        {
            var userProfileId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userProfile = _userProfileRepository.GetById(userProfileId);
            return View(userProfile);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Edit()
        {
            var userProfileId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userProfile = _userProfileRepository.GetById(userProfileId);


            UserProfile vm = new UserProfile()
            {
                UP = _userProfileRepository.GetById(userProfileId),
            };

            if (vm == null)
            {
                return NotFound();
            }


            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, UserProfile userProfile)
        {
            try
            {
                var userProfileId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _userProfileRepository.UpdateUserProfile(userProfile);

                return RedirectToAction("Details", "Home", new { id = userProfile.Id });
            }
            catch (Exception ex)
            {
                return View(userProfile);
            }
        }

    }
}
