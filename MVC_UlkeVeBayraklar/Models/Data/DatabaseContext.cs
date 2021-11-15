using Microsoft.EntityFrameworkCore;
using MVC_UlkeVeBayraklar.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UlkeVeBayraklar.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Ulke> Ulkeler { get; set; }

        public DbSet<Renk> Renkler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ulke>().HasData(
                new Ulke() { Id = 1, UlkeAd = "Türkiye" },
                new Ulke() { Id = 2, UlkeAd = "Almanya" },
                new Ulke() { Id = 3, UlkeAd = "Fransa" },
                new Ulke() { Id = 4, UlkeAd = "İngiltere" },
                new Ulke() { Id = 5, UlkeAd = "Portekiz" },
                new Ulke() { Id = 6, UlkeAd = "İtalya" },
                new Ulke() { Id = 7, UlkeAd = "Belçika" },
                new Ulke() { Id = 8, UlkeAd = "Hırvatistan" },
                new Ulke() { Id = 9, UlkeAd = "Galler" },
                new Ulke() { Id = 10, UlkeAd = "Finlandiya" },
                new Ulke() { Id = 11, UlkeAd = "Rusya" },
                new Ulke() { Id = 12, UlkeAd = "Hollanda" },
                new Ulke() { Id = 13, UlkeAd = "Ukrayna" },
                new Ulke() { Id = 14, UlkeAd = "Avusturya" },
                new Ulke() { Id = 15, UlkeAd = "Kuzey Makedonya" },
                new Ulke() { Id = 16, UlkeAd = "İskoçya" },
                new Ulke() { Id = 17, UlkeAd = "Çekya" },
                new Ulke() { Id = 18, UlkeAd = "İsviçre" },
                new Ulke() { Id = 19, UlkeAd = "Danimarka" },
                new Ulke() { Id = 20, UlkeAd = "İspanya" },
                new Ulke() { Id = 21, UlkeAd = "Macaristan" },
                new Ulke() { Id = 22, UlkeAd = "Polonya" },
                new Ulke() { Id = 23, UlkeAd = "İsveç" },
                new Ulke() { Id = 24, UlkeAd = "Slovakya" }
                );

            modelBuilder.Entity<Renk>().HasData(
                new Renk() { Id = 1, RenkAdi = "Siyah" },
                new Renk() { Id = 2, RenkAdi = "Kahverengi" },
                new Renk() { Id = 3, RenkAdi = "Gri" },
                new Renk() { Id = 4, RenkAdi = "Beyaz" },
                new Renk() { Id = 5, RenkAdi = "Sarı" },
                new Renk() { Id = 6, RenkAdi = "Pembe" },
                new Renk() { Id = 7, RenkAdi = "Mor" },
                new Renk() { Id = 8, RenkAdi = "Mavi" },
                new Renk() { Id = 9, RenkAdi = "Yeşil" },
                new Renk() { Id = 10, RenkAdi = "Kırmızı" }
                );

            modelBuilder.Entity<Renk>()
                .HasMany(x => x.Ulkeler)
                .WithMany(x => x.BayrakRenkleri)
                .UsingEntity<Dictionary<string, object>>(
                    "UlkelerVeBayraklar",
                    x => x.HasOne<Ulke>().WithMany().HasForeignKey("UlkeId"),
                    x => x.HasOne<Renk>().WithMany().HasForeignKey("RenkId"),
                    x => x.HasData(
                        new { UlkeId = 1, RenkId = 4 },
                        new { UlkeId = 1, RenkId = 10 },
                        new { UlkeId = 2, RenkId = 1 },
                        new { UlkeId = 2, RenkId = 5 },
                        new { UlkeId = 2, RenkId = 10 },
                        new { UlkeId = 3, RenkId = 4 },
                        new { UlkeId = 3, RenkId = 8 },
                        new { UlkeId = 3, RenkId = 10 },
                        new { UlkeId = 4, RenkId = 4 },
                        new { UlkeId = 4, RenkId = 8 },
                        new { UlkeId = 4, RenkId = 10 },
                        new { UlkeId = 5, RenkId = 9 },
                        new { UlkeId = 5, RenkId = 10 },
                        new { UlkeId = 6, RenkId = 4 },
                        new { UlkeId = 6, RenkId = 9 },
                        new { UlkeId = 6, RenkId = 10 },
                        new { UlkeId = 7, RenkId = 1 },
                        new { UlkeId = 7, RenkId = 5 },
                        new { UlkeId = 7, RenkId = 10 },
                        new { UlkeId = 8, RenkId = 4 },
                        new { UlkeId = 8, RenkId = 8 },
                        new { UlkeId = 8, RenkId = 10 },
                        new { UlkeId = 9, RenkId = 4 },
                        new { UlkeId = 9, RenkId = 9 },
                        new { UlkeId = 9, RenkId = 10 },
                        new { UlkeId = 10, RenkId = 4 },
                        new { UlkeId = 10, RenkId = 8 },
                        new { UlkeId = 11, RenkId = 4 },
                        new { UlkeId = 11, RenkId = 8 },
                        new { UlkeId = 11, RenkId = 10 },
                        new { UlkeId = 12, RenkId = 4 },
                        new { UlkeId = 12, RenkId = 8 },
                        new { UlkeId = 12, RenkId = 10 },
                        new { UlkeId = 13, RenkId = 5 },
                        new { UlkeId = 13, RenkId = 8 },
                        new { UlkeId = 14, RenkId = 4 },
                        new { UlkeId = 14, RenkId = 10 },
                        new { UlkeId = 15, RenkId = 5 },
                        new { UlkeId = 15, RenkId = 10 },
                        new { UlkeId = 16, RenkId = 4 },
                        new { UlkeId = 16, RenkId = 8 },
                        new { UlkeId = 17, RenkId = 4 },
                        new { UlkeId = 17, RenkId = 8 },
                        new { UlkeId = 17, RenkId = 10 },
                        new { UlkeId = 18, RenkId = 4 },
                        new { UlkeId = 18, RenkId = 10 },
                        new { UlkeId = 19, RenkId = 4 },
                        new { UlkeId = 19, RenkId = 10 },
                        new { UlkeId = 20, RenkId = 5 },
                        new { UlkeId = 20, RenkId = 10 },
                        new { UlkeId = 21, RenkId = 4 },
                        new { UlkeId = 21, RenkId = 9 },
                        new { UlkeId = 21, RenkId = 10 },
                        new { UlkeId = 22, RenkId = 4 },
                        new { UlkeId = 22, RenkId = 10 },
                        new { UlkeId = 23, RenkId = 5 },
                        new { UlkeId = 23, RenkId = 8 },
                        new { UlkeId = 24, RenkId = 4 },
                        new { UlkeId = 24, RenkId = 8 },
                        new { UlkeId = 24, RenkId = 10 }
                        )
                );
        }
    }
}
