using API_Tester.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_Tester.ViewModel
{
    internal class MainViewModel
    {
        private Request _request;
        public string ReqUri
        {
            get { return _request.Uri; }
            set
            {
                _request.Uri = value;
            }
        }

        public MainViewModel()
        {
            _request = new Request();
        }
    }
}
