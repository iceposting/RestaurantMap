using RestaurantMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMap.Models
{
    public class GeocodingResult
    {
        public List<AddressComponents> address_components { get; set; }
        public Geometry geometry { get; set; }
        public string location_type { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
        public string formatted_address { get; set; }
    }

    public class AddressComponents
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
}
