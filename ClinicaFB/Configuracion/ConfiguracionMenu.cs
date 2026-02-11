using ClinicaFB.Configuracion.Empresas;
using ClinicaFB.Configuracion.Usuarios;
using ClinicaFB.Helpers;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using ClinicaFB.Modelo;
using ClinicaFB.ModeloWEB;
using ClinicaFB.Configuracion.Recetas;
using ClinicaFB.Configuracion.PuntoDeVenta;
using ClinicaFB.Configuracion.Facturacion;
using ClinicaFB.PuntoDeVenta;

namespace ClinicaFB.Configuracion
{
    public partial class ConfiguracionMenu : Form
    {
        private FbConnection _db;
        private FbConnection _dbConfig;
        public ConfiguracionMenu(FbConnection db, FbConnection dbConfig)
        {
            _db = db;
            _dbConfig = dbConfig;
            InitializeComponent();
        }

        private void ConfiguracionMenu_Load(object sender, EventArgs e)
        {

        }

        private void cmdDoctores_Click(object sender, EventArgs e)
        {
            DoctoresListado doctoresListado = new DoctoresListado(_db);
            doctoresListado.ShowDialog();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdEquipos_Click(object sender, EventArgs e)
        {
            EquiposListado equiposListado = new EquiposListado(_db);
            equiposListado.ShowDialog();

        }

        private void cmdCuartos_Click(object sender, EventArgs e)
        {
            CuartosListado cuartosListado = new CuartosListado(_db);
            cuartosListado.ShowDialog();
        }

        private void cmdProcedimientos_Click(object sender, EventArgs e)
        {
            ProcedimientosListado procedimientosListado = new ProcedimientosListado(_db);
            procedimientosListado.ShowDialog();
        }

        private void MantenimientoCatalogo(string tipo)
        {
            DescripcionesListado cat = new DescripcionesListado(_db, tipo);
            cat.ShowDialog();
        }

        private void cmdInstrucciones_Click(object sender, EventArgs e)
        {
            MantenimientoCatalogo("INS");
        }

        private void cmdMotivosBloqueo_Click(object sender, EventArgs e)
        {
            MantenimientoCatalogo("BLO");
        }

        private void cmdMotivosCancelaciones_Click(object sender, EventArgs e)
        {
            MantenimientoCatalogo("MOC");
        }

        private void cmdColores_Click(object sender, EventArgs e)
        {
            ColoresConfigurar coloresConfigurar = new ColoresConfigurar(_db);
            coloresConfigurar.ShowDialog();
        }

        private void cmdEmpresa_Click(object sender, EventArgs e)
        {
            EmpresasListado empresasListado = new EmpresasListado(_dbConfig);
            empresasListado.ShowDialog();

        }

        private void cmdUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosListado usuariosListado = new UsuariosListado(_dbConfig);
            usuariosListado.ShowDialog();

        }

        private async void cmdGeneraWEB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea generar las citas WEB?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
            csb.DataSource = "localhost";
            csb.Database = @"C:\ClinicaFB Datos\web\cdi\CDIWEB.FDB";
            csb.UserID = "SYSDBA";
            csb.Password = "masterkey";
            FbConnection dbWEB = new FbConnection();
            dbWEB.ConnectionString = csb.ToString();

            string sql = Queries.DoctoresWEBInicializa();
            await dbWEB.ExecuteAsync(sql);

            sql = Queries.DoctoresSelect();

            var docs = _db.Query<Doctor>(sql).ToList();

            sql = Queries.DoctorWEBInsert();
            foreach (var dr in docs)
            {
                DoctorWEB doc = new DoctorWEB();
                doc.Nombres = dr.Nombres;
                doc.ApellidoPaterno = dr.Apellido_Paterno;
                doc.ApellidoMaterno = dr.Apellido_Materno;
                doc.Telefonos = dr.Telefonos;
                doc.Correos = dr.Correos;
                doc.OriginalId = (int)dr.Doctor_Id;

                dbWEB.Execute(sql, doc);
            }

            sql = Queries.CitasSelectDesdeFecha();
            var citas = _db.Query<Cita>(sql, new { Fecha = DateTime.Now }).ToList();

