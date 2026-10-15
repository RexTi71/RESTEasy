using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace API_Tester.Model
{
    public abstract class Payload
    {
        protected string data;
        public Payload(string data)
        {
            this.data = data;
        }
        public abstract StringContent GetContent();
        public static Payload Create(string data) {
            string trimmed = data.TrimStart();

            if (trimmed.StartsWith("{") || trimmed.StartsWith("["))
            {
                return new JSONPayload(data);
            }else if (trimmed.StartsWith("<"))
            {
                return new XMLPayload(data);
            }
            else
            {
                return new TextPayload(data);
            }
        }
    }
}
