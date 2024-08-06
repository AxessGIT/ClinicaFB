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
            string lic = "Ngo9BigBOggjHTQxAR8/V1NCaF5cWWFCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXhccnVQRGBYV0Z3X0c=";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(lic);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuPrincipal());

        }
    }
}
