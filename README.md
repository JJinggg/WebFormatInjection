# WebFormatInjection


httpwebrequest 주입
httpwebresponse 주입
httpwebio  라이브러리





예제

using (Webformat _webformat = new Webformat(url,referer url))
{
    request = webformat (cookiecontainer , crud , accept , contenttype , certificate , webheader , useragent)
    response = await webformat.GetresponseAsync(request,sendData);
}

string responsetext = HttpWebIO.ReturnStrHtml(response.GetResponseStream(), Encoding.UTF8);


끄덕끄덕
