using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORMDAL
{
    public partial class DefaultDBContext : DbContext
    {
        public DefaultDBContext()
        {
        }

        public DefaultDBContext(DbContextOptions<DefaultDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HP76AG0\\SQLEXPRESS;Initial Catalog=DBPrikol;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.playDate).HasColumnType("datetime");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.game)
                    .HasForeignKey(d => d.userID)
                    .HasConstraintName("FK_Games_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.creationDate).HasColumnType("datetime");

                entity.Property(e => e.login).IsRequired();

                entity.Property(e => e.name).IsRequired();

                entity.Property(e => e.password).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
