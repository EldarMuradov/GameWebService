using Game_Web_Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Game_Web_Service.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsersCollection _collection;

        public AccountController() 
        {
            _collection = new UsersCollection();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "All Users";
            List<User> info = (List<User>)_collection.GetUsers;
            
            return View(info);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Current user";
            User user = _collection.GetCurrentUser(id).Result;

            return View(user);
        }

    }
}
