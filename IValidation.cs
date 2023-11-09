using System.Collections.Generic;

namespace PasswordValidation
{

    public interface IValidation
    {
        void Validate(string password);
        List<string> GetErrors();
    }

    public class Validation : IValidation
    {
        private readonly RuleValidation _ruleValidator;

        public Validation(RuleValidation ruleValidator)
        {
            _ruleValidator = ruleValidator;
        }

        public void Validate(string password) => _ruleValidator.Validate(password);

        public List<string> GetErrors() => _ruleValidator.GetErrors();
    }
}