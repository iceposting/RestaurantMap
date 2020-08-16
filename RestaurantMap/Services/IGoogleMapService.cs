using RestaurantMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMap.Services
{
    public interface IGoogleMapService
    {
        PlaceResponse FindNearbySearchByPlace(string place = "Bang%20sue");

        PlaceResponse FindPlace(string place = "");

        PlaceResponse GetPlace(GoogleMapRequest request, bool findGeometry = false);

        PlaceResponse GetGeocoding(string place = "ChIJ0Wy3yXKc4jAR4CNvJtGeJaU");

        PlaceResponse GetNearbySearch(GoogleMapRequest request);
    }
}
