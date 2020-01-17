using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;

        public ClientsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Client> model = _db.Clients.Include(clients => clients.Stylist).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.StylistList = new SelectList(_db.Stylists, "StylistId", "StylistName");

            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Client newClient)
        {
            _db.Clients.Add(newClient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}