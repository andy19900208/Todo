using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using WEB.Models;

namespace WEB.DAL
{
    public class ObjectTaskRepository : ITaskRepository
    {
        private int IdCount = 1;

        private List<Task> data = new List<Task>();

        public ObjectTaskRepository()
        {
            List<Task> init = new List<Task>() {
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

            init.ForEach( f => {
                Add(f);
            });

        }

        public List<Task> GetAll()
        {
            return data;
        }

        public Task Get(int id)
        {
            return data.FirstOrDefault(x => x.Id == id);
        }

        public Task Add(Task item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = IdCount++;
            data.Add(item);

            return item;
        }


        public bool Delete(int id)
        {
            data.RemoveAll(p => p.Id == id);

            return true;
        }

        public bool Update(Task item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (data.Any(a => a.Id == item.Id))
            {
                Task task = data.First(f => f.Id == item.Id);

                task = item;

                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
