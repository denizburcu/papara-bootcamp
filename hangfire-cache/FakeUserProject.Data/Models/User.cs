using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeUserProject.Data.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int userId { get; set; }
        public string? title { get; set; }
        public string? body { get; set; }
    }
}