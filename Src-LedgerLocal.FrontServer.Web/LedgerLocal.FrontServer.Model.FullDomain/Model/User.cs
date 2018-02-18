using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class User
    {
        public User()
        {
            PeopleOnline = new HashSet<PeopleOnline>();
            PeopleOnlineHistory = new HashSet<PeopleOnlineHistory>();
            UserRoleMap = new HashSet<UserRoleMap>();
            VoucherLedger = new HashSet<VoucherLedger>();
        }

        public int UserId { get; set; }
        public int? CultureId { get; set; }
        public int? EncryptionId { get; set; }
        public int PeopleId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? TaxExempt { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public DateTime? LastLockOutDate { get; set; }
        public string PasswordHint { get; set; }
        public string Comment { get; set; }
        public string PasswordAnswer { get; set; }
        public int? Locked { get; set; }
        public DateTime? LockedUntil { get; set; }
        public int? FailedLoginCount { get; set; }
        public int? FailedAnswerCount { get; set; }
        public bool Activate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        
        public virtual ICollection<PeopleOnline> PeopleOnline { get; set; }
        public virtual ICollection<PeopleOnlineHistory> PeopleOnlineHistory { get; set; }
        public virtual ICollection<UserRoleMap> UserRoleMap { get; set; }
        public virtual ICollection<VoucherLedger> VoucherLedger { get; set; }
        public virtual Culture Culture { get; set; }
        public virtual People People { get; set; }
    }
}
