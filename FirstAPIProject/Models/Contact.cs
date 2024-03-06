using System.ComponentModel.DataAnnotations;

namespace FirstAPIProject.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } //Property
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
  
}
