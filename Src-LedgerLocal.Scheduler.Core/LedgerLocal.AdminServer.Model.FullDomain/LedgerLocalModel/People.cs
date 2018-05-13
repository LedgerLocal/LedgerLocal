using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class People
    {
        public People()
        {
            Address = new HashSet<Address>();
            Contact = new HashSet<Contact>();
            Mailinglistpeoplemap = new HashSet<Mailinglistpeoplemap>();
            Phone = new HashSet<Phone>();
            User = new HashSet<User>();
        }

        public int Peopleid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Lastip { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public ICollection<Address> Address { get; set; }
        public ICollection<Contact> Contact { get; set; }
        public ICollection<Mailinglistpeoplemap> Mailinglistpeoplemap { get; set; }
        public ICollection<Phone> Phone { get; set; }
        public ICollection<User> User { get; set; }
    }
}
