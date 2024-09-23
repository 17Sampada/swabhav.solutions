using ContactAppMVC.Models;
using FluentNHibernate.Mapping;

namespace ContactAppMVC.Mappings
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Table("Contacts");
            Id(e => e.Id).GeneratedBy.GuidComb();
            Map(e => e.FName);
            Map(e => e.LName);
            Map(e => e.IsActive);
            References(o => o.User).Column("UserId").Cascade.None().Nullable();
            HasMany(e => e.ContactDetails).Inverse().Cascade.All();
        }
    }

}

