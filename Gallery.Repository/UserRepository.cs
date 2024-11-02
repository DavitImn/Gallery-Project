using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using PasswordSecurities;

namespace Gallery.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IGalleryDbContext dbContext) : base(dbContext)
        {
           
        }

        public override void Save(User item)
        {
            using(var passwordHash = new PasswordHash(item.Password))
            {
                item.Password = Encoding.Default.GetString(passwordHash.ToArray());
                //StringBuilder passString = new StringBuilder();
                //foreach (var b in passwordHash.ToArray())
                //{
                //    passString.Append((char)b);
                //}
                //item.Password = passString.ToString();
            }
            base.Save(item);
        }
    }
}