            sql = Queries.CitaWEBInsert();
            foreach (var c in citas)
            {
                if (c.Cancelada || c.Bloqueada)
                    continue;

                CitaWEB cw = General.BuildCitaWEB(_db, c);
                dbWEB.Execute(sql, cw);


            }
            MessageBox.Show("Termine");

        }

        private void cmdPadecimientos_Click(object sender, EventArgs e)
        {
            MantenimientoCatalogo("PAD");
        }

        private void cmdPassWordSA_Click(object sender, EventArgs e)
        {

        }

        private void cmdTextosRapidos_Click(object sender, EventArgs e)
        {
            TextosRapidosConfigurar textosRapidosConfigurar = new TextosRapidosConfigurar();
            textosRapidosConfigurar.ShowDialog();

        }

        private void cmdImpuestos_Click(object sender, EventArgs e)
        {
            ImpuestosListado impuestosListado = new ImpuestosListado();
            impuestosListado.ShowDialog();
        }

        private void cmdClavesSAT_Click(object sender, EventArgs e)
        {
            ClavesSATActualiza cveSAT = new ClavesSATActualiza();
            cveSAT.ShowDialog();
        }

        private void pagPuntoDeventa_Click(object sender, EventArgs e)
        {

        }


        private void cmdMarcas_Click(object sender, EventArgs e)
        {
            MantenimientoCatalogo("MAR");

        }

        private void cmdLineas_Click(object sender, EventArgs e)
        {
            MantenimientoCatalogo("LIN");

        }

        private void cmdEmisores_Click(object sender, EventArgs e)
        {
            EmisoresListado emisoresListado = new EmisoresListado();
            emisoresListado.ShowDialog();

        }

        private void cmdArticulos_Click(object sender, EventArgs e)
        {
            ArticulosListado articulosListado = new ArticulosListado();
            articulosListado.ShowDialog();
        }

        private void cmdSucursales_Click(object sender, EventArgs e)
        {
            SucursalesListado sucursalesListado = new SucursalesListado();
            sucursalesListado.Show();
        }

        private void cmdImportarClientes_Click(object sender, EventArgs e)
        {
            ClientesFFImportar clientesFFImportar = new ClientesFFImportar();
            clientesFFImportar.ShowDialog();
        }

        private void cmdFormasPago_Click(object sender, EventArgs e)
        {
            FormasPagoListado formasPagoListado = new FormasPagoListado();
            formasPagoListado.ShowDialog();
        }

        private void cmdArticulosImportar_Click(object sender, EventArgs e)
        {
            ArticulosImportar();
        }

        private void ArticulosImportar()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos CSV|*.csv";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string[] lines = System.IO.File.ReadAllLines(ofd.FileName, Encoding.Unicode);
            string sql = Queries.ArticuloInsert();

            using (FbConnection db = General.GetDB())
            {

                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    Articulo a = new Articulo();
                    a.Clave = parts[0];
                    a.CodigoBarras = parts[0];
                    a.Descripcion = parts[1];
                    a.Moneda = "MXN";
                    a.Precio1 = decimal.Parse(parts[2]);
                    a.ImpuestoId = 1;
                    a.Tipo = 1;
                    a.UDM = "PIEZA";
                    db.Execute(sql, a);
                }
            }
            MessageBox.Show("Terminó la importación de artículos");
        }

        private void cmdInicializar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea inicializar la base de datos de inventarios?\nVentas\nCompras\nAjustes\nExistencias", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (FbConnection db = General.GetDB())
            {
                string[] instrucciones =
                    {
                    Queries.VentasDelete,
                    Queries.VentasDetalleDelete,
                    Queries.DocumentosDelete,
                    Queries.DocumentosDetalleDelete,
                    Queries.ArticulosExistenciasDelete,
                    Queries.ArticulosMovimientosDelete
                };

                foreach (var instruccion in instrucciones)
                {
                    db.Execute(instruccion);
                }
            }
            MessageBox.Show("Terminó la inicialización de inventarios");
        }
    }
}

