using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Entity
{
    public class ItemList
    {
        public int TaskID { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int UserID { get; set; }
    }
}
