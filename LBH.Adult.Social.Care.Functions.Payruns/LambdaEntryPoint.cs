using System;
using Amazon.Lambda.SQSEvents;

namespace LBH.Adult.Social.Care.Functions.Payruns
{
    public class LambdaEntryPoint
    {
        public LambdaEntryPoint()
        {
            // TODO: VK: Configure dependencies
        }

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
