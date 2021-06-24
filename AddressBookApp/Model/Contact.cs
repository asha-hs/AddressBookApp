using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookApp.Model
{
    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Contact(String name,string phone, string address)
        {
            Name = name;
            Phone = phone;
            Address = address;
        }
    }
}
