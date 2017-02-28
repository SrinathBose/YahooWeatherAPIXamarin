using Plugin.Connectivity;
using System;

namespace YahooAPI
{
    public class NetworkConnectivityManager
    {
        public static bool CheckConnectionStatus()
        {
            if (CrossConnectivity.Current.IsConnected)
                return true;
            return false;
        }

    }
}
