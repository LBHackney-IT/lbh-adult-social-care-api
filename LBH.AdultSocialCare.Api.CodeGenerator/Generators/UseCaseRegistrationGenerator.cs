namespace LBH.AdultSocialCare.Api.CodeGenerator.Generators
{
    public class UseCaseRegistrationGenerator : BaseServiceRegistrationGenerator
    {
        protected override string SourceNamespace => "LBH.AdultSocialCare.Api.V1.UseCase";

        protected override string SourceDirectory => "UseCase";
        protected override string ClassNamePostfix => "UseCase";
        protected override string GeneratedFileName => "UseCaseExtensions.cs";
    }
}
