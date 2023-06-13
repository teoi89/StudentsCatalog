using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsCatalog
{
    /// <summary>
    /// Represents an address.
    /// </summary>
    class Address
    {
        public Address(string v1, string v2, string v3)
        {
        }

        public object City { get; internal set; }
        public object Street { get; internal set; }
        public object Number { get; internal set; }

        internal class StudentAddress
        {
            public string City { get; set; }
            public string Street { get; set; }
            public string Number { get; set; }

            public StudentAddress(string city, string street, string number)
            {
                City = city;
                Street = street;
                Number = number;
            }
        }
    }
}
