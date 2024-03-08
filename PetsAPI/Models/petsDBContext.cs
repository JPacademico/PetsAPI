using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetsAPI.Models
{
    public partial class petsDBContext : DbContext
    {
        public petsDBContext()
        {
        }

        public petsDBContext(DbContextOptions<petsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<Tutor> Tutors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=PC03LAB2539\\SENAI; Database=petsDB; User Id=sa; Password=senai.123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.IdPet)
                    .HasName("PK__Pet__6FCACBE918CD40E5");

                entity.ToTable("Pet");

                entity.Property(e => e.IdPet).HasColumnName("id_pet");

                entity.Property(e => e.IdTutor).HasColumnName("id_tutor");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.NomePet)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_pet");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdTutorNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.IdTutor)
                    .HasConstraintName("FK__Pet__id_tutor__38996AB5");
            });

            modelBuilder.Entity<Tutor>(entity =>
            {
                entity.HasKey(e => e.IdTutor)
                    .HasName("PK__Tutor__C176593DB05664E6");

                entity.ToTable("Tutor");

                entity.Property(e => e.IdTutor).HasColumnName("id_tutor");

                entity.Property(e => e.Cpf)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("cpf");

                entity.Property(e => e.NomeTutor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome_tutor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
