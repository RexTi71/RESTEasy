using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace API_Tester.Model
{
    internal class JSONPayload : Payload
    {
        public JSONPayload(string data) : base(data){}
        public override StringContent GetContent()
        {
            return new StringContent(data, Encoding.UTF8, "application/json");   
        }
        public static string PrettyJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonElem = JsonSerializer.Deserialize<JsonElement>(json);

            return JsonSerializer.Serialize(jsonElem, options);
        }
    }
}
