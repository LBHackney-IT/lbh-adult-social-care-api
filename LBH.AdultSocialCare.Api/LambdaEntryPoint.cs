using Amazon.Lambda.AspNetCoreServer;
using Microsoft.AspNetCore.Hosting;

namespace LBH.AdultSocialCare.Api
{
    public class LambdaEntryPoint : APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            RegisterResponseContentEncodingForContentType("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ResponseContentEncoding.Base64);

            builder
                .UseStartup<Startup>();
        }
    }
}
