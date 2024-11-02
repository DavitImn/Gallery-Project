using Gallery.DependencyInjection;
using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using MailSender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        private static IUserRepository _userRepository;

        static UserRepositoryTest()
        {
            UnityInjection.GetContainer();
            _userRepository = UnityInjection.GetResolvedObject<IUserRepository>();
        }
        [TestMethod]
        public void UserSaveTest()
        {
            var user = new User() { Username = "TestName", Password = "TestPassword" };
            _userRepository.Save(user);
            _userRepository.SaveChanges();
            Assert.AreSame(user, _userRepository.Get(user.ID));
        }

        [TestMethod]
        public void UserDeleteTest()
        {
            var user = _userRepository.Set(x => x.Username == "TestName").First();
            _userRepository.Delete(user);
            _userRepository.SaveChanges();
            Assert.IsNull(_userRepository.Get(user.ID));
        }
    }
}
