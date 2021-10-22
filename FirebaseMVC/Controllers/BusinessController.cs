using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessVenture.Models;
using BusinessVenture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BusinessVenture.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IBusinessRepository _businessRepo;

        public BusinessController(IBusinessRepository businessRepository)
        {
            _businessRepo = businessRepository;
        }

        // GET: BusinessController
        public ActionResult Index()
        {
            int userProfileId = GetCurrentUserId();

            List<Business> businesses = _businessRepo.GetAllBusinessesByUserProfileId(userProfileId);

            return View(businesses);
        }

        // GET: BusinessController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusinessController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
