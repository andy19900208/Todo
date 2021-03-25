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
        private static int IdCount = 5;
        private static List<Task> data = new List<Task>() { 
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

        public ActionResult Index()
        {
            TodoIndexViewModel vm = new TodoIndexViewModel() {
                Tasks = data
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetState(int id, bool[] state)
        {
            if (data.Any(a => a.Id == id))
            {
                data.First(f => f.Id == id).IsDone = state.Any();
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (data.Any(a => a.Id == id))
            {
                data.Remove(data.First(f => f.Id == id));
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                data.Add(new Task() { 
                    Id = IdCount++,
                    Content = content,
                    IsDone = false
                });
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            try
            {
                return View(new EditViewModel() { task = data.First(f => f.Id == id)});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string content)
        {
            try
            {
                data.First(f => f.Id == id).Content = content;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
