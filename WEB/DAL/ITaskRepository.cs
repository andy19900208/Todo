using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using WEB.Models;

namespace WEB.DAL
{
    public interface ITaskRepository
    {
        List<Task> GetAll();

        Task Get(int id);

        Task Add(Task item);

        bool Update(Task item);

        bool Delete(int id);

    }
}
