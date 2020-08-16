using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMap.Models
{
    public class GeocodingResponse
    {
        public string status { get; set; }
        public List<GeocodingResult> results { get; set; }
    }
}
