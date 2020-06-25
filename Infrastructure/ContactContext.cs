using ContactsBackendDotnet.Models;
using Microsoft.EntityFrameworkCore;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(
            b =>
            {
                b.Property(e => e.Id);
                b.HasKey(e => e.Id);
                b.Property(e => e.FirstName);
                b.Property(e => e.LastName);
                b.Property(e => e.PhoneNumber);
            });
    }
}