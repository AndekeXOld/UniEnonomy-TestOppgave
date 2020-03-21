using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UniEconomyAPI.Handler;

namespace UniEconomyAPI.Login
{
    public class UniEconomy_Login
    {
        public Dictionary<string,string> GetAccessTokens(KeyValuePair<string, string> Arg_LoginCredentials)
        {
            Dictionary<string, string> AccessTokens = new Dictionary<string, string>();
            KeyValuePair<string, string> JWTtoken = GetJWTToken(Arg_LoginCredentials);
            KeyValuePair<string, string> CompanyCode = GetCompanyKey(JWTtoken);
            AccessTokens.Add(JWTtoken.Key, JWTtoken.Value);
            AccessTokens.Add(CompanyCode.Key, CompanyCode.Value);
            return AccessTokens;
        }

        //RETREIVE THE JWT TOKEN WITH LOGIN CREDENTIALS 
        private KeyValuePair<string, string> GetJWTToken(KeyValuePair<string, string> Arg_LoginCredentials)
        {
            string response = new UniEconomy_HttpHandler().POST("https://test-api.unieconomy.no/api/init/sign-in", new { Username = Arg_LoginCredentials.Key, Password = Arg_LoginCredentials.Value });
            JObject token = JObject.Parse(response);            
            return new KeyValuePair<string,string>("Authorization", "bearer " + (string)token["access_token"]);
        }

        //WHEN JWT TOKEN IS RETREIVED, THIS METHOD WILL GET THE COMPANY KEY
        private KeyValuePair<string, string> GetCompanyKey(KeyValuePair<string,string> Arg_JWTtoken)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            temp.Add(Arg_JWTtoken.Key, Arg_JWTtoken.Value);
            string response = new UniEconomy_HttpHandler(temp).GET("https://test-api.unieconomy.no/api/init/companies");
            JArray token = JsonConvert.DeserializeObject<JArray>(response);
            return new KeyValuePair<string, string>("CompanyKey", (string)token[0]["Key"]);
        }
    }
}
