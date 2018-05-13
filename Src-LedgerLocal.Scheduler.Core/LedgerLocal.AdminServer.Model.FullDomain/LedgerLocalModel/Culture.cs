using LedgerLocal.AdminServer.Model.FullDomain;
using System;
using System.Collections.Generic;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class Culture : BaseEntity
    {
        public Culture()
        {
            Article = new HashSet<Article>();
            Categoryculturemap = new HashSet<Categoryculturemap>();
            Contentblockculturemap = new HashSet<Contentblockculturemap>();
            Mailertemplate = new HashSet<Mailertemplate>();
            Order = new HashSet<Order>();
            Pageculturemap = new HashSet<Pageculturemap>();
            Policyculturemap = new HashSet<Policyculturemap>();
            Printtemplate = new HashSet<Printtemplate>();
            Productculturemap = new HashSet<Productculturemap>();
            Productreview = new HashSet<Productreview>();
            Shippingmethod = new HashSet<Shippingmethod>();
            Shoppingcart = new HashSet<Shoppingcart>();
            Supplierculturemap = new HashSet<Supplierculturemap>();
            User = new HashSet<User>();
        }

        public int Cultureid { get; set; }
        public char Languagecode { get; set; }
        public char? Locale { get; set; }
        public char? Defaultcurrencycode { get; set; }
        public string Defaultsizecode { get; set; }
        public string Defaultweightcode { get; set; }
        public string Defaultsizeunit { get; set; }
        public string Defaultweightunit { get; set; }

        public ICollection<Article> Article { get; set; }
        public ICollection<Categoryculturemap> Categoryculturemap { get; set; }
        public ICollection<Contentblockculturemap> Contentblockculturemap { get; set; }
        public ICollection<Mailertemplate> Mailertemplate { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Pageculturemap> Pageculturemap { get; set; }
        public ICollection<Policyculturemap> Policyculturemap { get; set; }
        public ICollection<Printtemplate> Printtemplate { get; set; }
        public ICollection<Productculturemap> Productculturemap { get; set; }
        public ICollection<Productreview> Productreview { get; set; }
        public ICollection<Shippingmethod> Shippingmethod { get; set; }
        public ICollection<Shoppingcart> Shoppingcart { get; set; }
        public ICollection<Supplierculturemap> Supplierculturemap { get; set; }
        public ICollection<User> User { get; set; }
    }
}
