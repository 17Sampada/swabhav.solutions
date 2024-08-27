using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApp.Models
{
    internal class Contact
    {
        [Key]
        public int ContactId { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("ContactDetails")]
        public List<ContactDetails> ContactDetails { get; set; }

        //public Contact(int id, string fname, string lname)
        //{
        //    ContactId = id;
        //    FName = fname;
        //    LName = lname;
        //    IsActive = true;

        //}

        public bool Deactivate()
        {
            return IsActive;
        }
    }
}
