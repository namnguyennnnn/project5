using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CategoryApi.Model
{
    [Table("categories")]
    public class Categories
    {        
        [Key ]
        [MaxLength(36)]
        public string category_id { get; set; }
        public string category_name { get; set; }

        public List<CategoryDetail> CategoryDetails { get; set; }
    }
}
