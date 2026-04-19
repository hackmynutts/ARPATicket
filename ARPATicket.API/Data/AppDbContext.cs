using ARPATicket.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ARPATicket.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);

            // Configure the relationship between User and Ticket
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.ticketID);
                entity.Property(e => e.title).IsRequired();
                entity.Property(e => e.description).HasMaxLength(500).IsRequired();
                entity.Property(e => e.status).IsRequired();
                entity.HasOne<User>(e => e.assignedUser) //EF Core necesita saber cómo navegar de Ticket → User en memoria, aunque en la base de datos solo guarde int
                              .WithMany()
                              .HasForeignKey(e => e.assignedUserID)
                              .IsRequired(false) // El ticket puede no tener un usuario asignado
                              .OnDelete(DeleteBehavior.SetNull);        // ← SetNull en vez de Cascade

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.userID); 
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.username).IsRequired();
                entity.Property(e => e.email).IsRequired();
                entity.Property(e => e.AvatarID).IsRequired();
            });
        }
    }
}
