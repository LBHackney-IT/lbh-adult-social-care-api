using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IDeleteTimeSlotShiftsUseCase
    {
        public Task<bool> DeleteAsync(Guid timeSlotShiftsId);
    }
}
