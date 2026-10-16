using System;
using System.Collections.Generic;
using System.Text;


namespace API_Tester.Services
{
    public static class UrlValidator
    {
        public static bool IsUrlValid(string url)
        {
            return Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri? _)
            && !String.IsNullOrWhiteSpace(url);
        }
    }
}
