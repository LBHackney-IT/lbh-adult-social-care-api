using Amazon.DynamoDBv2.DataModel;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class DynamoDbGateway : IExampleGateway
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public DynamoDbGateway(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public List<Entity> GetAll()
        {
            return new List<Entity>();
        }

        public Entity GetEntityById(int id)
        {
            var result = _dynamoDbContext.LoadAsync<DatabaseEntity>(id).GetAwaiter().GetResult();
            return result?.ToDomain();
        }
    }
}
