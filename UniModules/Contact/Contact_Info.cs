using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniModules
{
    public class Contact_Info
    {
        public int ID { get; set; }
        public int InfoID { get; set; }
        [Required]
        public string Name { get; set; }

        //public int InvoiceAddressID { get; set; }
        //public int DefaultPhoneID { get; set; }
        //public int DefaultEmailID { get; set; }

        public Contact_Phone DefaultPhone { get; set; } = new Contact_Phone();
        public Contact_Email DefaultEmail { get; set; } = new Contact_Email();
        public Contact_Address InvoiceAddress { get; set; } = new Contact_Address();

        public Contact_Info()
        {

        }
    }
}
