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
    }
}
