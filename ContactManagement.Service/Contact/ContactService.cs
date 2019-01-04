using ContactManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using ContactManagement.Contracts.Contact;
using ContactManagement.Repositories.GenericRepository;
using ContactManagement.Services;
using AutoMapper;

namespace ContactManagement.Service
{
    public class ContactService : IContactService
    {

        private readonly IGenericRepository<Contact> _contactRepository;

        public ContactService(IGenericRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;


        }

        public ContactResponseContract Add(ContactRequestContract requestContract)
        {
            var requestContact = Mapper.Map<Contact>(requestContract);

            var contact = _contactRepository.Add(requestContact);

            return Mapper.Map<ContactResponseContract>(contact);
        }

        public void Edit(long id, ContactRequestContract requestContract)
        {
            var contact = _contactRepository.GetById(id);

            var requestContact = Mapper.Map<Contact>(requestContract);

            contact.FirstName = requestContact.FirstName;
            contact.LastName = requestContact.LastName;
            contact.PhoneNumber = requestContact.PhoneNumber;
            contact.Email = requestContact.Email;
            contact.Status = requestContact.Status;

            _contactRepository.Edit(contact);
        }

        public IEnumerable<ContactResponseContract> Get()
        {
            var contacts = _contactRepository.GetAll().ToList();

            return contacts.Select(Mapper.Map<ContactResponseContract>);
        }

        public ContactResponseContract GetById(long id)
        {
            var contact = _contactRepository.GetById(id);

            var contactResponse = Mapper.Map<ContactResponseContract>(contact);

            return contactResponse;
        }

    }
}
