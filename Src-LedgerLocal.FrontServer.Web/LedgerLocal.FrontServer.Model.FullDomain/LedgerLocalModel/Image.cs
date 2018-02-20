using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class Image
    {
        public Image()
        {
            Articleimagemap = new HashSet<Articleimagemap>();
            Categoryimagemap = new HashSet<Categoryimagemap>();
            Headerimage = new HashSet<Headerimage>();
            Mailinglistimagemap = new HashSet<Mailinglistimagemap>();
            Pageimagemap = new HashSet<Pageimagemap>();
            Productimagemap = new HashSet<Productimagemap>();
            Supplierimagemap = new HashSet<Supplierimagemap>();
        }

        public int Imageid { get; set; }
        public int? Imagetypeid { get; set; }
        public string Thumburl { get; set; }
        public string Fullimageurl { get; set; }
        public bool Active { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Modifiedon { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }

        public Imagetype Imagetype { get; set; }
        public ICollection<Articleimagemap> Articleimagemap { get; set; }
        public ICollection<Categoryimagemap> Categoryimagemap { get; set; }
        public ICollection<Headerimage> Headerimage { get; set; }
        public ICollection<Mailinglistimagemap> Mailinglistimagemap { get; set; }
        public ICollection<Pageimagemap> Pageimagemap { get; set; }
        public ICollection<Productimagemap> Productimagemap { get; set; }
        public ICollection<Supplierimagemap> Supplierimagemap { get; set; }
    }
}
