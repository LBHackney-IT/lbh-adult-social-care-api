namespace LBH.AdultSocialCare.Api.CodeGenerator.Generators
{
    public class GatewayRegistrationGenerator : BaseServiceRegistrationGenerator
    {
        protected override string SourceNamespace => "LBH.AdultSocialCare.Api.V1.Gateways";

        protected override string SourceDirectory => "Gateways";
        protected override string ClassNamePostfix => "Gateway";
        protected override string GeneratedFileName => "GatewayExtensions.cs";
    }
}
