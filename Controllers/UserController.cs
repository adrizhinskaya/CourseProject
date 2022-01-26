using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Identity;
using Project.Models.ViewModels;
using Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        private ApplicationContext db;

        public UserController (ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult Personal()
        {
            return View();
        }

        //public IActionResult Create() => View();

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateCollectionViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserCollection collection = new UserCollection { Name = model.Name, Theme = model.Theme, ShortDescription = model.ShortDescription };

        //    }
        //}
    }
}
