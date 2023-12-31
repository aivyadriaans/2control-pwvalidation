﻿namespace PasswordValidation
{

    public class RuleValidatorBuilder
    {
        private readonly RuleValidation _ruleValidator;

        public RuleValidatorBuilder()
        {
            _ruleValidator = new RuleValidation();
        }

        public RuleValidatorBuilder WithIsNumberRule()
        {
            _ruleValidator.Add(new IncludesNumberRule());
            return this;
        }

        public RuleValidatorBuilder WithUpperCaseRule()
        {
            _ruleValidator.Add(new UpperCaseRule());
            return this;
        }

        public RuleValidatorBuilder WithLowerCaseRule()
        {
            _ruleValidator.Add(new LowerCaseRule());
            return this;
        }

        public RuleValidatorBuilder WithLenghtRule(int length)
        {
            _ruleValidator.Add(new LengthRule(length));
            return this;
        }

        public RuleValidatorBuilder WithIncludesCharacterRule(char character)
        {
            _ruleValidator.Add(new IncludesCharacterRule(character));
            return this;
        }


        public RuleValidation Build() => _ruleValidator;
    }
}