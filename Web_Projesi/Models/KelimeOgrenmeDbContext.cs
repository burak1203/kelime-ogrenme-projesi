using Microsoft.EntityFrameworkCore;

namespace Web_Projesi.Models
{
    public class KelimeOgrenmeDbContext : DbContext
    {
        public KelimeOgrenmeDbContext(DbContextOptions<KelimeOgrenmeDbContext> options) : base(options) { }

        public DbSet<Kelimeler> Kelimeler { get; set; } = null!;
        public DbSet<Kategoriler> Kategoriler { get; set; } = null!;
        public DbSet<KullaniciIlerlemesi> KullaniciIlerlemesi { get; set; } = null!;
        public DbSet<Kullanicilar> Kullanicilar { get; set; } = null!;
        public DbSet<Quiz> Quizler { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kelimeler>(entity =>
            {
                entity.ToTable("Kelimeler");
                entity.HasKey(e => e.KelimeID);
                entity.Property(e => e.KelimeAdi).HasColumnName("KelimeAdi").IsRequired();
                entity.Property(e => e.Tanim).HasColumnName("Tanim");
                entity.Property(e => e.Tur).HasColumnName("Tur");
                entity.Property(e => e.OrnekCumle).HasColumnName("OrnekCumle");
            });

            modelBuilder.Entity<Kategoriler>(entity =>
            {
                entity.ToTable("Kategoriler");
                entity.HasKey(e => e.KategoriID);
                entity.Property(e => e.KategoriAdi).IsRequired();
            });

            modelBuilder.Entity<KullaniciIlerlemesi>(entity =>
            {
                entity.ToTable("KullaniciIlerlemesi");
                entity.HasKey(e => e.IlerlemeID);
                entity.HasOne(e => e.Kullanici)
                    .WithMany()
                    .HasForeignKey(e => e.KullaniciID);
                entity.HasOne(e => e.Kelime)
                    .WithMany()
                    .HasForeignKey(e => e.KelimeID);
            });

            modelBuilder.Entity<Kullanicilar>(entity =>
            {
                entity.ToTable("Kullanicilar");
                entity.HasKey(e => e.KullaniciID);
                entity.Property(e => e.KullaniciAdi).IsRequired();
                entity.Property(e => e.Eposta).IsRequired();
                entity.Property(e => e.Sifre).IsRequired();
                entity.Property(e => e.Durum).HasDefaultValue("Aktif");
                entity.Property(e => e.Rol).HasDefaultValue("Kullanici");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quizler");
                entity.HasKey(e => e.QuizID);
                entity.Property(e => e.Tarih).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne(e => e.Kullanici)
                    .WithMany()
                    .HasForeignKey(e => e.KullaniciID);
            });
        }
    }
}
