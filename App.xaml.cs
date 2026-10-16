using API_Tester.Exceptions;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;

namespace API_Tester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HttpClient HttpClient { get; } = new HttpClient();
    }

}
