using HttpServices.Services.Contracts;
using Moq;
using System;

namespace LBH.AdultSocialCare.Api.Tests.Extensions
{
    public static class MockOfRestClientExtensions
    {
        public static void SetupPostRequestInterceptor<TResponse>(this Mock<IRestClient> mock, string url, Action<object> onRequest)
        {
            mock.Setup(api => api.PostAsync<TResponse>(
                    It.Is<string>(s => s == url),
                    It.IsAny<object>(),
                    It.IsAny<string>()))
                .ReturnsAsync(default(TResponse))
                .Callback((string uri, object req, string err) => onRequest(req));
        }
    }
}
