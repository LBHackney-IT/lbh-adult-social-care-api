using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IDeleteTimeSlotTypesUseCase
    {
        public Task<bool> DeleteAsync(Guid timeSlotTypesId);
    }
}
