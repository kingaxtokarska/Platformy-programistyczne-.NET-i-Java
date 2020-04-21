using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public partial class firmaContext : DbContext
    {
        public firmaContext()
        {
        }

        public firmaContext(DbContextOptions<firmaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dzial> Dzial { get; set; }
        public virtual DbSet<Godzinypracy> Godzinypracy { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Stanowisko> Stanowisko { get; set; }
        public virtual DbSet<Wejscia> Wejscia { get; set; }
        public virtual DbSet<Wyjscia> Wyjscia { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<Rola> Rola { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dzial>(entity =>
            {
                entity.HasKey(e => e.IdDzial)
                    .HasName("PRIMARY");

                entity.ToTable("dzial");

                entity.Property(e => e.IdDzial).HasColumnName("idDzial");

                entity.Property(e => e.NazwaDzial)
                    .IsRequired()
                    .HasColumnName("nazwaDzial")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Godzinypracy>(entity =>
            {
                entity.HasKey(e => e.idGodzinyPracy)
                    .HasName("PRIMARY");

                entity.ToTable("godzinypracy");

                entity.Property(e => e.idGodzinyPracy).HasColumnName("idGodzinyPracy");

                entity.Property(e => e.idGodzinyPracy)
                    .HasColumnName("idGodzinyPracy")
                    .HasColumnType("int");

                entity.HasIndex(e => e.IdDzial)
                    .HasName("FK_DzialGodziny");

                entity.Property(e => e.DzienTygodnia)
                    .IsRequired()
                    .HasColumnName("dzienTygodnia")
                    .HasColumnType("varchar(12)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdDzial).HasColumnName("idDzial");

                entity.Property(e => e.KoniecPracy)
                    .HasColumnName("koniecPracy")
                    .HasColumnType("time");

                entity.Property(e => e.PoczatekPracy)
                    .HasColumnName("poczatekPracy")
                    .HasColumnType("time");

                entity.HasOne(d => d.IdDzialNavigation)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(d => d.IdDzial)
                    .HasConstraintName("FK_DzialGodziny");
            });

            modelBuilder.Entity<Stanowisko>(entity =>
            {
                entity.HasKey(e => e.IdStanowisko)
                    .HasName("PRIMARY");

                entity.ToTable("stanowisko");

                entity.HasIndex(e => e.IdDzial)
                    .HasName("FK_DzialStanowisko");

                entity.Property(e => e.IdStanowisko).HasColumnName("idStanowisko");

                entity.Property(e => e.IdDzial).HasColumnName("idDzial");

                entity.Property(e => e.NazwaStanowisko)
                    .IsRequired()
                    .HasColumnName("nazwaStanowisko")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Wynagrodzenie).HasColumnName("wynagrodzenie");

                entity.HasOne(d => d.IdDzialNavigation)
                    .WithMany(p => p.Stanowisko)
                    .HasForeignKey(d => d.IdDzial)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DzialStanowisko");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("PRIMARY");

                entity.ToTable("pracownik");

                entity.HasIndex(e => e.IdStanowisko)
                    .HasName("FK_StanowiskoPracownik");

                entity.Property(e => e.IdPracownik).HasColumnName("idPracownik");

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnName("dataZatrudnienia")
                    .HasColumnType("date");

                entity.Property(e => e.IdStanowisko).HasColumnName("idStanowisko");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("pesel")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.StatusZatrudnienia)
                    .IsRequired()
                    .HasColumnName("statusZatrudnienia")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdStanowiskoNavigation)
                    .WithMany(p => p.Pracownik)
                    .HasForeignKey(d => d.IdStanowisko)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PracownikStanowisko");
            });

            modelBuilder.Entity<Rola>(entity =>
            {
                entity.HasKey(e => e.IdRola)
                    .HasName("PRIMARY");

                entity.ToTable("rola");

                entity.Property(e => e.IdRola).HasColumnName("idRola");

                entity.Property(e => e.NazwaRola)
                    .IsRequired()
                    .HasColumnName("nazwaRola")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Wejscia>(entity =>
            {
                entity.HasKey(e => e.idWejscie)
                    .HasName("PRIMARY");

                entity.ToTable("wejscia");

                entity.Property(e => e.idWejscie).HasColumnName("idWejscie");

                entity.Property(e => e.idWejscie)
                    .HasColumnName("idWejscie")
                    .HasColumnType("int");

                entity.HasIndex(e => e.IdPracownik)
                   .HasName("FK_PracownikWejscie");

                entity.Property(e => e.DataWejscia)
                    .HasColumnName("dataWejscia")
                    .HasColumnType("date");

                entity.Property(e => e.GodzinaWejscia)
                    .HasColumnName("godzinaWejscia")
                    .HasColumnType("time");

                entity.Property(e => e.DzienTygodnia)
                    .HasColumnName("dzienTygodnia")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.IdPracownik).HasColumnName("idPracownik");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PracownikWejscie");
            });


            modelBuilder.Entity<Wyjscia>(entity =>
            {
                entity.HasKey(e => e.idWyjscie)
                    .HasName("PRIMARY");

                entity.ToTable("wyjscia");

                entity.Property(e => e.idWyjscie).HasColumnName("idWyjscie");

                entity.Property(e => e.idWyjscie)
                    .HasColumnName("idWyjscie")
                    .HasColumnType("int");

                entity.HasIndex(e => e.IdPracownik)
                    .HasName("FK_PracownikWyjscie");

                entity.Property(e => e.DataWyjscia)
                    .HasColumnName("dataWyjscia")
                    .HasColumnType("date");

                entity.Property(e => e.GodzinaWyjscia)
                    .HasColumnName("godzinaWyjscia")
                    .HasColumnType("time");

                entity.Property(e => e.DzienTygodnia)
                  .HasColumnName("dzienTygodnia")
                  .HasColumnType("varchar(10)");

                entity.Property(e => e.IdPracownik).HasColumnName("idPracownik");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PracownikWyjscie");
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownik)
                    .HasName("PRIMARY");

                entity.ToTable("uzytkownik");

                entity.HasIndex(e => e.IdUzytkownik)
                    .HasName("FK_UzytkownikRola");

                entity.Property(e => e.IdUzytkownik).HasColumnName("idUzytkownik");

                entity.Property(e => e.IdRola).HasColumnName("idRola");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasColumnName("haslo")
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdRolaNavigation)
                    .WithMany(p => p.Uzytkownik)
                    .HasForeignKey(d => d.IdRola)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UzytkownikRola");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = ConfigurationSettings.ConnectionSettings;

            optionsBuilder.UseMySql(connection);
        }
    }
}