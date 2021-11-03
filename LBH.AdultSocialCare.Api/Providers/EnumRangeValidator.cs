using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LBH.AdultSocialCare.Api.Providers
{
    public class EnumRangeValidator : IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            return ValidateEnumRangeRecursive(context.Model, new List<ModelValidationResult>());
        }

        private static List<ModelValidationResult> ValidateEnumRangeRecursive(object validatedObject, List<ModelValidationResult> errors)
        {
            var properties = validatedObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                if (propertyType.IsEnum)
                {
                    var enumValue = property.GetValue(validatedObject);
                    if (enumValue != null && !Enum.IsDefined(propertyType, enumValue))
                    {
                        var propertyName = property.Name;
                        var enumValues = Enum.GetValues(propertyType).Cast<int>().ToList();

                        errors.Add(new ModelValidationResult(propertyName, $"The field {propertyName} must be between {enumValues.Min()} and {enumValues.Max()}."));
                    }
                }
                else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                {
                    var enumerable = (IEnumerable) property.GetValue(validatedObject);
                    if (enumerable != null)
                    {
                        foreach (var item in enumerable)
                        {
                            ValidateEnumRangeRecursive(item, errors);
                        }
                    }
                }
            }

            return errors;
        }
    }
}
