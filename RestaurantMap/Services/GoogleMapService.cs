using Newtonsoft.Json;
using RestaurantMap.Model;
using RestaurantMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMap.Services
{
    public class GoogleMapService : IGoogleMapService
    {

        public PlaceResponse FindNearbySearchByPlace(string place)
        {
            try
            {
                PlaceResponse response = null;
                GoogleMapRequest request = new GoogleMapRequest
                {
                    key = Environment.GetEnvironmentVariable("APIKey"),
                    input = place,
                    inputtype = "textquery",
                };

                response = this.GetPlace(request,true);

                if (!response.status.Equals("OK", StringComparison.OrdinalIgnoreCase))
                    return response;

                if(response.candidates != null)
                {
                    PlaceResult placeResult = response.candidates.FirstOrDefault();

                    if(placeResult.geometry.location != null)
                    {
                        request.lat = placeResult.geometry.location.lat;
                        request.lng = placeResult.geometry.location.lng;

                        response = this.GetNearbySearch(request);
                    }
                    response.center = placeResult.geometry.location;
                }

                return response;
            }
            catch 
            {
                return new PlaceResponse
                {
                    result = null,
                    status = "ERROR"

                };
            }
        }

        public PlaceResponse FindPlace(string place = "")
        {
            try
            {
                PlaceResponse response = null;
                GoogleMapRequest request = new GoogleMapRequest
                {
                    key = Environment.GetEnvironmentVariable("APIKey"),
                    input = place,
                    inputtype = "textquery",
                };

                response = this.GetPlace(request);

                return response;
            }
            catch
            {
                return new PlaceResponse
                {
                    result = null,
                    status = "ERROR"

                };
            }
        }

        #region Calling Place API
        public PlaceResponse GetPlace(GoogleMapRequest request, bool findGeometry = false)
        {
            try
            {
                PlaceResponse responseData = null;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/findplacefromtext");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    string parameter = string.Format("json?key={0}&input={1}&inputtype={2}", request.key, request.input, request.inputtype);

                    if (findGeometry)
                        parameter += "&fields=geometry";

                    var response = client.GetAsync("https://maps.googleapis.com/maps/api/place/findplacefromtext/" + parameter).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        responseData = JsonConvert.DeserializeObject<PlaceResponse>(response.Content.ReadAsStringAsync().Result);
                    }
                    return responseData;
                }
            }
            catch
            {
                return new PlaceResponse
                {
                    result = null,
                    status = "ERROR"

                };
            }
        }

        public PlaceResponse GetGeocoding(string place = "ChIJ0Wy3yXKc4jAR4CNvJtGeJaU")
        {
            try
            {
                PlaceResponse responseData = null;
                GoogleMapRequest googleMapRequest = new GoogleMapRequest
                {
                    key = Environment.GetEnvironmentVariable("APIKey"),
                    input = place,
                    inputtype = "textquery",
                };

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/details/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    string parameter = string.Format("json?key={0}&place_id={1}", googleMapRequest.key, googleMapRequest.input);
                    var response = client.GetAsync("https://maps.googleapis.com/maps/api/place/details/" + parameter).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        responseData = JsonConvert.DeserializeObject<PlaceResponse>(response.Content.ReadAsStringAsync().Result);
                        string test = response.Content.ReadAsStringAsync().Result;
                    }
                    return responseData;
                }
            }
            catch
            {
                return null;
            }
        }

        public PlaceResponse GetNearbySearch(GoogleMapRequest request)
        {
            try
            {
                PlaceResponse responseData = null;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/nearbysearch/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    string parameter = string.Format("json?key={0}&location={1},{2}&radius={3}&type=restaurant", request.key, request.lat, request.lng, 2000);
                    var response = client.GetAsync("https://maps.googleapis.com/maps/api/place/nearbysearch/" + parameter).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        responseData = JsonConvert.DeserializeObject<PlaceResponse>(response.Content.ReadAsStringAsync().Result);
                    }
                    return responseData;
                }
            }
            catch
            {
                return new PlaceResponse
                {
                    result = null,
                    status = "ERROR"

                };
            }
        }
        #endregion Calling Place API
    }
}
