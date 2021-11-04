using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace LBH.AdultSocialCare.Api.V1.Services.Queuing
{
    public class AmazonSimpleQueueService : IQueueService
    {
        public async Task Send<T>(T content)
        {
            using var client = new AmazonSQSClient(RegionEndpoint.EUWest2); // TODO: VK: Review

            var message = new SendMessageRequest
            {
                QueueUrl = "https://sqs.eu-west-2.amazonaws.com/290114655000/lbh-adult-social-care-payruns",
                MessageBody = content.ToString() // to JSON
            };

            var result = await client.SendMessageAsync(message);
        }
    }
}
