namespace PasswordValidation
{

    public class PasswordValidation
    {
        private readonly IValidation _validation;

        public PasswordValidation(IValidationFactory validationFactory)
        {
            _validation = validationFactory.Create();
        }

        public bool IsValid(string password)
        {
            _validation.Validate(password);
            return _validation.GetErrors().Count == 0;
        }
    }
}