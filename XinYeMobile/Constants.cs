using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYeMobile
{
    public class Constants
    {
        // URL of REST service
        //public static string RestUrl = "https://YOURPROJECT.azurewebsites.net/api/todoitems/{0}";

        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production
        //public static string LocalhostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string LocalhostUrl = "www.xinyebook.cn";
        public static string Scheme = "https"; // or https
        public static string Port = "5001"; // 5000 for http, 5001 for https
        //public static string Port = "7206"; // 5000 for http, 5001 for https
        public static string RestUrl = $"{Scheme}://{LocalhostUrl}:{Port}/api";
        public static string UserHubUrl = $"{Scheme}://{LocalhostUrl}:{Port}/UserHub";
    }
}
