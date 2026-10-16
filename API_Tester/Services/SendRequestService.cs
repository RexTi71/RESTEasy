using API_Tester.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace API_Tester.Services
{
    public class SendRequestService
    {
        private readonly HttpClient _client;
        private long _responseTime;
        public long ResponseTime {
            get => _responseTime;
         }
        public SendRequestService(HttpClient client)
        {
            _client = client;
            
        }
        public async Task<HttpResponseMessage> SendRequest(Request request, Payload payload)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var content = payload.GetContent();
            try
            {
                switch (request.Type)
                {
                    case RequestType.GET:
                        return await _client.GetAsync(request.Url);
                    case RequestType.POST:
                        return await _client.PostAsync(request.Url, content);
                    case RequestType.PUT:
                        return await _client.PutAsync(request.Url, content);
                    case RequestType.PATCH:
                        return await _client.PatchAsync(request.Url, content);
                    case RequestType.DELETE:
                        return await _client.DeleteAsync(request.Url);
                    default:
                        return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                }
                
            }catch(Exception ex)
            {
                var errMsg = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                errMsg.Content = new StringContent(ex.Message, Encoding.UTF8,"text/plain");
                return errMsg;
            }finally { 
                stopwatch.Stop();
                _responseTime = stopwatch.ElapsedMilliseconds;
            }
        }
    }
}
