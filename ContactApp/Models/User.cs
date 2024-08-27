using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApp.Models
{
    internal class User
    {
        [Key]
        public int UserId { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public bool IsAdmin { get; set; } = true;

        public bool IsActive { get; set; } = true;

        [ForeignKey("Contacts")]
        List<Contact> Contacts { get; set; }

        //public User(int userid, string fname, string lname, bool isAdmin)
        //{
        //    UserId = userid;
        //    FName = fname;
        //    LName = lname;
        //    IsAdmin = isAdmin;
        //    IsActive = true;



        //}

        //public bool Deactivate()
        //{
        //    return IsActive;
        //}
    }
}
