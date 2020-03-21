using System;
using System.Collections.Generic;
using System.Text;

namespace UniEconomyAPI.Modules
{
    public class Modules
    {
        public Modules_Contacts Contacts;

        public Modules(Dictionary<string, string> Arg_AuthData)
        {
            this.Contacts = new Modules_Contacts(Arg_AuthData);
        }
    }
}
