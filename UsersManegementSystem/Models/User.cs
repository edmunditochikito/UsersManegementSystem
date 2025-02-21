using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UsersManegementSystem.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El rol es requerido")]
        public int Id_role { get; set; } = 1;
        [ForeignKey("Id_role")]
        public Role Role { get; set; }
        [MaxLength(50, ErrorMessage = "El nombre es demasiado largo"), MinLength(3, ErrorMessage = "el nombre es demasiado corto"),Display(Name ="Nombres")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "El apellido es demasiado largo"), MinLength(3, ErrorMessage = "el apellido es demasiado corto"),Display(Name="Apellidos")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "El email no es valido"), Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida") ,Display(Name ="Contraseña")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El telefono es requerido"),Phone,Display(Name="Telefono")]
        public string Phone { get; set; }
        [Display(Name ="Fecha de creacion")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        [FileExtensions(Extensions = "jpg,jpeg,png,gif", ErrorMessage = "El archivo no es una imagen")]
        public string Photo { get; set; }
    }
}
