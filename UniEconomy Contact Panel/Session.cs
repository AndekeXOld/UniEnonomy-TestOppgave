using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniEconomy_Contact_Panel
{
    public static class Session
    {
        public static Dictionary<string, string> AccessTokens { get; set; } = new Dictionary<string, string>();

        public static bool LoggedIn { get; set; } = false;
    }
}
