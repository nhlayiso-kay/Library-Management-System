using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{   /* A class that defines GetRole() to return “Librarian”.
       Used during login to identify librarian accounts.*/
    public class Librarian : User
    {
        public override string GetRole() => "Librarian";
    }
}

