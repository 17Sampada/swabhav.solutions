using FluentNHibernate.Mapping;
using OneToOneDemoMVC.Models;

namespace OneToOneDemoMVC.Mappings
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Addresses");
            Id(a => a.Id).GeneratedBy.Identity();
            Map(a => a.Street);
            Map(a => a.City);
            References(a => a.User).Column("user_id").Unique().Cascade.None();
        }
    }
}