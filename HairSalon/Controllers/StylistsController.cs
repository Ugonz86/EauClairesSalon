using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private readonly HairSalonContext _db;
        public StylistsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index(string SearchStylist)
        {
            List<Stylist> model = _db.Stylists.ToList();
            if(SearchStylist!=null){
                model = _db.Stylists.Where(stylist => stylist.StylistName.Contains(SearchStylist)).ToList();
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist newStylist)
        {
            _db.Stylists.Add(newStylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            var stylistClients = _db.Clients.Where(clients => clients.StylistId == id).ToList();
            model.Add("stylist", thisStylist);
            model.Add("clients", stylistClients);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
        var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        return View(thisStylist);
        }

        [HttpPost]
        public ActionResult Edit(Stylist stylist)
        {
        _db.Entry(stylist).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
        var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        return View(thisStylist);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
        var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
        var stylistClients = _db.Clients.Where(clients => clients.StylistId == id).ToList();
        foreach(var client in stylistClients) {
            _db.Clients.Remove(client);
        }
        _db.Stylists.Remove(thisStylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
        var allStylists = _db.Stylists.ToList();
        return View();
        }

        [HttpPost, ActionName("DeleteAll")]
        public ActionResult DeleteAllConfirmed()
        {
        var allClients = _db.Clients.ToList();
        var allStylists = _db.Stylists.ToList();

        foreach (var client in allClients)
        {
        _db.Clients.Remove(client);
        }

        foreach (var stylist in allStylists)
        {
        _db.Stylists.Remove(stylist);
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
    }
}