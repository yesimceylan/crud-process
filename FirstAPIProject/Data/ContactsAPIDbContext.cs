using FirstAPIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIProject.Data
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {
            //options ile bağlantı dizesi alınmış olacak
        }
        public DbSet<Contact> Contacts { get; set; } //Tablo
    }
}
