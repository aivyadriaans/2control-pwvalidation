using FakeItEasy;
using NUnit.Framework;
using System.Collections.Generic;

namespace PasswordValidation.Tests
{

    public class PasswordValidatorTests
    {
        [TestCaseSource(nameof(IsValidReturnsExpectedCases))]
        public void IsValid_returns_expected_result(List<string> expectedErrorList, bool expectedResult)
        {
            var validatorFactory = A.Fake<IValidationFactory>();
            var ruleValidator = A.Fake<IValidation>();
            A.CallTo(() => validatorFactory.Create()).Returns(ruleValidator);
            A.CallTo(() => ruleValidator.GetErrors()).Returns(expectedErrorList);

            var validator = new PasswordValidation(validatorFactory);
            Assert.That(validator.IsValid("any-password"), Is.EqualTo(expectedResult));
        }

        [TestCase("PWISLONGERTHAN8Ch_")]
        [TestCase("PwHasUPP3RcaseCh_")]
        [TestCase("PwHASL0WERCASEch_")]
        [TestCase("PwHasNumb3r_")]
        [TestCase("PwHasUndersc0re_")]
        public void IsValid_returns_true_when_password_is_valid_on_validation_one(string password)
        {
            var validator = new PasswordValidation(new ValidationOneFactory());
            var isValid = validator.IsValid(password);
            Assert.That(isValid, Is.True);
        }

        [TestCase("PWISLONGERTHAN6Ch_")]
        [TestCase("Passw0rdContainsAUpperCaseCharacter")]
        [TestCase("PASSW0RDCONTAINSALOWERCASECHARACTEr")]
        [TestCase("Passw0rdContainsANumber")]
        public void IsValid_returns_true_when_password_is_valid_on_validation_two(string password)
        {
            var validator = new PasswordValidation(new ValidationTwoFactory());
            var isValid = validator.IsValid(password);
            Assert.That(isValid, Is.True);
        }

        [TestCase("PassWordISLONGERTHAN16Ch_")]
        [TestCase("PasswordContainsAUpperCaseCharacter_")]
        [TestCase("PASSWORDCONTAINSALOWERCASECHARACTEr_")]
        [TestCase("PasswordContainsAnUnderscore_")]
        public void IsValid_returns_true_when_password_is_valid_on_validation_three(string password)
        {
            var validator = new PasswordValidation(new ValidationThreeFactory());
            var isValid = validator.IsValid(password);
            Assert.That(isValid, Is.True);
        }

        private static IEnumerable<object[]> IsValidReturnsExpectedCases()
        {
            yield return new object[]
            {
            new List<string>(),
            true
            };
            yield return new object[]
            {
            new List<string>
            {
                "Length error"
            },
            false
            };
        }
    }


}