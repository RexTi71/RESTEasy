using API_Tester.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace API_Tester.Services
{
    internal class SendRequestService
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<HttpResponseMessage> SendRequest(Request request)
        {
            try
            {
                switch (request.Type)
                {
                    case RequestType.GET:
                        return await _client.GetAsync(request.Url);
                    case RequestType.DELETE:
                        return await _client.DeleteAsync(request.Url);
                    default:
                        return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                }
                
            }catch(InvalidOperationException ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }
        public async Task<HttpResponseMessage> SendRequest(Request request, Payload payload)
        {
            var content = payload.GetContent();
            try
            {
                switch(request.Type)
                {
                    case RequestType.POST:
                        return await _client.PostAsync(request.Url, content);
                    case RequestType.PUT:
                        return await _client.PutAsync(request.Url, content);
                    case RequestType.PATCH:
                        return await _client.PatchAsync(request.Url, content);
                    default:
                        return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                }
            }
            catch(InvalidOperationException ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}
