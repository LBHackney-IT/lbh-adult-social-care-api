using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Services.Queuing
{
    public interface IQueueService
    {
        Task Send<T>(T content);
    }
}
