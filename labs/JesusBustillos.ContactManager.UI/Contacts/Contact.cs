namespace Contacts
{
    public class Contact 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool IsFavorite { get; set; }
        public int ContactId { get; set; }

        public Contact (string FirstName, string LastName, string Email, string Notes, bool IsFavorite)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Notes = Notes;
            this.IsFavorite = IsFavorite;
        }

        public override string ToString ()
        {
            return LastName + ", " + FirstName;
        }

    }


}