using ContactManagement.API.Validators.Contact;
using ContactManagement.Models;
using System.Data.Entity;
using ContactManagement.Repositories.GenericRepository;
using ContactManagement.Service;
using ContactManagement.Services;
using Unity;
using Unity.Lifetime;

namespace ContactManagement.API.InjectModules
{
    public class RegisterModules
    {
        public static UnityContainer GetUnityContainer()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IContactService, ContactService>(new HierarchicalLifetimeManager());
            container.RegisterType<IContactValidator, ContactValidator>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericRepository<Contact>, GenericRepository<Contact>>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, ContactDBContext>(new HierarchicalLifetimeManager());

            container = Services.InjectModules.RegisterModules.RegisterDependency(container);

            return container;
        }
    }
}