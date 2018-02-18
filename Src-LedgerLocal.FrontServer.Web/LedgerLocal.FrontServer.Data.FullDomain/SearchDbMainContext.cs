using Microsoft.EntityFrameworkCore;
using LedgerLocal.FrontServer.Model.FullDomain.Model;

namespace LedgerLocal.FrontServer.Data.FullDomain
{
    public partial class LedgerLocalDbMainContext : DbContext
    {
        private readonly string _connectionString;

        public LedgerLocalDbMainContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryCultureMap> CategoryCultureMap { get; set; }
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<CustomExport> CustomExport { get; set; }
        public virtual DbSet<GenericAttribute> GenericAttribute { get; set; }
        public virtual DbSet<GenericAttributeType> GenericAttributeType { get; set; }
        public virtual DbSet<GenericAttributeValue> GenericAttributeValue { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LedgerLocalPolicy> LedgerLocalPolicy { get; set; }
        public virtual DbSet<LedgerLocalPolicyGenericAttributeMap> LedgerLocalPolicyGenericAttributeMap { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PeopleOnline> PeopleOnline { get; set; }
        public virtual DbSet<PeopleOnlineHistory> PeopleOnlineHistory { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<RolePermissionMap> RolePermissionMap { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserRoleMap> UserRoleMap { get; set; }
        public virtual DbSet<VoucherLedger> VoucherLedger { get; set; }
        public virtual DbSet<VoucherLedgerGenericAttributeMap> VoucherLedgerGenericAttributeMap { get; set; }
        public virtual DbSet<VoucherType> VoucherType { get; set; }
        public virtual DbSet<WorkflowContainer> WorkflowContainer { get; set; }
        public virtual DbSet<WorkflowGenericAttributeMap> WorkflowGenericAttributeMap { get; set; }
        public virtual DbSet<WorkflowType> WorkflowType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsDefault).HasDefaultValueSql("0");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Sort).HasDefaultValueSql("0");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_ChildrenCategory_Category");
            });

