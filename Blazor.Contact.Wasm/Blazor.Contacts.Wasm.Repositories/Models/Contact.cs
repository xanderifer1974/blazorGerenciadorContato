namespace Blazor.Contacts.Wasm.Repositories.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string FullName
        {
            get
            {


                return $"{LastName}, {FirstName}";

            }
        }
    }
}
