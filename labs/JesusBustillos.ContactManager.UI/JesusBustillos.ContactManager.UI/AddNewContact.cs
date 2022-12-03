using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contacts;

namespace JesusBustillos.ContactManager.UI
{
    public partial class AddNewContact : Form
    {
        public JesusBustillos mainWindow;
        public AddNewContact ()
        {
            InitializeComponent();
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            
            var contact = SelectedContact?? new Contact(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked);
            if (textBox2.Text != "" && IsValidEmail(textBox3.Text))
            {
                if (contact == SelectedContact)
                {
                    SelectedContact.FirstName = textBox1.Text;
                    SelectedContact.LastName = textBox2.Text;
                    SelectedContact.Email = textBox3.Text;
                    SelectedContact.Notes = textBox4.Text;
                    SelectedContact.IsFavorite = checkBox1.Checked;
                }else
                    JesusBustillos.contactDatabase.Add (contact);
                mainWindow.updatedisplay();
                this.Close();
            } else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            this.Close();
        }

        bool IsValidEmail (string source)
        {
            return MailAddress.TryCreate(source, out var address);
        }

        public Contact SelectedContact = null;
        private void AddNewContact_Load ( object sender, EventArgs e )
        {
            
                if (SelectedContact != null)
            {
                textBox1.Text = SelectedContact.FirstName;
                textBox2.Text = SelectedContact.LastName;
                textBox3.Text = SelectedContact.Email;
                textBox4.Text = SelectedContact.Notes;
                checkBox1.Checked = SelectedContact.IsFavorite;

            };
            ValidateChildren();
        }
    }
}
