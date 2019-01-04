using ContactManagement.Models;
using System;
using System.Collections.Generic;
using ContactManagement.Contracts.Contact;

namespace ContactManagement.Services
{
    public interface IContactService
    {
        ContactResponseContract GetById(long id);
        IEnumerable<ContactResponseContract> Get();
        ContactResponseContract Add(ContactRequestContract responseContract);
        void Edit(long id, ContactRequestContract requestContract);
    }
}
