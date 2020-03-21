using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace UniEconomyAPI.Handler
{
    class UniEconomy_HttpHandler
    {
        //REQUEST WHEN NO JSON DATA IS SENT
        private HttpWebRequest UniRequest(string Arg_Method, string Arg_Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Arg_Url);
            request.Method = Arg_Method;
            foreach (KeyValuePair<string, string> header in AuthData)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            return request;
        }

        //REQUSET WHEN JSON DATA IS SENT
        private HttpWebRequest UniRequest(string Arg_Method, string Arg_Url, object Arg_Data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Arg_Url);
            request.Method = Arg_Method;
            request.ContentType = "application/json";
            foreach (KeyValuePair<string, string> header in AuthData)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(Newtonsoft.Json.JsonConvert.SerializeObject(Arg_Data));
            }

            return request;
        }

        //AUTH AND COMPANY KEY
        Dictionary<string, string> AuthData;

        public UniEconomy_HttpHandler(Dictionary<string, string> Arg_AuthData)
        {
            this.AuthData = Arg_AuthData;
        }

        //Used before authTokens are received 
        public UniEconomy_HttpHandler()
        {
            this.AuthData = new Dictionary<string, string>();
        }

        public string GET(string Arg_Url)
        {
            WebResponse response = UniRequest("GET", Arg_Url).GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd(); 
        }

        public string POST(string Arg_Url, object Arg_Data)
        {
            WebResponse response = UniRequest("POST", Arg_Url, Arg_Data).GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public string PUT(string Arg_Url, object Arg_Data)
        {
            WebResponse response = UniRequest("PUT", Arg_Url, Arg_Data).GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public bool DELETE(string Arg_Url)
        {
            HttpWebResponse response = (HttpWebResponse)UniRequest("DELETE", Arg_Url).GetResponse();
            if((response.StatusCode is HttpStatusCode.NoContent))
            {
                return true;                
            }

            return false;
        }
    }
}
