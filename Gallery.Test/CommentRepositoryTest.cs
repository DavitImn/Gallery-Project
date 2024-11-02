using Gallery.DependencyInjection;
using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Test
{
    [TestClass]
    public class CommentRepositoryTest
    {
        private static ICommentRepository _commentRepository;

        static CommentRepositoryTest()
        {
            UnityInjection.GetContainer();
            _commentRepository = UnityInjection.GetResolvedObject<ICommentRepository>();
        }

        [TestMethod]
        public void CommentSaveTest()
        {
            var user = new User() { Username = "TestName", Password = "TestPassword" };
            var comment = new Comment()
            {
                CommentText = "TestComment",
                User = user,
                GalleryItem = new GalleryItem() { User = user, Category = new Category() { CategoryName = "TestCategory" }}
            };
            _commentRepository.Save(comment);
            _commentRepository.SaveChanges();
            Assert.AreSame(comment, _commentRepository.Get(comment.ID));
        }

        [TestMethod]
        public void CommentDeleteTest()
        {
            var comment = _commentRepository.Set(x => x.CommentText == "TestComment").First();
            _commentRepository.Delete(comment);
            _commentRepository.SaveChanges();
            Assert.IsNull(_commentRepository.Get(comment.ID));
        }
    }
}
