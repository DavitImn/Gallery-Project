using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IGalleryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
