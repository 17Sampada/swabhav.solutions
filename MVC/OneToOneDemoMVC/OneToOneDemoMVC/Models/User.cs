using System.ComponentModel.DataAnnotations;

namespace OneToOneDemoMVC.Models
{
    public class User
    {
        [Required]
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public virtual string Name { get; set; }

        [Required]
        public virtual Address Address { get; set; }
    }
}