using System.Collections.Generic;
using ContactManagement.Contracts.Contact;
using ContactManagement.Models;

namespace ContactManagement.Mappers.Mappers
{
    public static class ContactMapper
    {
        public static Contact Map(ContactResponseContract contactResponseContract)
        {
            return new Contact
            {
                FirstName = contactResponseContract.FirstName,
                LastName = contactResponseContract.LastName,
                Email = contactResponseContract.Email,
                PhoneNumber = contactResponseContract.PhoneNumber,
                Status = contactResponseContract.Status
            };

        }

        public static Contact Map(Contact customer, ContactResponseContract contactResponseContract)
        {
            customer.FirstName = contactResponseContract.FirstName;
            customer.LastName = contactResponseContract.LastName;
            customer.Email = contactResponseContract.Email;
            customer.PhoneNumber = contactResponseContract.PhoneNumber;

            return customer;
        }
        public static ContactResponseContract Map(Contact customer)
        {
            return new ContactResponseContract
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Status = customer.Status
            };

        }

        public static List<ContactResponseContract> Map(List<Contact> customers)
        {
            List<ContactResponseContract> customerList = new List<ContactResponseContract>();

            foreach (Contact customer in customers)
            {
                customerList.Add(Map(customer));
            }

            return customerList;
        }

    }
}
