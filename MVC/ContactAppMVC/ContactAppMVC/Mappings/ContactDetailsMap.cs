using ContactAppMVC.Models;
using FluentNHibernate.Mapping;

namespace ContactAppMVC.Mappings
{
    public class ContactDetailsMap : ClassMap<ContactDetails>
    {
        public ContactDetailsMap()
        {
            Table("ContactDetails");
            Id(cd => cd.Id).GeneratedBy.GuidComb();
            Map(cd => cd.Number);
            Map(cd => cd.Email);
            References(cd => cd.Contact).Column("ContactId").Cascade.None().Nullable();

        }
    }
}