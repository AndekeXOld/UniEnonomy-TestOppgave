using Newtonsoft.Json;
using System;

namespace UniModules
{
    public class Contact
    {
        public int ID { get; set; }
        public int InfoID { get; set; }

        public string Comment { get; set; }
        public string Role { get; set; }

        public Contact_Info Info { get; set; }

        public Contact()
        {
            this.Info = new Contact_Info();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
