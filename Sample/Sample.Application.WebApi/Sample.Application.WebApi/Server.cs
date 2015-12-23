using System;
using Microsoft.Owin.Hosting;

namespace Sample.Application.WebApi
{
    public class Server : IDisposable
    {
        private IDisposable _server = null;
        private string _url = "";

        public Server(string url)
        {
            _url = url;
        }

        public void Start()
        {
            _server = WebApp.Start<Startup>(url: _url);
        }

        public void Dispose()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
        }
    }
}