using FluentValidation.TestHelper;
using SkyMove.Application.Dtos.Customer;
using SkyMove.Application.Validators.Customer;

namespace SkyMove.Tests.UnitTests.Validators.Customer
{
    public class CreateCustomerValidatorTests
    {
        private readonly CreateCustomerValidator _validator;

        public CreateCustomerValidatorTests()
        {
            _validator = new();
        }

        #region MemberData

        public static IEnumerable<object[]> InvalidFirstNames => [[""], ["Ab"], [new string('a', 101)]];

        public static IEnumerable<object[]> InvalidLastNames => [[""], ["Ab"], [new string('a', 101)]];

        public static IEnumerable<object[]> InvalidCpfs => [[""], ["123"], ["123456789012"]];

        public static IEnumerable<object[]> InvalidDdds => [[""], ["1"], ["123"]];

        public static IEnumerable<object[]> InvalidPhoneNumbers => [[""], ["12345678"], ["1234567890"]];

        public static IEnumerable<object[]> InvalidEmails => [[""], ["invalidemail"], ["invalid@"]];

        public static IEnumerable<object[]> InvalidDateOfBirths => [[DateTime.Today.AddYears(-17)], [DateTime.Today.AddYears(-1)]];

        #endregion

        [Theory]
        [MemberData(nameof(InvalidFirstNames))]
        public void FirstName_Should_Have_Error_When_Invalid(string firstName)
        {
            var model = new CreateCustomerRequest { FirstName = firstName };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Theory]
        [MemberData(nameof(InvalidLastNames))]
        public void LastName_Should_Have_Error_When_Invalid(string lastName)
        {
            var model = new CreateCustomerRequest { LastName = lastName };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Theory]
        [MemberData(nameof(InvalidCpfs))]
        public void Cpf_Should_Have_Error_When_Invalid(string cpf)
        {
            var model = new CreateCustomerRequest { Cpf = cpf };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Cpf);
        }

        [Theory]
        [MemberData(nameof(InvalidDdds))]
        public void Ddd_Should_Have_Error_When_Invalid(string ddd)
        {
            var model = new CreateCustomerRequest { Ddd = ddd };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Ddd);
        }

        [Theory]
        [MemberData(nameof(InvalidPhoneNumbers))]
        public void PhoneNumber_Should_Have_Error_When_Invalid(string phoneNumber)
        {
            var model = new CreateCustomerRequest { PhoneNumber = phoneNumber };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber);
        }

        [Theory]
        [MemberData(nameof(InvalidEmails))]
        public void Email_Should_Have_Error_When_Invalid(string email)
        {
            var model = new CreateCustomerRequest { Email = email };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Theory]
        [MemberData(nameof(InvalidDateOfBirths))]
        public void DateOfBirth_Should_Have_Error_When_Under18(DateTime dateOfBirth)
        {
            var model = new CreateCustomerRequest { DateOfBirth = dateOfBirth };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.DateOfBirth);
        }

        [Fact]
        public void Should_Not_Have_Error_For_Valid_Model()
        {
            var model = new CreateCustomerRequest
            {
                FirstName = "John",
                LastName = "Doe",
                Cpf = "12345678901",
                Ddd = "11",
                PhoneNumber = "912345678",
                DateOfBirth = DateTime.Today.AddYears(-25),
                Email = "john.doe@example.com"
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}