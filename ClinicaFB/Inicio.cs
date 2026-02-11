using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;

namespace ClinicaFB
{
    static class Inicio
    {
        [STAThread]
        static void Main()
        {
            string lic = "Ngo9BigBOggjHTQxAR8/V1JGaF5cXGpCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWH1ccnVURmNfVUN/V0RWYEs=";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(lic);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuPrincipal());
        } 
    }
}
