using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using LBH.AdultSocialCare.Api.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LBH.AdultSocialCare.Api.V1.Services.Queuing
{
    public class AmazonSqsService : IQueueService
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly PayrunsQueueOptions _options;

        public AmazonSqsService(IAmazonSQS sqsClient, IOptions<PayrunsQueueOptions> options)
        {
            _sqsClient = sqsClient;
            _options = options.Value;
        }

        public async Task Send<T>(T content)
        {
            var message = new SendMessageRequest
            {
                QueueUrl = _options.Url,
                MessageBody = JsonConvert.SerializeObject(content)
            };

            await _sqsClient.SendMessageAsync(message);
        }
    }
}
