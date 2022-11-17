using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwnerProject.Domain.Models
{
    [Table("OWNER")]
    public class Owner
    {
        [Key]
        [Required(ErrorMessage = "Not null")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Not null")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters.")]
        public string? Name { get; set; }

        [StringLength(60, ErrorMessage = "Surname can't be longer than 60 characters.")]
        public string? Surname { get; set; }
        public DateTime Date { get; set; }

        [StringLength(255, ErrorMessage = "Description can't be longer than 255 characters.")]
        public string? Description { get; set; }

        [StringLength(10, ErrorMessage = "Type can't be longer than 10 characters.")]
        public string? Type { get; set; }
    }
}