using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Services.IO
{
    public interface IFileStorage
    {
        Task<string> SaveFileAsync(byte[] fileContent);
    }
}
