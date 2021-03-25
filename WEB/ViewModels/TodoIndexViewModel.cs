using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using WEB.Models;

namespace WEB.ViewModels
{
    public class TodoIndexViewModel
    {
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
