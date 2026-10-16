using System;
using System.Collections.Generic;
using API_Tester.Services;
using System.Text;

namespace Tests.Services
{
    public class UrlValidatorTest
    {
        [Test]
        public void IsUrlValid_EmptyString_ReturnsFalse(){
            bool result = UrlValidator.IsUrlValid(String.Empty);
            Assert.That(result, Is.False);
        }
        [Test]
        public void IsUrlValid_Null_ReturnsFalse()
        {
            bool result = UrlValidator.IsUrlValid(null);
            Assert.That(result, Is.False);
        }
        [Test]
        public void IsUrlValid_StringIsOnlyWhitespace_ReturnsFalse()
        {
            bool result = UrlValidator.IsUrlValid("               ");
            Assert.That(result, Is.False);
        }
        [Test]
        public void IsUrlValid_InvalidUrl_ReturnsFalse()
        {
            bool result = UrlValidator.IsUrlValid("https://localhost<>");
            Assert.That(result, Is.False);
        }
        [Test]
        public void IsUrlValid_ValidUrl_ReturnsTrue()
        {
            bool result = UrlValidator.IsUrlValid("https://localhost");
            Assert.That(result, Is.True);
        }
        [Test]
        public void IsUrlValid_ValidUrlNoHttpsPrefix_ReturnsTrue()
        {
            bool result = UrlValidator.IsUrlValid("localhost.com");
            Assert.That(result, Is.True);
        }
    }
}
