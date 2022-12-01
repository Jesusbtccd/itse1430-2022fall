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
    }
}