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
    public class GalleryItemRepositoryTest
    {
        private static IGalleryItemRepository _galleryItemRepository;
        static GalleryItemRepositoryTest()
        {
            UnityInjection.GetContainer();
            _galleryItemRepository = UnityInjection.GetResolvedObject<IGalleryItemRepository>();
        }

        [TestMethod]
        public void GalleryItemSaveTest()
        {
            var category = new Category() { CategoryName = "TestName" };
            var user = new User() { Username = "TestUser", Password = "TestPassword" };
            var draft = new ItemData() { Name = "TestName", Description = "TestDescription" , Data = new byte[] {0,1} };
            var galleryItem = new GalleryItem() { Draft = draft, Category = category, User = user };
            _galleryItemRepository.Save(galleryItem);
            _galleryItemRepository.SaveChanges();
            Assert.AreSame(galleryItem, _galleryItemRepository.Get(galleryItem.ID));
        }

        [TestMethod]
        public void GalleryItemDeleteTest()
        {
            var galleryItem = _galleryItemRepository.Set(x => x.Draft.Name == "TestName").First();
            _galleryItemRepository.Delete(galleryItem);
            _galleryItemRepository.SaveChanges();
            Assert.IsNull(_galleryItemRepository.Get(galleryItem.ID));
        }
    }
}
