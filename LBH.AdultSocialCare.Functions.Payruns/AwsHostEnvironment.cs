using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace LBH.AdultSocialCare.Functions.Payruns
{
    public class AwsHostEnvironment : IHostEnvironment
    {
        public string ApplicationName { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
        public string ContentRootPath { get; set; }
        public string EnvironmentName { get; set; }
    }
}
