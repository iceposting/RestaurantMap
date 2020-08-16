using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMap.Model
{
    public class PlaceResult
    {
        public Geometry geometry { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string referance { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
        public string vicinity { get; set; }
        public string formatted_address { get; set; }

    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class OpeningHours
    {
        public bool open_now { get; set; }
        public string[] weekday_text { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public int width { get; set; }
        public string[] html_attributions { get; set; }
        public string photo_reference { get; set; }
    }
}
