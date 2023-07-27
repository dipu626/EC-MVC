using System.ComponentModel.DataAnnotations;

namespace EC.WEB.Models.Category
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
