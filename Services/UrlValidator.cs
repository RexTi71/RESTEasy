using System;
using System.Collections.Generic;
using System.Text;

namespace API_Tester.Services
{
    internal class UrlValidator
    {
        public static bool IsUrlValid(string url)
        {
            return !String.IsNullOrWhiteSpace(url);
        }
    }
}
