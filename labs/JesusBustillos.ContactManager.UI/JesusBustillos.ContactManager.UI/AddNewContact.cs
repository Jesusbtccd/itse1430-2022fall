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
            var contact = new Contact(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked);
            if (contact.LastName != "" && IsValidEmail(contact.Email))
            {

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
    }
}
