using System;
using HttpServices.Services.Contracts;
using Moq;

namespace LBH.AdultSocialCare.Api.Tests.Extensions
{
    public static class MockOfRestClientExtensions
    {
        public static void SetupPostRequestInterceptor<TResponse>(this Mock<IRestClient> mock, string url, Func<TResponse> createResponse, Action<string, object, string> onRequest)
        {
            mock.Setup(api => api.PostAsync<TResponse>(
                    It.Is<string>(s => s == url),
                    It.IsAny<object>(),
                    It.IsAny<string>()))
                .ReturnsAsync(createResponse)
                .Callback(onRequest);
        }
    }
}
