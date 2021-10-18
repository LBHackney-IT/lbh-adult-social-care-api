using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Services.IO
{
    public class FileStorage : IFileStorage
    {
        public Task<string> SaveFileAsync(byte[] fileContent)
        {
            return Task.FromResult("this_is_just_temporary_stub.pdf");
        }
    }
}
