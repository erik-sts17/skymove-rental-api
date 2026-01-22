using FluentValidation;
using SkyMove.Application.Dtos.Customer;
using SkyMove.Application.Extensions;

namespace SkyMove.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Please ensure you have entered the FirstName")
                .Length(3, 100).WithMessage("The FirstName must have between 4 and 100 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Please ensure you have entered the LastName")
                .Length(3, 100).WithMessage("The LastName must have between 4 and 100 characters");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("Please ensure you have entered the Cpf")
                .Length(11).WithMessage("The Cpf must have 11 characters");

            RuleFor(x => x.Ddd)
                .NotEmpty().WithMessage("Please ensure you have entered the Ddd")
                .Length(2).WithMessage("The Ddd must have 2 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Please ensure you have entered the PhoneNumber")
                .Length(9).WithMessage("The PhoneNumber must have 9 characters");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Please ensure you have entered the DateOfBirth")
                .Must(DateExtensions.MustBeOver18)
                .WithMessage("You must be over 18 years old");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Please ensure you have entered the Email")
                .EmailAddress().WithMessage("The Email must be a valid email address");
        }
    }
}