using System.ComponentModel.DataAnnotations;

namespace Otamimi.Models
{
    public class  Note   
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        [Required]
        public ApplicationUser AddedBy { get; set; }
    }
}