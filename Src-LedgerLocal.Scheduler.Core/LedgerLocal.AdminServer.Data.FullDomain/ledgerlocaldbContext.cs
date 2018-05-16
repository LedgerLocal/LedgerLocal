using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LedgerLocal.AdminServer.Data.FullDomain
{
    public partial class LedgerLocalDbContext : DbContext
    {
        private string _connString;

        public LedgerLocalDbContext(string connString)
        {
            _connString = connString;
        }

        public virtual DbSet<Abusecommentmap> Abusecommentmap { get; set; }
        public virtual DbSet<Abuseproductreviewmap> Abuseproductreviewmap { get; set; }
        public virtual DbSet<Accountmailqueue> Accountmailqueue { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Addresstype> Addresstype { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Articleimagemap> Articleimagemap { get; set; }
        public virtual DbSet<Articletag> Articletag { get; set; }
        public virtual DbSet<Articletagmap> Articletagmap { get; set; }
        public virtual DbSet<Attribute> Attribute { get; set; }
        public virtual DbSet<Attributebehavior> Attributebehavior { get; set; }
        public virtual DbSet<Attributeevent> Attributeevent { get; set; }
        public virtual DbSet<Attributeitem> Attributeitem { get; set; }
        public virtual DbSet<Attributetype> Attributetype { get; set; }
        public virtual DbSet<Blacklistrepository> Blacklistrepository { get; set; }
        public virtual DbSet<Cartresultproductmap> Cartresultproductmap { get; set; }
        public virtual DbSet<Cartrulecondition> Cartrulecondition { get; set; }
        public virtual DbSet<Cartruleengine> Cartruleengine { get; set; }
        public virtual DbSet<Cartruleresult> Cartruleresult { get; set; }
        public virtual DbSet<Cartruleschedule> Cartruleschedule { get; set; }
        public virtual DbSet<Cartruleshoppingcartmap> Cartruleshoppingcartmap { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Categoryculturemap> Categoryculturemap { get; set; }
        public virtual DbSet<Categoryimagemap> Categoryimagemap { get; set; }
        public virtual DbSet<Categoryproductmap> Categoryproductmap { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Contacttype> Contacttype { get; set; }
        public virtual DbSet<Contentblock> Contentblock { get; set; }
        public virtual DbSet<Contentblockculturemap> Contentblockculturemap { get; set; }
        public virtual DbSet<Contentblocktype> Contentblocktype { get; set; }
        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Couponrepository> Couponrepository { get; set; }
        public virtual DbSet<Creditcardtype> Creditcardtype { get; set; }
        public virtual DbSet<Csvdelimiter> Csvdelimiter { get; set; }
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Customexport> Customexport { get; set; }
        public virtual DbSet<Deliverymethod> Deliverymethod { get; set; }
        public virtual DbSet<Dreamcomment> Dreamcomment { get; set; }
        public virtual DbSet<Dreamimage> Dreamimage { get; set; }
        public virtual DbSet<Dreamproduct> Dreamproduct { get; set; }
        public virtual DbSet<Dreamproductimagemap> Dreamproductimagemap { get; set; }
        public virtual DbSet<Encryptiontype> Encryptiontype { get; set; }
        public virtual DbSet<Genericattribute> Genericattribute { get; set; }
        public virtual DbSet<Genericattributetype> Genericattributetype { get; set; }
        public virtual DbSet<Genericattributevalue> Genericattributevalue { get; set; }
        public virtual DbSet<Globalsetting> Globalsetting { get; set; }
        public virtual DbSet<Globalsettingtype> Globalsettingtype { get; set; }
        public virtual DbSet<Headerimage> Headerimage { get; set; }
        public virtual DbSet<Headerimagetype> Headerimagetype { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Imagetype> Imagetype { get; set; }
        public virtual DbSet<Instantnotification> Instantnotification { get; set; }
        public virtual DbSet<Instantnotificationpagemap> Instantnotificationpagemap { get; set; }
        public virtual DbSet<Instantnotificationtype> Instantnotificationtype { get; set; }
        public virtual DbSet<Inventoryrecord> Inventoryrecord { get; set; }
        public virtual DbSet<Inventorystatus> Inventorystatus { get; set; }
        public virtual DbSet<Ledgeruseraddressmap> Ledgeruseraddressmap { get; set; }
        public virtual DbSet<Ledgerusers> Ledgerusers { get; set; }
        public virtual DbSet<Letter> Letter { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Mailertemplate> Mailertemplate { get; set; }
        public virtual DbSet<Mailertemplatetype> Mailertemplatetype { get; set; }
        public virtual DbSet<Mailinglist> Mailinglist { get; set; }
        public virtual DbSet<Mailinglistcontentblockmap> Mailinglistcontentblockmap { get; set; }
        public virtual DbSet<Mailinglistcontentblocktype> Mailinglistcontentblocktype { get; set; }
        public virtual DbSet<Mailinglistimagemap> Mailinglistimagemap { get; set; }
        public virtual DbSet<Mailinglistimagetype> Mailinglistimagetype { get; set; }
        public virtual DbSet<Mailinglistpeoplegroup> Mailinglistpeoplegroup { get; set; }
        public virtual DbSet<Mailinglistpeoplemap> Mailinglistpeoplemap { get; set; }
        public virtual DbSet<Mailinglistproductmap> Mailinglistproductmap { get; set; }
        public virtual DbSet<Mailinglistqueue> Mailinglistqueue { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Ordercouponmap> Ordercouponmap { get; set; }
        public virtual DbSet<Orderitem> Orderitem { get; set; }
        public virtual DbSet<Orderitempackagemap> Orderitempackagemap { get; set; }
        public virtual DbSet<Orderitemsuppliermap> Orderitemsuppliermap { get; set; }
        public virtual DbSet<Ordermailqueue> Ordermailqueue { get; set; }
        public virtual DbSet<Ordernote> Ordernote { get; set; }
        public virtual DbSet<Ordernotetype> Ordernotetype { get; set; }
        public virtual DbSet<Orderpackage> Orderpackage { get; set; }
        public virtual DbSet<Ordershippingmethodmap> Ordershippingmethodmap { get; set; }
        public virtual DbSet<Orderstatus> Orderstatus { get; set; }
        public virtual DbSet<Ordersupplier> Ordersupplier { get; set; }
        public virtual DbSet<Ordersupplierstatus> Ordersupplierstatus { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<Pagebehavior> Pagebehavior { get; set; }
        public virtual DbSet<Pageculturemap> Pageculturemap { get; set; }
        public virtual DbSet<Pageevent> Pageevent { get; set; }
        public virtual DbSet<Pageimagemap> Pageimagemap { get; set; }
        public virtual DbSet<Pageimagetype> Pageimagetype { get; set; }
        public virtual DbSet<Pagetype> Pagetype { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Peopleonline> Peopleonline { get; set; }
        public virtual DbSet<Peopleonlinehistory> Peopleonlinehistory { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Phonetype> Phonetype { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<Policyculturemap> Policyculturemap { get; set; }
        public virtual DbSet<Postalcode> Postalcode { get; set; }
        public virtual DbSet<Postalzone> Postalzone { get; set; }
        public virtual DbSet<Postalzonecountrymap> Postalzonecountrymap { get; set; }
        public virtual DbSet<Printtemplate> Printtemplate { get; set; }
        public virtual DbSet<Printtemplatetype> Printtemplatetype { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Productattributemap> Productattributemap { get; set; }
        public virtual DbSet<Productbehavior> Productbehavior { get; set; }
        public virtual DbSet<Productcrosssellmap> Productcrosssellmap { get; set; }
        public virtual DbSet<Productculturemap> Productculturemap { get; set; }
        public virtual DbSet<Productevent> Productevent { get; set; }
        public virtual DbSet<Productgroup> Productgroup { get; set; }
        public virtual DbSet<Productimagemap> Productimagemap { get; set; }
        public virtual DbSet<Productimagetype> Productimagetype { get; set; }
        public virtual DbSet<Productinventory> Productinventory { get; set; }
        public virtual DbSet<Productinventorywarehousemap> Productinventorywarehousemap { get; set; }
        public virtual DbSet<Productrelatedmap> Productrelatedmap { get; set; }
        public virtual DbSet<Productreview> Productreview { get; set; }
        public virtual DbSet<Productshippingmethodmap> Productshippingmethodmap { get; set; }
        public virtual DbSet<Productsuppliermap> Productsuppliermap { get; set; }
        public virtual DbSet<Productwarehouse> Productwarehouse { get; set; }
        public virtual DbSet<Programpointofsalemap> Programpointofsalemap { get; set; }
        public virtual DbSet<Queuestatus> Queuestatus { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Returnmaterial> Returnmaterial { get; set; }
        public virtual DbSet<Returnmaterialitem> Returnmaterialitem { get; set; }
        public virtual DbSet<Returnmaterialreason> Returnmaterialreason { get; set; }
        public virtual DbSet<Returnmaterialstatus> Returnmaterialstatus { get; set; }
        public virtual DbSet<Rolepermission> Rolepermission { get; set; }
        public virtual DbSet<Rolepermissionmap> Rolepermissionmap { get; set; }
        public virtual DbSet<Ruleconditionoperator> Ruleconditionoperator { get; set; }
        public virtual DbSet<Ruleresultoperation> Ruleresultoperation { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Saleattributemap> Saleattributemap { get; set; }
        public virtual DbSet<Salecategorymap> Salecategorymap { get; set; }
        public virtual DbSet<Saleproductmap> Saleproductmap { get; set; }
        public virtual DbSet<Shippingmethod> Shippingmethod { get; set; }
        public virtual DbSet<Shippingmethodrate> Shippingmethodrate { get; set; }
        public virtual DbSet<Shoppingcart> Shoppingcart { get; set; }
        public virtual DbSet<Shoppingcartbehavior> Shoppingcartbehavior { get; set; }
        public virtual DbSet<Shoppingcartcouponmap> Shoppingcartcouponmap { get; set; }
        public virtual DbSet<Shoppingcartevent> Shoppingcartevent { get; set; }
        public virtual DbSet<Shoppingcartproductmap> Shoppingcartproductmap { get; set; }
        public virtual DbSet<Sourcetype> Sourcetype { get; set; }
        public virtual DbSet<Stockmanagment> Stockmanagment { get; set; }
        public virtual DbSet<Stockmanagmenttype> Stockmanagmenttype { get; set; }
        public virtual DbSet<Subproductattributemap> Subproductattributemap { get; set; }
        public virtual DbSet<Subproductmap> Subproductmap { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Supplierculturemap> Supplierculturemap { get; set; }
        public virtual DbSet<Supplierimagemap> Supplierimagemap { get; set; }
        public virtual DbSet<Supplierimagetype> Supplierimagetype { get; set; }
        public virtual DbSet<Suppliernote> Suppliernote { get; set; }
        public virtual DbSet<Suppliertype> Suppliertype { get; set; }
        public virtual DbSet<Taxrate> Taxrate { get; set; }
        public virtual DbSet<Taxweee> Taxweee { get; set; }
        public virtual DbSet<Tokenprice> Tokenprice { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Transactionprocessor> Transactionprocessor { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Transactionstatus> Transactionstatus { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Userrole> Userrole { get; set; }
        public virtual DbSet<Userrolemap> Userrolemap { get; set; }
        public virtual DbSet<Workflowcontainer> Workflowcontainer { get; set; }
        public virtual DbSet<Workflowgenericattributemap> Workflowgenericattributemap { get; set; }
        public virtual DbSet<Workflowtype> Workflowtype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abusecommentmap>(entity =>
            {
                entity.HasKey(e => e.Abusecommentid);

                entity.ToTable("abusecommentmap", "news");

                entity.Property(e => e.Abusecommentid)
                    .HasColumnName("abusecommentid")
                    .HasDefaultValueSql("nextval('news.abusecommentmap_abusecommentid_seq'::regclass)");

                entity.Property(e => e.Commentid).HasColumnName("commentid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Isabuse).HasColumnName("isabuse");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Abusecommentmap)
                    .HasForeignKey(d => d.Commentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_abusecommentmap_comment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Abusecommentmap)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_abusecommentmap_user");
            });

            modelBuilder.Entity<Abuseproductreviewmap>(entity =>
            {
                entity.HasKey(e => e.Abuseproductreviewid);

                entity.ToTable("abuseproductreviewmap", "dbo");

                entity.Property(e => e.Abuseproductreviewid)
                    .HasColumnName("abuseproductreviewid")
                    .HasDefaultValueSql("nextval('dbo.abuseproductreviewmap_abuseproductreviewid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Isabuse).HasColumnName("isabuse");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Peopleid).HasColumnName("peopleid");

                entity.Property(e => e.Productreviewid).HasColumnName("productreviewid");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Abuseproductreviewmap)
                    .HasForeignKey(d => d.Peopleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_abuseproductreviewmap_user");

                entity.HasOne(d => d.Productreview)
                    .WithMany(p => p.Abuseproductreviewmap)
                    .HasForeignKey(d => d.Productreviewid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_abueviewmap_productreview");
            });

            modelBuilder.Entity<Accountmailqueue>(entity =>
            {
                entity.HasKey(e => e.Acountmailqueueid);

                entity.ToTable("accountmailqueue", "queue");

                entity.Property(e => e.Acountmailqueueid)
                    .HasColumnName("acountmailqueueid")
                    .HasDefaultValueSql("nextval('queue.accountmailqueue_acountmailqueueid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Mailertemplateid).HasColumnName("mailertemplateid");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Queuestatusid).HasColumnName("queuestatusid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Mailertemplate)
                    .WithMany(p => p.Accountmailqueue)
                    .HasForeignKey(d => d.Mailertemplateid)
                    .HasConstraintName("fk_accoutemplate");

                entity.HasOne(d => d.Queuestatus)
                    .WithMany(p => p.Accountmailqueue)
                    .HasForeignKey(d => d.Queuestatusid)
                    .HasConstraintName("fk_accountmailqueue_queuestatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accountmailqueue)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_accountmailqueue_user");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address", "dbo");

                entity.Property(e => e.Addressid)
                    .HasColumnName("addressid")
                    .HasDefaultValueSql("nextval('dbo.address_addressid_seq'::regclass)");

                entity.Property(e => e.Addresstypeid).HasColumnName("addresstypeid");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Brandid).HasColumnName("brandid");

                entity.Property(e => e.Businessid).HasColumnName("businessid");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city");

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.Isdefault)
                    .HasColumnName("isdefault")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename).HasColumnName("middlename");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Peopleid).HasColumnName("peopleid");

                entity.Property(e => e.Postalcode)
                    .IsRequired()
                    .HasColumnName("postalcode");

                entity.Property(e => e.Postalcodeid).HasColumnName("postalcodeid");

                entity.Property(e => e.Stateorprovince)
                    .IsRequired()
                    .HasColumnName("stateorprovince");

                entity.Property(e => e.Street1)
                    .IsRequired()
                    .HasColumnName("street1");

                entity.Property(e => e.Street2).HasColumnName("street2");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Weburl).HasColumnName("weburl");

                entity.HasOne(d => d.Addresstype)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.Addresstypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_address_addresstype");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.Peopleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_address_people");

                entity.HasOne(d => d.PostalcodeNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.Postalcodeid)
                    .HasConstraintName("fk_address_postalcode");
            });

            modelBuilder.Entity<Addresstype>(entity =>
            {
                entity.ToTable("addresstype", "dbo");

                entity.Property(e => e.Addresstypeid)
                    .HasColumnName("addresstypeid")
                    .HasDefaultValueSql("nextval('dbo.addresstype_addresstypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article", "news");

                entity.Property(e => e.Articleid)
                    .HasColumnName("articleid")
                    .HasDefaultValueSql("nextval('news.article_articleid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Body)
                    .HasColumnName("body");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Imagepost)
                    .HasColumnName("imagepost");

                entity.Property(e => e.Imagethumb)
                    .HasColumnName("imagethumb");

                entity.Property(e => e.Ishtml).HasColumnName("ishtml");

                entity.Property(e => e.Keywords).HasColumnName("keywords");

                entity.Property(e => e.Metadescription).HasColumnName("metadescription");

                entity.Property(e => e.Metakeyword).HasColumnName("metakeyword");

                entity.Property(e => e.Metatitle).HasColumnName("metatitle");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.Cultureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_article_culture");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_article_user");
            });

            modelBuilder.Entity<Articleimagemap>(entity =>
            {
                entity.HasKey(e => e.Articleimageid);

                entity.ToTable("articleimagemap", "news");

                entity.Property(e => e.Articleimageid)
                    .HasColumnName("articleimageid")
                    .HasDefaultValueSql("nextval('news.articleimagemap_articleimageid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Articleid).HasColumnName("articleid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Articleimagemap)
                    .HasForeignKey(d => d.Articleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articleimagemap_article");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Articleimagemap)
                    .HasForeignKey(d => d.Imageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articleimagemap_image");
            });

            modelBuilder.Entity<Articletag>(entity =>
            {
                entity.ToTable("articletag", "news");

                entity.Property(e => e.Articletagid)
                    .HasColumnName("articletagid")
                    .HasDefaultValueSql("nextval('news.articletag_articletagid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Isprivate).HasColumnName("isprivate");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Tagname)
                    .IsRequired()
                    .HasColumnName("tagname");
            });

            modelBuilder.Entity<Articletagmap>(entity =>
            {
                entity.ToTable("articletagmap", "news");

                entity.Property(e => e.Articletagmapid)
                    .HasColumnName("articletagmapid")
                    .HasDefaultValueSql("nextval('news.articletagmap_articletagmapid_seq'::regclass)");

                entity.Property(e => e.Articleid).HasColumnName("articleid");

                entity.Property(e => e.Articletagid).HasColumnName("articletagid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Articletagmap)
                    .HasForeignKey(d => d.Articleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articletagmap_article");

                entity.HasOne(d => d.Articletag)
                    .WithMany(p => p.Articletagmap)
                    .HasForeignKey(d => d.Articletagid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articletagmap_articletag");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("attribute", "dbo");

                entity.Property(e => e.Attributeid)
                    .HasColumnName("attributeid")
                    .HasDefaultValueSql("nextval('dbo.attribute_attributeid_seq'::regclass)");

                entity.Property(e => e.Adjustment)
                    .HasColumnName("adjustment")
                    .HasColumnType("money");

                entity.Property(e => e.Attributeitemid).HasColumnName("attributeitemid");

                entity.Property(e => e.Attributetypeid).HasColumnName("attributetypeid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Skusuffix).HasColumnName("skusuffix");

                entity.HasOne(d => d.Attributeitem)
                    .WithMany(p => p.Attribute)
                    .HasForeignKey(d => d.Attributeitemid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attribute_attributeitem");

                entity.HasOne(d => d.Attributetype)
                    .WithMany(p => p.Attribute)
                    .HasForeignKey(d => d.Attributetypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attribute_attributetype");
            });

            modelBuilder.Entity<Attributebehavior>(entity =>
            {
                entity.ToTable("attributebehavior", "dbo");

                entity.Property(e => e.Attributebehaviorid)
                    .HasColumnName("attributebehaviorid")
                    .HasDefaultValueSql("nextval('dbo.attributebehavior_attributebehaviorid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Attributeevent>(entity =>
            {
                entity.ToTable("attributeevent", "dbo");

                entity.Property(e => e.Attributeeventid)
                    .HasColumnName("attributeeventid")
                    .HasDefaultValueSql("nextval('dbo.attributeevent_attributeeventid_seq'::regclass)");

                entity.Property(e => e.Attributebehaviorid).HasColumnName("attributebehaviorid");

                entity.Property(e => e.Attributeid).HasColumnName("attributeid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Eventdate)
                    .HasColumnName("eventdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Attributebehavior)
                    .WithMany(p => p.Attributeevent)
                    .HasForeignKey(d => d.Attributebehaviorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attribbutebehavior");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.Attributeevent)
                    .HasForeignKey(d => d.Attributeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_attributeevent_attribute");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attributeevent)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_attributeevent_user");
            });

            modelBuilder.Entity<Attributeitem>(entity =>
            {
                entity.ToTable("attributeitem", "dbo");

                entity.Property(e => e.Attributeitemid)
                    .HasColumnName("attributeitemid")
                    .HasDefaultValueSql("nextval('dbo.attributeitem_attributeitemid_seq'::regclass)");

                entity.Property(e => e.Attributetypeid).HasColumnName("attributetypeid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Label).HasColumnName("label");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Attributetype)
                    .WithMany(p => p.Attributeitem)
                    .HasForeignKey(d => d.Attributetypeid)
                    .HasConstraintName("fk_attributeitem_attributetype");
            });

            modelBuilder.Entity<Attributetype>(entity =>
            {
                entity.ToTable("attributetype", "dbo");

                entity.Property(e => e.Attributetypeid)
                    .HasColumnName("attributetypeid")
                    .HasDefaultValueSql("nextval('dbo.attributetype_attributetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Sort).HasColumnName("sort");
            });

            modelBuilder.Entity<Blacklistrepository>(entity =>
            {
                entity.HasKey(e => e.Blacklistrepoditoryid);

                entity.ToTable("blacklistrepository", "system");

                entity.Property(e => e.Blacklistrepoditoryid)
                    .HasColumnName("blacklistrepoditoryid")
                    .HasDefaultValueSql("nextval('system.blacklistrepository_blacklistrepoditoryid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Dateblacklisted)
                    .HasColumnName("dateblacklisted")
                    .HasColumnType("date");

                entity.Property(e => e.Dayblacklisted).HasColumnName("dayblacklisted");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note).HasColumnName("note");
            });

            modelBuilder.Entity<Cartresultproductmap>(entity =>
            {
                entity.HasKey(e => e.Cartresultproductid);

                entity.ToTable("cartresultproductmap", "rule");

                entity.Property(e => e.Cartresultproductid)
                    .HasColumnName("cartresultproductid")
                    .HasDefaultValueSql("nextval('rule.cartresultproductmap_cartresultproductid_seq'::regclass)");

                entity.Property(e => e.Cartruleresultid).HasColumnName("cartruleresultid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Cartruleresult)
                    .WithMany(p => p.Cartresultproductmap)
                    .HasForeignKey(d => d.Cartruleresultid)
                    .HasConstraintName("fk_cartreresult");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cartresultproductmap)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("fk_cartresultproductmap_product");
            });

            modelBuilder.Entity<Cartrulecondition>(entity =>
            {
                entity.ToTable("cartrulecondition", "rule");

                entity.Property(e => e.Cartruleconditionid)
                    .HasColumnName("cartruleconditionid")
                    .HasDefaultValueSql("nextval('rule.cartrulecondition_cartruleconditionid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Cartruleengineid).HasColumnName("cartruleengineid");

                entity.Property(e => e.Conditionmember)
                    .IsRequired()
                    .HasColumnName("conditionmember");

                entity.Property(e => e.Conditionvalue)
                    .IsRequired()
                    .HasColumnName("conditionvalue");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Ruleconditionoperatorid).HasColumnName("ruleconditionoperatorid");

                entity.HasOne(d => d.Cartruleengine)
                    .WithMany(p => p.Cartrulecondition)
                    .HasForeignKey(d => d.Cartruleengineid)
                    .HasConstraintName("fk_cartcondition_cartruleengine");

                entity.HasOne(d => d.Ruleconditionoperator)
                    .WithMany(p => p.Cartrulecondition)
                    .HasForeignKey(d => d.Ruleconditionoperatorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cartditionoperator");
            });

            modelBuilder.Entity<Cartruleengine>(entity =>
            {
                entity.ToTable("cartruleengine", "rule");

                entity.Property(e => e.Cartruleengineid)
                    .HasColumnName("cartruleengineid")
                    .HasDefaultValueSql("nextval('rule.cartruleengine_cartruleengineid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Cartrulescheduleid).HasColumnName("cartrulescheduleid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Cartruleschedule)
                    .WithMany(p => p.Cartruleengine)
                    .HasForeignKey(d => d.Cartrulescheduleid)
                    .HasConstraintName("fk_cartrule_reference_cartrule");
            });

            modelBuilder.Entity<Cartruleresult>(entity =>
            {
                entity.ToTable("cartruleresult", "rule");

                entity.Property(e => e.Cartruleresultid)
                    .HasColumnName("cartruleresultid")
                    .HasDefaultValueSql("nextval('rule.cartruleresult_cartruleresultid_seq'::regclass)");

                entity.Property(e => e.Cartruleengineid).HasColumnName("cartruleengineid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Resultvalue)
                    .IsRequired()
                    .HasColumnName("resultvalue");

                entity.Property(e => e.Ruleresultoperationid).HasColumnName("ruleresultoperationid");

                entity.HasOne(d => d.Cartruleengine)
                    .WithMany(p => p.Cartruleresult)
                    .HasForeignKey(d => d.Cartruleengineid)
                    .HasConstraintName("fk_cartresult_cartruleengine");

                entity.HasOne(d => d.Ruleresultoperation)
                    .WithMany(p => p.Cartruleresult)
                    .HasForeignKey(d => d.Ruleresultoperationid)
                    .HasConstraintName("fk_caltoperation");
            });

            modelBuilder.Entity<Cartruleschedule>(entity =>
            {
                entity.ToTable("cartruleschedule", "dbo");

                entity.Property(e => e.Cartrulescheduleid)
                    .HasColumnName("cartrulescheduleid")
                    .HasDefaultValueSql("nextval('dbo.cartruleschedule_cartrulescheduleid_seq'::regclass)");

                entity.Property(e => e.Branchid).HasColumnName("branchid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Cartruleshoppingcartmap>(entity =>
            {
                entity.HasKey(e => e.Cartruleshoppingcartid);

                entity.ToTable("cartruleshoppingcartmap", "rule");

                entity.Property(e => e.Cartruleshoppingcartid)
                    .HasColumnName("cartruleshoppingcartid")
                    .HasDefaultValueSql("nextval('rule.cartruleshoppingcartmap_cartruleshoppingcartid_seq'::regclass)");

                entity.Property(e => e.Applied).HasColumnName("applied");

                entity.Property(e => e.Cartruleengineid).HasColumnName("cartruleengineid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Promotioncode)
                    .IsRequired()
                    .HasColumnName("promotioncode");

                entity.Property(e => e.Shoppingcartid).HasColumnName("shoppingcartid");

                entity.HasOne(d => d.Cartruleengine)
                    .WithMany(p => p.Cartruleshoppingcartmap)
                    .HasForeignKey(d => d.Cartruleengineid)
                    .HasConstraintName("fk_cartruleengine");

                entity.HasOne(d => d.Shoppingcart)
                    .WithMany(p => p.Cartruleshoppingcartmap)
                    .HasForeignKey(d => d.Shoppingcartid)
                    .HasConstraintName("fk_cartrpingcart");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category", "dbo");

                entity.Property(e => e.Categoryid)
                    .HasColumnName("categoryid")
                    .HasDefaultValueSql("nextval('dbo.category_categoryid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Isdefault)
                    .HasColumnName("isdefault")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Parentid).HasColumnName("parentid");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.Parentid)
                    .HasConstraintName("fk_childrencategory_category");
            });

            modelBuilder.Entity<Categoryculturemap>(entity =>
            {
                entity.HasKey(e => e.Categorycultureid);

                entity.ToTable("categoryculturemap", "dbo");

                entity.Property(e => e.Categorycultureid)
                    .HasColumnName("categorycultureid")
                    .HasDefaultValueSql("nextval('dbo.categoryculturemap_categorycultureid_seq'::regclass)");

                entity.Property(e => e.Categoryalternativename).HasColumnName("categoryalternativename");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Metadescription).HasColumnName("metadescription");

                entity.Property(e => e.Metakeyword).HasColumnName("metakeyword");

                entity.Property(e => e.Metatitle).HasColumnName("metatitle");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Categoryculturemap)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoryculturemap_category");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Categoryculturemap)
                    .HasForeignKey(d => d.Cultureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoryculturemap_culture");
            });

            modelBuilder.Entity<Categoryimagemap>(entity =>
            {
                entity.HasKey(e => e.Categoryimageid);

                entity.ToTable("categoryimagemap", "dbo");

                entity.Property(e => e.Categoryimageid)
                    .HasColumnName("categoryimageid")
                    .HasDefaultValueSql("nextval('dbo.categoryimagemap_categoryimageid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Categoryimagemap)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoryimagemap_category");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Categoryimagemap)
                    .HasForeignKey(d => d.Imageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoryimagemap_image");
            });

            modelBuilder.Entity<Categoryproductmap>(entity =>
            {
                entity.HasKey(e => e.Categoryproductid);

                entity.ToTable("categoryproductmap", "dbo");

                entity.Property(e => e.Categoryproductid)
                    .HasColumnName("categoryproductid")
                    .HasDefaultValueSql("nextval('dbo.categoryproductmap_categoryproductid_seq'::regclass)");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Categoryproductmap)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoryproductmap_category");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Categoryproductmap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categories_products_products");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city", "geographic");

                entity.Property(e => e.Cityid)
                    .HasColumnName("cityid")
                    .HasDefaultValueSql("nextval('geographic.city_cityid_seq'::regclass)");

                entity.Property(e => e.City1)
                    .IsRequired()
                    .HasColumnName("city");

                entity.Property(e => e.Citycode).HasColumnName("citycode");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Dmaid).HasColumnName("dmaid");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Regionid).HasColumnName("regionid");

                entity.Property(e => e.Timezone).HasColumnName("timezone");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("fk_city_country");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.Regionid)
                    .HasConstraintName("fk_city_region");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment", "news");

                entity.Property(e => e.Commentid)
                    .HasColumnName("commentid")
                    .HasDefaultValueSql("nextval('news.comment_commentid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Articleid).HasColumnName("articleid");

                entity.Property(e => e.Body)
                    .HasColumnName("body");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.Articleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comment_article");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentNavigation)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comment_user");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact", "dbo");

                entity.Property(e => e.Contactid)
                    .HasColumnName("contactid")
                    .HasDefaultValueSql("nextval('dbo.contact_contactid_seq'::regclass)");

                entity.Property(e => e.Contacttypeid).HasColumnName("contacttypeid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Peopleid).HasColumnName("peopleid");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.HasOne(d => d.Contacttype)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.Contacttypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_contact_contacttype");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.Peopleid)
                    .HasConstraintName("fk_contact_people");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("fk_contact_supplier");
            });

            modelBuilder.Entity<Contacttype>(entity =>
            {
                entity.ToTable("contacttype", "dbo");

                entity.Property(e => e.Contacttypeid)
                    .HasColumnName("contacttypeid")
                    .HasDefaultValueSql("nextval('dbo.contacttype_contacttypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Contentblock>(entity =>
            {
                entity.ToTable("contentblock", "dbo");

                entity.Property(e => e.Contentblockid)
                    .HasColumnName("contentblockid")
                    .HasDefaultValueSql("nextval('dbo.contentblock_contentblockid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Contentblocktypeid).HasColumnName("contentblocktypeid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Pageid).HasColumnName("pageid");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.HasOne(d => d.Contentblocktype)
                    .WithMany(p => p.Contentblock)
                    .HasForeignKey(d => d.Contentblocktypeid)
                    .HasConstraintName("fk_contenttblocktype");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Contentblock)
                    .HasForeignKey(d => d.Pageid)
                    .HasConstraintName("fk_contentblock_page");
            });

            modelBuilder.Entity<Contentblockculturemap>(entity =>
            {
                entity.ToTable("contentblockculturemap", "dbo");

                entity.Property(e => e.Contentblockculturemapid)
                    .HasColumnName("contentblockculturemapid")
                    .HasDefaultValueSql("nextval('dbo.contentblockculturemap_contentblockculturemapid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Content)
                    .HasColumnName("content");

                entity.Property(e => e.Contentblockid).HasColumnName("contentblockid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.HasOne(d => d.Contentblock)
                    .WithMany(p => p.Contentblockculturemap)
                    .HasForeignKey(d => d.Contentblockid)
                    .HasConstraintName("fk_contentbloentblock");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Contentblockculturemap)
                    .HasForeignKey(d => d.Cultureid)
                    .HasConstraintName("fk_contemap_culture");
            });

            modelBuilder.Entity<Contentblocktype>(entity =>
            {
                entity.ToTable("contentblocktype", "dbo");

                entity.Property(e => e.Contentblocktypeid)
                    .HasColumnName("contentblocktypeid")
                    .HasDefaultValueSql("nextval('dbo.contentblocktype_contentblocktypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.ToTable("continent", "dbo");

                entity.Property(e => e.Continentid)
                    .HasColumnName("continentid")
                    .HasDefaultValueSql("nextval('dbo.continent_continentid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Geonameid).HasColumnName("geonameid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country", "geographic");

                entity.Property(e => e.Countryid)
                    .HasColumnName("countryid")
                    .HasDefaultValueSql("nextval('geographic.country_countryid_seq'::regclass)");

                entity.Property(e => e.Capital).HasColumnName("capital");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Continentid).HasColumnName("continentid");

                entity.Property(e => e.Country1)
                    .IsRequired()
                    .HasColumnName("country");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.Currencycode).HasColumnName("currencycode");

                entity.Property(e => e.Fips104).HasColumnName("fips104");

                entity.Property(e => e.Geonameid).HasColumnName("geonameid");

                entity.Property(e => e.Internet).HasColumnName("internet");

                entity.Property(e => e.Iso2).HasColumnName("iso2");

                entity.Property(e => e.Iso3).HasColumnName("iso3");

                entity.Property(e => e.Ison).HasColumnName("ison");

                entity.Property(e => e.Mapreference).HasColumnName("mapreference");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Nationalityplural).HasColumnName("nationalityplural");

                entity.Property(e => e.Nationalitysingular).HasColumnName("nationalitysingular");

                entity.Property(e => e.Population).HasColumnName("population");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.Continentid)
                    .HasConstraintName("fk_country_continent");
            });

            modelBuilder.Entity<Couponrepository>(entity =>
            {
                entity.ToTable("couponrepository", "dbo");

                entity.Property(e => e.Couponrepositoryid)
                    .HasColumnName("couponrepositoryid")
                    .HasDefaultValueSql("nextval('dbo.couponrepository_couponrepositoryid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Coinledgerid).HasColumnName("coinledgerid");

                entity.Property(e => e.Couponcode)
                    .HasColumnName("couponcode");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Dateused)
                    .HasColumnName("dateused")
                    .HasColumnType("date");

                entity.Property(e => e.Iotdeviceid).HasColumnName("iotdeviceid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Qrcoderepositoryid).HasColumnName("qrcoderepositoryid");

                entity.Property(e => e.Saleid).HasColumnName("saleid");

                entity.Property(e => e.Unlimited).HasColumnName("unlimited");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Couponrepository)
                    .HasForeignKey(d => d.Saleid)
                    .HasConstraintName("fk_couponrepository_sale");
            });

            modelBuilder.Entity<Creditcardtype>(entity =>
            {
                entity.ToTable("creditcardtype", "dbo");

                entity.Property(e => e.Creditcardtypeid)
                    .HasColumnName("creditcardtypeid")
                    .HasDefaultValueSql("nextval('dbo.creditcardtype_creditcardtypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Csvdelimiter>(entity =>
            {
                entity.ToTable("csvdelimiter", "export");

                entity.Property(e => e.Csvdelimiterid)
                    .HasColumnName("csvdelimiterid")
                    .HasDefaultValueSql("nextval('export.csvdelimiter_csvdelimiterid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Delimiter)
                    .IsRequired()
                    .HasColumnName("delimiter");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("culture", "dbo");

                entity.Property(e => e.Cultureid)
                    .HasColumnName("cultureid")
                    .HasDefaultValueSql("nextval('dbo.culture_cultureid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Defaultcurrencycode)
                    .HasColumnName("defaultcurrencycode")
                    .HasColumnType("char(3)");

                entity.Property(e => e.Defaultsizecode).HasColumnName("defaultsizecode");

                entity.Property(e => e.Defaultsizeunit).HasColumnName("defaultsizeunit");

                entity.Property(e => e.Defaultweightcode).HasColumnName("defaultweightcode");

                entity.Property(e => e.Defaultweightunit).HasColumnName("defaultweightunit");

                entity.Property(e => e.Languagecode)
                    .HasColumnName("languagecode")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("currency", "ll");

                entity.Property(e => e.Currencyid)
                    .HasColumnName("currencyid")
                    .HasDefaultValueSql("nextval('ll.currency_currencyid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customexport>(entity =>
            {
                entity.ToTable("customexport", "export");

                entity.Property(e => e.Customexportid)
                    .HasColumnName("customexportid")
                    .HasDefaultValueSql("nextval('export.customexport_customexportid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Defaultcsvdelimiter).HasColumnName("defaultcsvdelimiter");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Sourcetypeid).HasColumnName("sourcetypeid");

                entity.HasOne(d => d.DefaultcsvdelimiterNavigation)
                    .WithMany(p => p.Customexport)
                    .HasForeignKey(d => d.Defaultcsvdelimiter)
                    .HasConstraintName("fk_customexport_csvdelimiter");

                entity.HasOne(d => d.Sourcetype)
                    .WithMany(p => p.Customexport)
                    .HasForeignKey(d => d.Sourcetypeid)
                    .HasConstraintName("fk_customexport_sourcetype");
            });

            modelBuilder.Entity<Deliverymethod>(entity =>
            {
                entity.ToTable("deliverymethod", "dbo");

                entity.Property(e => e.Deliverymethodid)
                    .HasColumnName("deliverymethodid")
                    .HasDefaultValueSql("nextval('dbo.deliverymethod_deliverymethodid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Dreamcomment>(entity =>
            {
                entity.HasKey(e => e.Commentid);

                entity.ToTable("dreamcomment", "dream");

                entity.Property(e => e.Commentid)
                    .HasColumnName("commentid")
                    .HasDefaultValueSql("nextval('dream.dreamcomment_commentid_seq'::regclass)");

                entity.Property(e => e.Content)
                    .HasColumnName("content");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Vote).HasColumnName("vote");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Dreamcomment)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("fk_dreamcomment_dreamproduct");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dreamcomment)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_dreamcomment_user");
            });

            modelBuilder.Entity<Dreamimage>(entity =>
            {
                entity.ToTable("dreamimage", "dream");

                entity.Property(e => e.Dreamimageid)
                    .HasColumnName("dreamimageid")
                    .HasDefaultValueSql("nextval('dream.dreamimage_dreamimageid_seq'::regclass)");

                entity.Property(e => e.Caption).HasColumnName("caption");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Fullimageurl)
                    .IsRequired()
                    .HasColumnName("fullimageurl");

                entity.Property(e => e.Imagetypeid).HasColumnName("imagetypeid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Thumburl).HasColumnName("thumburl");

                entity.HasOne(d => d.Imagetype)
                    .WithMany(p => p.Dreamimage)
                    .HasForeignKey(d => d.Imagetypeid)
                    .HasConstraintName("fk_deamimage_imagetype");
            });

            modelBuilder.Entity<Dreamproduct>(entity =>
            {
                entity.HasKey(e => e.Productid);

                entity.ToTable("dreamproduct", "dream");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasDefaultValueSql("nextval('dream.dreamproduct_productid_seq'::regclass)");

                entity.Property(e => e.Content)
                    .HasColumnName("content");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Views).HasColumnName("views");

                entity.Property(e => e.Vote).HasColumnName("vote");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dreamproduct)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_dreamproduct_user");
            });

            modelBuilder.Entity<Dreamproductimagemap>(entity =>
            {
                entity.HasKey(e => e.Dreamproductimageid);

                entity.ToTable("dreamproductimagemap", "dream");

                entity.Property(e => e.Dreamproductimageid)
                    .HasColumnName("dreamproductimageid")
                    .HasDefaultValueSql("nextval('dream.dreamproductimagemap_dreamproductimageid_seq'::regclass)");

                entity.Property(e => e.Activate)
                    .HasColumnName("activate")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Dreamimageid).HasColumnName("dreamimageid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Dreamimage)
                    .WithMany(p => p.Dreamproductimagemap)
                    .HasForeignKey(d => d.Dreamimageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dreamprmimage");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Dreamproductimagemap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dreamamproduct");
            });

            modelBuilder.Entity<Encryptiontype>(entity =>
            {
                entity.HasKey(e => e.Encryptionid);

                entity.ToTable("encryptiontype", "dbo");

                entity.Property(e => e.Encryptionid)
                    .HasColumnName("encryptionid")
                    .HasDefaultValueSql("nextval('dbo.encryptiontype_encryptionid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Encryptionname)
                    .IsRequired()
                    .HasColumnName("encryptionname");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Genericattribute>(entity =>
            {
                entity.ToTable("genericattribute", "system");

                entity.Property(e => e.Genericattributeid)
                    .HasColumnName("genericattributeid")
                    .HasDefaultValueSql("nextval('system.genericattribute_genericattributeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Genericattributetypeid).HasColumnName("genericattributetypeid");

                entity.Property(e => e.Genericattributevalueid).HasColumnName("genericattributevalueid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Typelabelstring)
                    .HasColumnName("typelabelstring");

                entity.Property(e => e.Typestring).HasColumnName("typestring");

                entity.Property(e => e.Valuelabelstring)
                    .HasColumnName("valuelabelstring");

                entity.Property(e => e.Valuestring)
                    .HasColumnName("valuestring");

                entity.HasOne(d => d.Genericattributetype)
                    .WithMany(p => p.Genericattribute)
                    .HasForeignKey(d => d.Genericattributetypeid)
                    .HasConstraintName("fk_generica_fk_generi_generica");

                entity.HasOne(d => d.Genericattributevalue)
                    .WithMany(p => p.Genericattribute)
                    .HasForeignKey(d => d.Genericattributevalueid)
                    .HasConstraintName("fk_genericattribute_value");
            });

            modelBuilder.Entity<Genericattributetype>(entity =>
            {
                entity.ToTable("genericattributetype", "system");

                entity.Property(e => e.Genericattributetypeid)
                    .HasColumnName("genericattributetypeid")
                    .HasDefaultValueSql("nextval('system.genericattributetype_genericattributetypeid_seq'::regclass)");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Metatypelabel)
                    .HasColumnName("metatypelabel");

                entity.Property(e => e.Metatypestring).HasColumnName("metatypestring");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Valuebool).HasColumnName("valuebool");

                entity.Property(e => e.Valuedate)
                    .HasColumnName("valuedate")
                    .HasColumnType("date");

                entity.Property(e => e.Valuelabelbool).HasColumnName("valuelabelbool");

                entity.Property(e => e.Valuelabeldate)
                    .HasColumnName("valuelabeldate")
                    .HasColumnType("date");

                entity.Property(e => e.Valuelabelnumber)
                    .HasColumnName("valuelabelnumber")
                    .HasColumnType("numeric(12, 4)");

                entity.Property(e => e.Valuelabelstring)
                    .HasColumnName("valuelabelstring");

                entity.Property(e => e.Valuenumber)
                    .HasColumnName("valuenumber")
                    .HasColumnType("numeric(12, 4)");

                entity.Property(e => e.Valuestring)
                    .HasColumnName("valuestring");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Genericattributetype)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("fk_generica_reference_category");
            });

            modelBuilder.Entity<Genericattributevalue>(entity =>
            {
                entity.ToTable("genericattributevalue", "system");

                entity.Property(e => e.Genericattributevalueid)
                    .HasColumnName("genericattributevalueid")
                    .HasDefaultValueSql("nextval('system.genericattributevalue_genericattributevalueid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Label)
                    .HasColumnName("label");

                entity.Property(e => e.Metatypelabel)
                    .HasColumnName("metatypelabel");

                entity.Property(e => e.Metatypestring)
                    .HasColumnName("metatypestring");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .HasColumnName("name");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Valuebool).HasColumnName("valuebool");

                entity.Property(e => e.Valuedate)
                    .HasColumnName("valuedate")
                    .HasColumnType("date");

                entity.Property(e => e.Valuelabelbool).HasColumnName("valuelabelbool");

                entity.Property(e => e.Valuelabeldate)
                    .HasColumnName("valuelabeldate")
                    .HasColumnType("date");

                entity.Property(e => e.Valuelabelnumber)
                    .HasColumnName("valuelabelnumber")
                    .HasColumnType("numeric(12, 4)");

                entity.Property(e => e.Valuelabelstring)
                    .HasColumnName("valuelabelstring");

                entity.Property(e => e.Valuenumber)
                    .HasColumnName("valuenumber")
                    .HasColumnType("numeric(12, 4)");

                entity.Property(e => e.Valuestring)
                    .HasColumnName("valuestring");
            });

            modelBuilder.Entity<Globalsetting>(entity =>
            {
                entity.ToTable("globalsetting", "system");

                entity.Property(e => e.Globalsettingid)
                    .HasColumnName("globalsettingid")
                    .HasDefaultValueSql("nextval('system.globalsetting_globalsettingid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Globalsettingtypeid).HasColumnName("globalsettingtypeid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.Globalsettingtype)
                    .WithMany(p => p.Globalsetting)
                    .HasForeignKey(d => d.Globalsettingtypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_globallsettingtype");
            });

            modelBuilder.Entity<Globalsettingtype>(entity =>
            {
                entity.ToTable("globalsettingtype", "system");

                entity.Property(e => e.Globalsettingtypeid)
                    .HasColumnName("globalsettingtypeid")
                    .HasDefaultValueSql("nextval('system.globalsettingtype_globalsettingtypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Headerimage>(entity =>
            {
                entity.ToTable("headerimage", "dbo");

                entity.Property(e => e.Headerimageid)
                    .HasColumnName("headerimageid")
                    .HasDefaultValueSql("nextval('dbo.headerimage_headerimageid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Headerimagetypeid).HasColumnName("headerimagetypeid");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.HasOne(d => d.Headerimagetype)
                    .WithMany(p => p.Headerimage)
                    .HasForeignKey(d => d.Headerimagetypeid)
                    .HasConstraintName("fk_headerimage_headerimagetype");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Headerimage)
                    .HasForeignKey(d => d.Imageid)
                    .HasConstraintName("fk_headerimage_image");
            });

            modelBuilder.Entity<Headerimagetype>(entity =>
            {
                entity.ToTable("headerimagetype", "dbo");

                entity.Property(e => e.Headerimagetypeid)
                    .HasColumnName("headerimagetypeid")
                    .HasDefaultValueSql("nextval('dbo.headerimagetype_headerimagetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image", "dbo");

                entity.Property(e => e.Imageid)
                    .HasColumnName("imageid")
                    .HasDefaultValueSql("nextval('dbo.image_imageid_seq'::regclass)");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Fullimageurl)
                    .IsRequired()
                    .HasColumnName("fullimageurl");

                entity.Property(e => e.Imagetypeid).HasColumnName("imagetypeid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Thumburl).HasColumnName("thumburl");

                entity.HasOne(d => d.Imagetype)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.Imagetypeid)
                    .HasConstraintName("fk_image_imagetype");
            });

            modelBuilder.Entity<Imagetype>(entity =>
            {
                entity.ToTable("imagetype", "dbo");

                entity.Property(e => e.Imagetypeid)
                    .HasColumnName("imagetypeid")
                    .HasDefaultValueSql("nextval('dbo.imagetype_imagetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Instantnotification>(entity =>
            {
                entity.ToTable("instantnotification", "dbo");

                entity.Property(e => e.Instantnotificationid)
                    .HasColumnName("instantnotificationid")
                    .HasDefaultValueSql("nextval('dbo.instantnotification_instantnotificationid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Delay).HasColumnName("delay");

                entity.Property(e => e.Instantnotificationtypeid).HasColumnName("instantnotificationtypeid");

                entity.Property(e => e.Ishtml).HasColumnName("ishtml");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Notification)
                    .IsRequired()
                    .HasColumnName("notification");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Sticky).HasColumnName("sticky");

                entity.HasOne(d => d.Instantnotificationtype)
                    .WithMany(p => p.Instantnotification)
                    .HasForeignKey(d => d.Instantnotificationtypeid)
                    .HasConstraintName("fk_instatantnotificationtype");
            });

            modelBuilder.Entity<Instantnotificationpagemap>(entity =>
            {
                entity.HasKey(e => e.Instantnotificationpageid);

                entity.ToTable("instantnotificationpagemap", "dbo");

                entity.Property(e => e.Instantnotificationpageid)
                    .HasColumnName("instantnotificationpageid")
                    .HasDefaultValueSql("nextval('dbo.instantnotificationpagemap_instantnotificationpageid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Instantnotificationid).HasColumnName("instantnotificationid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Pageid).HasColumnName("pageid");

                entity.HasOne(d => d.Instantnotification)
                    .WithMany(p => p.Instantnotificationpagemap)
                    .HasForeignKey(d => d.Instantnotificationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_instantnotantnotification");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Instantnotificationpagemap)
                    .HasForeignKey(d => d.Pageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_instantn_reference_page");
            });

            modelBuilder.Entity<Instantnotificationtype>(entity =>
            {
                entity.ToTable("instantnotificationtype", "dbo");

                entity.Property(e => e.Instantnotificationtypeid)
                    .HasColumnName("instantnotificationtypeid")
                    .HasDefaultValueSql("nextval('dbo.instantnotificationtype_instantnotificationtypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Notificationtype)
                    .IsRequired()
                    .HasColumnName("notificationtype");
            });

            modelBuilder.Entity<Inventoryrecord>(entity =>
            {
                entity.ToTable("inventoryrecord", "dbo");

                entity.Property(e => e.Inventoryrecordid)
                    .HasColumnName("inventoryrecordid")
                    .HasDefaultValueSql("nextval('dbo.inventoryrecord_inventoryrecordid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Dateentered)
                    .HasColumnName("dateentered")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Increment)
                    .HasColumnName("increment")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Productinventoryid).HasColumnName("productinventoryid");

                entity.Property(e => e.Productwarehouseid).HasColumnName("productwarehouseid");

                entity.HasOne(d => d.Productinventory)
                    .WithMany(p => p.Inventoryrecord)
                    .HasForeignKey(d => d.Productinventoryid)
                    .HasConstraintName("fk_inventuctinventory");

                entity.HasOne(d => d.Productwarehouse)
                    .WithMany(p => p.Inventoryrecord)
                    .HasForeignKey(d => d.Productwarehouseid)
                    .HasConstraintName("fk_invenuctwarehouse");
            });

            modelBuilder.Entity<Inventorystatus>(entity =>
            {
                entity.ToTable("inventorystatus", "dbo");

                entity.Property(e => e.Inventorystatusid)
                    .HasColumnName("inventorystatusid")
                    .HasDefaultValueSql("nextval('dbo.inventorystatus_inventorystatusid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Ledgeruseraddressmap>(entity =>
            {
                entity.ToTable("ledgeruseraddressmap", "ll");

                entity.Property(e => e.Ledgeruseraddressmapid)
                    .HasColumnName("ledgeruseraddressmapid")
                    .HasDefaultValueSql("nextval('ll.ledgeruseraddressmap_ledgeruseraddressmapid_seq'::regclass)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.Memobc).HasColumnName("memobc");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Ledgeruseraddressmap)
                    .HasForeignKey(d => d.Currencyid)
                    .HasConstraintName("fk_ledgerus_reference_currency");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ledgeruseraddressmap)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_ledgerus_reference_user");
            });

            modelBuilder.Entity<Ledgerusers>(entity =>
            {
                entity.HasKey(e => e.Bitsharesaccountid);

                entity.ToTable("ledgerusers", "ll");

                entity.Property(e => e.Bitsharesaccountid)
                    .HasColumnName("bitsharesaccountid")
                    .HasDefaultValueSql("nextval('ll.ledgerusers_bitsharesaccountid_seq'::regclass)");

                entity.Property(e => e.Bitsharesaccount).HasColumnName("bitsharesaccount");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ledgerusers)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_ledgerus_reference_user");
            });

            modelBuilder.Entity<Letter>(entity =>
            {
                entity.ToTable("letter", "news");

                entity.Property(e => e.Letterid)
                    .HasColumnName("letterid")
                    .HasDefaultValueSql("nextval('news.letter_letterid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log", "system");

                entity.Property(e => e.Logid)
                    .HasColumnName("logid")
                    .HasDefaultValueSql("nextval('system.log_logid_seq'::regclass)");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Controller).HasColumnName("controller");

                entity.Property(e => e.Logdate)
                    .HasColumnName("logdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Logger)
                    .IsRequired()
                    .HasColumnName("logger");

                entity.Property(e => e.Logguid).HasColumnName("logguid");

                entity.Property(e => e.Loginfo)
                    .IsRequired()
                    .HasColumnName("loginfo");

                entity.Property(e => e.Loglevel)
                    .IsRequired()
                    .HasColumnName("loglevel");

                entity.Property(e => e.Logmessage)
                    .HasColumnName("logmessage");

                entity.Property(e => e.Thread)
                    .IsRequired()
                    .HasColumnName("thread");
            });

            modelBuilder.Entity<Mailertemplate>(entity =>
            {
                entity.ToTable("mailertemplate", "dbo");

                entity.Property(e => e.Mailertemplateid)
                    .HasColumnName("mailertemplateid")
                    .HasDefaultValueSql("nextval('dbo.mailertemplate_mailertemplateid_seq'::regclass)");

                entity.Property(e => e.Body)
                    .HasColumnName("body");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Isdefault).HasColumnName("isdefault");

                entity.Property(e => e.Ishtml)
                    .HasColumnName("ishtml")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Mailertypeid).HasColumnName("mailertypeid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Mailertemplate)
                    .HasForeignKey(d => d.Cultureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mailerculturedetail_culture");

                entity.HasOne(d => d.Mailertype)
                    .WithMany(p => p.Mailertemplate)
                    .HasForeignKey(d => d.Mailertypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mailerctemplates");
            });

            modelBuilder.Entity<Mailertemplatetype>(entity =>
            {
                entity.HasKey(e => e.Mailertypeid);

                entity.ToTable("mailertemplatetype", "dbo");

                entity.Property(e => e.Mailertypeid)
                    .HasColumnName("mailertypeid")
                    .HasDefaultValueSql("nextval('dbo.mailertemplatetype_mailertypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Mailinglist>(entity =>
            {
                entity.ToTable("mailinglist", "dbo");

                entity.Property(e => e.Mailinglistid)
                    .HasColumnName("mailinglistid")
                    .HasDefaultValueSql("nextval('dbo.mailinglist_mailinglistid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Mailertemplateid).HasColumnName("mailertemplateid");

                entity.Property(e => e.Mailinglistcode).HasColumnName("mailinglistcode");

                entity.Property(e => e.Mailinglistpeoplegroupid).HasColumnName("mailinglistpeoplegroupid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Mailertemplate)
                    .WithMany(p => p.Mailinglist)
                    .HasForeignKey(d => d.Mailertemplateid)
                    .HasConstraintName("fk_mailinglist_mailertemplate");

                entity.HasOne(d => d.Mailinglistpeoplegroup)
                    .WithMany(p => p.Mailinglist)
                    .HasForeignKey(d => d.Mailinglistpeoplegroupid)
                    .HasConstraintName("fk_maileoplegroup");
            });

            modelBuilder.Entity<Mailinglistcontentblockmap>(entity =>
            {
                entity.HasKey(e => e.Mailinglistcontentblockid);

                entity.ToTable("mailinglistcontentblockmap", "dbo");

                entity.Property(e => e.Mailinglistcontentblockid)
                    .HasColumnName("mailinglistcontentblockid")
                    .HasDefaultValueSql("nextval('dbo.mailinglistcontentblockmap_mailinglistcontentblockid_seq'::regclass)");

                entity.Property(e => e.Contentblockid).HasColumnName("contentblockid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Mailinglistcontentblocktypeid).HasColumnName("mailinglistcontentblocktypeid");

                entity.Property(e => e.Mailinglistid).HasColumnName("mailinglistid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.HasOne(d => d.Contentblock)
                    .WithMany(p => p.Mailinglistcontentblockmap)
                    .HasForeignKey(d => d.Contentblockid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_macontentblock");

                entity.HasOne(d => d.Mailinglistcontentblocktype)
                    .WithMany(p => p.Mailinglistcontentblockmap)
                    .HasForeignKey(d => d.Mailinglistcontentblocktypeid)
                    .HasConstraintName("fk_mailingocktype");

                entity.HasOne(d => d.Mailinglist)
                    .WithMany(p => p.Mailinglistcontentblockmap)
                    .HasForeignKey(d => d.Mailinglistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mailinglilinglist");
            });

            modelBuilder.Entity<Mailinglistcontentblocktype>(entity =>
            {
                entity.ToTable("mailinglistcontentblocktype", "dbo");

                entity.Property(e => e.Mailinglistcontentblocktypeid)
                    .HasColumnName("mailinglistcontentblocktypeid")
                    .HasDefaultValueSql("nextval('dbo.mailinglistcontentblocktype_mailinglistcontentblocktypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Mailinglistimagemap>(entity =>
            {
                entity.HasKey(e => e.Mailinglistimageid);

                entity.ToTable("mailinglistimagemap", "dbo");

                entity.Property(e => e.Mailinglistimageid)
                    .HasColumnName("mailinglistimageid")
                    .HasDefaultValueSql("nextval('dbo.mailinglistimagemap_mailinglistimageid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Mailinglistid).HasColumnName("mailinglistid");

                entity.Property(e => e.Mailinglistimagetypeid).HasColumnName("mailinglistimagetypeid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Mailinglistimagemap)
                    .HasForeignKey(d => d.Imageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mailinglistimagemap_image");

                entity.HasOne(d => d.Mailinglist)
                    .WithMany(p => p.Mailinglistimagemap)
                    .HasForeignKey(d => d.Mailinglistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mailiailinglist");

                entity.HasOne(d => d.Mailinglistimagetype)
                    .WithMany(p => p.Mailinglistimagemap)
                    .HasForeignKey(d => d.Mailinglistimagetypeid)
                    .HasConstraintName("fk_mailinimagetype");
            });

            modelBuilder.Entity<Mailinglistimagetype>(entity =>
            {
                entity.ToTable("mailinglistimagetype", "dbo");

                entity.Property(e => e.Mailinglistimagetypeid)
                    .HasColumnName("mailinglistimagetypeid")
                    .HasDefaultValueSql("nextval('dbo.mailinglistimagetype_mailinglistimagetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Mailinglistpeoplegroup>(entity =>
            {
                entity.ToTable("mailinglistpeoplegroup", "dbo");

                entity.Property(e => e.Mailinglistpeoplegroupid)
                    .HasColumnName("mailinglistpeoplegroupid")
                    .HasDefaultValueSql("nextval('dbo.mailinglistpeoplegroup_mailinglistpeoplegroupid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Private).HasColumnName("private");
            });

            modelBuilder.Entity<Mailinglistpeoplemap>(entity =>
            {
                entity.HasKey(e => e.Mailinglistpeopleid);

                entity.ToTable("mailinglistpeoplemap", "dbo");

                entity.Property(e => e.Mailinglistpeopleid)
                    .HasColumnName("mailinglistpeopleid")
                    .HasDefaultValueSql("nextval('dbo.mailinglistpeoplemap_mailinglistpeopleid_seq'::regclass)");

                entity.Property(e => e.Activate)
                    .HasColumnName("activate")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Mailinglistpeoplegroupid).HasColumnName("mailinglistpeoplegroupid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Peopleid).HasColumnName("peopleid");

                entity.HasOne(d => d.Mailinglistpeoplegroup)
                    .WithMany(p => p.Mailinglistpeoplemap)
                    .HasForeignKey(d => d.Mailinglistpeoplegroupid)
                    .HasConstraintName("fk_mailinoplegroup");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Mailinglistpeoplemap)
                    .HasForeignKey(d => d.Peopleid)
                    .HasConstraintName("fk_mailinglistpeoplemap_people");
            });

            modelBuilder.Entity<Mailinglistproductmap>(entity =>
            {
                entity.HasKey(e => e.Mailinglistproductid);

                entity.ToTable("mailinglistproductmap", "dbo");

                entity.Property(e => e.Mailinglistproductid)
                    .HasColumnName("mailinglistproductid")
                    .HasDefaultValueSql("nextval('dbo.mailinglistproductmap_mailinglistproductid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Mailinglistid).HasColumnName("mailinglistid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.HasOne(d => d.Mailinglist)
                    .WithMany(p => p.Mailinglistproductmap)
                    .HasForeignKey(d => d.Mailinglistid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mailinilinglist");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Mailinglistproductmap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mailinproduct");
            });

            modelBuilder.Entity<Mailinglistqueue>(entity =>
            {
                entity.ToTable("mailinglistqueue", "queue");

                entity.Property(e => e.Mailinglistqueueid)
                    .HasColumnName("mailinglistqueueid")
                    .HasDefaultValueSql("nextval('queue.mailinglistqueue_mailinglistqueueid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Mailertemplateid).HasColumnName("mailertemplateid");

                entity.Property(e => e.Mailinglistid).HasColumnName("mailinglistid");

                entity.Property(e => e.Mailinglistpeopleid).HasColumnName("mailinglistpeopleid");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Queuestatusid).HasColumnName("queuestatusid");

                entity.HasOne(d => d.Mailertemplate)
                    .WithMany(p => p.Mailinglistqueue)
                    .HasForeignKey(d => d.Mailertemplateid)
                    .HasConstraintName("fk_maililertemplate");

                entity.HasOne(d => d.Mailinglist)
                    .WithMany(p => p.Mailinglistqueue)
                    .HasForeignKey(d => d.Mailinglistid)
                    .HasConstraintName("fk_mailinglistqueue_mailinglist");

                entity.HasOne(d => d.Mailinglistpeople)
                    .WithMany(p => p.Mailinglistqueue)
                    .HasForeignKey(d => d.Mailinglistpeopleid)
                    .HasConstraintName("fk_mailipeoplemap");

                entity.HasOne(d => d.Queuestatus)
                    .WithMany(p => p.Mailinglistqueue)
                    .HasForeignKey(d => d.Queuestatusid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mailinglistqueue_queuestatus");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "dbo");

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .HasDefaultValueSql("nextval('dbo.\"Order_orderid_seq\"'::regclass)");

                entity.Property(e => e.Billingaddressid).HasColumnName("billingaddressid");

                entity.Property(e => e.Coinid).HasColumnName("coinid");

                entity.Property(e => e.Couponamount)
                    .HasColumnName("couponamount")
                    .HasColumnType("money");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Dateshipped)
                    .HasColumnName("dateshipped")
                    .HasColumnType("date");

                entity.Property(e => e.Estimateddelivery)
                    .HasColumnName("estimateddelivery")
                    .HasColumnType("date");

                entity.Property(e => e.Executedon)
                    .HasColumnName("executedon")
                    .HasColumnType("date");

                entity.Property(e => e.Finaltotal)
                    .HasColumnName("finaltotal")
                    .HasColumnType("money");

                entity.Property(e => e.Grandtotal)
                    .HasColumnName("grandtotal")
                    .HasColumnType("money");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Ordernumber).HasColumnName("ordernumber");

                entity.Property(e => e.Orderstatusid).HasColumnName("orderstatusid");

                entity.Property(e => e.Shippingaddressid).HasColumnName("shippingaddressid");

                entity.Property(e => e.Shippingamount)
                    .HasColumnName("shippingamount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Subshippingtotal)
                    .HasColumnName("subshippingtotal")
                    .HasColumnType("money");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Subweeetotal)
                    .HasColumnName("subweeetotal")
                    .HasColumnType("money");

                entity.Property(e => e.Taxamount)
                    .HasColumnName("taxamount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Trackingnumber).HasColumnName("trackingnumber");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Weeeamount)
                    .HasColumnName("weeeamount")
                    .HasColumnType("money");

                entity.HasOne(d => d.Billingaddress)
                    .WithMany(p => p.OrderBillingaddress)
                    .HasForeignKey(d => d.Billingaddressid)
                    .HasConstraintName("fk_orderbilling_addresses");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Cultureid)
                    .HasConstraintName("fk_order_culture");

                entity.HasOne(d => d.Orderstatus)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Orderstatusid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_orderstatus");

                entity.HasOne(d => d.Shippingaddress)
                    .WithMany(p => p.OrderShippingaddress)
                    .HasForeignKey(d => d.Shippingaddressid)
                    .HasConstraintName("fk_ordershipping_address");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_order_user");
            });

            modelBuilder.Entity<Ordercouponmap>(entity =>
            {
                entity.HasKey(e => e.Ordercouponid);

                entity.ToTable("ordercouponmap", "dbo");

                entity.Property(e => e.Ordercouponid)
                    .HasColumnName("ordercouponid")
                    .HasDefaultValueSql("nextval('dbo.ordercouponmap_ordercouponid_seq'::regclass)");

                entity.Property(e => e.Couponrepositoryid).HasColumnName("couponrepositoryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.HasOne(d => d.Couponrepository)
                    .WithMany(p => p.Ordercouponmap)
                    .HasForeignKey(d => d.Couponrepositoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordercoupon_couponrepository");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ordercouponmap)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordercoupon_order");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.ToTable("orderitem", "dbo");

                entity.Property(e => e.Orderitemid)
                    .HasColumnName("orderitemid")
                    .HasDefaultValueSql("nextval('dbo.orderitem_orderitemid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Discountamount)
                    .HasColumnName("discountamount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Grandprice)
                    .HasColumnName("grandprice")
                    .HasColumnType("money");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Totalprice)
                    .HasColumnName("totalprice")
                    .HasColumnType("money");

                entity.Property(e => e.Totaltaxprice)
                    .HasColumnName("totaltaxprice")
                    .HasColumnType("money");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("unitprice")
                    .HasColumnType("money");

                entity.Property(e => e.Unittaxprice)
                    .HasColumnName("unittaxprice")
                    .HasColumnType("money");

                entity.Property(e => e.Weeeprice)
                    .HasColumnName("weeeprice")
                    .HasColumnType("money");

                entity.Property(e => e.Weeetaxprice)
                    .HasColumnName("weeetaxprice")
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitem)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderitem_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitem)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shoppingcartitem_product");
            });

            modelBuilder.Entity<Orderitempackagemap>(entity =>
            {
                entity.HasKey(e => e.Orderitempackageid);

                entity.ToTable("orderitempackagemap", "dbo");

                entity.Property(e => e.Orderitempackageid)
                    .HasColumnName("orderitempackageid")
                    .HasDefaultValueSql("nextval('dbo.orderitempackagemap_orderitempackageid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Orderitemid).HasColumnName("orderitemid");

                entity.Property(e => e.Orderpackageid).HasColumnName("orderpackageid");

                entity.Property(e => e.Quantitypackaged).HasColumnName("quantitypackaged");

                entity.HasOne(d => d.Orderitem)
                    .WithMany(p => p.Orderitempackagemap)
                    .HasForeignKey(d => d.Orderitemid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordertem");

                entity.HasOne(d => d.Orderpackage)
                    .WithMany(p => p.Orderitempackagemap)
                    .HasForeignKey(d => d.Orderpackageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordederpackage");
            });

            modelBuilder.Entity<Orderitemsuppliermap>(entity =>
            {
                entity.ToTable("orderitemsuppliermap", "dbo");

                entity.Property(e => e.Orderitemsuppliermapid)
                    .HasColumnName("orderitemsuppliermapid")
                    .HasDefaultValueSql("nextval('dbo.orderitemsuppliermap_orderitemsuppliermapid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Ordersupplierid).HasColumnName("ordersupplierid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Realquantity).HasColumnName("realquantity");

                entity.Property(e => e.Totalprice)
                    .HasColumnName("totalprice")
                    .HasColumnType("money");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("unitprice")
                    .HasColumnType("money");

                entity.Property(e => e.Validate).HasColumnName("validate");

                entity.HasOne(d => d.Ordersupplier)
                    .WithMany(p => p.Orderitemsuppliermap)
                    .HasForeignKey(d => d.Ordersupplierid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordersupplier");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitemsuppliermap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderitemsuppliermap_product");
            });

            modelBuilder.Entity<Ordermailqueue>(entity =>
            {
                entity.ToTable("ordermailqueue", "queue");

                entity.Property(e => e.Ordermailqueueid)
                    .HasColumnName("ordermailqueueid")
                    .HasDefaultValueSql("nextval('queue.ordermailqueue_ordermailqueueid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Mailertemplateid).HasColumnName("mailertemplateid");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Queuestatusid).HasColumnName("queuestatusid");

                entity.HasOne(d => d.Mailertemplate)
                    .WithMany(p => p.Ordermailqueue)
                    .HasForeignKey(d => d.Mailertemplateid)
                    .HasConstraintName("fk_ordemplate");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ordermailqueue)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("fk_ordermailqueue_order");

                entity.HasOne(d => d.Queuestatus)
                    .WithMany(p => p.Ordermailqueue)
                    .HasForeignKey(d => d.Queuestatusid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordermailqueue_queuestatus");
            });

            modelBuilder.Entity<Ordernote>(entity =>
            {
                entity.ToTable("ordernote", "dbo");

                entity.Property(e => e.Ordernoteid)
                    .HasColumnName("ordernoteid")
                    .HasDefaultValueSql("nextval('dbo.ordernote_ordernoteid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note)
                    .HasColumnName("note");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Ordernotetypeid).HasColumnName("ordernotetypeid");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ordernote)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("fk_ordernote_order");

                entity.HasOne(d => d.Ordernotetype)
                    .WithMany(p => p.Ordernote)
                    .HasForeignKey(d => d.Ordernotetypeid)
                    .HasConstraintName("fk_ordernote_ordernotetype");
            });

            modelBuilder.Entity<Ordernotetype>(entity =>
            {
                entity.ToTable("ordernotetype", "dbo");

                entity.Property(e => e.Ordernotetypeid)
                    .HasColumnName("ordernotetypeid")
                    .HasDefaultValueSql("nextval('dbo.ordernotetype_ordernotetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Orderpackage>(entity =>
            {
                entity.ToTable("orderpackage", "dbo");

                entity.Property(e => e.Orderpackageid)
                    .HasColumnName("orderpackageid")
                    .HasDefaultValueSql("nextval('dbo.orderpackage_orderpackageid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .HasColumnName("description");

                entity.Property(e => e.Estimatedshippingcost)
                    .HasColumnName("estimatedshippingcost")
                    .HasColumnType("money");

                entity.Property(e => e.Hasshipped).HasColumnName("hasshipped");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Shipdate)
                    .HasColumnName("shipdate")
                    .HasColumnType("date");

                entity.Property(e => e.Shippingmethodid).HasColumnName("shippingmethodid");

                entity.Property(e => e.Timeintransit).HasColumnName("timeintransit");

                entity.Property(e => e.Trackingnumber)
                    .IsRequired()
                    .HasColumnName("trackingnumber");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasColumnType("numeric(18, 4)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderpackage)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("fk_orderpackage_order");

                entity.HasOne(d => d.Shippingmethod)
                    .WithMany(p => p.Orderpackage)
                    .HasForeignKey(d => d.Shippingmethodid)
                    .HasConstraintName("fk_orderpackage_shippingmethod");
            });

            modelBuilder.Entity<Ordershippingmethodmap>(entity =>
            {
                entity.HasKey(e => e.Ordershippingmethodid);

                entity.ToTable("ordershippingmethodmap", "dbo");

                entity.Property(e => e.Ordershippingmethodid)
                    .HasColumnName("ordershippingmethodid")
                    .HasDefaultValueSql("nextval('dbo.ordershippingmethodmap_ordershippingmethodid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Discountamount)
                    .HasColumnName("discountamount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Grandprice)
                    .HasColumnName("grandprice")
                    .HasColumnType("money");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Shippingmethodid).HasColumnName("shippingmethodid");

                entity.Property(e => e.Totalprice)
                    .HasColumnName("totalprice")
                    .HasColumnType("money");

                entity.Property(e => e.Totaltaxprice)
                    .HasColumnName("totaltaxprice")
                    .HasColumnType("money");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("unitprice")
                    .HasColumnType("money");

                entity.Property(e => e.Unittaxprice)
                    .HasColumnName("unittaxprice")
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ordershippingmethodmap)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("ordershippingmethodmap_order");

                entity.HasOne(d => d.Shippingmethod)
                    .WithMany(p => p.Ordershippingmethodmap)
                    .HasForeignKey(d => d.Shippingmethodid)
                    .HasConstraintName("ordershimethod");
            });

            modelBuilder.Entity<Orderstatus>(entity =>
            {
                entity.ToTable("orderstatus", "dbo");

                entity.Property(e => e.Orderstatusid)
                    .HasColumnName("orderstatusid")
                    .HasDefaultValueSql("nextval('dbo.orderstatus_orderstatusid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Ordersupplier>(entity =>
            {
                entity.ToTable("ordersupplier", "dbo");

                entity.Property(e => e.Ordersupplierid)
                    .HasColumnName("ordersupplierid")
                    .HasDefaultValueSql("nextval('dbo.ordersupplier_ordersupplierid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Estimateddelivery)
                    .HasColumnName("estimateddelivery")
                    .HasColumnType("date");

                entity.Property(e => e.Executedon)
                    .HasColumnName("executedon")
                    .HasColumnType("date");

                entity.Property(e => e.Grandtotal)
                    .HasColumnName("grandtotal")
                    .HasColumnType("money");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Ordernumber).HasColumnName("ordernumber");

                entity.Property(e => e.Ordersupplierstatusid).HasColumnName("ordersupplierstatusid");

                entity.Property(e => e.Productwarehouseid).HasColumnName("productwarehouseid");

                entity.Property(e => e.Shippingamount)
                    .HasColumnName("shippingamount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Taxamount)
                    .HasColumnName("taxamount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Trackingnumber).HasColumnName("trackingnumber");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Validate).HasColumnName("validate");

                entity.HasOne(d => d.Ordersupplierstatus)
                    .WithMany(p => p.Ordersupplier)
                    .HasForeignKey(d => d.Ordersupplierstatusid)
                    .HasConstraintName("fk_ordersrstatus");

                entity.HasOne(d => d.Productwarehouse)
                    .WithMany(p => p.Ordersupplier)
                    .HasForeignKey(d => d.Productwarehouseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ordrehouse");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Ordersupplier)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("fk_ordersupplier_supplier");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ordersupplier)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_ordersupplier_user");
            });

            modelBuilder.Entity<Ordersupplierstatus>(entity =>
            {
                entity.ToTable("ordersupplierstatus", "dbo");

                entity.Property(e => e.Ordersupplierstatusid)
                    .HasColumnName("ordersupplierstatusid")
                    .HasDefaultValueSql("nextval('dbo.ordersupplierstatus_ordersupplierstatusid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("page", "dbo");

                entity.Property(e => e.Pageid)
                    .HasColumnName("pageid")
                    .HasDefaultValueSql("nextval('dbo.page_pageid_seq'::regclass)");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Controller).HasColumnName("controller");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Isdefault).HasColumnName("isdefault");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Pagetypeid).HasColumnName("pagetypeid");

                entity.Property(e => e.Parentpageid).HasColumnName("parentpageid");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Page)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("fk_page_category");

                entity.HasOne(d => d.Pagetype)
                    .WithMany(p => p.Page)
                    .HasForeignKey(d => d.Pagetypeid)
                    .HasConstraintName("fk_page_pagetype");

                entity.HasOne(d => d.Parentpage)
                    .WithMany(p => p.InverseParentpage)
                    .HasForeignKey(d => d.Parentpageid)
                    .HasConstraintName("fk_childrenpage_page");
            });

            modelBuilder.Entity<Pagebehavior>(entity =>
            {
                entity.ToTable("pagebehavior", "dbo");

                entity.Property(e => e.Pagebehaviorid)
                    .HasColumnName("pagebehaviorid")
                    .HasDefaultValueSql("nextval('dbo.pagebehavior_pagebehaviorid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Pageculturemap>(entity =>
            {
                entity.ToTable("pageculturemap", "dbo");

                entity.Property(e => e.Pageculturemapid)
                    .HasColumnName("pageculturemapid")
                    .HasDefaultValueSql("nextval('dbo.pageculturemap_pageculturemapid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Keywords).HasColumnName("keywords");

                entity.Property(e => e.Metadescription).HasColumnName("metadescription");

                entity.Property(e => e.Metakeyword).HasColumnName("metakeyword");

                entity.Property(e => e.Metatitle).HasColumnName("metatitle");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Pageid).HasColumnName("pageid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Pageculturemap)
                    .HasForeignKey(d => d.Cultureid)
                    .HasConstraintName("fk_pageculturemap_culture");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Pageculturemap)
                    .HasForeignKey(d => d.Pageid)
                    .HasConstraintName("fk_pageculturemap_page");
            });

            modelBuilder.Entity<Pageevent>(entity =>
            {
                entity.ToTable("pageevent", "dbo");

                entity.Property(e => e.Pageeventid)
                    .HasColumnName("pageeventid")
                    .HasDefaultValueSql("nextval('dbo.pageevent_pageeventid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Eventdate)
                    .HasColumnName("eventdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Pagebehaviorid).HasColumnName("pagebehaviorid");

                entity.Property(e => e.Pageculturemapid).HasColumnName("pageculturemapid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Pagebehavior)
                    .WithMany(p => p.Pageevent)
                    .HasForeignKey(d => d.Pagebehaviorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pageevent_pagebehavior");

                entity.HasOne(d => d.Pageculturemap)
                    .WithMany(p => p.Pageevent)
                    .HasForeignKey(d => d.Pageculturemapid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pageevent_pageculturemap");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Pageevent)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_pageevent_user");
            });

            modelBuilder.Entity<Pageimagemap>(entity =>
            {
                entity.HasKey(e => e.Pageimageid);

                entity.ToTable("pageimagemap", "dbo");

                entity.Property(e => e.Pageimageid)
                    .HasColumnName("pageimageid")
                    .HasDefaultValueSql("nextval('dbo.pageimagemap_pageimageid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Alt).HasColumnName("alt");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Pageid).HasColumnName("pageid");

                entity.Property(e => e.Pageimagetypeid).HasColumnName("pageimagetypeid");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Pageimagemap)
                    .HasForeignKey(d => d.Imageid)
                    .HasConstraintName("fk_pageimagemap_image");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.Pageimagemap)
                    .HasForeignKey(d => d.Pageid)
                    .HasConstraintName("fk_pageimagemap_page");

                entity.HasOne(d => d.Pageimagetype)
                    .WithMany(p => p.Pageimagemap)
                    .HasForeignKey(d => d.Pageimagetypeid)
                    .HasConstraintName("fk_pageimagemap_pageimagetype");
            });

            modelBuilder.Entity<Pageimagetype>(entity =>
            {
                entity.ToTable("pageimagetype", "dbo");

                entity.Property(e => e.Pageimagetypeid)
                    .HasColumnName("pageimagetypeid")
                    .HasDefaultValueSql("nextval('dbo.pageimagetype_pageimagetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Pagetype>(entity =>
            {
                entity.ToTable("pagetype", "dbo");

                entity.Property(e => e.Pagetypeid)
                    .HasColumnName("pagetypeid")
                    .HasDefaultValueSql("nextval('dbo.pagetype_pagetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.ToTable("people", "dbo");

                entity.Property(e => e.Peopleid)
                    .HasColumnName("peopleid")
                    .HasDefaultValueSql("nextval('dbo.people_peopleid_seq'::regclass)");

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastip).HasColumnName("lastip");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename).HasColumnName("middlename");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Peopleonline>(entity =>
            {
                entity.ToTable("peopleonline", "system");

                entity.Property(e => e.Peopleonlineid)
                    .HasColumnName("peopleonlineid")
                    .HasDefaultValueSql("nextval('system.peopleonline_peopleonlineid_seq'::regclass)");

                entity.Property(e => e.Browser)
                    .IsRequired()
                    .HasColumnName("browser");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip");

                entity.Property(e => e.Lastactivity)
                    .HasColumnName("lastactivity")
                    .HasColumnType("date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Peopleonline)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_peopleonline_user");
            });

            modelBuilder.Entity<Peopleonlinehistory>(entity =>
            {
                entity.ToTable("peopleonlinehistory", "system");

                entity.Property(e => e.Peopleonlinehistoryid)
                    .HasColumnName("peopleonlinehistoryid")
                    .HasDefaultValueSql("nextval('system.peopleonlinehistory_peopleonlinehistoryid_seq'::regclass)");

                entity.Property(e => e.Browser)
                    .IsRequired()
                    .HasColumnName("browser");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Durationminute)
                    .HasColumnName("durationminute")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Endactivity)
                    .HasColumnName("endactivity")
                    .HasColumnType("date");

                entity.Property(e => e.Firstactivity)
                    .HasColumnName("firstactivity")
                    .HasColumnType("date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Peopleonlinehistory)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_peopleonlinehistory_user");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone", "dbo");

                entity.Property(e => e.Phoneid)
                    .HasColumnName("phoneid")
                    .HasDefaultValueSql("nextval('dbo.phone_phoneid_seq'::regclass)");

                entity.Property(e => e.Cell).HasColumnName("cell");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Peopleid).HasColumnName("peopleid");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasColumnName("phone");

                entity.Property(e => e.Phonetypeid).HasColumnName("phonetypeid");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.Peopleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_phone_people");

                entity.HasOne(d => d.Phonetype)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.Phonetypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_phone_phonetype");
            });

            modelBuilder.Entity<Phonetype>(entity =>
            {
                entity.ToTable("phonetype", "dbo");

                entity.Property(e => e.Phonetypeid)
                    .HasColumnName("phonetypeid")
                    .HasDefaultValueSql("nextval('dbo.phonetype_phonetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("policy", "dbo");

                entity.Property(e => e.Policyid)
                    .HasColumnName("policyid")
                    .HasDefaultValueSql("nextval('dbo.policy_policyid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Policyculturemap>(entity =>
            {
                entity.ToTable("policyculturemap", "dbo");

                entity.Property(e => e.Policyculturemapid)
                    .HasColumnName("policyculturemapid")
                    .HasDefaultValueSql("nextval('dbo.policyculturemap_policyculturemapid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Content)
                    .HasColumnName("content");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Policyid).HasColumnName("policyid");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Policyculturemap)
                    .HasForeignKey(d => d.Cultureid)
                    .HasConstraintName("fk_policyculturemap_culture");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Policyculturemap)
                    .HasForeignKey(d => d.Policyid)
                    .HasConstraintName("fk_policyculturemap_policy");
            });

            modelBuilder.Entity<Postalcode>(entity =>
            {
                entity.ToTable("postalcode", "geographic");

                entity.Property(e => e.Postalcodeid)
                    .HasColumnName("postalcodeid")
                    .HasDefaultValueSql("nextval('geographic.postalcode_postalcodeid_seq'::regclass)");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Postallabel).HasColumnName("postallabel");

                entity.Property(e => e.Postalnumber)
                    .IsRequired()
                    .HasColumnName("postalnumber");

                entity.Property(e => e.Regionid).HasColumnName("regionid");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Postalcode)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("fk_postalcode_city");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Postalcode)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("fk_postalcode_country");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Postalcode)
                    .HasForeignKey(d => d.Regionid)
                    .HasConstraintName("fk_postalcode_region");
            });

            modelBuilder.Entity<Postalzone>(entity =>
            {
                entity.ToTable("postalzone", "geographic");

                entity.Property(e => e.Postalzoneid)
                    .HasColumnName("postalzoneid")
                    .HasDefaultValueSql("nextval('geographic.postalzone_postalzoneid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Zonename)
                    .IsRequired()
                    .HasColumnName("zonename");
            });

            modelBuilder.Entity<Postalzonecountrymap>(entity =>
            {
                entity.HasKey(e => e.Postalzonecountryid);

                entity.ToTable("postalzonecountrymap", "geographic");

                entity.Property(e => e.Postalzonecountryid)
                    .HasColumnName("postalzonecountryid")
                    .HasDefaultValueSql("nextval('geographic.postalzonecountrymap_postalzonecountryid_seq'::regclass)");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Postalzoneid).HasColumnName("postalzoneid");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Postalzonecountrymap)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("fk_postalzonecountrymap_country");

                entity.HasOne(d => d.Postalzone)
                    .WithMany(p => p.Postalzonecountrymap)
                    .HasForeignKey(d => d.Postalzoneid)
                    .HasConstraintName("fk_postastalzone");
            });

            modelBuilder.Entity<Printtemplate>(entity =>
            {
                entity.ToTable("printtemplate", "dbo");

                entity.Property(e => e.Printtemplateid)
                    .HasColumnName("printtemplateid")
                    .HasDefaultValueSql("nextval('dbo.printtemplate_printtemplateid_seq'::regclass)");

                entity.Property(e => e.Body)
                    .HasColumnName("body");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Displayname)
                    .IsRequired()
                    .HasColumnName("displayname");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Printtypeid).HasColumnName("printtypeid");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Printtemplate)
                    .HasForeignKey(d => d.Cultureid)
                    .HasConstraintName("pk_printtemplate_culture");

                entity.HasOne(d => d.Printtype)
                    .WithMany(p => p.Printtemplate)
                    .HasForeignKey(d => d.Printtypeid)
                    .HasConstraintName("pk_prinplatetype");
            });

            modelBuilder.Entity<Printtemplatetype>(entity =>
            {
                entity.HasKey(e => e.Printtypeid);

                entity.ToTable("printtemplatetype", "dbo");

                entity.Property(e => e.Printtypeid)
                    .HasColumnName("printtypeid")
                    .HasDefaultValueSql("nextval('dbo.printtemplatetype_printtypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "dbo");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasDefaultValueSql("nextval('dbo.product_productid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Deliverymethodid)
                    .HasColumnName("deliverymethodid")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productcode)
                    .IsRequired()
                    .HasColumnName("productcode");

                entity.Property(e => e.Productean).HasColumnName("productean");

                entity.Property(e => e.Productgroupid).HasColumnName("productgroupid");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname");

                entity.Property(e => e.Productsku).HasColumnName("productsku");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Stockmanagmentid).HasColumnName("stockmanagmentid");

                entity.Property(e => e.Supplierinfo).HasColumnName("supplierinfo");

                entity.Property(e => e.Supplierminimumqty).HasColumnName("supplierminimumqty");

                entity.Property(e => e.Supplierprice)
                    .HasColumnName("supplierprice")
                    .HasColumnType("money");

                entity.Property(e => e.Suppliersku).HasColumnName("suppliersku");

                entity.Property(e => e.Trackinventory)
                    .HasColumnName("trackinventory")
                    .HasDefaultValueSql("true");

                entity.HasOne(d => d.Deliverymethod)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Deliverymethodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_deliverymethod");

                entity.HasOne(d => d.Productgroup)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Productgroupid)
                    .HasConstraintName("fk_product_productgroup");

                entity.HasOne(d => d.Stockmanagment)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Stockmanagmentid)
                    .HasConstraintName("fk_product_stockmanagment");
            });

            modelBuilder.Entity<Productattributemap>(entity =>
            {
                entity.HasKey(e => e.Productattributeid);

                entity.ToTable("productattributemap", "dbo");

                entity.Property(e => e.Productattributeid)
                    .HasColumnName("productattributeid")
                    .HasDefaultValueSql("nextval('dbo.productattributemap_productattributeid_seq'::regclass)");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Attributeid).HasColumnName("attributeid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Filter)
                    .HasColumnName("filter")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.Productattributemap)
                    .HasForeignKey(d => d.Attributeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_prodribute");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productattributemap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productattributemap_product");
            });

            modelBuilder.Entity<Productbehavior>(entity =>
            {
                entity.ToTable("productbehavior", "dbo");

                entity.Property(e => e.Productbehaviorid)
                    .HasColumnName("productbehaviorid")
                    .HasDefaultValueSql("nextval('dbo.productbehavior_productbehaviorid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Productcrosssellmap>(entity =>
            {
                entity.HasKey(e => e.Productcrosssellid);

                entity.ToTable("productcrosssellmap", "dbo");

                entity.Property(e => e.Productcrosssellid)
                    .HasColumnName("productcrosssellid")
                    .HasDefaultValueSql("nextval('dbo.productcrosssellmap_productcrosssellid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Crossproductid).HasColumnName("crossproductid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Crossproduct)
                    .WithMany(p => p.ProductcrosssellmapCrossproduct)
                    .HasForeignKey(d => d.Crossproductid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_crosssold_product");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Productcrosssellmap)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("fk_productcrosssellmap_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductcrosssellmapProduct)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_crosssell_product");
            });

            modelBuilder.Entity<Productculturemap>(entity =>
            {
                entity.HasKey(e => e.Productcultureid);

                entity.ToTable("productculturemap", "dbo");

                entity.Property(e => e.Productcultureid)
                    .HasColumnName("productcultureid")
                    .HasDefaultValueSql("nextval('dbo.productculturemap_productcultureid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Allowbackorder)
                    .HasColumnName("allowbackorder")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Allowreturn).HasColumnName("allowreturn");

                entity.Property(e => e.Baseunitprice)
                    .HasColumnName("baseunitprice")
                    .HasColumnType("money");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Description)
                    .HasColumnName("description");

                entity.Property(e => e.Discountpercent)
                    .HasColumnName("discountpercent")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Estimatedhandlingtime).HasColumnName("estimatedhandlingtime");

                entity.Property(e => e.Extrashipfee)
                    .HasColumnName("extrashipfee")
                    .HasColumnType("money");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Keywords).HasColumnName("keywords");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Metadescription).HasColumnName("metadescription");

                entity.Property(e => e.Metakeyword).HasColumnName("metakeyword");

                entity.Property(e => e.Metatitle).HasColumnName("metatitle");

                entity.Property(e => e.Minimumqty).HasColumnName("minimumqty");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname");

                entity.Property(e => e.Shipseparately)
                    .HasColumnName("shipseparately")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Shortdescription)
                    .IsRequired()
                    .HasColumnName("shortdescription");

                entity.Property(e => e.Taxweeeid).HasColumnName("taxweeeid");

                entity.Property(e => e.Warranty).HasColumnName("warranty");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Productculturemap)
                    .HasForeignKey(d => d.Cultureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productculturemap_culture");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productculturemap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productculturemap_product");

                entity.HasOne(d => d.Taxweee)
                    .WithMany(p => p.Productculturemap)
                    .HasForeignKey(d => d.Taxweeeid)
                    .HasConstraintName("fk_productculturemap_taxweee");
            });

            modelBuilder.Entity<Productevent>(entity =>
            {
                entity.ToTable("productevent", "dbo");

                entity.Property(e => e.Producteventid)
                    .HasColumnName("producteventid")
                    .HasDefaultValueSql("nextval('dbo.productevent_producteventid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Eventdate)
                    .HasColumnName("eventdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productbehaviorid).HasColumnName("productbehaviorid");

                entity.Property(e => e.Productcultureid).HasColumnName("productcultureid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Productbehavior)
                    .WithMany(p => p.Productevent)
                    .HasForeignKey(d => d.Productbehaviorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productevent_productbehavior");

                entity.HasOne(d => d.Productculture)
                    .WithMany(p => p.Productevent)
                    .HasForeignKey(d => d.Productcultureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produculturemap");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Productevent)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_productevent_user");
            });

            modelBuilder.Entity<Productgroup>(entity =>
            {
                entity.ToTable("productgroup", "dbo");

                entity.Property(e => e.Productgroupid)
                    .HasColumnName("productgroupid")
                    .HasDefaultValueSql("nextval('dbo.productgroup_productgroupid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Productimagemap>(entity =>
            {
                entity.HasKey(e => e.Productimageid);

                entity.ToTable("productimagemap", "dbo");

                entity.Property(e => e.Productimageid)
                    .HasColumnName("productimageid")
                    .HasDefaultValueSql("nextval('dbo.productimagemap_productimageid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Productimagetypeid).HasColumnName("productimagetypeid");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Productimagemap)
                    .HasForeignKey(d => d.Imageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productimagemap_image");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productimagemap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productimagemap_product");

                entity.HasOne(d => d.Productimagetype)
                    .WithMany(p => p.Productimagemap)
                    .HasForeignKey(d => d.Productimagetypeid)
                    .HasConstraintName("fk_productimagetype");
            });

            modelBuilder.Entity<Productimagetype>(entity =>
            {
                entity.ToTable("productimagetype", "dbo");

                entity.Property(e => e.Productimagetypeid)
                    .HasColumnName("productimagetypeid")
                    .HasDefaultValueSql("nextval('dbo.productimagetype_productimagetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Productinventory>(entity =>
            {
                entity.ToTable("productinventory", "dbo");

                entity.Property(e => e.Productinventoryid)
                    .HasColumnName("productinventoryid")
                    .HasDefaultValueSql("nextval('dbo.productinventory_productinventoryid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Inventorystatusid).HasColumnName("inventorystatusid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Outofstockmode)
                    .HasColumnName("outofstockmode")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Quantityavailable)
                    .HasColumnName("quantityavailable")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Quantityavailableforsale).HasColumnName("quantityavailableforsale");

                entity.Property(e => e.Quantityoutofstockpoint)
                    .HasColumnName("quantityoutofstockpoint")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Quantityreserved)
                    .HasColumnName("quantityreserved")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Reorderlevel).HasColumnName("reorderlevel");

                entity.Property(e => e.Reorderpoint)
                    .HasColumnName("reorderpoint")
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Inventorystatus)
                    .WithMany(p => p.Productinventory)
                    .HasForeignKey(d => d.Inventorystatusid)
                    .HasConstraintName("fk_prodstatus");
            });

            modelBuilder.Entity<Productinventorywarehousemap>(entity =>
            {
                entity.HasKey(e => e.Productinventorymapid);

                entity.ToTable("productinventorywarehousemap", "dbo");

                entity.Property(e => e.Productinventorymapid)
                    .HasColumnName("productinventorymapid")
                    .HasDefaultValueSql("nextval('dbo.productinventorywarehousemap_productinventorymapid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productinventoryid).HasColumnName("productinventoryid");

                entity.Property(e => e.Productwarehouseid).HasColumnName("productwarehouseid");

                entity.Property(e => e.Quantityavailable)
                    .HasColumnName("quantityavailable")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Quantityavailableforsale).HasColumnName("quantityavailableforsale");

                entity.Property(e => e.Quantityoutofstockpoint)
                    .HasColumnName("quantityoutofstockpoint")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Quantityreserved)
                    .HasColumnName("quantityreserved")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Reorderlevel).HasColumnName("reorderlevel");

                entity.Property(e => e.Reorderpoint)
                    .HasColumnName("reorderpoint")
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Productinventory)
                    .WithMany(p => p.Productinventorywarehousemap)
                    .HasForeignKey(d => d.Productinventoryid)
                    .HasConstraintName("fk_producttinventory");

                entity.HasOne(d => d.Productwarehouse)
                    .WithMany(p => p.Productinventorywarehousemap)
                    .HasForeignKey(d => d.Productwarehouseid)
                    .HasConstraintName("fk_produwarehouse");
            });

            modelBuilder.Entity<Productrelatedmap>(entity =>
            {
                entity.HasKey(e => e.Productrelatedid);

                entity.ToTable("productrelatedmap", "dbo");

                entity.Property(e => e.Productrelatedid)
                    .HasColumnName("productrelatedid")
                    .HasDefaultValueSql("nextval('dbo.productrelatedmap_productrelatedid_seq'::regclass)");

                entity.Property(e => e.Activate)
                    .HasColumnName("activate")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Relatedproductid).HasColumnName("relatedproductid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductrelatedmapProduct)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productrelatedfrom_product");

                entity.HasOne(d => d.Relatedproduct)
                    .WithMany(p => p.ProductrelatedmapRelatedproduct)
                    .HasForeignKey(d => d.Relatedproductid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productrelatedto_product");
            });

            modelBuilder.Entity<Productreview>(entity =>
            {
                entity.ToTable("productreview", "dbo");

                entity.Property(e => e.Productreviewid)
                    .HasColumnName("productreviewid")
                    .HasDefaultValueSql("nextval('dbo.productreview_productreviewid_seq'::regclass)");

                entity.Property(e => e.Abusecount).HasColumnName("abusecount");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.Body)
                    .HasColumnName("body");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Reviewdate)
                    .HasColumnName("reviewdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Usefull).HasColumnName("usefull");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Productreview)
                    .HasForeignKey(d => d.Cultureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productreviews_cultures");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productreview)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productreview_product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Productreview)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_productreview_user");
            });

            modelBuilder.Entity<Productshippingmethodmap>(entity =>
            {
                entity.HasKey(e => e.Productshippingmethodid);

                entity.ToTable("productshippingmethodmap", "dbo");

                entity.Property(e => e.Productshippingmethodid)
                    .HasColumnName("productshippingmethodid")
                    .HasDefaultValueSql("nextval('dbo.productshippingmethodmap_productshippingmethodid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Isfreeshipping).HasColumnName("isfreeshipping");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Shippingmethodid).HasColumnName("shippingmethodid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productshippingmethodmap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producproduct");

                entity.HasOne(d => d.Shippingmethod)
                    .WithMany(p => p.Productshippingmethodmap)
                    .HasForeignKey(d => d.Shippingmethodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producgmethod");
            });

            modelBuilder.Entity<Productsuppliermap>(entity =>
            {
                entity.HasKey(e => e.Productsupplierid);

                entity.ToTable("productsuppliermap", "dbo");

                entity.Property(e => e.Productsupplierid)
                    .HasColumnName("productsupplierid")
                    .HasDefaultValueSql("nextval('dbo.productsuppliermap_productsupplierid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Estimateddelivery).HasColumnName("estimateddelivery");

                entity.Property(e => e.Estimateddeliverymargin).HasColumnName("estimateddeliverymargin");

                entity.Property(e => e.Isdefault).HasColumnName("isdefault");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productsuppliermap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productsuppliermap_product");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Productsuppliermap)
                    .HasForeignKey(d => d.Supplierid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productsuppliermap_supplier");
            });

            modelBuilder.Entity<Productwarehouse>(entity =>
            {
                entity.ToTable("productwarehouse", "dbo");

                entity.Property(e => e.Productwarehouseid)
                    .HasColumnName("productwarehouseid")
                    .HasDefaultValueSql("nextval('dbo.productwarehouse_productwarehouseid_seq'::regclass)");

                entity.Property(e => e.Addressid).HasColumnName("addressid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Productwarehouse)
                    .HasForeignKey(d => d.Addressid)
                    .HasConstraintName("fk_productwarehouse_address");
            });

            modelBuilder.Entity<Programpointofsalemap>(entity =>
            {
                entity.HasKey(e => e.Programpointofsaleid);

                entity.ToTable("programpointofsalemap", "dbo");

                entity.Property(e => e.Programpointofsaleid)
                    .HasColumnName("programpointofsaleid")
                    .HasDefaultValueSql("nextval('dbo.programpointofsalemap_programpointofsaleid_seq'::regclass)");

                entity.Property(e => e.Brandid).HasColumnName("brandid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Pointofsaleid).HasColumnName("pointofsaleid");

                entity.Property(e => e.Programid).HasColumnName("programid");
            });

            modelBuilder.Entity<Queuestatus>(entity =>
            {
                entity.ToTable("queuestatus", "queue");

                entity.Property(e => e.Queuestatusid)
                    .HasColumnName("queuestatusid")
                    .HasDefaultValueSql("nextval('queue.queuestatus_queuestatusid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region", "geographic");

                entity.Property(e => e.Regionid)
                    .HasColumnName("regionid")
                    .HasDefaultValueSql("nextval('geographic.region_regionid_seq'::regclass)");

                entity.Property(e => e.Adm1code).HasColumnName("adm1code");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Region1)
                    .IsRequired()
                    .HasColumnName("region");

                entity.Property(e => e.Regioncode).HasColumnName("regioncode");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("fk_region_country");
            });

            modelBuilder.Entity<Returnmaterial>(entity =>
            {
                entity.HasKey(e => e.Returnid);

                entity.ToTable("returnmaterial", "dbo");

                entity.Property(e => e.Returnid)
                    .HasColumnName("returnid")
                    .HasDefaultValueSql("nextval('dbo.returnmaterial_returnid_seq'::regclass)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Dateofreturn)
                    .HasColumnName("dateofreturn")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Emailaddress)
                    .IsRequired()
                    .HasColumnName("emailaddress");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Returnstatusid).HasColumnName("returnstatusid");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Returnmaterial)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("fk_returnmaterial_order");

                entity.HasOne(d => d.Returnstatus)
                    .WithMany(p => p.Returnmaterial)
                    .HasForeignKey(d => d.Returnstatusid)
                    .HasConstraintName("fk_returrialstatus");
            });

            modelBuilder.Entity<Returnmaterialitem>(entity =>
            {
                entity.HasKey(e => e.Returnitemid);

                entity.ToTable("returnmaterialitem", "dbo");

                entity.Property(e => e.Returnitemid)
                    .HasColumnName("returnitemid")
                    .HasDefaultValueSql("nextval('dbo.returnmaterialitem_returnitemid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Itemdescription)
                    .HasColumnName("itemdescription");

                entity.Property(e => e.Itemname)
                    .IsRequired()
                    .HasColumnName("itemname");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note)
                    .HasColumnName("note");

                entity.Property(e => e.Orderitemid).HasColumnName("orderitemid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Quantityreceived).HasColumnName("quantityreceived");

                entity.Property(e => e.Quantityreturnedtoinventory).HasColumnName("quantityreturnedtoinventory");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason");

                entity.Property(e => e.Replace).HasColumnName("replace");

                entity.Property(e => e.Returnid).HasColumnName("returnid");

                entity.Property(e => e.Returnmaterialreasonid).HasColumnName("returnmaterialreasonid");

                entity.HasOne(d => d.Orderitem)
                    .WithMany(p => p.Returnmaterialitem)
                    .HasForeignKey(d => d.Orderitemid)
                    .HasConstraintName("fk_returnmaterialitem_orderitem");

                entity.HasOne(d => d.Return)
                    .WithMany(p => p.Returnmaterialitem)
                    .HasForeignKey(d => d.Returnid)
                    .HasConstraintName("fk_retuaterial");

                entity.HasOne(d => d.Returnmaterialreason)
                    .WithMany(p => p.Returnmaterialitem)
                    .HasForeignKey(d => d.Returnmaterialreasonid)
                    .HasConstraintName("fk_returnerialreason");
            });

            modelBuilder.Entity<Returnmaterialreason>(entity =>
            {
                entity.ToTable("returnmaterialreason", "dbo");

                entity.Property(e => e.Returnmaterialreasonid)
                    .HasColumnName("returnmaterialreasonid")
                    .HasDefaultValueSql("nextval('dbo.returnmaterialreason_returnmaterialreasonid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Reasoncode)
                    .IsRequired()
                    .HasColumnName("reasoncode");

                entity.Property(e => e.Reasonname)
                    .IsRequired()
                    .HasColumnName("reasonname");
            });

            modelBuilder.Entity<Returnmaterialstatus>(entity =>
            {
                entity.HasKey(e => e.Returnstatusid);

                entity.ToTable("returnmaterialstatus", "dbo");

                entity.Property(e => e.Returnstatusid)
                    .HasColumnName("returnstatusid")
                    .HasDefaultValueSql("nextval('dbo.returnmaterialstatus_returnstatusid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Rolepermission>(entity =>
            {
                entity.ToTable("rolepermission", "dbo");

                entity.Property(e => e.Rolepermissionid)
                    .HasColumnName("rolepermissionid")
                    .HasDefaultValueSql("nextval('dbo.rolepermission_rolepermissionid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Rolepermissionmap>(entity =>
            {
                entity.ToTable("rolepermissionmap", "dbo");

                entity.Property(e => e.Rolepermissionmapid)
                    .HasColumnName("rolepermissionmapid")
                    .HasDefaultValueSql("nextval('dbo.rolepermissionmap_rolepermissionmapid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Rolepermissionid).HasColumnName("rolepermissionid");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Rolepermissionmap)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("fk_rolepermissionmap_userrole");

                entity.HasOne(d => d.Rolepermission)
                    .WithMany(p => p.Rolepermissionmap)
                    .HasForeignKey(d => d.Rolepermissionid)
                    .HasConstraintName("fk_roleprmission");
            });

            modelBuilder.Entity<Ruleconditionoperator>(entity =>
            {
                entity.ToTable("ruleconditionoperator", "rule");

                entity.Property(e => e.Ruleconditionoperatorid)
                    .HasColumnName("ruleconditionoperatorid")
                    .HasDefaultValueSql("nextval('rule.ruleconditionoperator_ruleconditionoperatorid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Symbol).HasColumnName("symbol");
            });

            modelBuilder.Entity<Ruleresultoperation>(entity =>
            {
                entity.ToTable("ruleresultoperation", "rule");

                entity.Property(e => e.Ruleresultoperationid)
                    .HasColumnName("ruleresultoperationid")
                    .HasDefaultValueSql("nextval('rule.ruleresultoperation_ruleresultoperationid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasColumnName("operation");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sale", "dbo");

                entity.Property(e => e.Saleid)
                    .HasColumnName("saleid")
                    .HasDefaultValueSql("nextval('dbo.sale_saleid_seq'::regclass)");

                entity.Property(e => e.Activate)
                    .HasColumnName("activate")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Allowunrestrictedscope)
                    .HasColumnName("allowunrestrictedscope")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Dicountpercent)
                    .HasColumnName("dicountpercent")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Ispercentsale)
                    .HasColumnName("ispercentsale")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Saleattributemap>(entity =>
            {
                entity.HasKey(e => e.Saleattributeid);

                entity.ToTable("saleattributemap", "dbo");

                entity.Property(e => e.Saleattributeid)
                    .HasColumnName("saleattributeid")
                    .HasDefaultValueSql("nextval('dbo.saleattributemap_saleattributeid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Attributeid).HasColumnName("attributeid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Saleid).HasColumnName("saleid");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.Saleattributemap)
                    .HasForeignKey(d => d.Attributeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pk_saleattributemap_attribute");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Saleattributemap)
                    .HasForeignKey(d => d.Saleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_saleattributemap_sale");
            });

            modelBuilder.Entity<Salecategorymap>(entity =>
            {
                entity.HasKey(e => e.Salecategoryid);

                entity.ToTable("salecategorymap", "dbo");

                entity.Property(e => e.Salecategoryid)
                    .HasColumnName("salecategoryid")
                    .HasDefaultValueSql("nextval('dbo.salecategorymap_salecategoryid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Saleid).HasColumnName("saleid");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Salecategorymap)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pk_salecategorymap_category");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Salecategorymap)
                    .HasForeignKey(d => d.Saleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_salecategorymap_sale");
            });

            modelBuilder.Entity<Saleproductmap>(entity =>
            {
                entity.HasKey(e => e.Saleproductid);

                entity.ToTable("saleproductmap", "dbo");

                entity.Property(e => e.Saleproductid)
                    .HasColumnName("saleproductid")
                    .HasDefaultValueSql("nextval('dbo.saleproductmap_saleproductid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Saleid).HasColumnName("saleid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Saleproductmap)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pk_saleproductmap_product");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Saleproductmap)
                    .HasForeignKey(d => d.Saleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_saleproductmap_sale");
            });

            modelBuilder.Entity<Shippingmethod>(entity =>
            {
                entity.ToTable("shippingmethod", "dbo");

                entity.Property(e => e.Shippingmethodid)
                    .HasColumnName("shippingmethodid")
                    .HasDefaultValueSql("nextval('dbo.shippingmethod_shippingmethodid_seq'::regclass)");

                entity.Property(e => e.Baserate)
                    .HasColumnName("baserate")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Carrier)
                    .IsRequired()
                    .HasColumnName("carrier");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Daystodeliver)
                    .HasColumnName("daystodeliver")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Estimateddelivery).HasColumnName("estimateddelivery");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Rateperunit)
                    .HasColumnName("rateperunit")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Servicename)
                    .IsRequired()
                    .HasColumnName("servicename");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Shippingmethod)
                    .HasForeignKey(d => d.Cultureid)
                    .HasConstraintName("fk_shippingmethod_culture");
            });

            modelBuilder.Entity<Shippingmethodrate>(entity =>
            {
                entity.ToTable("shippingmethodrate", "dbo");

                entity.Property(e => e.Shippingmethodrateid)
                    .HasColumnName("shippingmethodrateid")
                    .HasDefaultValueSql("nextval('dbo.shippingmethodrate_shippingmethodrateid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Estimateddelivery).HasColumnName("estimateddelivery");

                entity.Property(e => e.Fromcontinentid).HasColumnName("fromcontinentid");

                entity.Property(e => e.Fromcountryid).HasColumnName("fromcountryid");

                entity.Property(e => e.Frompostalcodeid).HasColumnName("frompostalcodeid");

                entity.Property(e => e.Frompostalzoneid).HasColumnName("frompostalzoneid");

                entity.Property(e => e.Fromregionid).HasColumnName("fromregionid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("money");

                entity.Property(e => e.Shippingmethodid).HasColumnName("shippingmethodid");

                entity.Property(e => e.Tocontinentid).HasColumnName("tocontinentid");

                entity.Property(e => e.Tocountryid).HasColumnName("tocountryid");

                entity.Property(e => e.Topostalcodeid).HasColumnName("topostalcodeid");

                entity.Property(e => e.Topostalzoneid).HasColumnName("topostalzoneid");

                entity.Property(e => e.Toregionid).HasColumnName("toregionid");

                entity.Property(e => e.Weightmax)
                    .HasColumnName("weightmax")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Weightmin)
                    .HasColumnName("weightmin")
                    .HasColumnType("numeric(18, 6)");

                entity.HasOne(d => d.Fromcontinent)
                    .WithMany(p => p.ShippingmethodrateFromcontinent)
                    .HasForeignKey(d => d.Fromcontinentid)
                    .HasConstraintName("fk_shippiontinent");

                entity.HasOne(d => d.Fromcountry)
                    .WithMany(p => p.ShippingmethodrateFromcountry)
                    .HasForeignKey(d => d.Fromcountryid)
                    .HasConstraintName("fk_shippicountry");

                entity.HasOne(d => d.Frompostalcode)
                    .WithMany(p => p.ShippingmethodrateFrompostalcode)
                    .HasForeignKey(d => d.Frompostalcodeid)
                    .HasConstraintName("fk_shippinstalcode");

                entity.HasOne(d => d.Frompostalzone)
                    .WithMany(p => p.ShippingmethodrateFrompostalzone)
                    .HasForeignKey(d => d.Frompostalzoneid)
                    .HasConstraintName("fk_shippistalzone");

                entity.HasOne(d => d.Fromregion)
                    .WithMany(p => p.ShippingmethodrateFromregion)
                    .HasForeignKey(d => d.Fromregionid)
                    .HasConstraintName("fk_shippregion");

                entity.HasOne(d => d.Shippingmethod)
                    .WithMany(p => p.Shippingmethodrate)
                    .HasForeignKey(d => d.Shippingmethodid)
                    .HasConstraintName("fk_shippinghippingmethod");

                entity.HasOne(d => d.Tocontinent)
                    .WithMany(p => p.ShippingmethodrateTocontinent)
                    .HasForeignKey(d => d.Tocontinentid)
                    .HasConstraintName("fk_shippingmeto_continent");

                entity.HasOne(d => d.Tocountry)
                    .WithMany(p => p.ShippingmethodrateTocountry)
                    .HasForeignKey(d => d.Tocountryid)
                    .HasConstraintName("fk_shippingmethodrateto_country");

                entity.HasOne(d => d.Topostalcode)
                    .WithMany(p => p.ShippingmethodrateTopostalcode)
                    .HasForeignKey(d => d.Topostalcodeid)
                    .HasConstraintName("fk_shippalcode");

                entity.HasOne(d => d.Topostalzone)
                    .WithMany(p => p.ShippingmethodrateTopostalzone)
                    .HasForeignKey(d => d.Topostalzoneid)
                    .HasConstraintName("fk_ship_postalzone");

                entity.HasOne(d => d.Toregion)
                    .WithMany(p => p.ShippingmethodrateToregion)
                    .HasForeignKey(d => d.Toregionid)
                    .HasConstraintName("fk_shippingmethodrateto_region");
            });

            modelBuilder.Entity<Shoppingcart>(entity =>
            {
                entity.HasKey(e => e._);

                entity.ToTable("shoppingcart", "dbo");

                entity.Property(e => e._).HasDefaultValueSql("nextval('dbo.shoppingcart___seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Grandtotal)
                    .HasColumnName("grandtotal")
                    .HasColumnType("money");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Shoppingcartguid)
                    .IsRequired()
                    .HasColumnName("shoppingcartguid");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("money");

                entity.Property(e => e.Taxamount)
                    .HasColumnName("taxamount")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Shoppingcart)
                    .HasForeignKey(d => d.Cultureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shoppingcart_culture");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Shoppingcart)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_shoppingcart_user");
            });

            modelBuilder.Entity<Shoppingcartbehavior>(entity =>
            {
                entity.ToTable("shoppingcartbehavior", "dbo");

                entity.Property(e => e.Shoppingcartbehaviorid)
                    .HasColumnName("shoppingcartbehaviorid")
                    .HasDefaultValueSql("nextval('dbo.shoppingcartbehavior_shoppingcartbehaviorid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Shoppingcartcouponmap>(entity =>
            {
                entity.HasKey(e => e.Shoppingcartcouponid);

                entity.ToTable("shoppingcartcouponmap", "dbo");

                entity.Property(e => e.Shoppingcartcouponid)
                    .HasColumnName("shoppingcartcouponid")
                    .HasDefaultValueSql("nextval('dbo.shoppingcartcouponmap_shoppingcartcouponid_seq'::regclass)");

                entity.Property(e => e.Couponrepositoryid).HasColumnName("couponrepositoryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Shoppingcartid).HasColumnName("shoppingcartid");

                entity.HasOne(d => d.Couponrepository)
                    .WithMany(p => p.Shoppingcartcouponmap)
                    .HasForeignKey(d => d.Couponrepositoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shoppiouponrepository");

                entity.HasOne(d => d.Shoppingcart)
                    .WithMany(p => p.Shoppingcartcouponmap)
                    .HasForeignKey(d => d.Shoppingcartid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shoppingcart");
            });

            modelBuilder.Entity<Shoppingcartevent>(entity =>
            {
                entity.ToTable("shoppingcartevent", "dbo");

                entity.Property(e => e.Shoppingcarteventid)
                    .HasColumnName("shoppingcarteventid")
                    .HasDefaultValueSql("nextval('dbo.shoppingcartevent_shoppingcarteventid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Eventcontent).HasColumnName("eventcontent");

                entity.Property(e => e.Eventdate)
                    .HasColumnName("eventdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Oldeventcontent).HasColumnName("oldeventcontent");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Shoppingcartbehaviorid).HasColumnName("shoppingcartbehaviorid");

                entity.Property(e => e.Shoppingcartid).HasColumnName("shoppingcartid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Shoppingcartevent)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("fk_shoppingcartevent_product");

                entity.HasOne(d => d.Shoppingcartbehavior)
                    .WithMany(p => p.Shoppingcartevent)
                    .HasForeignKey(d => d.Shoppingcartbehaviorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shoppiartbehavior");

                entity.HasOne(d => d.Shoppingcart)
                    .WithMany(p => p.Shoppingcartevent)
                    .HasForeignKey(d => d.Shoppingcartid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shophoppingcart");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Shoppingcartevent)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_shoppingcartevent_user");
            });

            modelBuilder.Entity<Shoppingcartproductmap>(entity =>
            {
                entity.ToTable("shoppingcartproductmap", "dbo");

                entity.Property(e => e.Shoppingcartproductmapid)
                    .HasColumnName("shoppingcartproductmapid")
                    .HasDefaultValueSql("nextval('dbo.shoppingcartproductmap_shoppingcartproductmapid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Shoppingcartid).HasColumnName("shoppingcartid");

                entity.Property(e => e.Totalprice)
                    .HasColumnName("totalprice")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Unitprice)
                    .HasColumnName("unitprice")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Shoppingcartproductmap)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("fk_shoppingcart_product");

                entity.HasOne(d => d.Shoppingcart)
                    .WithMany(p => p.Shoppingcartproductmap)
                    .HasForeignKey(d => d.Shoppingcartid)
                    .HasConstraintName("fk_shoppingcart");
            });

            modelBuilder.Entity<Sourcetype>(entity =>
            {
                entity.ToTable("sourcetype", "export");

                entity.Property(e => e.Sourcetypeid)
                    .HasColumnName("sourcetypeid")
                    .HasDefaultValueSql("nextval('export.sourcetype_sourcetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Stockmanagment>(entity =>
            {
                entity.ToTable("stockmanagment", "dbo");

                entity.Property(e => e.Stockmanagmentid)
                    .HasColumnName("stockmanagmentid")
                    .HasDefaultValueSql("nextval('dbo.stockmanagment_stockmanagmentid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productinventoryid).HasColumnName("productinventoryid");

                entity.Property(e => e.Stockmanagmenttypeid).HasColumnName("stockmanagmenttypeid");

                entity.HasOne(d => d.Productinventory)
                    .WithMany(p => p.Stockmanagment)
                    .HasForeignKey(d => d.Productinventoryid)
                    .HasConstraintName("fk_stockmaentory");

                entity.HasOne(d => d.Stockmanagmenttype)
                    .WithMany(p => p.Stockmanagment)
                    .HasForeignKey(d => d.Stockmanagmenttypeid)
                    .HasConstraintName("fk_stackmenttype");
            });

            modelBuilder.Entity<Stockmanagmenttype>(entity =>
            {
                entity.ToTable("stockmanagmenttype", "dbo");

                entity.Property(e => e.Stockmanagmenttypeid)
                    .HasColumnName("stockmanagmenttypeid")
                    .HasDefaultValueSql("nextval('dbo.stockmanagmenttype_stockmanagmenttypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Subproductattributemap>(entity =>
            {
                entity.ToTable("subproductattributemap", "dbo");

                entity.Property(e => e.Subproductattributemapid)
                    .HasColumnName("subproductattributemapid")
                    .HasDefaultValueSql("nextval('dbo.subproductattributemap_subproductattributemapid_seq'::regclass)");

                entity.Property(e => e.Attributeid).HasColumnName("attributeid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.Subproductattributemap)
                    .HasForeignKey(d => d.Attributeid)
                    .HasConstraintName("fk_subttribute");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Subproductattributemap)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("fk_subpduct");
            });

            modelBuilder.Entity<Subproductmap>(entity =>
            {
                entity.ToTable("subproductmap", "dbo");

                entity.Property(e => e.Subproductmapid)
                    .HasColumnName("subproductmapid")
                    .HasDefaultValueSql("nextval('dbo.subproductmap_subproductmapid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Subproductid).HasColumnName("subproductid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SubproductmapProduct)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("fk_subproductfrom_product");

                entity.HasOne(d => d.Subproduct)
                    .WithMany(p => p.SubproductmapSubproduct)
                    .HasForeignKey(d => d.Subproductid)
                    .HasConstraintName("fk_subproductto_product");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier", "dbo");

                entity.Property(e => e.Supplierid)
                    .HasColumnName("supplierid")
                    .HasDefaultValueSql("nextval('dbo.supplier_supplierid_seq'::regclass)");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Dealedwith).HasColumnName("dealedwith");

                entity.Property(e => e.Dealingwith).HasColumnName("dealingwith");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Skuprefix).HasColumnName("skuprefix");

                entity.Property(e => e.Suppliertypeid).HasColumnName("suppliertypeid");

                entity.Property(e => e.Weburl).HasColumnName("weburl");

                entity.HasOne(d => d.Suppliertype)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.Suppliertypeid)
                    .HasConstraintName("fk_supplier_suppliertype");
            });

            modelBuilder.Entity<Supplierculturemap>(entity =>
            {
                entity.ToTable("supplierculturemap", "dbo");

                entity.Property(e => e.Supplierculturemapid)
                    .HasColumnName("supplierculturemapid")
                    .HasDefaultValueSql("nextval('dbo.supplierculturemap_supplierculturemapid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Description)
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Shortdescription).HasColumnName("shortdescription");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.Supplierculturemap)
                    .HasForeignKey(d => d.Cultureid)
                    .HasConstraintName("fk_supplierculturemap_culture");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Supplierculturemap)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("fk_supplierculturemap_supplier");
            });

            modelBuilder.Entity<Supplierimagemap>(entity =>
            {
                entity.HasKey(e => e.Supplierimageid);

                entity.ToTable("supplierimagemap", "dbo");

                entity.Property(e => e.Supplierimageid)
                    .HasColumnName("supplierimageid")
                    .HasDefaultValueSql("nextval('dbo.supplierimagemap_supplierimageid_seq'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Imageid).HasColumnName("imageid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Supplierimagetypeid).HasColumnName("supplierimagetypeid");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Supplierimagemap)
                    .HasForeignKey(d => d.Imageid)
                    .HasConstraintName("fk_supplierimagemap_image");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Supplierimagemap)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("fk_supplierimagemap_supplier");

                entity.HasOne(d => d.Supplierimagetype)
                    .WithMany(p => p.Supplierimagemap)
                    .HasForeignKey(d => d.Supplierimagetypeid)
                    .HasConstraintName("fk_supplieragetype");
            });

            modelBuilder.Entity<Supplierimagetype>(entity =>
            {
                entity.ToTable("supplierimagetype", "dbo");

                entity.Property(e => e.Supplierimagetypeid)
                    .HasColumnName("supplierimagetypeid")
                    .HasDefaultValueSql("nextval('dbo.supplierimagetype_supplierimagetypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Suppliernote>(entity =>
            {
                entity.ToTable("suppliernote", "dbo");

                entity.Property(e => e.Suppliernoteid)
                    .HasColumnName("suppliernoteid")
                    .HasDefaultValueSql("nextval('dbo.suppliernote_suppliernoteid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note)
                    .HasColumnName("note");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Suppliernote)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("fk_suppliernote_supplier");
            });

            modelBuilder.Entity<Suppliertype>(entity =>
            {
                entity.ToTable("suppliertype", "dbo");

                entity.Property(e => e.Suppliertypeid)
                    .HasColumnName("suppliertypeid")
                    .HasDefaultValueSql("nextval('dbo.suppliertype_suppliertypeid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Taxrate>(entity =>
            {
                entity.ToTable("taxrate", "dbo");

                entity.Property(e => e.Taxrateid)
                    .HasColumnName("taxrateid")
                    .HasDefaultValueSql("nextval('dbo.taxrate_taxrateid_seq'::regclass)");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Regionid).HasColumnName("regionid");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Taxrate)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("fk_taxrate_city");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Taxrate)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("fk_taxrate_country");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Taxrate)
                    .HasForeignKey(d => d.Regionid)
                    .HasConstraintName("fk_taxrate_region");
            });

            modelBuilder.Entity<Taxweee>(entity =>
            {
                entity.ToTable("taxweee", "dbo");

                entity.Property(e => e.Taxweeeid)
                    .HasColumnName("taxweeeid")
                    .HasDefaultValueSql("nextval('dbo.taxweee_taxweeeid_seq'::regclass)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Subamount)
                    .HasColumnName("subamount")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Tokenprice>(entity =>
            {
                entity.ToTable("tokenprice", "ll");

                entity.Property(e => e.Tokenpriceid)
                    .HasColumnName("tokenpriceid")
                    .HasDefaultValueSql("nextval('ll.tokenprice_tokenpriceid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Fullysold).HasColumnName("fullysold");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Priceusd).HasColumnName("priceusd");

                entity.Property(e => e.Remainingtokens).HasColumnName("remainingtokens");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transaction", "dbo");

                entity.Property(e => e.Transactionid)
                    .HasColumnName("transactionid")
                    .HasDefaultValueSql("nextval('dbo.transaction_transactionid_seq'::regclass)");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Amountauthorized)
                    .HasColumnName("amountauthorized")
                    .HasColumnType("numeric(18, 10)");

                entity.Property(e => e.Amountcharged)
                    .HasColumnName("amountcharged")
                    .HasColumnType("numeric(18, 10)");

                entity.Property(e => e.Amountrefunded)
                    .HasColumnName("amountrefunded")
                    .HasColumnType("numeric(18, 10)");

                entity.Property(e => e.Authorizationcode).HasColumnName("authorizationcode");

                entity.Property(e => e.Checknumber).HasColumnName("checknumber");

                entity.Property(e => e.Coinledgerid).HasColumnName("coinledgerid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Creditcardcvn).HasColumnName("creditcardcvn");

                entity.Property(e => e.Creditcardencrypted).HasColumnName("creditcardencrypted");

                entity.Property(e => e.Creditcardexp)
                    .HasColumnName("creditcardexp")
                    .HasColumnType("date");

                entity.Property(e => e.Creditcardholder).HasColumnName("creditcardholder");

                entity.Property(e => e.Creditcardnumber).HasColumnName("creditcardnumber");

                entity.Property(e => e.Creditcardtypeid).HasColumnName("creditcardtypeid");

                entity.Property(e => e.Giftcertificatenumber).HasColumnName("giftcertificatenumber");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Pointofsaleid).HasColumnName("pointofsaleid");

                entity.Property(e => e.Processorid).HasColumnName("processorid");

                entity.Property(e => e.Programid).HasColumnName("programid");

                entity.Property(e => e.Transactiondate)
                    .HasColumnName("transactiondate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Transactionreferencenumber).HasColumnName("transactionreferencenumber");

                entity.Property(e => e.Transactionresponsecode).HasColumnName("transactionresponsecode");

                entity.Property(e => e.Transactionstatusid).HasColumnName("transactionstatusid");

                entity.HasOne(d => d.Creditcardtype)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.Creditcardtypeid)
                    .HasConstraintName("fk_transaction_creditcardtype");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactions_orders");

                entity.HasOne(d => d.Processor)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.Processorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transocessors");

                entity.HasOne(d => d.Transactionstatus)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.Transactionstatusid)
                    .HasConstraintName("fk_transtatus");
            });

            modelBuilder.Entity<Transactionprocessor>(entity =>
            {
                entity.HasKey(e => e.Processorid);

                entity.ToTable("transactionprocessor", "dbo");

                entity.Property(e => e.Processorid)
                    .HasColumnName("processorid")
                    .HasDefaultValueSql("nextval('dbo.transactionprocessor_processorid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.Transactionid);

                entity.ToTable("transactions", "ll");

                entity.Property(e => e.Transactionid)
                    .HasColumnName("transactionid")
                    .HasDefaultValueSql("nextval('ll.transactions_transactionid_seq'::regclass)");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.AmountDecimal).HasColumnName("amountdecimal");

                entity.Property(e => e.Amounttoken).HasColumnName("amounttoken");

                entity.Property(e => e.Amountusd).HasColumnName("amountusd");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.Godfathercode).HasColumnName("godfathercode");

                entity.Property(e => e.Memobc).HasColumnName("memobc");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Paidonbc).HasColumnName("paidonbc");

                entity.Property(e => e.Cryptoaddress).HasColumnName("cryptoaddress");

                entity.Property(e => e.Cryptoconfirmed).HasColumnName("cryptoconfirmed");

                entity.Property(e => e.Cryptocurrency).HasColumnName("cryptocurrency");

                entity.Property(e => e.Purchaseprice).HasColumnName("purchaseprice");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Currencyid)
                    .HasConstraintName("fk_transact_reference_currency");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_transact_reference_user");
            });

            modelBuilder.Entity<Transactionstatus>(entity =>
            {
                entity.ToTable("transactionstatus", "dbo");

                entity.Property(e => e.Transactionstatusid)
                    .HasColumnName("transactionstatusid")
                    .HasDefaultValueSql("nextval('dbo.transactionstatus_transactionstatusid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "dbo");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasDefaultValueSql("nextval('dbo.\"User_userid_seq\"'::regclass)");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Encryptionid).HasColumnName("encryptionid");

                entity.Property(e => e.Failedanswercount).HasColumnName("failedanswercount");

                entity.Property(e => e.Failedlogincount)
                    .HasColumnName("failedlogincount")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Godfathercode).HasColumnName("godfathercode");

                entity.Property(e => e.Lastactivitydate)
                    .HasColumnName("lastactivitydate")
                    .HasColumnType("date");

                entity.Property(e => e.Lastlockoutdate)
                    .HasColumnName("lastlockoutdate")
                    .HasColumnType("date");

                entity.Property(e => e.Lastlogindate)
                    .HasColumnName("lastlogindate")
                    .HasColumnType("date");

                entity.Property(e => e.Lastpasswordchangeddate)
                    .HasColumnName("lastpasswordchangeddate")
                    .HasColumnType("date");

                entity.Property(e => e.Locked)
                    .HasColumnName("locked")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lockeduntil)
                    .HasColumnName("lockeduntil")
                    .HasColumnType("date");

                entity.Property(e => e.Mobilelanguage).HasColumnName("mobilelanguage");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Passwordanswer)
                    .HasColumnName("passwordanswer");

                entity.Property(e => e.Passwordhint)
                    .HasColumnName("passwordhint");

                entity.Property(e => e.Peopleid).HasColumnName("peopleid");

                entity.Property(e => e.Picture)
                    .HasColumnName("picture");

                entity.Property(e => e.Referalcode).HasColumnName("referalcode");

                entity.Property(e => e.Taxexempt).HasColumnName("taxexempt");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Cultureid)
                    .HasConstraintName("fk_user_culture");

                entity.HasOne(d => d.Encryption)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Encryptionid)
                    .HasConstraintName("fk_user_encryptiontype");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Peopleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_people");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasKey(e => e.Roleid);

                entity.ToTable("userrole", "dbo");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasDefaultValueSql("nextval('dbo.userrole_roleid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Rolename).HasColumnName("rolename");
            });

            modelBuilder.Entity<Userrolemap>(entity =>
            {
                entity.ToTable("userrolemap", "dbo");

                entity.Property(e => e.Userrolemapid)
                    .HasColumnName("userrolemapid")
                    .HasDefaultValueSql("nextval('dbo.userrolemap_userrolemapid_seq'::regclass)");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userrolemap)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("fk_userrolemap_userrole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userrolemap)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_userrolemap_user");
            });

            modelBuilder.Entity<Workflowcontainer>(entity =>
            {
                entity.ToTable("workflowcontainer", "dbo");

                entity.Property(e => e.Workflowcontainerid)
                    .HasColumnName("workflowcontainerid")
                    .HasDefaultValueSql("nextval('dbo.workflowcontainer_workflowcontainerid_seq'::regclass)");

                entity.Property(e => e.Body)
                    .HasColumnName("body");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Cultureid).HasColumnName("cultureid");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Hasarguments).HasColumnName("hasarguments");

                entity.Property(e => e.Iscomponent).HasColumnName("iscomponent");

                entity.Property(e => e.Isentrypoint).HasColumnName("isentrypoint");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Pointofsaleid).HasColumnName("pointofsaleid");

                entity.Property(e => e.Programid).HasColumnName("programid");

                entity.Property(e => e.Workflowtypeid).HasColumnName("workflowtypeid");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Workflowcontainer)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("fk_workflow_fk_catego_category");

                entity.HasOne(d => d.Workflowtype)
                    .WithMany(p => p.Workflowcontainer)
                    .HasForeignKey(d => d.Workflowtypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workflow_fk_workfl_workflow");
            });

            modelBuilder.Entity<Workflowgenericattributemap>(entity =>
            {
                entity.HasKey(e => e.Workflowgenericattributeid);

                entity.ToTable("workflowgenericattributemap", "dbo");

                entity.Property(e => e.Workflowgenericattributeid)
                    .HasColumnName("workflowgenericattributeid")
                    .HasDefaultValueSql("nextval('dbo.workflowgenericattributemap_workflowgenericattributeid_seq'::regclass)");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Genericattributeid).HasColumnName("genericattributeid");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Workflowcontainerid).HasColumnName("workflowcontainerid");

                entity.HasOne(d => d.Genericattribute)
                    .WithMany(p => p.Workflowgenericattributemap)
                    .HasForeignKey(d => d.Genericattributeid)
                    .HasConstraintName("fk_workflow_reference_generica");

                entity.HasOne(d => d.Workflowcontainer)
                    .WithMany(p => p.Workflowgenericattributemap)
                    .HasForeignKey(d => d.Workflowcontainerid)
                    .HasConstraintName("fk_workflow_reference_workflow");
            });

            modelBuilder.Entity<Workflowtype>(entity =>
            {
                entity.ToTable("workflowtype", "dbo");

                entity.Property(e => e.Workflowtypeid)
                    .HasColumnName("workflowtypeid")
                    .HasDefaultValueSql("nextval('dbo.workflowtype_workflowtypeid_seq'::regclass)");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2018-02-19'::date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Workflowtype)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("fk_workflow_reference_category");
            });

            modelBuilder.HasSequence("abuseproductreviewmap_abuseproductreviewid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("address_addressid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("addresstype_addresstypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("attribute_attributeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("attributebehavior_attributebehaviorid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("attributeevent_attributeeventid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("attributeitem_attributeitemid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("attributetype_attributetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("cartruleschedule_cartrulescheduleid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("category_categoryid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("categoryculturemap_categorycultureid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("categoryimagemap_categoryimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("categoryproductmap_categoryproductid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("contact_contactid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("contacttype_contacttypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("contentblock_contentblockid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("contentblockculturemap_contentblockculturemapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("contentblocktype_contentblocktypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("continent_continentid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("couponrepository_couponrepositoryid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("creditcardtype_creditcardtypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("culture_cultureid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("deliverymethod_deliverymethodid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("encryptiontype_encryptionid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("headerimage_headerimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("headerimagetype_headerimagetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("image_imageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("imagetype_imagetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("instantnotification_instantnotificationid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("instantnotificationpagemap_instantnotificationpageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("instantnotificationtype_instantnotificationtypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("inventoryrecord_inventoryrecordid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("inventorystatus_inventorystatusid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailertemplate_mailertemplateid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailertemplatetype_mailertypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglist_mailinglistid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglistcontentblockmap_mailinglistcontentblockid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglistcontentblocktype_mailinglistcontentblocktypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglistimagemap_mailinglistimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglistimagetype_mailinglistimagetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglistpeoplegroup_mailinglistpeoplegroupid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglistpeoplemap_mailinglistpeopleid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglistproductmap_mailinglistproductid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("Order_orderid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ordercouponmap_ordercouponid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("orderitem_orderitemid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("orderitempackagemap_orderitempackageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("orderitemsuppliermap_orderitemsuppliermapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ordernote_ordernoteid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ordernotetype_ordernotetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("orderpackage_orderpackageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ordershippingmethodmap_ordershippingmethodid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("orderstatus_orderstatusid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ordersupplier_ordersupplierid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ordersupplierstatus_ordersupplierstatusid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("page_pageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("pagebehavior_pagebehaviorid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("pageculturemap_pageculturemapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("pageevent_pageeventid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("pageimagemap_pageimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("pageimagetype_pageimagetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("pagetype_pagetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("people_peopleid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("phone_phoneid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("phonetype_phonetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("policy_policyid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("policyculturemap_policyculturemapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("printtemplate_printtemplateid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("printtemplatetype_printtypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("product_productid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productattributemap_productattributeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productbehavior_productbehaviorid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productcrosssellmap_productcrosssellid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productculturemap_productcultureid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productevent_producteventid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productgroup_productgroupid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productimagemap_productimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productimagetype_productimagetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productinventory_productinventoryid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productinventorywarehousemap_productinventorymapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productrelatedmap_productrelatedid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productreview_productreviewid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productshippingmethodmap_productshippingmethodid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productsuppliermap_productsupplierid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("productwarehouse_productwarehouseid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("programpointofsalemap_programpointofsaleid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("returnmaterial_returnid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("returnmaterialitem_returnitemid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("returnmaterialreason_returnmaterialreasonid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("returnmaterialstatus_returnstatusid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("rolepermission_rolepermissionid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("rolepermissionmap_rolepermissionmapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("sale_saleid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("saleattributemap_saleattributeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("salecategorymap_salecategoryid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("saleproductmap_saleproductid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("shippingmethod_shippingmethodid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("shippingmethodrate_shippingmethodrateid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("shoppingcart___seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("shoppingcartbehavior_shoppingcartbehaviorid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("shoppingcartcouponmap_shoppingcartcouponid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("shoppingcartevent_shoppingcarteventid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("shoppingcartproductmap_shoppingcartproductmapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("stockmanagment_stockmanagmentid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("stockmanagmenttype_stockmanagmenttypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("subproductattributemap_subproductattributemapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("subproductmap_subproductmapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("supplier_supplierid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("supplierculturemap_supplierculturemapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("supplierimagemap_supplierimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("supplierimagetype_supplierimagetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("suppliernote_suppliernoteid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("suppliertype_suppliertypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("taxrate_taxrateid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("taxweee_taxweeeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("transaction_transactionid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("transactionprocessor_processorid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("transactionstatus_transactionstatusid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("User_userid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("userrole_roleid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("userrolemap_userrolemapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("workflowcontainer_workflowcontainerid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("workflowgenericattributemap_workflowgenericattributeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("workflowtype_workflowtypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("dreamcomment_commentid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("dreamimage_dreamimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("dreamproduct_productid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("dreamproductimagemap_dreamproductimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("csvdelimiter_csvdelimiterid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("customexport_customexportid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("sourcetype_sourcetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("city_cityid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("country_countryid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("postalcode_postalcodeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("postalzone_postalzoneid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("postalzonecountrymap_postalzonecountryid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("region_regionid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("currency_currencyid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ledgeruseraddressmap_ledgeruseraddressmapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ledgerusers_bitsharesaccountid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("tokenprice_tokenpriceid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("transactions_transactionid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("abusecommentmap_abusecommentid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("article_articleid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("articleimagemap_articleimageid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("articletag_articletagid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("articletagmap_articletagmapid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("comment_commentid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("letter_letterid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("accountmailqueue_acountmailqueueid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("mailinglistqueue_mailinglistqueueid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ordermailqueue_ordermailqueueid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("queuestatus_queuestatusid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("cartresultproductmap_cartresultproductid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("cartrulecondition_cartruleconditionid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("cartruleengine_cartruleengineid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("cartruleresult_cartruleresultid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("cartruleshoppingcartmap_cartruleshoppingcartid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ruleconditionoperator_ruleconditionoperatorid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("ruleresultoperation_ruleresultoperationid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("blacklistrepository_blacklistrepoditoryid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("genericattribute_genericattributeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("genericattributetype_genericattributetypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("genericattributevalue_genericattributevalueid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("globalsetting_globalsettingid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("globalsettingtype_globalsettingtypeid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("log_logid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("peopleonline_peopleonlineid_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("peopleonlinehistory_peopleonlinehistoryid_seq")
                .HasMin(1)
                .HasMax(2147483647);
        }
    }
}
