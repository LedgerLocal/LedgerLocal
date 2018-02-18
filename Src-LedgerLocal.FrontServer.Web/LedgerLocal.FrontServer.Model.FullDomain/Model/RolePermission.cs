using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class RolePermission
    {
        public RolePermission()
        {
            RolePermissionMap = new HashSet<RolePermissionMap>();
        }

        public int RolePermissionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<RolePermissionMap> RolePermissionMap { get; set; }
    }
}
