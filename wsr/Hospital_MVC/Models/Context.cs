using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hospital_MVC.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointman> Appointmen { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<CardHasIssuer> CardHasIssuers { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Issuer> Issuers { get; set; } = null!;
        public virtual DbSet<Pacient> Pacients { get; set; } = null!;
        public virtual DbSet<Poli> Polis { get; set; } = null!;
        public virtual DbSet<Recomendation> Recomendations { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<TypeAppointman> TypeAppointmen { get; set; } = null!;
        public virtual DbSet<TypeDoctor> TypeDoctors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointman>(entity =>
            {
                entity.HasKey(e => e.IdAppointmen)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CardIdCard, "fk_Appointmen_Card1_idx");

                entity.HasIndex(e => e.RecomendationIdRecom, "fk_Appointmen_Recomendation1_idx");

                entity.HasIndex(e => e.ResultIdResult, "fk_Appointmen_Result1_idx");

                entity.HasIndex(e => e.TypeAppointmenIdType, "fk_Appointmen_TypeAppointmen1_idx");

                entity.Property(e => e.IdAppointmen)
                    .HasColumnType("int(11)")
                    .HasColumnName("idAppointmen");

                entity.Property(e => e.CardIdCard)
                    .HasColumnType("int(11)")
                    .HasColumnName("Card_idCard");

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.RecomendationIdRecom)
                    .HasColumnType("int(11)")
                    .HasColumnName("Recomendation_idRecom");

                entity.Property(e => e.ResultIdResult)
                    .HasColumnType("int(11)")
                    .HasColumnName("Result_idResult");

                entity.Property(e => e.TypeAppointmenIdType)
                    .HasColumnType("int(11)")
                    .HasColumnName("TypeAppointmen_idType");

                entity.HasOne(d => d.CardIdCardNavigation)
                    .WithMany(p => p.Appointmen)
                    .HasForeignKey(d => d.CardIdCard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Appointmen_Card1");

                entity.HasOne(d => d.RecomendationIdRecomNavigation)
                    .WithMany(p => p.Appointmen)
                    .HasForeignKey(d => d.RecomendationIdRecom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Appointmen_Recomendation1");

                entity.HasOne(d => d.ResultIdResultNavigation)
                    .WithMany(p => p.Appointmen)
                    .HasForeignKey(d => d.ResultIdResult)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Appointmen_Result1");

                entity.HasOne(d => d.TypeAppointmenIdTypeNavigation)
                    .WithMany(p => p.Appointmen)
                    .HasForeignKey(d => d.TypeAppointmenIdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Appointmen_TypeAppointmen1");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.IdCard)
                    .HasName("PRIMARY");

                entity.ToTable("Card");

                entity.Property(e => e.IdCard)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCard");

                entity.Property(e => e.Dategive).HasColumnType("date");

                entity.Property(e => e.Datelast).HasColumnType("date");

                entity.Property(e => e.Datenext).HasColumnType("date");
            });

            modelBuilder.Entity<CardHasIssuer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Card_has_Issuer");

                entity.HasIndex(e => e.CardIdCard1, "fk_Card_has_Issuer_Card1_idx");

                entity.HasIndex(e => e.IssuerIdIssuer, "fk_Card_has_Issuer_Issuer1_idx");

                entity.Property(e => e.CardIdCard1)
                    .HasColumnType("int(11)")
                    .HasColumnName("Card_idCard1");

                entity.Property(e => e.IssuerIdIssuer)
                    .HasColumnType("int(11)")
                    .HasColumnName("Issuer_idIssuer");

                entity.HasOne(d => d.CardIdCard1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.CardIdCard1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Card_has_Issuer_Card1");

                entity.HasOne(d => d.IssuerIdIssuerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IssuerIdIssuer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Card_has_Issuer_Issuer1");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PRIMARY");

                entity.ToTable("Doctor");

                entity.HasIndex(e => e.AppointmenIdAppointmen, "fk_Doctor_Appointmen1_idx");

                entity.HasIndex(e => e.TypeDoctorIdTypeDoctor, "fk_Doctor_TypeDoctor_idx");

                entity.Property(e => e.IdDoctor)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDoctor");

                entity.Property(e => e.AppointmenIdAppointmen)
                    .HasColumnType("int(11)")
                    .HasColumnName("Appointmen_idAppointmen");

                entity.Property(e => e.Dadname).HasMaxLength(45);

                entity.Property(e => e.Firstname).HasMaxLength(45);

                entity.Property(e => e.Surname).HasMaxLength(45);

                entity.Property(e => e.TypeDoctorIdTypeDoctor)
                    .HasColumnType("int(11)")
                    .HasColumnName("TypeDoctor_idTypeDoctor");

                entity.HasOne(d => d.AppointmenIdAppointmenNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.AppointmenIdAppointmen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Doctor_Appointmen1");

                entity.HasOne(d => d.TypeDoctorIdTypeDoctorNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.TypeDoctorIdTypeDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Doctor_TypeDoctor");
            });

            modelBuilder.Entity<Issuer>(entity =>
            {
                entity.HasKey(e => e.IdIssuer)
                    .HasName("PRIMARY");

                entity.ToTable("Issuer");

                entity.Property(e => e.IdIssuer)
                    .HasColumnType("int(11)")
                    .HasColumnName("idIssuer");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Pacient>(entity =>
            {
                entity.HasKey(e => e.IdPacient)
                    .HasName("PRIMARY");

                entity.ToTable("Pacient");

                entity.HasIndex(e => e.CardIdCard, "fk_Pacient_Card1_idx");

                entity.HasIndex(e => e.PolisIdPolis, "fk_Pacient_Polis1_idx");

                entity.Property(e => e.IdPacient)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPacient");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.CardIdCard)
                    .HasColumnType("int(11)")
                    .HasColumnName("Card_idCard");

                entity.Property(e => e.Dadname).HasMaxLength(45);

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Firstname).HasMaxLength(45);

                entity.Property(e => e.Passport).HasColumnType("int(10)");

                entity.Property(e => e.Phone).HasMaxLength(45);

                entity.Property(e => e.PolisIdPolis)
                    .HasColumnType("int(11)")
                    .HasColumnName("Polis_idPolis");

                entity.Property(e => e.Surname).HasMaxLength(45);

                entity.HasOne(d => d.CardIdCardNavigation)
                    .WithMany(p => p.Pacients)
                    .HasForeignKey(d => d.CardIdCard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pacient_Card1");

                entity.HasOne(d => d.PolisIdPolisNavigation)
                    .WithMany(p => p.Pacients)
                    .HasForeignKey(d => d.PolisIdPolis)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pacient_Polis1");
            });

            modelBuilder.Entity<Poli>(entity =>
            {
                entity.HasKey(e => e.IdPolis)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdPolis)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPolis");

                entity.Property(e => e.Dateend).HasColumnType("date");

                entity.Property(e => e.Number).HasColumnType("int(10)");
            });

            modelBuilder.Entity<Recomendation>(entity =>
            {
                entity.HasKey(e => e.IdRecom)
                    .HasName("PRIMARY");

                entity.ToTable("Recomendation");

                entity.Property(e => e.IdRecom)
                    .HasColumnType("int(11)")
                    .HasColumnName("idRecom");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.IdResult)
                    .HasName("PRIMARY");

                entity.ToTable("Result");

                entity.Property(e => e.IdResult)
                    .HasColumnType("int(11)")
                    .HasColumnName("idResult");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<TypeAppointman>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdType)
                    .HasColumnType("int(11)")
                    .HasColumnName("idType");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<TypeDoctor>(entity =>
            {
                entity.HasKey(e => e.IdTypeDoctor)
                    .HasName("PRIMARY");

                entity.ToTable("TypeDoctor");

                entity.Property(e => e.IdTypeDoctor)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTypeDoctor");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
