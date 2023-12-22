using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumoApi.models
{
    public class ResponseBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public string origin { get; set; }
        public string location { get; set; }
        public string image { get; set; }
        public string episode { get; set; }
        public string url { get; set; }
    }
}
