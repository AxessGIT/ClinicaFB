using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB
{
    static class Inicio
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string lic = "Mgo+DSMBaFt+QHJqUU1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfR1xnSH9XcURgX31Wcg==;Mgo+DSMBPh8sVXJ1S0R+WFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jTH9Xd0RnXn5ddnBURA==;ORg4AjUWIQA/Gnt2VFhiQlVPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtSckRiXXhfc3JQRWI=;MjA0MDMxN0AzMjMxMmUzMjJlMzREaUZxSHNYSUptb0VnZFlVbHlwOEFBVDhrQnAwdnBYc0RteSsza0NLU240PQ==;MjA0MDMxOEAzMjMxMmUzMjJlMzRnOFdIRUxTdW83TnZsSUY0YlVVU2lVcGhKQnUyVG9WR3pjNmtrUm5UZnFrPQ==;NRAiBiAaIQQuGjN/V0d+Xk9AfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5Wd0FiWHtZcXdSRGBe;MjA0MDMyMEAzMjMxMmUzMjJlMzRSbTZLaUFFd29LdjZ4MWR6bVg1YUwyRXR1eENOMVJsTGxtR2UrN0xLa0I4PQ==;MjA0MDMyMUAzMjMxMmUzMjJlMzRDUXpBa1JxSVV6akFYMHhvdDhTSWRhcmRPdndKYTFNNXUzVE1ialREbWJBPQ==;Mgo+DSMBMAY9C3t2VFhiQlVPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtSckRiXXhfc3NdQ2I=;MjA0MDMyM0AzMjMxMmUzMjJlMzRoTWl3WDgzc2IyMFd0MmViRjN6bmxMWGNVQkJ0aTlDNzV6OTFxaTBnWUJNPQ==;MjA0MDMyNEAzMjMxMmUzMjJlMzRKemxmM0pSMHZwYTgvZUFtcjdSSncwOUttS0tmZ2JpSkxKdVNQbm5PbTRJPQ==;MjA0MDMyNUAzMjMxMmUzMjJlMzRSbTZLaUFFd29LdjZ4MWR6bVg1YUwyRXR1eENOMVJsTGxtR2UrN0xLa0I4PQ==";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(lic);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuPrincipal());
        }
    }
}
