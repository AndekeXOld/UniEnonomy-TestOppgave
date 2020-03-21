using System;
using System.Collections.Generic;

namespace UniEconomyAPI
{
    public class UniEconomyAPIRequest
    {
        public Login.UniEconomy_Login Login;
        public Modules.Modules Modules;

        public UniEconomyAPIRequest(Dictionary<string, string> Arg_AuthData)
        {
            this.Modules = new Modules.Modules(Arg_AuthData);
        }

        public UniEconomyAPIRequest()
        {
            Login = new Login.UniEconomy_Login();
        }
    }
}
