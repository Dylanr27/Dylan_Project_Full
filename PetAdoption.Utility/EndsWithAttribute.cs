using System.ComponentModel.DataAnnotations;

namespace PetAdoption.Utility
{
    public class EndsWithAttribute : ValidationAttribute
    {
        private readonly string _endsWith;

        public EndsWithAttribute(string endsWith)
        {
            _endsWith = endsWith;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var strValue = value as string;
            if (strValue != null && !strValue.EndsWith(_endsWith))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"The field must end with \"{_endsWith}\"";
        }
    }
}