            modelBuilder.Entity<CategoryCultureMap>(entity =>
            {
                entity.HasKey(e => e.CategoryCultureId)
                    .HasName("PK_CategoryCultureDetail");

                entity.Property(e => e.CategoryCultureId).HasColumnName("CategoryCultureID");

                entity.Property(e => e.CategoryAlternativeName).HasMaxLength(150);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.CultureId).HasColumnName("CultureID");

                entity.Property(e => e.MetaDescription).HasMaxLength(255);

                entity.Property(e => e.MetaKeyword).HasMaxLength(255);

                entity.Property(e => e.MetaTitle).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryCultureMap)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CategoryCultureMap_Category");

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.CategoryCultureMap)
                    .HasForeignKey(d => d.CultureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CategoryCultureMap_Culture");
            });
            
            modelBuilder.Entity<Culture>(entity =>
            {
                entity.Property(e => e.CultureId).HasColumnName("CultureID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DefaultCurrencyCode).HasColumnType("char(3)");

                entity.Property(e => e.DefaultSizeCode).HasMaxLength(10);

                entity.Property(e => e.DefaultSizeUnit).HasMaxLength(10);

                entity.Property(e => e.DefaultWeightCode).HasMaxLength(10);

                entity.Property(e => e.DefaultWeightUnit).HasMaxLength(10);

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasColumnType("char(2)");

                entity.Property(e => e.Locale).HasColumnType("char(5)");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<CustomExport>(entity =>
            {
                entity.ToTable("CustomExport", "Export");

                entity.Property(e => e.CustomExportId).HasColumnName("CustomExportID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            

            modelBuilder.Entity<GenericAttribute>(entity =>
            {
                entity.ToTable("GenericAttribute", "System");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.TypeString).HasMaxLength(512);

                entity.HasOne(d => d.GenericAttributeType)
                    .WithMany(p => p.GenericAttribute)
                    .HasForeignKey(d => d.GenericAttributeTypeId)
                    .HasConstraintName("FK_GENERICA_FK_GENERI_GENERICA");

                entity.HasOne(d => d.GenericAttributeValue)
                    .WithMany(p => p.GenericAttribute)
                    .HasForeignKey(d => d.GenericAttributeValueId)
                    .HasConstraintName("FK_GENERICAttribute_Value");
            });

            modelBuilder.Entity<GenericAttributeType>(entity =>
            {
                entity.ToTable("GenericAttributeType", "System");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.MetaTypeString).HasMaxLength(512);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.Property(e => e.ValueLabelDate).HasColumnType("datetime");

                entity.Property(e => e.ValueLabelNumber).HasColumnType("decimal");

                entity.Property(e => e.ValueNumber).HasColumnType("decimal");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.GenericAttributeType)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_GENERICA_REFERENCE_CATEGORY");
            });

            modelBuilder.Entity<GenericAttributeValue>(entity =>
            {
                entity.ToTable("GenericAttributeValue", "System");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Label).HasMaxLength(150);

                entity.Property(e => e.MetaTypeString).HasMaxLength(512);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sort).HasDefaultValueSql("0");

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.Property(e => e.ValueLabelDate).HasColumnType("datetime");

                entity.Property(e => e.ValueLabelNumber).HasColumnType("decimal");

                entity.Property(e => e.ValueNumber).HasColumnType("decimal");
            });

            

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log", "System");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Action).HasMaxLength(255);

                entity.Property(e => e.Controller).HasMaxLength(255);

                entity.Property(e => e.LogDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.LogInfo).IsRequired();

                entity.Property(e => e.LogLevel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LogMessage).IsRequired();

                entity.Property(e => e.Logger)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Thread)
                    .IsRequired()
                    .HasMaxLength(255);
            });
            
            modelBuilder.Entity<LedgerLocalPolicy>(entity =>
            {
                entity.ToTable("LedgerLocalPolicy", "LedgerLocal");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<LedgerLocalPolicyGenericAttributeMap>(entity =>
            {
                entity.HasKey(e => e.LedgerLocalPolicyGenericAttributeId)
                    .HasName("PK_LedgerLocalPOLICYGENERICATTRIBUTEMA");

                entity.ToTable("LedgerLocalPolicyGenericAttributeMap", "LedgerLocal");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.GenericAttribute)
                    .WithMany(p => p.LedgerLocalPolicyGenericAttributeMap)
                    .HasForeignKey(d => d.GenericAttributeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LedgerLocalPOLIC_REFERENCE_GENERICA");
            });

            

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.PeopleId).HasColumnName("PeopleID");

                entity.Property(e => e.Company).HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastIp)
                    .HasColumnName("LastIP")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Title).HasMaxLength(255);
            });
            

            modelBuilder.Entity<PeopleOnline>(entity =>
            {
                entity.ToTable("PeopleOnline", "System");

                entity.Property(e => e.PeopleOnlineId).HasColumnName("PeopleOnlineID");

                entity.Property(e => e.Browser)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastActivity).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PeopleOnline)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PeopleOnline_User");
            });

            modelBuilder.Entity<PeopleOnlineHistory>(entity =>
            {
                entity.ToTable("PeopleOnlineHistory", "System");

                entity.Property(e => e.PeopleOnlineHistoryId).HasColumnName("PeopleOnlineHistoryID");

                entity.Property(e => e.Browser)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DurationMinute).HasColumnType("decimal");

                entity.Property(e => e.EndActivity).HasColumnType("datetime");

                entity.Property(e => e.FirstActivity).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PeopleOnlineHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PeopleOnlineHistory_User");
            });
            
            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.Property(e => e.RolePermissionId).HasColumnName("RolePermissionID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<RolePermissionMap>(entity =>
            {
                entity.Property(e => e.RolePermissionMapId).HasColumnName("RolePermissionMapID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RolePermissionId).HasColumnName("RolePermissionID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissionMap)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RolePermissionMap_UserRole");

                entity.HasOne(d => d.RolePermission)
                    .WithMany(p => p.RolePermissionMap)
                    .HasForeignKey(d => d.RolePermissionId)
                    .HasConstraintName("FK_RolePermissionMap_RolePermission");
            });
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.CultureId).HasColumnName("CultureID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(255);

                entity.Property(e => e.EncryptionId).HasColumnName("EncryptionID");

                entity.Property(e => e.FailedLoginCount).HasDefaultValueSql("0");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LastLockOutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.Locked).HasDefaultValueSql("0");

                entity.Property(e => e.LockedUntil).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PeopleId).HasColumnName("PeopleID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Culture)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CultureId)
                    .HasConstraintName("FK_User_Culture");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_User_People");
            });
            
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_UserRole");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.RoleName).HasMaxLength(255);
            });

            modelBuilder.Entity<UserRoleMap>(entity =>
            {
                entity.Property(e => e.UserRoleMapId).HasColumnName("UserRoleMapID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoleMap)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoleMap_UserRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleMap)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoleMap_User");
            });

            modelBuilder.Entity<VoucherLedger>(entity =>
            {
                entity.ToTable("VoucherLedger", "LedgerLocal");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Label).HasMaxLength(1024);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StringValue).HasMaxLength(1024);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.GenericAttribute)
                    .WithMany(p => p.VoucherLedger)
                    .HasForeignKey(d => d.GenericAttributeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_VOUCHERL_REFERENCE_GENERI1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VoucherLedger)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_VOUCHERL_REFERENCE_USER");

                entity.HasOne(d => d.VoucherType)
                    .WithMany(p => p.VoucherLedger)
                    .HasForeignKey(d => d.VoucherTypeId)
                    .HasConstraintName("FK_VOUCHERL_REFERENCE_VOUCHERT");
            });

            modelBuilder.Entity<VoucherLedgerGenericAttributeMap>(entity =>
            {
                entity.HasKey(e => e.VoucherLedgerGenericAttributeId)
                    .HasName("PK_VoucherLedgerGenericAttributeMap");

                entity.ToTable("VoucherLedgerGenericAttributeMap", "LedgerLocal");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.GenericAttribute)
                    .WithMany(p => p.VoucherLedgerGenericAttributeMap)
                    .HasForeignKey(d => d.GenericAttributeId)
                    .HasConstraintName("FK_VOUCHERL_REFERENCE_GENERI2");

                entity.HasOne(d => d.VoucherLedger)
                    .WithMany(p => p.VoucherLedgerGenericAttributeMap)
                    .HasForeignKey(d => d.VoucherLedgerId)
                    .HasConstraintName("FK_VOUCHERL_REFERENCE_VOUCHERL");
            });

            modelBuilder.Entity<VoucherType>(entity =>
            {
                entity.ToTable("VoucherType", "LedgerLocal");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Description).HasColumnType("varchar(100)");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<WorkflowContainer>(entity =>
            {
                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.CultureId).HasColumnName("CultureID");

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.WorkflowContainer)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_WORKFLOW_FK_CATEGO_CATEGORY");

                entity.HasOne(d => d.WorkflowType)
                    .WithMany(p => p.WorkflowContainer)
                    .HasForeignKey(d => d.WorkflowTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WORKFLOW_FK_WORKFL_WORKFLOW");
            });

            modelBuilder.Entity<WorkflowGenericAttributeMap>(entity =>
            {
                entity.HasKey(e => e.WorkflowGenericAttributeId)
                    .HasName("PK_WorkflowGenericAttributeMap");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.GenericAttribute)
                    .WithMany(p => p.WorkflowGenericAttributeMap)
                    .HasForeignKey(d => d.GenericAttributeId)
                    .HasConstraintName("FK_WORKFLOW_REFERENCE_GENERICA");

                entity.HasOne(d => d.WorkflowContainer)
                    .WithMany(p => p.WorkflowGenericAttributeMap)
                    .HasForeignKey(d => d.WorkflowContainerId)
                    .HasConstraintName("FK_WORKFLOW_REFERENCE_WORKFLOW");
            });

            modelBuilder.Entity<WorkflowType>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.WorkflowType)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_WORKFLOW_REFERENCE_CATEGORY");
            });
        }
    }
}