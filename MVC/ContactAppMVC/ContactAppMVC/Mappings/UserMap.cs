using ContactAppMVC.Models;
using FluentNHibernate.Mapping;

namespace ContactAppMVC.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(e => e.Id).GeneratedBy.GuidComb();

            Map(e => e.UserName);
            Map(u => u.Password);
            Map(e => e.Email);
            Map(e => e.FName);
            Map(e => e.LName);
            Map(e => e.IsAdmin);
            Map(e => e.IsActive);
            HasOne(r => r.Role).Cascade.All().PropertyRef(r => r.User).Constrained();
            HasMany(e => e.Contacts).Inverse().Cascade.All();


        }
    }
}