using System;
using System.Collections.Generic;

namespace YahooAPI
{


    public class CityListProvider
    {
        public  List<string> cityList = new List<string> { "Chennai", "Delhi", "Mumbai", "Calcutta", "Pune", "Patna", "Srinagar", "Bangalore", "Hydrapath" };

        public  List<string> GetCities()
        {
            // cityList = new List<string> {"Chennai","Delhi","Mumbai","Calcutta","Pune","Patna","Srinagar","Bangalore","Hydrapath"};
            return cityList;
        }
    }
}
