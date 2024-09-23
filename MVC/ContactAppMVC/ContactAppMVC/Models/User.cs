using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactAppMVC.Models
{
    public class User
    {
        public virtual Guid Id { get; set; }

        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string FName { get; set; }

        public virtual string LName { get; set; }

        public virtual bool IsAdmin { get; set; } = true;

        public virtual bool IsActive { get; set; } = true;
        [Required]
        public virtual string Password { get; set; }

        public virtual Role Role { get; set; } = new Role();


        public virtual IList<Contact> Contacts { get; set; } = new List<Contact>();
    }
}