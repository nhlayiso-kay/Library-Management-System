using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{   /*Abstract class which Contains basic shared properties such as Id, Name, and Password.
        Uses an abstract GetRole() method that subclasses override.*/
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public abstract string GetRole();
    }
}
