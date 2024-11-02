using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Domain.DTO
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(1000)]
        public string CommentText { get; set; }

        public User User { get; set; }

        public GalleryItem GalleryItem { get; set; }
    }
}
