using FluentValidation;
using SkyMove.Application.Dtos.Vehicle;

namespace SkyMove.Application.Validators.Vehicle
{
    public class CreateVehicleValidator : AbstractValidator<CreateVehicleRequest>
    {
        public CreateVehicleValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Please ensure you have entered the Brand")
                .MinimumLength(3).WithMessage("The Brand must have at least 3 characters");

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("Please ensure you have entered the Model")
                .MinimumLength(3).WithMessage("The Model must have at least 3 characters");

            RuleFor(x => x.Version)
                .NotEmpty().WithMessage("Please ensure you have entered the Version")
                .MinimumLength(3).WithMessage("The Version must have at least 3 characters");

            RuleFor(x => x.Kilometers)
                .GreaterThanOrEqualTo(0).WithMessage("Kilometers cannot be negative")
                .LessThanOrEqualTo(5000).WithMessage("The vehicle must have a maximum of 5000 kilometers");

            RuleFor(x => x.Year)
                .Must(BeAtMostTwoYearsOld)
                .WithMessage("The vehicle must be at most 2 years old");

            RuleFor(x => x.HorsePower)
                .GreaterThan(60).WithMessage("HorsePower must be greater than 60");

            RuleFor(x => x.Color)
                .IsInEnum().WithMessage("Invalid vehicle color");
        }

        private bool BeAtMostTwoYearsOld(int year) =>
            year >= DateTime.Today.Year - 2;
    }
}