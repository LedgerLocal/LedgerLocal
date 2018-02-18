using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class UserRole
    {
        public UserRole()
        {
            RolePermissionMap = new HashSet<RolePermissionMap>();
            UserRoleMap = new HashSet<UserRoleMap>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<RolePermissionMap> RolePermissionMap { get; set; }
        public virtual ICollection<UserRoleMap> UserRoleMap { get; set; }
    }
}
