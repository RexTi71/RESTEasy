using API_Tester.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace API_Tester.Services
{
    internal class SendRequestService
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly Stopwatch _stopwatch;
        private long _responseTime;
        public long ResponseTime {
            get => _responseTime;
         }
        public SendRequestService()
        {
            _stopwatch = new Stopwatch();
        }
        public async Task<HttpResponseMessage> SendRequest(Request request, Payload payload)
        {
            _stopwatch.Start();
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
                        return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                }
                
            }catch(Exception ex)
            {
                var errMsg = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                errMsg.Content = new StringContent(ex.Message, Encoding.UTF8,"text/plain");
                return errMsg;
            }finally { 
                _stopwatch.Stop();
                _responseTime = _stopwatch.ElapsedMilliseconds;
                _stopwatch.Reset();
            }
        }
    }
}
