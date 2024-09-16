namespace OneToOneDemoMVC.Models
{
    public class Address
    {
        public virtual int Id { get; set; }

        public virtual string Street { get; set; }

        public virtual string City { get; set; }

        public virtual User User { get; set; }

    }
}