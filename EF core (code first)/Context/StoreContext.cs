using EF_core__code_first_.Entity;
using Microsoft.EntityFrameworkCore;

namespace EF_core__code_first_.Context
{
    public class StoreContext : DbContext
    {
        DbSet<Advertising> Advertisings;
        DbSet<Person> People;
        DbSet<Product> Products;
        DbSet<PurchaseHistory> PurchaseHistories;
        DbSet<SpecialQuestion> SpecialQuestions;
        DbSet<User> Users;

        public StoreContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Store;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertising>(entity =>
            {
                entity.ToTable("tblAdvertisings");

                entity.Property(e => e.Info).HasMaxLength(300);
                entity.Property(e => e.Picture).HasDefaultValueSql("(N'\\DefoultPicture')");
                entity.Property(e => e.Purchase).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblPeople");

                entity.HasIndex(e => e.PhoneNumber).IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();
                entity.Property(e => e.Address).HasMaxLength(30) .HasDefaultValue("No address information");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Surname).IsRequired().HasMaxLength(20);

                entity.HasOne(d => d.User).WithOne(p => p.Person) .HasForeignKey<Person>(d => d.UserId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("tblProducts");

                entity.Property(e => e.Brand).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Type).IsRequired() .HasMaxLength(20);
            });

            modelBuilder.Entity<PurchaseHistory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.UserId, e.Date });

                entity.ToTable("tblPurchaseHistories");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Date).HasDefaultValueSql("GETDATE()");

                entity.HasOne(d => d.Product).WithMany(p => p.PurchaseHistories).HasForeignKey(d => d.ProductId);
                entity.HasOne(d => d.User).WithMany(p => p.PurchaseHistories).HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<SpecialQuestion>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblSpecialQuestions");

                entity.Property(e => e.UserId).ValueGeneratedNever();
                entity.Property(e => e.Answer).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Question).IsRequired().HasMaxLength(40);

                entity.HasOne(d => d.User).WithOne(p => p.SpecialQuestion).HasForeignKey<SpecialQuestion>(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.HasIndex(e => e.Nickname).IsUnique();

                entity.Property(e => e.Nickname).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(20);
            });
        }
    }
}
