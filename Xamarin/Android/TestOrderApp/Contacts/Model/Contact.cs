namespace Contacts.Model
{
    public class Contact
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Specialty { get; set; }
        public string Biography { get; set; }

        public override string ToString()
        {
            return Name + " " + Specialty;
        }
    }
}