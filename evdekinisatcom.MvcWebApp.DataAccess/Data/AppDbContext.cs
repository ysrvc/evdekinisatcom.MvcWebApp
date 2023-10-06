using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace evdekinisatcom.MvcWebApp.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //base.OnModelCreating(modelBuilder);
            //modelBuilder
            //    .Entity<Product>()
            //    .HasOne(e => e.Seller)                       //ilişki tanımı, delete davranışı
            //    .WithMany(e => e.ProductsToSell)
            //    .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
                .Entity<Category>()
                .HasOne(c => c.ParentCategory)                       //ilişki tanımı
                .WithMany(c => c.subCategories)
                .HasForeignKey(c => c.ParentCategoryId);

            
            modelBuilder
                .Entity<Category>()
                .HasOne(e => e.ParentCategory)                       //ilişki tanımı, delete davranışı
                .WithMany(e => e.subCategories)
                .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUserToken<int>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name });

            modelBuilder.Entity<AppUser>().Property(p => p.Balance).HasDefaultValue(0);
            modelBuilder.Entity<AppUser>().Property(p => p.ProfilePicUrl).HasDefaultValue("/userImages/defaultProfilePic.webp"); //default profil fotoğrafı
            //Seed Data          
                

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "BaseCategory", ParentCategoryId = 1 },
            // Elektronik
            new Category { Id = 2, Name = "Elektronik", ParentCategoryId = 1 },
            new Category { Id = 3, Name = "Bilgisayarlar & Tabletler", ParentCategoryId = 2 },
            new Category { Id = 4, Name = "Telefonlar", ParentCategoryId = 2 },
            new Category { Id = 5, Name = "Oyun & Konsollar", ParentCategoryId = 2 },
            new Category { Id = 6, Name = "TV & Ses Sistemleri", ParentCategoryId = 2 },
            new Category { Id = 7, Name = "Kamera & Fotoğraf Makineleri", ParentCategoryId = 2 },

            // Giyim ve Aksesuar
            new Category { Id = 8, Name = "Giyim & Aksesuar", ParentCategoryId = 1 },
            new Category { Id = 9, Name = "Erkek Giyim", ParentCategoryId = 8 },
            new Category { Id = 10, Name = "Kadın Giyim", ParentCategoryId = 8 },
            new Category { Id = 11, Name = "Çocuk Giyim", ParentCategoryId = 8 },
            new Category { Id = 12, Name = "Ayakkabılar", ParentCategoryId = 8 },
            new Category { Id = 13, Name = "Çantalar", ParentCategoryId = 8 },

            // Ev ve Yaşam
            new Category { Id = 14, Name = "Ev & Yaşam", ParentCategoryId = 1 },
            new Category { Id = 15, Name = "Mobilya", ParentCategoryId = 14 },
            new Category { Id = 16, Name = "Dekorasyon", ParentCategoryId = 14 },
            new Category { Id = 17, Name = "Ev Aletleri", ParentCategoryId = 14 },

            // Kitap, Müzik ve Film
            new Category { Id = 18, Name = "Kitap & Müzik & Film", ParentCategoryId = 1 },
            new Category { Id = 19, Name = "Kitaplar", ParentCategoryId = 18 },
            new Category { Id = 20, Name = "Müzik Albümleri", ParentCategoryId = 18 },
            new Category { Id = 21, Name = "Filmler & Diziler", ParentCategoryId = 18 },

            // Spor ve Outdoor
            new Category { Id = 22, Name = "Spor & Outdoor", ParentCategoryId = 1 },
            new Category { Id = 23, Name = "Spor Giyim", ParentCategoryId = 22 },
            new Category { Id = 24, Name = "Spor Aletleri", ParentCategoryId = 22 },
            new Category { Id = 25, Name = "Kamp & Outdoor", ParentCategoryId = 22 },

            // Kozmetik ve Sağlık
            new Category { Id = 26, Name = "Kozmetik & Sağlık", ParentCategoryId = 1 },
            new Category { Id = 27, Name = "Makyaj", ParentCategoryId = 26 },
            new Category { Id = 28, Name = "Cilt Bakımı", ParentCategoryId = 26 },
            new Category { Id = 29, Name = "Saç Bakımı", ParentCategoryId = 26 },
            new Category { Id = 30, Name = "Parfümler", ParentCategoryId = 26 }
            );

            modelBuilder.Entity<Product>().HasData(

                new()
                {
                    Id = 1,
                    Title = "Iphone 15",
                    Description = "Kutusu Açılmadı",
                    Price = 100,
					Brand = "Apple",
                    Color = "Siyah",
                    Condition = "Yeni & Etiketli",
                    HeaderImageUrl = "/userUploads/users/ali/137425-1_large.webp",
                    CategoryId = 4,
                    SellerId = 1,
                    SellerUsername = "ali",
                    BuyerId = null
                },
                new()
                {
                    Id = 2,
                    Title = "S23 Ultra",
                    Description = "Sıfıra yakın",
                    Price = 150,
                    Brand = "Samsung",
                    Color = "Siyah",
                    Condition = "Az Kullanılmış",
                    HeaderImageUrl = "/userUploads/users/ali/137425-1_large.webp",
                    CategoryId = 4,
                    SellerId = 1,
                    SellerUsername = "ali",
                    BuyerId = null
                }


                );

            base.OnModelCreating(modelBuilder);

        }
    }
}
