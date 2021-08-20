
namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public static class ThrowOpsErrorUsecase
    {
        public static void Execute()
        {
            throw new TestOpsErrorException();
        }
    }
}
