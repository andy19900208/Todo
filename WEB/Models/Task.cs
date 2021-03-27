using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsDone { get; set; }

    }
}
