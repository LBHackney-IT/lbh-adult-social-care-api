using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LBH.AdultSocialCare.Api.Providers
{
    public class EnumRangeValidator : IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            if (context.Model is null) yield break;

            var nullableSubType = Nullable.GetUnderlyingType(context.Model.GetType());
            var modelType = nullableSubType ?? context.Model.GetType();

            if (modelType.IsEnum && !Enum.IsDefined(modelType, context.Model))
            {
                var propertyName = context.ModelMetadata.Name;
                var enumValues = Enum.GetValues(modelType).Cast<int>().ToList();

                yield return new ModelValidationResult(propertyName, $"The field {propertyName} must be between {enumValues.Min()} and {enumValues.Max()}.");
            }
        }
    }
}
