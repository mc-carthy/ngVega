using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ngVega.Models
{
    [Table("Models")]
    public class Model
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Make Make { get; set; }
        public int MakeId { get; set; }
        // By convention, naming the property using the pattern parent_name + parent_property
        // it ensures it can be used as a foreign key. Ensure the types are the same (int).
    }
}