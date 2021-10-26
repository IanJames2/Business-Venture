using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessVenture.Models;
using BusinessVenture.Repositories;
using System;
using System.Collections.Generic;
using BusinessVenture.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace BusinessVenture.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IBusinessRepository _businessRepo;
        private readonly IBusinessTypeRepository _businessTypeRepo;


        public BusinessController(
            IBusinessRepository businessRepository, 
            IBusinessTypeRepository businessTypeRepository)
        {
            _businessRepo = businessRepository;
            _businessTypeRepo = businessTypeRepository;
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
            Business business = _businessRepo.GetBusinessById(id);

            if (business == null)
            {
                return NotFound();
            }
            return View(business);
        }

        // GET: BusinessController/Create
        public ActionResult Create()
        {
            List<BusinessType> businessTypes = _businessTypeRepo.GetAll();

            BusinessFormViewModel vm = new BusinessFormViewModel()
            {
                Business = new Business(),
                BusinessTypes = businessTypes
            };

            return View(vm);
        }

        // POST: BusinessController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Business business)
        {
            try
            {
                business.UserProfileId = GetCurrentUserId();

                _businessRepo.AddBusiness(business);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(business);
            }
        }

        // GET: BusinessController/Edit/5
        public ActionResult Edit(int id)
        {
            List<BusinessType> businessTypes = _businessTypeRepo.GetAll();

            BusinessFormViewModel vm = new BusinessFormViewModel()
            {
                Business = _businessRepo.GetBusinessById(id),
                BusinessTypes = businessTypes
            };

            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // POST: BusinessController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, Business business)
        {
            try
            {
                business.UserProfileId = GetCurrentUserId();

                _businessRepo.UpdateBusiness(business);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(business);
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
