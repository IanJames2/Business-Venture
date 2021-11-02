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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace BusinessVenture.Controllers
{
    public class ProductOrServiceController : Controller
    {
        private readonly IProductOrServiceRepository _productOrServiceRepo;
        private readonly IBusinessRepository _businessRepo;


        public ProductOrServiceController(
            IProductOrServiceRepository productOrServiceRepository,
            IBusinessRepository businessRepository)
        {
            _productOrServiceRepo = productOrServiceRepository;
            _businessRepo = businessRepository;
        }

        // GET: ProductOrServiceController
        public ActionResult Index()
        {
            int userProfileId = GetCurrentUserId();

            List<ProductOrService> productsOrServices = _productOrServiceRepo.GetAllProductsOrServicesByUserProfileId(userProfileId);

            return View(productsOrServices);
        }

        // GET: ProductOrServiceController/Details/5
        public ActionResult Details(int id)
        {
            ProductOrService productOrService = _productOrServiceRepo.GetProductOrServiceById(id);

            if (productOrService == null)
            {
                return NotFound();
            }
            return View(productOrService);
        }

        // GET: ProductOrServiceController/Create
        public ActionResult Create()
        {
            int userProfileId = GetCurrentUserId();
            List<Business> business = _businessRepo.GetAllBusinessesByUserProfileId(userProfileId);

            ProductOrServiceFormViewModel vm = new ProductOrServiceFormViewModel()
            {
                ProductOrService = new ProductOrService(),
                Businesses = business
            };

            return View(vm);
        }

        // POST: ProductOrServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ProductOrService productOrService, Business business)
        {
            try
            {
                business.UserProfileId = GetCurrentUserId();

                _productOrServiceRepo.AddProductOrService(productOrService);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(productOrService);
            }
        }

        // GET: ProductOrServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            int userProfileId = GetCurrentUserId();
            List<Business> business = _businessRepo.GetAllBusinessesByUserProfileId(userProfileId);

            ProductOrServiceFormViewModel vm = new ProductOrServiceFormViewModel()
            {
                ProductOrService = _productOrServiceRepo.GetProductOrServiceById(id),
                Businesses = business
            };

            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // POST: ProductOrServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, ProductOrService productOrService, Business business)
        {
            try
            {
                business.UserProfileId = GetCurrentUserId();

                _productOrServiceRepo.UpdateProductOrService(productOrService);

                return RedirectToAction("Details", "ProductOrService", new { id = productOrService.Id });
            }
            catch (Exception ex)
            {
                return View(productOrService);
            }
        }

        // GET: ProductOrServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductOrService productOrService = _productOrServiceRepo.GetProductOrServiceById(id);

            return View(productOrService);
        }

        // POST: ProductOrServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductOrService productOrService)
        {
            try
            {
                _productOrServiceRepo.DeleteProductOrService(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(productOrService);
            }
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

    }
}
