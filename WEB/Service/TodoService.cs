using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using WEB.Models;
using WEB.DAL;

namespace WEB.Service
{
    public class TodoService
    {
        readonly ITaskRepository repo;

        public TodoService(ITaskRepository _repo)
        {
            repo = _repo;
        }

        public List<Task> GetAll()
        {
            return repo.GetAll().OrderBy(o => o.Id).ToList();
        }

        public Task Get(int id)
        {
            return repo.Get(id);
        }

        public bool SetState(int id, bool boo)
        {
            Task task = repo.Get(id);
            task.IsDone = boo;

            return repo.Update(task);
        }

        public bool Delete(int id)
        {
           return repo.Delete(id);
        }

        public Task Create(string content)
        {
            return repo.Add(new Task {
                Content = content,
                IsDone = false
            });
        }

        public bool Edit(int id, string content)
        {
            Task task = repo.Get(id);
            task.Content = content;

            return repo.Update(task);
        }
        

    }
}
