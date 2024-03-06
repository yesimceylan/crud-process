using FirstAPIProject.Data;
using FirstAPIProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPIProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        // Dependency Injection

        private readonly ContactsAPIDbContext _dbContext;  // ContactsAPIDbContext'in implementasyonu yerleşik olarak yapıldı

        // Bir readonly'nin değerini iki yerde verebilirsiniz ilki constructor, diğeri tanımlandığı yerdir.
        // Ayrıca readonly ifadeler bir kez set edilebilir
        public ContactsController(ContactsAPIDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts() 
        {
            return Ok(await _dbContext.Contacts.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact([FromRoute] int id) 
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if (contact == null)
            { 
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] AddContactRequest contact)
        {
            Contact newContact = new()
            {
                FullName = contact.FullName,
                Address = contact.Address,
                Email = contact.Email,
                Gender = contact.Gender,
                Phone = contact.Phone
            };
            await _dbContext.Contacts.AddAsync(newContact);
            await _dbContext.SaveChangesAsync();

            return Ok(newContact);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactRequest contact, int id)
        {
            var data = await _dbContext.Contacts.FindAsync(id);
            if (data == null)
            {
                return NotFound("Kişi bulunamadı.");
            }
            data.FullName =contact.FullName;
            data.Email=contact.Email;
            data.Address = contact.Address;
            data.Gender=contact.Gender;
            data.Phone = contact.Phone;

            await _dbContext.SaveChangesAsync();
            return Ok(data);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteContact( int id)
        {
            await _dbContext.Contacts.Where(x => x.Id == id).ExecuteDeleteAsync();
            return Ok("Kişi silindi !");
        }

    }
}
