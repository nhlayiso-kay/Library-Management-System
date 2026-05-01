using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibraryManagementSystem.Models
{   /*	This adds properties: JoinDate and BorrowedBooks.
    	Used to store what books each member has borrowed.*/
    public class Member : User
    {
        public DateTime JoinDate { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public override string GetRole() => "Library Member";
    }
}
