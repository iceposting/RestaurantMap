using RestaurantMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMap.Model
{
    public class PlaceResponse
    {
        public List<PlaceResult> results { get; set; }
        public List<PlaceResult> candidates { get; set; }
        public PlaceResult result { get; set; }
        public Location center { get; set; }
        public string status { get; set; }
    }
}
