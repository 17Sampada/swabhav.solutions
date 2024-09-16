using FluentNHibernate.Mapping;
using OneTo1CombinedWith1ToMany.Models;

namespace OneTo1CombinedWith1ToMany.Mappings
{
    public class AuthorDetailsMap : ClassMap<AuthorDetails>
    {
        public AuthorDetailsMap()
        {
            Table("AuthorDetails");
            Id(a => a.Id).GeneratedBy.Identity();
            Map(a => a.Street);
            Map(a => a.City);
            Map(a => a.State);
            Map(a => a.Country);
            References(a => a.Author).Column("author_id").Cascade.None();

        }


    }
}