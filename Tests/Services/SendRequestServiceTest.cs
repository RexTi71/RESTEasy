using API_Tester;
using API_Tester.Model;
using API_Tester.Services;
namespace Tests.Services
{
    public class FakeHttpHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
        }
    }
    public class SendRequestServiceTest
    {
        private FakeHttpHandler handler;
        private HttpClient client;
        private SendRequestService service;
        [SetUp]
        public void Setup()
        {
            handler = new FakeHttpHandler();
            client = new HttpClient(handler);
            service = new SendRequestService(client);
        }
        [TearDown]
        public void TearDown()
        {
            client.Dispose();
            handler.Dispose();
        }
        [Test]
        public async Task SendRequest_RequestTypeGet_ReturnsOk()
        {
            var request = new Request();
            request.Url = "https://localhost";
            request.Type = RequestType.GET;

            var response = await service.SendRequest(request, Payload.Create(null));
            Assert.That(response.StatusCode,Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
        [Test]
        public async Task SendRequest_RequesTypePost_ReturnsOk()
        {
            var request = new Request();
            request.Url = "https://localhost";
            request.Type = RequestType.POST;

            var response = await service.SendRequest(request, Payload.Create("Hello world"));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
        [Test]
        public async Task SendRequest_RequesTypePostNoPayload_ReturnsOk()
        {
            var request = new Request();
            request.Url = "https://localhost";
            request.Type = RequestType.POST;

            var response = await service.SendRequest(request, Payload.Create(null));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
        [Test]
        public async Task SendRequest_RequesTypePut_ReturnsOk()
        {
            var request = new Request();
            request.Url = "https://localhost";
            request.Type = RequestType.PUT;

            var response = await service.SendRequest(request, Payload.Create("Hello world"));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
        [Test]
        public async Task SendRequest_RequesTypePutNoPayload_ReturnsOk()
        {
            var request = new Request();
            request.Url = "https://localhost";
            request.Type = RequestType.PUT;

            var response = await service.SendRequest(request, Payload.Create(null));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
        [Test]
        public async Task SendRequest_RequesTypePatch_ReturnsOk()
        {
            var request = new Request();
            request.Url = "https://localhost";
            request.Type = RequestType.PATCH;

            var response = await service.SendRequest(request, Payload.Create("Hello world"));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
        [Test]
        public async Task SendRequest_RequesTypePatchNoPayload_ReturnsOk()
        {
            var request = new Request();
            request.Url = "https://localhost";
            request.Type = RequestType.PATCH;

            var response = await service.SendRequest(request, Payload.Create(null));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
        [Test]
        public async Task SendRequest_RequesTypeDelete_ReturnsOk()
        {
            var request = new Request();
            request.Url = "https://localhost";
            request.Type = RequestType.DELETE;

            var response = await service.SendRequest(request, Payload.Create(null));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
        [Test]
        public async Task SendRequest_RequestUrlIsNull_ReturnsBadRequest()
        {
            var request = new Request();
            request.Type = RequestType.DELETE;

            var response = await service.SendRequest(request, Payload.Create(null));
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.Not.Null);
            Assert.That(response.Content, Is.TypeOf<StringContent>());
        }
    }
}
