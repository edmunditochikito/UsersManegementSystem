using System.ComponentModel.DataAnnotations;

namespace UsersManegementSystem.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "El nombre del rol es demasiado largo"), MinLength(3, ErrorMessage = "El nombre del rol es demasiado corto")]
        public string Roles { get; set; }
    }
}
