using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IGalleryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
