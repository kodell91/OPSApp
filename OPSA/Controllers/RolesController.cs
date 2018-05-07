using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using OPSA.Models;

namespace OPSA.Controllers
{
    public class RolesController : Controller
    {

        OPSAEntities db;

        public RolesController()
        {
            db = new OPSAEntities();
        }
        // Getting all roles and putting them in an object
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var Roles = db.Roles.ToList();
            return View(Roles);
        }

        //Create a New Role
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        //Create a New Role
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            db.Roles.Add(Role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}