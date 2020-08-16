using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMap.Model
{
    public class GoogleMapRequest
    {
        public string key { get; set; }
        public string input { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string inputtype { get; set; }
    }
}
