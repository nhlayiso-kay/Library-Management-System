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
using LibraryManagementSystem.Exceptions;

namespace LibraryManagementSystem.Forms
{
    public partial class MemberForm : Form
    {
        private Member _member;

        public MemberForm(Member member)
        {
            InitializeComponent();
            _member = member;
            lblWelcome.Text = $"Welcome, {_member.Name}";
            RefreshAvailableAndBorrowed();
        }

        private void RefreshAvailableAndBorrowed()
        {
            lstAvailableBooks.Items.Clear();
            foreach (var b in LibraryData.Books.Where(x => x.IsAvailable))
                lstAvailableBooks.Items.Add(b);

            lstBorrowedBooks.Items.Clear();
            foreach (var b in _member.BorrowedBooks)
                lstBorrowedBooks.Items.Add(b);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (lstAvailableBooks.SelectedItem == null)
            {
                MessageBox.Show("Please select a book to borrow.");
                return;
            }

            Book selected = (Book)lstAvailableBooks.SelectedItem;

            try
            {
                if (!selected.IsAvailable)
                {
                    // Throw your custom exception
                    throw new BookNotAvailableException(selected.Title);
                }

                // Borrow the book
                selected.IsAvailable = false;
                _member.BorrowedBooks.Add(selected);

                RefreshAvailableAndBorrowed();

                MessageBox.Show($"You borrowed: {selected.Title}");
            }
            catch (BookNotAvailableException ex)
            {
                // Show a user-friendly message
                MessageBox.Show(ex.Message, "Book Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (lstBorrowedBooks.SelectedItem == null)
            {
                MessageBox.Show("Please select a book to return.");
                return;
            }

            Book selected = (Book)lstBorrowedBooks.SelectedItem;

            // Return the book
            selected.IsAvailable = true;
            _member.BorrowedBooks.Remove(selected);

            RefreshAvailableAndBorrowed();

            MessageBox.Show($"Returned: {selected.Title}");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
