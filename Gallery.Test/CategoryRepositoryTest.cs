using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gallery.Repository;
using System;
using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using Gallery.DependencyInjection;
using System.Linq;

namespace Gallery.Test
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        private static ICategoryRepository _categoryRepository;

        static CategoryRepositoryTest()
        {
            UnityInjection.GetContainer();
            _categoryRepository = UnityInjection.GetResolvedObject<ICategoryRepository>();
        }
        [TestMethod]
        public void CategorySaveTest()
        {
            var category = new Category() { CategoryName = "Test", Description = "Rame" };
            _categoryRepository.Save(category);
            _categoryRepository.SaveChanges();
            Assert.AreSame(category,_categoryRepository.Get(category.ID));
        }

        [TestMethod]
        public void CategoryDeleteTest()
        {
            var category = _categoryRepository.Set(x => x.CategoryName == "Test").First();
            _categoryRepository.Delete(category);
            _categoryRepository.SaveChanges();
            Assert.IsNull(_categoryRepository.Get(category.ID));
        }
    }
}
