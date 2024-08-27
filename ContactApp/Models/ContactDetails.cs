using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactApp.Models
{
    internal class ContactDetails
    {
        [Key]
        public int Contact_DetailsId { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        //public ContactDetails(int contactDetailsId, string type, string value)
        //{
        //    Contact_DetailsId = contactDetailsId;
        //    Type = type;
        //    Value = value;

        //}

    }
}
