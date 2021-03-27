using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using WEB.Models;

namespace WEB.DAL
{
    public class EFTaskRepository : ITaskRepository
    {
        private TodoContext context;

        public EFTaskRepository()
        {
            context = new TodoContext();
        }

        public List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }

        public Task Get(int id)
        {
            return context.Tasks.FirstOrDefault(f => f.Id == id);
        }

        public Task Add(Task item)
        {
            context.Tasks.Add(item);
            context.SaveChanges();

            return item;
        }

        public bool Delete(int id)
        {
            context.Tasks.Remove(Get(id));
            context.SaveChanges();

            return true;
        }        

        public bool Update(Task item)
        {
            Task task = context.Tasks.SingleOrDefault(s => s.Id == item.Id);
            if (task != null)
            {
                task.Content = item.Content;
                task.IsDone = item.IsDone;

                context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
