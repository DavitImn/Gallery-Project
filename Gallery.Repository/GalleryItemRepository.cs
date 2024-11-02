using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Repository
{
    public class GalleryItemRepository : RepositoryBase<GalleryItem>, IGalleryItemRepository
    {
        public GalleryItemRepository(IGalleryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
