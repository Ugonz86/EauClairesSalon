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

        public ActionResult Details(int id)
        {
        Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
        return View(thisClient);
        }

        public ActionResult Edit(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName");
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

         public ActionResult Delete(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            return View(thisClient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
            _db.Clients.Remove(thisClient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            var allClients = _db.Clients.ToList();
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
            public ActionResult DeleteAllConfirmed()
        {
            var allClients = _db.Clients.ToList();

        foreach (var client in allClients)
        {
            _db.Clients.Remove(client);
        }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}