using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UniEconomyAPI.Modules
{
    public class Modules_Contacts
    {
        private UniEconomyAPI.Handler.UniEconomy_HttpHandler handler;

        public Modules_Contacts(Dictionary<string, string> Arg_AuthData)
        {
            this.handler = new Handler.UniEconomy_HttpHandler(Arg_AuthData);
        }


        //RETURNS ALL CONTACTS FROM UNIECONOMY
        public UniModules.Contact[] GetAll()
        {            
            return JsonConvert.DeserializeObject<UniModules.Contact[]>(handler.GET("https://test-api.unieconomy.no/api/biz/contacts?expand=Info,Info.InvoiceAddress,Info.DefaultPhone,Info.DefaultEmail,Info.DefaultAddress&hateoas=false"));
        }


        //RETURNS CONTACT WITH SPESFIED ID
        public UniModules.Contact Get(int Arg_ContactID)
        {            
            return JsonConvert.DeserializeObject<UniModules.Contact>(handler.GET("https://test-api.unieconomy.no/api/biz/contacts/" + Arg_ContactID + "?expand=Info,Info.InvoiceAddress,Info.DefaultPhone,Info.DefaultEmail,Info.DefaultAddress&hateoas=false"));
        }


        //POST NEW CONTACT, THEN RETURN WHEN CREATED IN DATABASE
        public UniModules.Contact New(UniModules.Contact Arg_NewContact)
        {            
            return JsonConvert.DeserializeObject<UniModules.Contact>(handler.POST("https://test-api.unieconomy.no/api/biz/contacts",Arg_NewContact)); 
        }


        //UPDATES CONTACT, THEN RETURN WHEN UPDATED IN DATABASE
        public UniModules.Contact Update(UniModules.Contact Arg_NewContact)
        {            
            return JsonConvert.DeserializeObject<UniModules.Contact>(handler.PUT("https://test-api.unieconomy.no/api/biz/contacts/"+ Arg_NewContact.ID, Arg_NewContact));
        }


        //DELETES EXISTING CONTACT, THEN RETURN TRUE WHEN DONE.
        public bool Delete(int Arg_ContactID)
        {            
            if (handler.DELETE("https://test-api.unieconomy.no/api/biz/contacts/" + Arg_ContactID)) { return true; }
            //ITEM IS DELETED

            return false;
            //ITEM NOT DELETED
        }
    }
}
