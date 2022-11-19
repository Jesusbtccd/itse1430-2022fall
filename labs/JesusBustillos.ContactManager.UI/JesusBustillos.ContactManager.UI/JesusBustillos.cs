using Contacts;
namespace JesusBustillos.ContactManager.UI
{
    public partial class JesusBustillos : Form
    {
        public static IContactDatabase contactDatabase = new ContactDatabase();

        public JesusBustillos ()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click ( object sender, EventArgs e )
        {
            
        }

        private void addNewContactToolStripMenuItem_Click ( object sender, EventArgs e )
        { 
            AddNewContact contactMenu = new AddNewContact();
            contactMenu.Show();
            contactMenu.MaximizeBox = false;
            contactMenu.MinimizeBox = false;
            //textBox1.Text="Hello!";
        }

        private void toolStripComboBox1_Click ( object sender, EventArgs e )
        {

        }
    }
}