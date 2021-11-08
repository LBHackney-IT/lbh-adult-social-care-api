using System;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

namespace LBH.AdultSocialCare.Functions.Payruns
{
    public class LambdaEntryPoint
    {
        public LambdaEntryPoint()
        {
            // TODO: VK: Configure dependencies
        }

        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public string Handler(SQSEvent sqsEvent)
        {
            foreach (var record in sqsEvent.Records)
            {
                // TODO: VK: Replace with real logger
                Console.WriteLine($"[{record.EventSource}] Body = {record.Body}");
            }

            return "Hello world";
        }
    }
}
