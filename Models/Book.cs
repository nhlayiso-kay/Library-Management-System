using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{   /* Creates a class which Stores ID, Title, Author, and Availability.
    Includes a ToString() override for clean list display.*/

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;

        public override string ToString()
            => $"[ID: {Id}] {Title} by {Author} - {(IsAvailable ? "Available" : "Borrowed")}";
    }
}

