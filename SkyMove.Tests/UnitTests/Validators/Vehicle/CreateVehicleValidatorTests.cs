using FluentValidation.TestHelper;
using SkyMove.Application.Dtos.Vehicle;
using SkyMove.Application.Validators.Vehicle;
using SkyMove.Domain.Enums;

namespace SkyMove.Tests.UnitTests.Validators.Vehicle
{
    public class CreateVehicleValidatorTests
    {
        private readonly CreateVehicleValidator _validator;

        public CreateVehicleValidatorTests()
        {
            _validator = new();
        }

        #region MemberData

        public static IEnumerable<object[]> InvalidShortTexts => [[""], ["a"], ["ab"]];
        public static IEnumerable<object[]> InvalidKilometers => [[-1m], [5001m], [10000m]];
        public static IEnumerable<object[]> InvalidYears => [[DateTime.Today.Year - 3], [DateTime.Today.Year - 10]];
        public static IEnumerable<object[]> InvalidHorsePower => [[30], [-50]];

        #endregion

        [Theory]
        [MemberData(nameof(InvalidShortTexts))]
        public void Brand_Should_Have_Error_When_Less_Than_3_Characters(string brand)
        {
            var model = new CreateVehicleRequest { Brand = brand };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Brand);
        }

        [Theory]
        [MemberData(nameof(InvalidShortTexts))]
        public void Model_Should_Have_Error_When_Less_Than_3_Characters(string modelName)
        {
            var model = new CreateVehicleRequest { Model = modelName };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Model);
        }

        [Theory]
        [MemberData(nameof(InvalidShortTexts))]
        public void Version_Should_Have_Error_When_Less_Than_3_Characters(string version)
        {
            var model = new CreateVehicleRequest { Version = version };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Version);
        }


        [Theory]
        [MemberData(nameof(InvalidKilometers))]
        public void Kilometers_Should_Have_Error_When_Invalid(decimal kilometers)
        {
            var model = new CreateVehicleRequest { Kilometers = kilometers };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Kilometers);
        }

        [Theory]
        [MemberData(nameof(InvalidYears))]
        public void Year_Should_Have_Error_When_Older_Than_2_Years(int year)
        {
            var model = new CreateVehicleRequest { Year = year };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Year);
        }

        [Theory]
        [MemberData(nameof(InvalidHorsePower))]
        public void HorsePower_Should_Have_Error_When_Invalid(int horsePower)
        {
            var model = new CreateVehicleRequest { HorsePower = horsePower };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.HorsePower);
        }


        [Fact]
        public void Should_Not_Have_Error_For_Valid_Model()
        {
            var model = new CreateVehicleRequest
            {
                Brand = "Toyota",
                Model = "Corolla",
                Version = "XEI",
                Year = DateTime.Today.Year - 1,
                Kilometers = 2500,
                HorsePower = 177,
                Color = Color.Black
            };

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}