using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Domain.Interfaces;
using Gallery.Domain.DTO;

namespace Gallery.Repository.Repositories
{
    public class GalleryItemRepository : RepositoryBase<GalleryItem>, IGalleryItemRepository
    {
        public GalleryItemRepository(IGalleryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
