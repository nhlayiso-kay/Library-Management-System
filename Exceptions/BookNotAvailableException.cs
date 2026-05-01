using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagementSystem.Exceptions
{
    public class BookNotAvailableException : Exception
    {
        public BookNotAvailableException(string title)
            : base($"The book '{title}' is not available for borrowing.") 
        { 
        
        }
    }
}
