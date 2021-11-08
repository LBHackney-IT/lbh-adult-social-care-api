using System.Collections.Generic;
using System.IO;
using Amazon.Lambda.SQSEvents;
using Microsoft.AspNetCore.Builder;

namespace LBH.AdultSocialCare.Functions.Payruns
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // development-time-only handler for incoming messages
            app.Run(async context =>
            {
                using (var streamReader = new StreamReader(context.Request.Body))
                {
                    var jsonRequest = await streamReader.ReadToEndAsync();
                    var sqsEvent = new SQSEvent
                    {
                        Records = new List<SQSEvent.SQSMessage>
                        {
                            new SQSEvent.SQSMessage
                            {
                                Body = jsonRequest
                            }
                        }
                    };

                    new LambdaEntryPoint().Handler(sqsEvent);
                }
            });
        }
    }
}
