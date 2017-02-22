using System;
using System.Collections.Generic;

namespace YahooAPI
{
    public class CityListProvider
    {
        public List<string> cityList = new List<string>();

        public CityListProvider()
        {
        }

        public List<String> GetCities()
        {
            cityList = new List<String> {"Chennai","Delhi","Mumbai","Calcutta","Pune","Patna","Srinagar","Bangalore","Hydrapath"};
            return cityList;
        }
    }
}
