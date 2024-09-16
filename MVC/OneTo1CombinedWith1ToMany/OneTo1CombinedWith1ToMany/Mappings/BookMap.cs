using FluentNHibernate.Mapping;
using OneTo1CombinedWith1ToMany.Models;

namespace OneTo1CombinedWith1ToMany.Mappings
{
    public class BookMap : ClassMap<Books>

    {
        public BookMap()
        {
            Table("Books");
            Id(o => o.Id).GeneratedBy.Identity();
            Map(o => o.Name);
            Map(o => o.Genre);
            Map(o => o.Description);
            References(o => o.Author).Column("author_id").Cascade.None().Nullable();
        }
    }
}