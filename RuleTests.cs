﻿using NUnit.Framework;

namespace PasswordValidation.Tests
{

    public class RuleTests
    {
        [TestCase(8, "validpassword", true)]
        [TestCase(16, "invalidpassword", false)]
        public void IsValid_returns_expected_value_when_LenghtRule(int minLength, string password, bool expected)
        {
            var rule = new LengthRule(minLength);
            Assert.That(rule.IsValid(password), Is.EqualTo(expected));
        }

        [TestCase("Validpassword", true)]
        [TestCase("invalidpassword", false)]
        public void IsValid_returns_expected_value_when_UpperCaseRule(string password, bool expected)
        {
            var rule = new UpperCaseRule();
            Assert.That(rule.IsValid(password), Is.EqualTo(expected));
        }

        [TestCase("VALIDPASSWORd", true)]
        [TestCase("INVALIDPASSOWORD", false)]
        public void IsValid_returns_expected_value_when_LowerCaseRule(string password, bool expected)
        {
            var rule = new LowerCaseRule();
            Assert.That(rule.IsValid(password), Is.EqualTo(expected));
        }

        [TestCase("validpassword1", true)]
        [TestCase("invalidpassword", false)]
        public void IsValid_returns_expected_value_when_IncludesNumberRule(string password, bool expected)
        {
            var rule = new IncludesNumberRule();
            Assert.That(rule.IsValid(password), Is.EqualTo(expected));
        }

        [TestCase("validpassword_", '_', true)]
        [TestCase("validpassword&", '&', true)]
        [TestCase("invalidpassword", '_', false)]
        [TestCase("invalidpassword", '&', false)]
        public void IsValid_returns_expected_value_when_IncludesCharacterRule(string password, char character, bool expected)
        {
            var rule = new IncludesCharacterRule(character);
            Assert.That(rule.IsValid(password), Is.EqualTo(expected));
        }

        [Test]
        public void GetErrorMessage_returns_expected_message_when_LengthRule()
        {
            var rule = new LengthRule(TestContext.CurrentContext.Random.Next(int.MaxValue));
            Assert.That(rule.GetErrorMessage, Is.EqualTo("Error with password length rule"));
        }

        [Test]
        public void GetErrorMessage_returns_expected_message_when_UpperCaseRule()
        {
            var rule = new UpperCaseRule();
            Assert.That(rule.GetErrorMessage, Is.EqualTo("Error with Uppercase rule"));
        }

        [Test]
        public void GetErrorMessage_returns_expected_message_when_LowerCaseRule()
        {
            var rule = new LowerCaseRule();
            Assert.That(rule.GetErrorMessage, Is.EqualTo("Error with lowercase rule"));
        }

        [Test]
        public void GetErrorMessage_returns_expected_message_when_IncludesCharacterRule()
        {
            var rule = new IncludesCharacterRule('_');
            Assert.That(rule.GetErrorMessage, Is.EqualTo("Error with special character rule"));
        }

        [Test]
        public void GetErrorMessage_returns_expected_message_when_IncludesNumberRule()
        {
            var rule = new IncludesNumberRule();
            Assert.That(rule.GetErrorMessage, Is.EqualTo("Error with number rule"));
        }
    }

}