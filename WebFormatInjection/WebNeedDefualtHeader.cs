using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace WebFormatInjection.WebNeedDefualtHeader
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

        public static string X_www_form = "application/x-www-form-urlencoded;";
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
        Cache_Control_max_0 = 100,
        Sec_Fetch_Dest_image = 201,
        Sec_Fetch_Dest_document = 202,
        Sec_Fetch_Dest_script = 203,
        Sec_Fetch_Dest_Empty = 204,
        Sec_Fetch_Mode_navigate = 301,
        Sec_Fetch_Mode_no_cors = 302,
        Sec_Fetch_Mode_cors = 303,
        Sec_Fetch_Site_same_site = 401,
        Sec_Fetch_Site_same_origin = 402,
        Sec_Fetch_User_1 = 500,
        Upgrade_Insecure_Requests_1 = 600,
        X_Requested_With_Xml = 700

    }

    public class CreateHeader
    {
        public static WebHeaderCollection CreateHeaderCollection(params HeaderValue_Flags[] headerValue_Flags)
        {
            WebHeaderCollection webHeaderCollection = new WebHeaderCollection();

            foreach (HeaderValue_Flags flags in headerValue_Flags)
            {
                switch (flags)
                {
                    case HeaderValue_Flags.Cache_Control_max_0:
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
                    case HeaderValue_Flags.Sec_Fetch_User_1:
                        webHeaderCollection.Add("Sec-Fetch-User", "?1");
                        break;
                    case HeaderValue_Flags.Upgrade_Insecure_Requests_1:
                        webHeaderCollection.Add("Upgrade-Insecure-Requests", "1");
                        break;
                    case HeaderValue_Flags.X_Requested_With_Xml:
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
