using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LBH.AdultSocialCare.Api.Providers
{
    public class EnumValidatorProvider : IModelValidatorProvider
    {
        public void CreateValidators(ModelValidatorProviderContext context)
        {
            if (context.ModelMetadata.MetadataKind == ModelMetadataKind.Type)
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
