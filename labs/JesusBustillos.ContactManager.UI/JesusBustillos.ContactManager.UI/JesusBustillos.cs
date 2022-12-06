using Contacts;
namespace JesusBustillos.ContactManager.UI
{
    public partial class JesusBustillos : Form
    {
        public static IContactDatabase contactDatabase = new ContactDatabase();

        public JesusBustillos ()
        {
            InitializeComponent();
            listBox1.DoubleClick += new System.EventHandler(listBox1_DoubleClick);
            listBox1.KeyDown += new KeyEventHandler(listDeleteKey);

            contactDatabase.Add(new Contact("John", "Doe", "123@gmail.com", "", false));
            contactDatabase.Add(new Contact("Jane", "Doe", "321@gmail.com", "", false));
            contactDatabase.Add(new Contact("Fred", "Doe", "678@gmail.com", "", false));

            updatedisplay();
        }
        public void listDeleteKey(object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                delete();
            }
        }
        public void updatedisplay (bool initialLoad = false)
        {
            var contacts = contactDatabase.GetAll();

            //if (initialLoad && !contacts.Any())
            //{
            //    if (Confirm("Do you want to seed some contacts?" , "Database emtpy"))
            //    {
            //        _contacts.Seed();
            //        contacts = contactDatabase.GetAll();
            //    };
            //};

            listBox1.Items.Clear();

            var items = contacts.OrderBy(x => x.FirstName)
                                .ThenBy(x => x.LastName)
                                .ToArray();
            listBox1.Items.AddRange(items);
        }

        private void toolStripMenuItem1_Click ( object sender, EventArgs e )
        {
            
        }

        private void addNewContactToolStripMenuItem_Click ( object sender, EventArgs e )
        { 
            AddNewContact contactMenu = new AddNewContact();
            contactMenu.mainWindow = this;
            contactMenu.Show();
            contactMenu.MaximizeBox = false;
            contactMenu.MinimizeBox = false;
            //textBox1.Text="Hello!";
        }

        private void toolStripComboBox1_Click ( object sender, EventArgs e )
        {

        }

        private void listBox1_SelectedIndexChanged ( object sender, EventArgs e )
        {

        }

        private void listBox1_DoubleClick ( object sender, EventArgs e )
        {
            //MessageBox.Show("Selected " + listBox1.SelectedItem.ToString());
        }

        private void editExistingContactToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            AddNewContact contactMenu = new AddNewContact();
            contactMenu.mainWindow = this;
            contactMenu.SelectedContact = listBox1.SelectedItem as Contact;
            contactMenu.Show();
            contactMenu.MaximizeBox = false;
            contactMenu.MinimizeBox = false;
        }

        private void deleteContactToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            delete();
        }

        public void delete ()
        {
            var result = MessageBox.Show("Confirm deletion?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                contactDatabase.Remove(((Contact)listBox1.SelectedItem).ContactId); //ERROR - Deleting null contact causes crash
                updatedisplay();
            }
        }
    }
}