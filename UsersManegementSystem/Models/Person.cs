using System.ComponentModel.DataAnnotations;

namespace UsersManegementSystem.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="El nombre es demasiado largo"),MinLength(3,ErrorMessage ="el nombre es demasiado corto")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "El apellido es demasiado largo"), MinLength(3, ErrorMessage = "el apellido es demasiado corto")]
        public string LastName { get; set; }
    }
}
