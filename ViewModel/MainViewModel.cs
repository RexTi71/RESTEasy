using API_Tester.Exceptions;
using API_Tester.Model;
using API_Tester.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
        public Array RequestTypes => Enum.GetValues(typeof(RequestType));
        public string ReqUrl
        {
            get { return _request.Url; }
            set
            {
                _request.Url = value;
            }
        }


        [RelayCommand]
        public async Task SendRequestAsync()
        {
            _request.Type = SelectedReqType;
            if (!UrlValidator.IsUrlValid(ReqUrl))
            {
                MessageBox.Show("Provided url can't be empty","Empty url" , MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _request.Url = ReqUrl;
            var response = await _reqService.SendRequest(_request);
            ResponseBody = await response.Content.ReadAsStringAsync();
            
            Trace.WriteLine($"Typ: {_request.Type}\nUrl: {_request.Url}");
        }
        public MainViewModel()
        {
            _request = new Request();
            _reqService = new SendRequestService();
        }
    }
}
