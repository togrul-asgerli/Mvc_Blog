using MyBLog.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBLog.Controllers
{
    public class HomeController : Controller
    {
        testEntities1 db=new testEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult List()
        {
            var model = db.ToDoLists.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Insert(ToDoList ord)
        {
            if (ord.id == 0)
            {
                db.ToDoLists.Add(ord);
            }
            else
            {
                var updateData = db.ToDoLists.Find(ord.id);
                if (updateData == null)
                {
                    return HttpNotFound();
                }
                updateData.list = ord.list;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Update(int id)
        {
            var model = db.ToDoLists.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Insert", model);
        }
        public ActionResult Delete(int id)
        {
            var deleteOrder = db.ToDoLists.Find(id);
            if (deleteOrder == null)
            {
                return HttpNotFound();
            }
            db.ToDoLists.Remove(deleteOrder);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}