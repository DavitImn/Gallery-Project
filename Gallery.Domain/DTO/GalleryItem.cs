using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Domain.DTO
{
    [ComplexType]
    public class ItemData 
    { 
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required] 
        [Column(TypeName = "varbinary(max)")]
        public byte[] Data { get; set; }
    }

    //ToDo: უნდა შეგვეძლოს დრაფტის და გამოქვეყნებული მასალის მართვა.
    public class GalleryItem
    {
        [Key]
        public int ID { get; set; }

        public ItemData Draft { get; set; }

        public ItemData Published { get; set; }

        [Required] 
        public User User { get; set; }

        [Required] 
        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
