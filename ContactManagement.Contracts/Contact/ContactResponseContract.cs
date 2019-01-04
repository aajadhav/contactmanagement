using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactManagement.Contracts.Contact
{
    public class ContactResponseContract
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public IEnumerable<Link> Links;

        public void AddLinks(IEnumerable<Link> links)
        {
            Links = Links == null ? links : Links.Concat(links);
        }
    }
}
