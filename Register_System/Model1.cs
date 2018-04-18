namespace Register_System
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class Model1 : DbContext
    {
        public Model1() : base("name=Model1")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<TempSession> TempSessions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .Property(e => e.SessionTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Session>()
                .Property(e => e.SessionDate)
                .IsUnicode(false);

            modelBuilder.Entity<Session>()
                .Property(e => e.SessionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<TempSession>()
                .Property(e => e.TempSessTitle)
                .IsUnicode(false);

            modelBuilder.Entity<TempSession>()
                .Property(e => e.TempSessDate)
                .IsUnicode(false);

            modelBuilder.Entity<TempSession>()
                .Property(e => e.TempSessDescription)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Division)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Sessions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
