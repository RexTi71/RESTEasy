using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace API_Tester.Model
{
    public class EmptyPayload : Payload
    {
        public EmptyPayload():base(String.Empty) {}

        public override StringContent GetContent() => new StringContent(String.Empty);
    }
}
