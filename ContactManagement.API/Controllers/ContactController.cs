using System.Collections.Generic;
using FluentValidation.Results;
using Swashbuckle.Swagger.Annotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ContactManagement.API.Validators.Contact;
using ContactManagement.Contracts.Contact;
using ContactManagement.Services;
using Swashbuckle.Swagger;

namespace ContactManagement.API.Controllers
{
    [RoutePrefix("api/contact")]
    public class ContactController : ApiController
    {
        private readonly IContactValidator _contactValidator;
        private readonly IContactService _contactService;

        public ContactController()
        {

        }
        public ContactController(IContactValidator contactValidator, IContactService contactService)
        {
            _contactService = contactService;
            _contactValidator = contactValidator;
        }

        /// <summary>
        /// Returns list of contacts, for partial response - use a comma-separated list (fields=firstname,email) to select multiple fields.
        /// </summary>
        /// <returns> Returns list of contacts, for partial response - use a comma-separated list (fields=firstname,email) to select multiple fields.</returns>
        /// <returns>200 - OK, if everything is fine</returns>
        /// <returns>400 - BadRequest, in case of validation issue</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string[]))]
        public HttpResponseMessage Get()
        {
            var contacts = _contactService.Get();

            contacts = contacts.Select(d =>
            {
                d.AddLinks(CreateLinks(d));
                return d;
            });

            return Request.CreateResponse(HttpStatusCode.OK, contacts);
        }

        /// <summary>
        /// Returns contacts based on id
        /// </summary>
        /// <returns></returns>
        /// <returns>200 - OK, if everything is fine</returns>
        /// <returns>400 - BadRequest, in case of validation issue</returns>
        [HttpGet, Route("{id}", Name = "getById")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns this status code if the request was successful", Type = typeof(ContactResponseContract))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "In case of validation issue")]
        [SwaggerResponse(HttpStatusCode.NotFound, Description = "Contact with Id not found")]
        public HttpResponseMessage Get([FromUri]long id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Id is required");
            }
            
            var contact = _contactService.GetById(id);

            if (contact != null)
            {
                contact.AddLinks(CreateLinks(contact));
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            }

            return   Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Contact with id {id} not found");

        }

        /// <summary>
        /// For creating an contact information entry
        /// </summary>
        /// <param name="requestContract">requestContract that will be passed to this method</param>
        /// <returns>201 - Created, if contact is created</returns>
        /// <returns>400 - BadRequest, in case of model and model state validation</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Returns this status code if the request was successful")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "In case of invalid model data or if model validation fails")]
        public HttpResponseMessage Post(ContactRequestContract requestContract)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            var validationResult = _contactValidator.Validate(requestContract);

            if (!validationResult.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "This request is invalid, please review your request parameters. Errors: " + string.Join(", ",validationResult.Errors));
            }

            var addedContact = _contactService.Add(requestContract);

            return Request.CreateResponse(HttpStatusCode.OK, addedContact);
        }

        /// <summary>
        /// For updating an contact information entry
        /// </summary>
        /// <param name="requestContract">requestContract that will be passed to this method</param>
        /// <param name="id"></param>
        /// <returns>200 - OK, if contact is updated</returns>
        /// <returns>400 - BadRequest, in case of model and model state validation</returns>
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns this status code if the request was successful")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "In case of invalid model data or if model validation fails")]
        public HttpResponseMessage Put([FromUri] long id, ContactRequestContract requestContract)
        {
            if (!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            if (id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "Id missing");
            }

            var validationResult = _contactValidator.Validate(requestContract);

            if (!validationResult.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "This request is invalid, please review your request parameters. Errors: " +
                    string.Join(", ", validationResult.Errors));
            }

            _contactService.Edit(id, requestContract);

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        /// <summary>
        /// For deleting an contact entry
        /// </summary>
        /// <param name="id">id of the contact entry</param>
        /// <returns>200 - OK, if contact is deleted</returns>
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns this status code if the request was successful")]
        public HttpResponseMessage Delete([FromUri] long id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Id is required");
            }

            var contact = _contactService.GetById(id);

            contact.Status = false;

            var requestContact = Mapper.Map<ContactRequestContract>(contact);

            _contactService.Edit(id, requestContact);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private IEnumerable<Link> CreateLinks(ContactResponseContract contact)
        {
            var links = new[]
            {
                new Link
                {
                    Method = "GET",
                    Rel = "self",
                    Href = Url.Link("getById", new {id = contact.Id})
                }
            };
            return links;
        }


    }
}
