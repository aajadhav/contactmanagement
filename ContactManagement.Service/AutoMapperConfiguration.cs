using AutoMapper;
using ContactManagement.Contracts.Contact;
using ContactManagement.Models;

namespace ContactManagement.Services
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<Contact, ContactResponseContract>();
                    cfg.CreateMap<Contact, ContactRequestContract>();
                    cfg.CreateMap<ContactResponseContract, Contact>();
                    cfg.CreateMap<ContactRequestContract, Contact>();
                    cfg.CreateMap<ContactRequestContract, ContactResponseContract>();
                    cfg.CreateMap<ContactResponseContract, ContactRequestContract>();
                });
        }
    }
}
