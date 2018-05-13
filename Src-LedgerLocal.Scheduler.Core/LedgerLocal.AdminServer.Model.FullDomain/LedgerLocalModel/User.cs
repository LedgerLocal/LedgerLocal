using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class User
    {
        public User()
        {
            Abusecommentmap = new HashSet<Abusecommentmap>();
            Abuseproductreviewmap = new HashSet<Abuseproductreviewmap>();
            Accountmailqueue = new HashSet<Accountmailqueue>();
            Article = new HashSet<Article>();
            Attributeevent = new HashSet<Attributeevent>();
            CommentNavigation = new HashSet<Comment>();
            Dreamcomment = new HashSet<Dreamcomment>();
            Dreamproduct = new HashSet<Dreamproduct>();
            Ledgeruseraddressmap = new HashSet<Ledgeruseraddressmap>();
            Ledgerusers = new HashSet<Ledgerusers>();
            Order = new HashSet<Order>();
            Ordersupplier = new HashSet<Ordersupplier>();
            Pageevent = new HashSet<Pageevent>();
            Peopleonline = new HashSet<Peopleonline>();
            Peopleonlinehistory = new HashSet<Peopleonlinehistory>();
            Productevent = new HashSet<Productevent>();
            Productreview = new HashSet<Productreview>();
            Shoppingcart = new HashSet<Shoppingcart>();
            Shoppingcartevent = new HashSet<Shoppingcartevent>();
            Transactions = new HashSet<Transactions>();
            Userrolemap = new HashSet<Userrolemap>();
        }

        public int Userid { get; set; }
        public int? Cultureid { get; set; }
        public int? Encryptionid { get; set; }
        public int Peopleid { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Taxexempt { get; set; }
        public DateTime? Lastlogindate { get; set; }
        public DateTime? Lastactivitydate { get; set; }
        public DateTime? Lastpasswordchangeddate { get; set; }
        public DateTime? Lastlockoutdate { get; set; }
        public string Passwordhint { get; set; }
        public string Comment { get; set; }
        public string Passwordanswer { get; set; }
        public int? Locked { get; set; }
        public DateTime? Lockeduntil { get; set; }
        public int? Failedlogincount { get; set; }
        public int? Failedanswercount { get; set; }
        public bool Activate { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public string Picture { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Mobilelanguage { get; set; }
        public long? Referalcode { get; set; }
        public long? Godfathercode { get; set; }

        public Culture Culture { get; set; }
        public Encryptiontype Encryption { get; set; }
        public People People { get; set; }
        public ICollection<Abusecommentmap> Abusecommentmap { get; set; }
        public ICollection<Abuseproductreviewmap> Abuseproductreviewmap { get; set; }
        public ICollection<Accountmailqueue> Accountmailqueue { get; set; }
        public ICollection<Article> Article { get; set; }
        public ICollection<Attributeevent> Attributeevent { get; set; }
        public ICollection<Comment> CommentNavigation { get; set; }
        public ICollection<Dreamcomment> Dreamcomment { get; set; }
        public ICollection<Dreamproduct> Dreamproduct { get; set; }
        public ICollection<Ledgeruseraddressmap> Ledgeruseraddressmap { get; set; }
        public ICollection<Ledgerusers> Ledgerusers { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Ordersupplier> Ordersupplier { get; set; }
        public ICollection<Pageevent> Pageevent { get; set; }
        public ICollection<Peopleonline> Peopleonline { get; set; }
        public ICollection<Peopleonlinehistory> Peopleonlinehistory { get; set; }
        public ICollection<Productevent> Productevent { get; set; }
        public ICollection<Productreview> Productreview { get; set; }
        public ICollection<Shoppingcart> Shoppingcart { get; set; }
        public ICollection<Shoppingcartevent> Shoppingcartevent { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
        public ICollection<Userrolemap> Userrolemap { get; set; }
    }
}
