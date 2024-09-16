namespace OneTo1CombinedWith1ToMany.Models
{
    public class Books
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual string Genre { get; set; }

        public virtual string Description { get; set; }

        public virtual Author Author { get; set; } = new Author();

    }
}