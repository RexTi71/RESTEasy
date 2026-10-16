using API_Tester.Model;
using API_Tester.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace API_Tester.ViewModel
{
    internal partial class MainViewModel : ObservableObject
    {
        private Request _request;
        private SendRequestService _reqService;
        [ObservableProperty]
        private string? responseBody;
        [ObservableProperty]
        private RequestType selectedReqType = RequestType.GET;
        [ObservableProperty]
        private string? reqPayload;
        [ObservableProperty]
        private string statusCodeText = String.Empty;
        [ObservableProperty]
        private string responseTimeText = String.Empty;
        [ObservableProperty]
        private Visibility additionalInfoVisibility = Visibility.Hidden;
        public Array RequestTypes => Enum.GetValues(typeof(RequestType));
        public string ReqUrl
        {
            get { return _request.Url; }
            set
            {
                _request.Url = value;
            }
        }

        private async void SetResponse(HttpResponseMessage response)
        {
            //Used to get actual response code and not
            //"OK" or "UNATHORIZED"
            StatusCodeText = Convert.ToString((int)response.StatusCode);
            ResponseTimeText = $"{_reqService.ResponseTime.ToString()} ms";
            AdditionalInfoVisibility = Visibility.Visible;

            try
            {
                ResponseBody = JSONPayload.PrettyJson(await response.Content.ReadAsStringAsync());
            }
            catch (JsonException)
            {
                ResponseBody = await response.Content.ReadAsStringAsync();
            }
            Trace.WriteLine($"Typ: {_request.Type}\nUrl: {_request.Url}");

        }
        [RelayCommand]
        public async Task SendRequestAsync()
        {
            HttpResponseMessage response;
            _request.Type = SelectedReqType;
            if (!UrlValidator.IsUrlValid(ReqUrl))
            {
                MessageBox.Show("Provided url is not valid","Invalid url" , MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            _request.Url = ReqUrl;

            response = await _reqService.SendRequest(_request, Payload.Create(ReqPayload));
            SetResponse(response);
        }
        public MainViewModel()
        {
            _request = new Request();
            _reqService = new SendRequestService(App.HttpClient);
        }
    }
}
