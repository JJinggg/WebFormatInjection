using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WebformatInjection.WebNeedDefualtHeader
{

    public class CRUD
    {
        public static string Post = "POST";
        public static string Get = "GET";
        public static string Put = "PUT";
        public static string DELETE = "DELETE";
        public static string Options = "OPTIONS";
    }

    public class Accept
    {
        public static string All = "*/*";
        public static string Xml = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
        public static string OnlyJson = "application/json";
        public static string Json_A_JavaScript = "application/json, text/javascript, */*; q=0.01";
        public static string Json_A_Plain = "application/json, text/plain, */*";
        public static string Image = "image/webp,image/apng,image/*,*/*;q=0.8";
    }
    public class ContentType
    {
        static string UTF_8 = "; charset=UTF-8";

        public static string X_www_form = "application/x-www-form-urlencoded";
        public static string X_www_form_A_UTF8 = X_www_form + UTF_8;
        public static string Xml = "application/xml";
        public static string Xml_A_UTF8 = Xml + UTF_8;
        public static string Json = "application/json";
        public static string Json_A_UTF8 = Json + UTF_8;
        public static string Multipart = "multipart/form-data";
        public static string Multipart_A_UTF8 = Multipart + UTF_8;
    }
    [Flags]
    public enum Certificate
    {

        True = 1,
        False = 0
    }

    [Flags]
    public enum HeaderValue_Flags
    {
        Cache_Control=100,
        Sec_Fetch_Dest_image=201,
        Sec_Fetch_Dest_document = 202,
        Sec_Fetch_Dest_script = 203,
        Sec_Fetch_Dest_Empty = 204,
        Sec_Fetch_Mode_navigate = 301,
        Sec_Fetch_Mode_no_cors = 302,
        Sec_Fetch_Mode_cors = 303,
        Sec_Fetch_Site_same_site =401,
        Sec_Fetch_Site_same_origin = 402,
        Sec_Fetch_User =500,
        Upgrade_Insecure_Requests=600,
        X_Requested_With=700
        
    }


    public class SetHeaderModule
    {
        public WebHeaderCollection Collections = new WebHeaderCollection();

        public void CreateHeaderCollections(params HeaderValue_Flags[] headerValue_Flags)
        {

            Collections.Add(AddHeader(headerValue_Flags));
        }
        public void CreateCustomWebHeaderCollections(NameValueCollection _customHeader)
        {
            Collections.Add(_customHeader);
        }

        public WebHeaderCollection SetHeaderCollection(params WebHeaderCollection[] _collection)
        {
            _collection.ToList().ForEach(x => Collections.Add(x));

            return Collections;
        } 
        protected WebHeaderCollection AddHeader(HeaderValue_Flags[] _Flags)
        {
            var webHeaderCollection = new WebHeaderCollection();

            foreach (HeaderValue_Flags flags in _Flags)
            {
                switch (flags)
                {
                    case HeaderValue_Flags.Cache_Control:
                        webHeaderCollection.Add("Cache-Control", "max-age=0");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Dest_document:
                        webHeaderCollection.Add("Sec-Fetch-Dest", "document");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Dest_script:
                        webHeaderCollection.Add("Sec-Fetch-Dest", "script");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Dest_Empty:
                        webHeaderCollection.Add("Sec-Fetch-Dest", "empty");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Dest_image:
                        webHeaderCollection.Add("Sec-Fetch-Dest", "image");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Mode_navigate:
                        webHeaderCollection.Add("Sec-Fetch-Mode", "navigate");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Mode_cors:
                        webHeaderCollection.Add("Sec-Fetch-Mode", "cors");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Mode_no_cors:
                        webHeaderCollection.Add("Sec-Fetch-Mode", "no-cors");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Site_same_site:
                        webHeaderCollection.Add("Sec-Fetch-Site", "same-site");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Site_same_origin:
                        webHeaderCollection.Add("Sec-Fetch-Site", "same-origin");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_User:
                        webHeaderCollection.Add("Sec-Fetch-User", "?1");
                        break;
                    case HeaderValue_Flags.Upgrade_Insecure_Requests:
                        webHeaderCollection.Add("Upgrade-Insecure-Requests", "1");
                        break;
                    case HeaderValue_Flags.X_Requested_With:
                        webHeaderCollection.Add("X-Requested-With", "XMLHttpRequest");
                        break;
                }
            }
            return webHeaderCollection;
        }

    }

    public class CreateHeader
    {

    
        
        // 머지하기전까지 기존코드 정상작동시킬 매서드 머지후 패치하겠음
        public static WebHeaderCollection CreateHeaderCollection(params HeaderValue_Flags[] headerValue_Flags)
        {
            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
            webHeaderCollection.Add(SetHeader(webHeaderCollection, headerValue_Flags));
            return webHeaderCollection;
        }


   

        public static WebHeaderCollection CreateCustomWebHeaderCollection(NameValueCollection _customHeader)
        {
            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();
            webHeaderCollection.Add(_customHeader);
            return webHeaderCollection;
        }


        protected static WebHeaderCollection SetHeader(WebHeaderCollection _collection,HeaderValue_Flags[] _Flags)
        {
            WebHeaderCollection webHeaderCollection = _collection;

            foreach (HeaderValue_Flags flags in _Flags)
            {
                switch (flags)
                {
                    case HeaderValue_Flags.Cache_Control:
                        webHeaderCollection.Add("Cache-Control", "max-age=0");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Dest_document:
                        webHeaderCollection.Add("Sec-Fetch-Dest", "document");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Dest_script:
                        webHeaderCollection.Add("Sec-Fetch-Dest", "script");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Dest_Empty:
                        webHeaderCollection.Add("Sec-Fetch-Dest", "empty");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Dest_image:
                        webHeaderCollection.Add("Sec-Fetch-Dest", "image");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Mode_navigate:
                        webHeaderCollection.Add("Sec-Fetch-Mode", "navigate");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Mode_cors:
                        webHeaderCollection.Add("Sec-Fetch-Mode", "cors");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Mode_no_cors:
                        webHeaderCollection.Add("Sec-Fetch-Mode", "no-cors");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Site_same_site:
                        webHeaderCollection.Add("Sec-Fetch-Site", "same-site");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_Site_same_origin:
                        webHeaderCollection.Add("Sec-Fetch-Site", "same-origin");
                        break;
                    case HeaderValue_Flags.Sec_Fetch_User:
                        webHeaderCollection.Add("Sec-Fetch-User", "?1");
                        break;
                    case HeaderValue_Flags.Upgrade_Insecure_Requests:
                        webHeaderCollection.Add("Upgrade-Insecure-Requests", "1");
                        break;
                    case HeaderValue_Flags.X_Requested_With:
                        webHeaderCollection.Add("X-Requested-With", "XMLHttpRequest");
                        break;
                }
            }
            return webHeaderCollection;
        }


        
    }
    public class HttpWebIO
    {
        public static string SendDataBuilder(NameValueCollection _senddata)
        {
            StringBuilder sendDataBuilder = new StringBuilder();
            foreach (string key in _senddata.Keys)
            {
                sendDataBuilder.Append($"{key}={_senddata[key]}");
                sendDataBuilder.Append("&");
            }
            string value = sendDataBuilder.ToString().Remove(sendDataBuilder.ToString().Length - 1);

            return value;
        }


        public static string ReturnStrHtml(Stream stream, Encoding encoding)
        {
            TextReader textReader = (TextReader)new StreamReader(stream, encoding);
            string value = textReader.ReadToEnd();
            textReader.Close();
            stream.Close();
            return value;
        }
    }
    
}
