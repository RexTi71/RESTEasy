using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace API_Tester.Model
{
    public class XMLPayload : Payload
    {
        public XMLPayload(string data) : base(data) { }
        public override StringContent GetContent()
        {
            return new StringContent(data, Encoding.UTF8, "text/xml");
        }
    }
}
