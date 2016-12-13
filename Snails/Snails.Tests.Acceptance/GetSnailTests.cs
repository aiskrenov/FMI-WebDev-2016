using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace Snails.Tests.Acceptance
{
    [TestFixture]
    public class GetSnailTests
    {
        [Test]
        public void GetNotExistingSnailReturnsNotFound()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:51320")
            };

            client.DefaultRequestHeaders.Add("Snails-Authorization", "supersecret");

            var response = client.GetAsync("/api/snails").GetAwaiter().GetResult();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
