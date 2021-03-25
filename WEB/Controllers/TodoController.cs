using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;


using WEB.Models;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class TodoController : Controller
    {
        private List<Task> data = new List<Task>() { 
            new Task() { 
                Id = 1,
                Content = "Init",
                IsDone = true
            },

            new Task() {
                Id = 2,
                Content = "Easy Sample",
                IsDone = false
            },

            new Task() {
                Id = 3,
                Content = "DataAccess",
                IsDone = false
            },

            new Task() {
                Id = 4,
                Content = "Unit Test",
                IsDone = false
            },

        };

        // GET: TodoController
        public ActionResult Index()
        {
            TodoIndexViewModel vm = new TodoIndexViewModel() {
                Tasks = data
            };

            return View(vm);
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
