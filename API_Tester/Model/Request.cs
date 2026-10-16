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
    public class Request
    {
        public RequestType Type { get; set; }
        public string Url { get; set;}
    }
}
