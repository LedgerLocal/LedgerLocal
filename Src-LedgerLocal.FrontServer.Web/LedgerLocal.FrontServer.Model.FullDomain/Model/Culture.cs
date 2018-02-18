using System;
using System.Collections.Generic;

namespace LedgerLocal.FrontServer.Model.FullDomain.Model
{
    public partial class Culture
    {
        public Culture()
        {
            User = new HashSet<User>();
            CategoryCultureMap = new HashSet<CategoryCultureMap>();
        }

        public int CultureId { get; set; }
        public string LanguageCode { get; set; }
        public string Locale { get; set; }
        public string DefaultCurrencyCode { get; set; }
        public string DefaultSizeCode { get; set; }
        public string DefaultWeightCode { get; set; }
        public string DefaultSizeUnit { get; set; }
        public string DefaultWeightUnit { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<User> User { get; set; }

        public virtual ICollection<CategoryCultureMap> CategoryCultureMap { get; set; }
    }
}
