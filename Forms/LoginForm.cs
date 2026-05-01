using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            cmbUserType.Items.Add("Librarian");
            cmbUserType.Items.Add("Member");
            cmbUserType.SelectedIndex = 0;
        }


        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbUserType.SelectedItem.ToString();

            // Validate input
            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (role == "Librarian")
            {
                var librarian = LibraryData.Librarians
                    .FirstOrDefault(l => l.Name == username && l.Password == password);

                if (librarian != null)
                {
                    new LibrarianForm().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid librarian credentials.");
                }
            }
            else if (role == "Member")
            {
                var member = LibraryData.Members
                    .FirstOrDefault(m => m.Name == username && m.Password == password);

                if (member != null)
                {
                    new MemberForm(member).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid member login or account does not exist.");
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
