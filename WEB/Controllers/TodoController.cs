using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;


using WEB.Models;
using WEB.ViewModels;
using WEB.Service;
using WEB.DAL;

namespace WEB.Controllers
{
    public class TodoController : Controller
    {
        readonly TodoService service;

        public TodoController(ITaskRepository repo)
        {
            service = new TodoService(repo);
        }

        public ActionResult Index()
        {
            TodoIndexViewModel vm = new TodoIndexViewModel() {
                Tasks = service.GetAll()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetState(int id, bool[] state)
        {
            service.SetState(id, state.Any());

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            service.Delete(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string content)
        {
            service.Create(content);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            try
            {
                return View(new EditViewModel() { task = service.Get(id) });
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
                service.Edit(id, content);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
