using System;
using System.Collections.Generic;
using LibraryManagementSystem.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data
{
    //A central in-memory repository for list of books, members and librarians
    public static class LibraryData
    {
        public static List<Book> Books { get; } = new List<Book>();
        public static List<Member> Members { get; } = new List<Member>();
        public static List<Librarian> Librarians { get; } = new List<Librarian>();

        static LibraryData()
        {
            // Seed demo data
            Librarians.Add(new Librarian { Id = 1, Name = "Admin1", Password = "lib123" });
            Librarians.Add(new Librarian { Id = 2, Name = "Admin2", Password = "lib456" });
            Books.Add(new Book { Id = 1, Title = "C# Programming", Author = "Sabelo Sabs Nkwanyana" });
            Books.Add(new Book { Id = 2, Title = "Data Structures", Author = "Mathelo Monare" });
            Books.Add(new Book { Id = 3, Title = "SQL Server", Author = "Bongani Libisi" });
            Books.Add(new Book { Id = 4, Title = "OOP JAVA", Author = "Dr. Vincent Mzazi" });
        }
    }
}
