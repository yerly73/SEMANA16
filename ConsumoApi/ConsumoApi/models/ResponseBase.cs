using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumoApi.models
{
    public class RandomUserResponse
    {
        public List<User> results { get; set; }
        // Otros campos como info, etc.
    }

    public class User
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        // Otros campos relevantes...
    }

    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Location
    {
        public string city { get; set; }
        public string state { get; set; }
        // Otros campos relevantes...
    }
    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }
}
