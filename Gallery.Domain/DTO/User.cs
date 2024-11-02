using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gallery.Domain.DTO
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<GalleryItem> Items { get; set; }
    }
}
