using ContactManagement.Models;
using ContactManagement.Repositories.GenericRepository;
using Unity;
using Unity.Lifetime;

namespace ContactManagement.Services.InjectModules
{
    public static class RegisterModules
    {
        //Method where we need to register all the dependencies and return the container
        //This container gets resolved in the WebApiConfig
        public static UnityContainer RegisterDependency(UnityContainer container)
        {
            container.RegisterType<IGenericRepository<Contact>, GenericRepository<Contact>>(new HierarchicalLifetimeManager());
            return container;
        }

    }
}
