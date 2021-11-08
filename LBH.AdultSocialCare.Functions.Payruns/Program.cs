using System.Diagnostics;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LBH.AdultSocialCare.Functions.Payruns
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            RunApplication(args);
        }

        [Conditional("DEBUG")]
        private static void RunApplication(string[] args)
        {
            WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build().Run();
        }
    }
}
