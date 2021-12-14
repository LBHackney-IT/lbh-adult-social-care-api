using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LBH.AdultSocialCare.Api.Providers
{
    public class EnumValidatorProvider : IModelValidatorProvider
    {
        public void CreateValidators(ModelValidatorProviderContext context)
        {
            if (context.ModelMetadata.IsEnum || context.ModelMetadata.IsNullableValueType)
            {
                context.Results.Add(new ValidatorItem
                {
                    Validator = new EnumRangeValidator(),
                    IsReusable = true
                });
            }
        }
    }
}
