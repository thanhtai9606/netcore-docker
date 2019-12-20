using System;
using BecamexIDC.Pattern.EF.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace acb_app.Models
{
    public partial class ACBSystemContext : DataContext
    {
     
        public ACBSystemContext(DbContextOptions<ACBSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<BusinessEntity> BusinessEntity { get; set; }
        public virtual DbSet<BusinessEntityAddress> BusinessEntityAddress { get; set; }
        public virtual DbSet<BusinessEntityContact> BusinessEntityContact { get; set; }
        public virtual DbSet<BusinessEntityPhone> BusinessEntityPhone { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductInventory> ProductInventory { get; set; }
        public virtual DbSet<ProductListPriceHistory> ProductListPriceHistory { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductProductPhoto> ProductProductPhoto { get; set; }
        public virtual DbSet<ProductSubCategory> ProductSubCategory { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        public virtual DbSet<SaleOrderHeader> SaleOrderHeader { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistory { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasure { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                    //not Config
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.AddressLine2)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PostalCode)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.WardId)
                    .HasColumnName("WardID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.Property(e => e.AddressTypeId)
                    .HasColumnName("AddressTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<BusinessEntity>(entity =>
            {
                entity.Property(e => e.BusinessEntityId)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BusinessEntityAddress>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId)
                    .HasName("PRIMARY");

                entity.Property(e => e.BusinessEntityId)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressTypeId)
                    .HasColumnName("AddressTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.BusinessEntity)
                    .WithOne(p => p.BusinessEntityAddress)
                    .HasForeignKey<BusinessEntityAddress>(d => d.BusinessEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BusinessEntityAddress_ibfk_1");
            });

            modelBuilder.Entity<BusinessEntityContact>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ContactTypeId)
                    .HasName("ContactTypeID");

                entity.Property(e => e.BusinessEntityId)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactTypeId)
                    .HasColumnName("ContactTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.BusinessEntityContact)
                    .HasForeignKey(d => d.ContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BusinessEntityContact_ibfk_1");
            });

            modelBuilder.Entity<BusinessEntityPhone>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.PhoneId)
                    .HasName("PhoneID");

                entity.Property(e => e.BusinessEntityId)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PhoneId)
                    .HasColumnName("PhoneID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PhoneTypeId)
                    .HasColumnName("PhoneTypeID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.BusinessEntityPhone)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BusinessEntityPhone_ibfk_1");
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.Property(e => e.ContactTypeId)
                    .HasColumnName("ContactTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasIndex(e => e.ProvinceId)
                    .HasName("ProvinceID");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("DistrictID")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ProvinceId)
                    .IsRequired()
                    .HasColumnName("ProvinceID")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.District)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("District_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId)
                    .HasName("PRIMARY");

                entity.Property(e => e.BusinessEntityId)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasComment("M=male, F= Female")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.JobTitle)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasComment("S=Single, M= Married")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NationalIdnumber)
                    .HasColumnName("NationalIDNumber")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.Position)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.SickLeaveHours).HasColumnType("tinyint(4)");

                entity.Property(e => e.VacationHours)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'96'");

                entity.HasOne(d => d.BusinessEntity)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.BusinessEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_ibfk_1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId)
                    .HasName("PRIMARY");

                entity.Property(e => e.BusinessEntityId)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PersonType)
                    .IsRequired()
                    .HasColumnType("varchar(2)")
                    .HasComment("Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(8)")
                    .HasComment("A courtesy title. For example, Mr. or Ms.")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.HasOne(d => d.BusinessEntity)
                    .WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.BusinessEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_ibfk_1");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.PhoneId)
                    .HasColumnName("PhoneID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.Property(e => e.PhoneTypeId)
                    .HasColumnName("PhoneTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProductSubcategoryId)
                    .HasName("ProductSubcategoryID");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Class)
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ProductModelId)
                    .HasColumnName("ProductModelID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ProductSubcategoryId)
                    .HasColumnName("ProductSubcategoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReorderPoint)
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SafetyStockLevel).HasColumnType("smallint(6)");

                entity.Property(e => e.SellEndDate).HasColumnType("datetime");

                entity.Property(e => e.SellStartDate).HasColumnType("datetime");

                entity.Property(e => e.Size)
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.SizeUnitMeasureCode)
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.StandardCost).HasColumnType("decimal(10,0)");

                entity.Property(e => e.Style)
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.Weight).HasColumnType("decimal(10,0)");

                entity.Property(e => e.WeightUnitMeasureCode)
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.HasOne(d => d.ProductSubcategory)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductSubcategoryId)
                    .HasConstraintName("Product_ibfk_1");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("ProductCategoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<ProductInventory>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRIMARY");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bin).HasColumnType("int(11)");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Quantity).HasColumnType("smallint(6)");

                entity.Property(e => e.Shelf).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.ProductInventory)
                    .HasForeignKey<ProductInventory>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductInventory_ibfk_1");
            });

            modelBuilder.Entity<ProductListPriceHistory>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRIMARY");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ListPrice).HasColumnType("decimal(10,0)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.ProductListPriceHistory)
                    .HasForeignKey<ProductListPriceHistory>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductListPriceHistory_ibfk_1");
            });

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.Property(e => e.ProductPhotoId)
                    .HasColumnName("ProductPhotoID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LargePhoto).HasMaxLength(6553);

                entity.Property(e => e.LargePhotoFileName)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ThumbNailPhoto).HasMaxLength(6553);

                entity.Property(e => e.ThumbnailPhotoFileName)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<ProductProductPhoto>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ProductPhotoId)
                    .HasName("ProductPhotoID");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ProductPhotoId)
                    .HasColumnName("ProductPhotoID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Qrcode)
                    .HasColumnName("QRcode")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.ProductProductPhoto)
                    .HasForeignKey<ProductProductPhoto>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductProductPhoto_ibfk_2");

                entity.HasOne(d => d.ProductPhoto)
                    .WithMany(p => p.ProductProductPhoto)
                    .HasForeignKey(d => d.ProductPhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductProductPhoto_ibfk_1");
            });

            modelBuilder.Entity<ProductSubCategory>(entity =>
            {
                entity.HasKey(e => e.ProductSubCategoryId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ProductCategoryId)
                    .HasName("ProductCategoryID");

                entity.Property(e => e.ProductSubCategoryId)
                    .HasColumnName("ProductSubCategoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("ProductCategoryID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductSubCatetory)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductSubCatetory_ibfk_1");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ProviceId)
                    .HasName("PRIMARY");

                entity.Property(e => e.ProviceId)
                    .HasColumnName("ProviceID")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.ProviceName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseOrderDetailId, e.PurchaseOrderId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductID");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("PurchaseOrderID");

                entity.Property(e => e.PurchaseOrderDetailId)
                    .HasColumnName("PurchaseOrderDetailID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnName("PurchaseOrderID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.LineTotal).HasColumnType("decimal(10,0)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.OrderQty).HasColumnType("smallint(6)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReceivedQty).HasColumnType("int(11)");

                entity.Property(e => e.RejectedQty).HasColumnType("int(11)");

                entity.Property(e => e.StockedQty)
                    .HasColumnType("int(11)")
                    .HasComment("Quantity accepted into inventory. Computed as ReceivedQty - RejectedQty.");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PurchaseOrderDetail_ibfk_1");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PurchaseOrderDetail_ibfk_2");
            });

            modelBuilder.Entity<PurchaseOrderHeader>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderId)
                    .HasName("PRIMARY");

                entity.Property(e => e.PurchaseOrderId)
                    .HasColumnName("PurchaseOrderID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Freight)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("Shipping cost.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RevisionNumber)
                    .HasColumnType("int(11)")
                    .HasComment("Incremental number to track changes to the purchase order over time.");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasComment("Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal)for the appropriate PurchaseOrderID.");

                entity.Property(e => e.TaxAmt).HasColumnType("decimal(10,0)");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("Total due to vendor. Computed as Subtotal + TaxAmt + Freight.");

                entity.Property(e => e.VendorId)
                    .HasColumnName("VendorID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SaleOrderHeader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId)
                    .HasName("PRIMARY");

                entity.Property(e => e.SalesOrderId)
                    .HasColumnName("SalesOrderID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Freight)
                    .HasColumnType("decimal(10,0)")
                    .HasComment("Shipping cost.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RevisionNumber)
                    .HasColumnType("tinyint(4)")
                    .HasComment("Incremental number to track changes to the sales order over time.");

                entity.Property(e => e.SalesOrderNumber)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.SalesPersonId)
                    .HasColumnName("SalesPersonID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnType("tinyint(4)")
                    .HasComment("Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(10,0)");

                entity.Property(e => e.TaxAmt).HasColumnType("decimal(10,0)");

                entity.Property(e => e.TotalDue).HasColumnType("decimal(10,0)");

                // entity.HasOne(d => d.SalesOrder)
                //     .WithOne(p => p.SaleOrderHeader)
                //     .HasForeignKey<SaleOrderHeader>(d => d.SalesOrderId)
                //     .OnDelete(DeleteBehavior.ClientSetNull)
                //     .HasConstraintName("SaleOrderHeader_ibfk_1");
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId)
                    .HasName("PRIMARY");

                entity.Property(e => e.SalesOrderId)
                    .HasColumnName("SalesOrderID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LineTotal).HasColumnType("decimal(10,0)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.OrderQty).HasColumnType("smallint(6)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SalesOrderDetailId)
                    .HasColumnName("SalesOrderDetailID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpecialOfferId)
                    .HasColumnName("SpecialOfferID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10,0)");

                entity.Property(e => e.UnitPriceDiscount).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.SalesOrder)
                    .WithOne(p => p.SalesOrderDetail)
                    .HasForeignKey<SalesOrderDetail>(d => d.SalesOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SalesOrderDetail_ibfk_1");
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PRIMARY");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActualCost).HasColumnType("decimal(10,0)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.ReferenceOrderId)
                    .HasColumnName("ReferenceOrderID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReferenceOrderLineId)
                    .HasColumnName("ReferenceOrderLineID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasComment("W = WorkOrder, S = SalesOrder, P = PurchaseOrder")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<UnitMeasure>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.UnitMeasureCode)
                    .IsRequired()
                    .HasColumnType("varchar(3)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId)
                    .HasName("PRIMARY");

                entity.Property(e => e.BusinessEntityId)
                    .HasColumnName("BusinessEntityID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountNumber).HasColumnType("int(11)");

                entity.Property(e => e.ActiveFlag)
                    .HasColumnType("int(11)")
                    .HasComment("0 = Vendor no longer used. 1 = Vendor is actively used.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name).HasColumnType("int(11)");

                entity.Property(e => e.PreferredVendorStatus)
                    .HasColumnType("int(11)")
                    .HasComment("0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying the same product.");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.HasKey(e => e.WarId)
                    .HasName("PRIMARY");

                entity.Property(e => e.WarId)
                    .HasColumnName("WarID")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.DistrictId)
                    .IsRequired()
                    .HasColumnName("DistrictID")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");

                entity.Property(e => e.WardName)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_vietnamese_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
