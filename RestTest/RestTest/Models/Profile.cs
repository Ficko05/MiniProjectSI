using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestTest.Models
{
    public class Profile
    {
        public Profile(string id, string name, string phone, string country)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Country = country;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
    }
}