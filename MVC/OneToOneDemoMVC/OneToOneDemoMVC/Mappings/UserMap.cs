using FluentNHibernate.Mapping;
using OneToOneDemoMVC.Models;

namespace OneToOneDemoMVC.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.Name);
            HasOne(u => u.Address).Cascade.All().PropertyRef(a => a.User).Constrained();
        }
    }
}