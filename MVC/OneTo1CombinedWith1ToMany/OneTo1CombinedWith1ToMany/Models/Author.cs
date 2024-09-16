using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OneTo1CombinedWith1ToMany.Models
{
    public class Author
    {
        public virtual Guid Id { get; set; }
        [Required]

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual int Age { get; set; }

        [Required]
        public virtual string Password { get; set; }

        public virtual AuthorDetails AuthorDetails { get; set; } = new AuthorDetails();

        public virtual IList<Books> Books { get; set; } = new List<Books>();


    }
}