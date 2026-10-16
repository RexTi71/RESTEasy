using System;
using System.Collections.Generic;
using System.Text;
using API_Tester.Model;
namespace Tests.Model
{
    public class PayloadTest
    {
        [Test]
        public void Create_DataNull_ReturnsEmptyPayload()
        {
          var result =  Payload.Create(null);
            Assert.That(result, Is.TypeOf<EmptyPayload>());
        }
        [Test]
        public void Create_DataJsonStartingWithCurlyBracket_ReturnsJSONPayload()
        {
            var result = Payload.Create("{\"name\":\"thing\"}");
            Assert.That(result, Is.TypeOf<JSONPayload>());
        }
        [Test]
        public void Create_DataJsonStartingWithSquareBracket_ReturnsJSONPayload()
        {
            var result = Payload.Create("[{\"name\":\"thing\"}]");
            Assert.That(result, Is.TypeOf<JSONPayload>());
        }
        [Test]
        public void Create_DataXml_ReturnsXMLPayload()
        {
            var result = Payload.Create("<Thing>Content</Thing>");
            Assert.That(result, Is.TypeOf<XMLPayload>());
        }
        [Test]
        public void Create_DataString_ReturnsTextPayload()
        {
            var result = Payload.Create("Hello world");
            Assert.That(result, Is.TypeOf<TextPayload>());
        }
        [Test]
        public void Create_DataStringEmpty_ReturnsTextPayload()
        {
            var result = Payload.Create(String.Empty);
            Assert.That(result, Is.TypeOf<TextPayload>());
        }
    }
}
