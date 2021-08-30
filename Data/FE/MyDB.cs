using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.FE
{
    public partial class MyDB : DbContext
    {
        public MyDB()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<ADV> ADVs { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentTag> ContentTags { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ImagesType> ImagesTypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<MenuUser> MenuUsers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<QandA> QandAs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.FileType)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<MenuUser>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.Metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
