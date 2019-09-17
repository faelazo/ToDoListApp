using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApp.Commons
{
    public class Commons
    {
        public const string pasthJSON = @"./Data/tasks.json";
        public enum States
        {
            Completed, Pending
        };
    }
}
