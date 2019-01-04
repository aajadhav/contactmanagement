using ContactManagement.Contracts.Contact;
using FluentValidation;

namespace ContactManagement.API.Validators.Contact
{
    public class ContactValidator :AbstractValidator<ContactRequestContract>, IContactValidator
    {
        public ContactValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("Contact first name is required").MaximumLength(20).WithMessage("First name too long");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Contact last name is required").MaximumLength(20).WithMessage("Last name too long");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("Contact phone number is required").MinimumLength(10).WithMessage("A valid phone number is required");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Contact first name is required").EmailAddress().WithMessage("A valid email is required"); ;
        }
    }
}
