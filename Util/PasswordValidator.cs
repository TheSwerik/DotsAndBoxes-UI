using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using UI.Services.Model;

namespace UI.Util
{
    public class PasswordValidator : ValidationAttribute
    {
        private readonly string _authenticateModel;

        public PasswordValidator(string authenticateModel) { _authenticateModel = authenticateModel; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(_authenticateModel);
            if (otherPropertyInfo == null) return new ValidationResult("ERROR");
            if (otherPropertyInfo.GetIndexParameters().Any()) throw new ArgumentException("ERROR2");

            var otherValue = (AuthenticateModel) otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            return !value.ToString().Equals(otherValue.Password, StringComparison.InvariantCulture)
                       ? new ValidationResult("Passwords don't match.")
                       : null;
        }
    }
}