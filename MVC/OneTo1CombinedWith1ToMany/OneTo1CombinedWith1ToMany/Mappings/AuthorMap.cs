using FluentNHibernate.Mapping;
using OneTo1CombinedWith1ToMany.Models;

namespace OneTo1CombinedWith1ToMany.Mappings
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Table("Authors");
            Id(u => u.Id).GeneratedBy.GuidComb();
            Map(u => u.Name);
            Map(u => u.Email);
            Map(u => u.Password);
            Map(u => u.Age);

            HasOne(u => u.AuthorDetails).Cascade.All().PropertyRef(a => a.Author);
            HasMany(e => e.Books).Inverse().Cascade.All();

        }
    }
}