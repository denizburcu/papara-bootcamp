using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwnerProject.Domain.Entities
{
    [Table("owner")]
    public class Owner
    {
        [Key]
        [Required(ErrorMessage = "Not null")]
        public int Id { get; set; }
    
        [Required(ErrorMessage = "Not null")]
        [StringLength(255, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }

    }
}