using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

// This comment serves to check if the code will be viewed if yes Hi! Hope you having a good day
namespace LibraryManagementSystem.Forms
{
    public partial class LibrarianForm : Form
    {
        private void RefreshBooksList()
        {
            lstBooks.Items.Clear();
            foreach (var b in LibraryData.Books)
                lstBooks.Items.Add(b);
        }

        private void RefreshMembersList()
        {
            lstMembers.Items.Clear();
            foreach (var m in LibraryData.Members)
                lstMembers.Items.Add($"{m.Name} (Joined: {m.JoinDate:yyyy-MM-dd})");
        }

        public LibrarianForm()
        {
            InitializeComponent();
            RefreshBooksList();
            RefreshMembersList();

        }


        // Event handlers 

        private void LibrarianForm_Load(object sender, EventArgs e)
        {
            // call refresh
            RefreshBooksList();
            RefreshMembersList();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtBookTitle.Text.Trim();
            string author = txtBookAuthor.Text.Trim();

            if (title == "" || author == "")
            {
                MessageBox.Show("Both title and author are required.");
                return;
            }

            Book newBook = new Book
            {
                Id = LibraryData.Books.Count + 1,
                Title = title,
                Author = author
            };

            LibraryData.Books.Add(newBook);

            txtBookTitle.Clear();
            txtBookAuthor.Clear();

            RefreshBooksList();
            MessageBox.Show("Book added successfully!");
        }


        private void btnAddMember_Click(object sender, EventArgs e)
        {
            string name = txtMemberName.Text.Trim();
            string password = txtMemberPassword.Text.Trim();

            if (name == "" || password == "")
            {
                MessageBox.Show("Name and password are required.");
                return;
            }

            if (LibraryData.Members.Any(m => m.Name == name))
            {
                MessageBox.Show("A member with this name already exists.");
                return;
            }

            Member newMember = new Member
            {
                Id = LibraryData.Members.Count + 1,
                Name = name,
                Password = password,
                JoinDate = DateTime.Now
            };

            LibraryData.Members.Add(newMember);

            txtMemberName.Clear();
            txtMemberPassword.Clear();

            RefreshMembersList();
            MessageBox.Show("Member added successfully!");
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim().ToLower();

            lstBooks.Items.Clear();

            foreach (var b in LibraryData.Books)
            {
                if (b.Title.ToLower().Contains(term) ||
                    b.Author.ToLower().Contains(term))
                {
                    lstBooks.Items.Add(b);
                }
            }

            if (lstBooks.Items.Count == 0)
            {
                lstBooks.Items.Add("No results found.");
            }
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnToggleAvailability_Click(object sender, EventArgs e)
        {
            if (lstBooks.SelectedItem is Book selected)
            {
                selected.IsAvailable = !selected.IsAvailable;
                RefreshBooksList();
                MessageBox.Show($"Availability changed. Book is now: {(selected.IsAvailable ? "Available" : "Not Available")}");
            }
            else
            {
                MessageBox.Show("Select a book first.");
            }
        }

    }

}
