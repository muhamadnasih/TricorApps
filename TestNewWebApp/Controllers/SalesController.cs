using BusinessLayer.Interface;
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


        public async Task<IActionResult> Edit(int Id)
        {
            // to get current user info
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var result = await _data.GetSpecificSales(user.Id, Id);
            return PartialView("_EditSalesPartial", result);
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
