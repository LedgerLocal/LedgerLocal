using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class UserRoleMap
    {
        public int UserRoleMapId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual User User { get; set; }
    }
}
