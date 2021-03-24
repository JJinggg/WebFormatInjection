using System;
using System.IO;
using System.Net;
using WebformatInjection.WebNeedDefualtHeader;
namespace WebformatInjection
{
    public class Webformat : IDisposable
    {
        string requestUriString;
        string Referer = null;
        string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.106 Whale/2.8.108.15 Safari/537.36";
        public Webformat(string _requestUriString)
        {
            requestUriString = _requestUriString;
        }
        public Webformat(string _requestUriString,string _Refere)
        {
            requestUriString = _requestUriString;
            Referer = _Refere;

        }
        public HttpWebRequest CreateNewFormat(string _CRUD,string _Accept,string _ContentType,WebNeedDefualtHeader.Certificate _certificate, WebHeaderCollection _webHeaderCollection, string _userAgent = null)
        {
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(requestUriString);

            if (!String.IsNullOrEmpty(_userAgent))
            {
                hwr.UserAgent = _userAgent;
            }
            else
            {
                hwr.UserAgent = UserAgent;
            }

            hwr.Method = _CRUD;
            hwr.Accept = _Accept;
            
            hwr.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.None;
            if (!string.IsNullOrEmpty(_ContentType))
            {
                hwr.ContentType = _ContentType;
            }
            if (!String.IsNullOrEmpty(Referer))
            {
                hwr.Referer = Referer;
            }
            if (_certificate.HasFlag(Certificate.True))
            {
                hwr.ServerCertificateValidationCallback = delegate { return true; };
            }
            hwr.Headers.Add(_webHeaderCollection);
            
            return hwr;
        }
        public HttpWebRequest CreateNewFormat(CookieContainer cookie, string _CRUD, string _Accept, string _ContentType, WebNeedDefualtHeader.Certificate _certificate, WebHeaderCollection _webHeaderCollection,string _userAgent = null)
        {
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(requestUriString);
            System.Diagnostics.Debug.WriteLine(_userAgent);
            if (!String.IsNullOrEmpty(_userAgent))
            {
                hwr.UserAgent = _userAgent;
            }
            else
            {
                hwr.UserAgent = UserAgent;
            }

            hwr.Method = _CRUD;
            hwr.Accept = _Accept;
            hwr.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.None;
            if (!string.IsNullOrEmpty(_ContentType))
            {
                hwr.ContentType = _ContentType;
            }
            if (!String.IsNullOrEmpty(Referer))
            {
                hwr.Referer = Referer;
            }
            if (_certificate.HasFlag(Certificate.True))
            {
                hwr.ServerCertificateValidationCallback = delegate { return true; };
            }
            hwr.CookieContainer = cookie;
            hwr.Headers.Add(_webHeaderCollection);

            return hwr;
        }
        public HttpWebRequest CreateNewFormat(CookieContainer cookie, string _CRUD, string _Accept, string _ContentType, WebNeedDefualtHeader.Certificate _certificate,string _userAgent = null)
        {
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(requestUriString);

            if (!String.IsNullOrEmpty(_userAgent))
            {
                hwr.UserAgent = _userAgent;
            }
            else
            {
                hwr.UserAgent = UserAgent;
            }

            hwr.Method = _CRUD;
            hwr.Accept = _Accept;
            hwr.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.None;
            if (!string.IsNullOrEmpty(_ContentType))
            {
                hwr.ContentType = _ContentType;
            }
            if (!String.IsNullOrEmpty(Referer))
            {
                hwr.Referer = Referer;
            }
            if (_certificate.HasFlag(Certificate.True))
            {
                hwr.ServerCertificateValidationCallback = delegate { return true; };
            }
            hwr.CookieContainer = cookie;
        

            return hwr;
        }
        public HttpWebRequest CreateNewFormat(string _CRUD, string _Accept, string _ContentType, WebNeedDefualtHeader.Certificate _certificate)
        {
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(requestUriString);

            hwr.Method = _CRUD;
            hwr.Accept = _Accept;
            hwr.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.None;
            if (!string.IsNullOrEmpty(_ContentType))
            {
                hwr.ContentType = _ContentType;
            }
            if (!String.IsNullOrEmpty(Referer))
            {
                hwr.Referer = Referer;
            }
            if (_certificate.HasFlag(Certificate.True))
            {
                hwr.ServerCertificateValidationCallback = delegate { return true; };
            }
            return hwr;
        }
        public async System.Threading.Tasks.Task<HttpWebResponse> GetResponseAsync(HttpWebRequest request, string sendData = null)
        {
            if (!String.IsNullOrEmpty(sendData))
            {
                StreamWriter writer = new StreamWriter(await request.GetRequestStreamAsync());
                writer.Write(sendData);
                writer.Close();
            }
            return (HttpWebResponse)await request.GetResponseAsync();
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
