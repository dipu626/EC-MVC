using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EC.WEB.Models.Category
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public required string Name { get; set; }

        [Required]
        [Range(1, 100)]
        [DisplayName("Display Order")]
        public required int DisplayOrder { get; set; }
    }
}
