using System;
using System.Collections.Generic;
using System.Text;

namespace API_Tester.Model
{
    public enum RequestType
    {
        GET,
        POST,
        DELETE,
        PUT,
        PATCH
    }
    internal class Request
    {
        public RequestType Type { get; set; }
        public string Uri { get; set; }
    }
}
