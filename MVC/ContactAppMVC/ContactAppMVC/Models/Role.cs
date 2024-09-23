using System;

namespace ContactAppMVC.Models
{
    public class Role
    {
        public virtual Guid Id { get; set; }
        public virtual string RoleName { get; set; }

        public virtual User User { get; set; }
    }
}