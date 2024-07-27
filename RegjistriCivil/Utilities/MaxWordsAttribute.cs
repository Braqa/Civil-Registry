using System.ComponentModel.DataAnnotations;

namespace RegjistriCivil.Utilities
{
    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int maxWords;

        public MaxWordsAttribute(int maxWords) : base("{0} has too many words.")
        {
            this.maxWords = maxWords;
        }

     
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
                
            return ValidationResult.Success;
        }
    }
}
