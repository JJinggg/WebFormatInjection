using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using WebformatInjection.WebNeedDefualtHeader;


namespace WebformatInjection
{
    public class WebClientFormat : IDisposable
    {
        string Base_url = null;
        string RequestUrl = null;

        HttpClient client;
        HttpClientHandler httpClientHandler;
        WebHeaderCollection webHeaderCollection;
        Encoding encoding = Encoding.UTF8;
        HttpContent httpContent;
        string CRUD;

        public WebClientFormat(string _base_url,string _RequestUrl)
        {
            Base_url = _base_url;
            RequestUrl = _RequestUrl;
        }
        public void SetClientHandler(CookieContainer _cookie, WebNeedDefualtHeader.Certificate _certificate)
        {
            httpClientHandler= new HttpClientHandler();
            if (_certificate.HasFlag(Certificate.True))
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            }
            httpClientHandler.CookieContainer = _cookie;
        }
        public void SetwebHeaderCollection(WebHeaderCollection _webHeaderCollection)
        { 
            foreach (string key in _webHeaderCollection.Keys)
            {
                     
                client.DefaultRequestHeaders.Add(key, _webHeaderCollection[key]);
            }

        }
        public void SetEncoding(Encoding _encoding)
        {
            encoding = _encoding;
        }

        public HttpClient SetClientFormat(string _CRUD,string Accept,string _ContentType,string sendData = null)
        {
            client = new HttpClient(httpClientHandler);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(_ContentType));
            client.BaseAddress = new Uri(Base_url);

            if(!string.IsNullOrEmpty(Accept))client.DefaultRequestHeaders.Add("Accept", Accept);

            CRUD = _CRUD;
            if (sendData != null)
            {
                httpContent = new StringContent(sendData,encoding, _ContentType);
            }
            return client;
        }
        public async Task<HttpResponseMessage> GetResponseMessage()
        {
            HttpResponseMessage responseMessage = null;
            try
            {
                switch (CRUD)
                {
                    case "POST":

                        responseMessage = await client.PostAsync(RequestUrl, httpContent);

                        break;
                    case "GET":
                        responseMessage = await client.GetAsync(RequestUrl);

                        break;
                    case "DELETE":
                        responseMessage = await client.DeleteAsync(RequestUrl);
                        break;
                    case "PUT":
                        responseMessage = await client.PutAsync(RequestUrl, httpContent);
                        break;
                    default:
                        responseMessage = null;
                        break;
                }
            }
            catch
            {
                
            }
            return responseMessage;
        }

        public async Task<HttpResponseMessage> GetResponseMessage(string _CRUD,string _reqUri)
        { 
            HttpResponseMessage responseMessage = null;
            try
            {
                switch (_CRUD)
                {
                    case "POST":
                        responseMessage = await client.PostAsync(_reqUri, httpContent);
                        break;
                    case "GET":
                        responseMessage = await client.GetAsync(_reqUri);
                        break;
                    case "DELETE":
                        responseMessage = await client.DeleteAsync(_reqUri);
                        break;
                    case "PUT":
                        responseMessage = await client.PutAsync(_reqUri, httpContent);
                        break;
                    default:
                        responseMessage = null;
                        break;
                }
            }
            catch
            {

            }
            return responseMessage;
        }

   


        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }


    }
}
