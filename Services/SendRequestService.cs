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
        private Request _request;

        public SendRequestService(Request request)
        {
            this._request = request;
        }

        public async Task<string> SendRequest()
        {
            return await _client.GetStringAsync(_request.Uri);
        }
    }
}
