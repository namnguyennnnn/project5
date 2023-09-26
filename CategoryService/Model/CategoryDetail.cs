using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CategoryService.Model
{
    [Table("category_details") ]
    public class CategoryDetail
    {      
        [Key]
        [MaxLength(36)]
        public string category_detail_id { get; set; }
        public string category_detail_name { get; set; }
        [MaxLength(36)]
        public string category_id { get; set; } 

        [ForeignKey("category_id")]
        public Categories Category { get; set; }
    }
}
