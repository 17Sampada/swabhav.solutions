using FluentNHibernate.Mapping;
using PasswordHashingDemo.Models;

namespace PasswordHashingDemo.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("UserCredentials");
            Id(uc => uc.UserName);
            Map(uc => uc.Password);

        }
    }
}