using System;
using System.Collections.Generic;
using UniEconomyAPI;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            string UserName()
            {
                Console.WriteLine("Username:");
                return Console.ReadLine();
            }
            string Password()
            {
                Console.WriteLine("Password:");
                return Console.ReadLine();
            }

            Dictionary<string, string> accessTokens = new UniEconomyAPIRequest().Login.GetAccessTokens(new KeyValuePair<string, string>(UserName(), Password()));


            UniModules.Contact contact = new UniEconomyAPIRequest(accessTokens).Modules.Contacts.GetAll()[0];

            Console.WriteLine(contact.Role);

            Console.WriteLine("New comment:");
            contact.Info.DefaultPhone.Description = Console.ReadLine();

            if(contact.Info.DefaultPhone.Description == new UniEconomyAPIRequest(accessTokens).Modules.Contacts.Update(contact).Info.DefaultPhone.Description)
            {
                Console.WriteLine("DAMN BOY!");
            }

            Console.WriteLine("Lager ny kontakt...");
            UniModules.Contact contact1 = new UniModules.Contact();
            contact1.Info.Name = "Andreas Ekeland";
            contact1.Role = "Nyansatt";

            UniModules.Contact contact1_svar = new UniEconomyAPIRequest(accessTokens).Modules.Contacts.New(contact1);
            Console.WriteLine(contact1_svar.Role + " - " + contact1_svar.Info.Name);

            Console.WriteLine("Vil du slette kontakten? Om ja skriv OK");

            if(Console.ReadLine() == "OK")
            {
                if(new UniEconomyAPIRequest(accessTokens).Modules.Contacts.Delete(contact1_svar.ID) is true)
                {
                    Console.WriteLine("Konten er slettet!");
                }
            }

            Console.Read();
            Console.Read();
        }
    }
}
