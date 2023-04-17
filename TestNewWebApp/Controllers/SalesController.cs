using BusinessLayer.Interface;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;
using System;
using TestNewWebApp.Models;

namespace TestNewWebApp.Controllers
{
   [Authorize]
    public class SalesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISalesProcessor _data;
        public SalesController(UserManager<IdentityUser> userManager, ISalesProcessor data)
        {
            _userManager = userManager;
            this._data = data;
        }
        public IActionResult Dashboard()
        {

            return View();

        }

        public async Task<IActionResult> SalesData(int year, int month)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
           

                var result = await _data.GetMonthlySalesReport(month, year);
                return Json(result);

       

        }

        public async Task<IActionResult> GetSales()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                var result = await _data.GetAllSales(user.Id);

                return Json(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IActionResult> ViewSales()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            try
            {
                var result = await _data.GetAllSales(user.Id);
               
                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
                
        }

        public IActionResult CreateSales()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSales(SalesViewModel model)
        {
            // to get current user info
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var result = await _data.CreateSales(model.SalesItem,DateTime.Now,user.Id,model.Amount,DateTime.Now);

                return RedirectToAction("ViewSales");
            }

            return View();
            
        }


        public async Task<IActionResult> EditSalesPartial(int Id)
        {
            // to get current user info
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var result = await _data.GetSpecificSales(user.Id, Id);
            SalesViewModel model = new SalesViewModel();
            model.SalesId = result.Id;
            model.SalesItem = result.SalesItem;
            model.Amount = result.Amount; 
            model.SalesDate = result.SalesDate;
            return PartialView("_EditSalesPartial", model);
        }
        [HttpPost]
        public async Task<IActionResult> EditSales(SalesViewModel model)
        {
            try
            {
                // to get current user info
                var user = await _userManager.GetUserAsync(HttpContext.User);

               var result = await _data.UpdateSales(model.SalesId, model.SalesItem, user.Id, model.Amount, DateTime.Now);

                return Json(new { result });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            await _data.DeleteSales(user.Id, id);


            return Json(new { success = true });
        }




    }
}
