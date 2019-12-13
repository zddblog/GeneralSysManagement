using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace General.Entities.GeneralModels
{
    public partial class CoreContext : DbContext
    {
        public CoreContext()
        {
        }

        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserToken> SysUserToken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;database=Core;uid=sa;pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CssClass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FatherId)
                    .HasColumnName("FatherID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FatherResource)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceId)
                    .HasColumnName("ResourceID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RouteName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SysResource)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AllowLoginTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Salt).HasMaxLength(500);
            });

            modelBuilder.Entity<SysUserToken>(entity =>
            {
                entity.Property(e => e.ExpireTime).HasColumnType("datetime");

                entity.Property(e => e.SysUerId)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
