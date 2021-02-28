using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELiquid.Data.Models;
using ELiquid.Data.Services;

namespace ELiquid.Web.Controllers
{
    public class ElecLiquidsController : Controller
    {
        private readonly IElecLiquidData db;

        public ElecLiquidsController(IElecLiquidData db)
        {
            this.db = db;
        }
        // GET: ElecLiquids
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string category, string search)
        {
            
            var model = db.GetAll();
            

            var selected = from e in model
                           select e;

            if (!String.IsNullOrEmpty(search))
            {

                selected = selected.Where(e => e.Name.ToUpper().Contains(search.ToUpper())
                                            || e.Category.ToString().ToUpper().Contains(search.ToUpper()));
            }

            //if (!String.IsNullOrEmpty(category))
            //{
            //    selected = selected.Where(e => e.Category.ToString().ToUpper() == category.ToUpper());
            //}
            //if (category == "All")
            //{
            //    selected = model;
            //}

            return View(selected);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ElecLiquid elecLiquid)
        {            
            if(ModelState.IsValid)
            {
                db.Add(elecLiquid);
                return RedirectToAction("Details", new { id = elecLiquid.Id});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
                //return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ElecLiquid elecLiquid)
        {
            if (ModelState.IsValid)
            {
                db.Update(elecLiquid);
                TempData["Message"] = $"You have successfully updated " + elecLiquid.Name +"!";
                return RedirectToAction("Details", new { id = elecLiquid.Id});
            }
            return View(elecLiquid);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
                //return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult Like(int id)
        {
            var elecLiquid = db.Get(id);
            elecLiquid.Like++;
            db.Update(elecLiquid);

            if (elecLiquid == null)
            {
                return View("NotFound");
                //return HttpNotFound();
            }
            return RedirectToAction("Index");
            //return View(model);
        }
        
        public ActionResult Dislike(int id)
        {
            var elecLiquid = db.Get(id);
            elecLiquid.Dislike++;
            db.Update(elecLiquid);

            if (elecLiquid == null)
            {
                return View("NotFound");
                //return HttpNotFound();
            }
            return RedirectToAction("Index");
            //return View(model);
        }
    }
}