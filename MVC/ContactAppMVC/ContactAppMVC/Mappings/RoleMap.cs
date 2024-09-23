using ContactAppMVC.Models;
using FluentNHibernate.Mapping;

namespace ContactAppMVC.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("Roles");
            Id(a => a.Id).GeneratedBy.Identity();
            Map(a => a.RoleName);
            References(a => a.User).Column("user_id").Unique().Cascade.None();
        }
    }
}