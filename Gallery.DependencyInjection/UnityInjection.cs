using Gallery.Domain.DTO;
using Gallery.Domain.Interfaces;
using Gallery.Repository;
using MailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Gallery.DependencyInjection
{
    public static class UnityInjection
    {
        private readonly static IUnityContainer _container;

        static UnityInjection()
        {
            _container = new UnityContainer();
        }

        public static void GetContainer()
        {
            // Get all domain interfaces
            var interfaces = typeof(User).Assembly.GetTypes()
              .Where(t => t.IsInterface);

            // Configure all repositories 
            (
              from t in typeof(UserRepository).Assembly.GetTypes()
              from i in interfaces
              where i.IsAssignableFrom(t)
              select _container.RegisterType(i, t)
            ).ToArray();

            _container.RegisterType(typeof(IMailSenderService), typeof(MailSenderService));
        }

        public static T GetResolvedObject<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
