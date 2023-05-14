using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFB.Modelo;
using ClinicaFB.ModeloConfiguracion;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;
using Twilio.TwiML.Voice;


namespace ClinicaFB.Helpers
{
    public static class Queries
    {

        #region CFDi

        public static string FacturasSelect()
        {
            string sql = "";
            sql = "Select Cfdis.CfdiId,Cfdis.IngresoId,Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.PacienteId,Cfdis.Cancelado, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.TipoComprobante='I' and " +
                " Cfdis.Emisorid = @Emisorid and Cfdis.Fecha Between @FechaIni and @FechaFin " +
                " Order By Cfdis.Fecha Desc";
            return sql;


        }

        public static string FacturasSelectxFechas()
        {
            string sql = "";
            sql = "Select Cfdis.CfdiId,Cfdis.IngresoId,Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.PacienteId, Cfdis.Cancelado, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.TipoComprobante='I' and " +
                " Cfdis.Fecha Between @FechaIni and @FechaFin " +
                " Order By Cfdis.Fecha Desc";
            return sql;


        }


        public static string CfdiSelect()
        {
            string sql = "";
            sql = "Select Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.PacienteId,Cfdis.uid, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RFC as ReceptorRFC, RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where CfdiId = @Id";
            return sql;


        }

        public static string CfdiDetallesSelect()
        {
            string sql = "";
            sql = "Select CfdisDetalle.ArticuloId,CfdisDetalle.NoIden,CfdisDetalle.Descripcion,Articulos.UDM," +
                "CfdisDetalle.Cantidad,CfdisDetalle.ValorUnitario,CfdisDetalle.CveProSer,CfdisDetalle.CveUNI," +
                "CfdisDetalle.Descuento,CfdisDetalle.TasaIVA,CfdisDetalle.TipoIVA,CfdisDetalle.IVA," +
                "CfdisDetalle.RetIVA,CfdisDetalle.RetISR " +
                "From CfdisDetalle " +
                " Left Join Articulos On CfdisDetalle.ArticuloId = Articulos.ArticuloId " +
                " Where CfdiId = @Id";
            return sql;


        }




        public static string CfdiInsert()
        {
            string sql = "";
            sql = "Insert Into Cfdis " +
                "(EmisorId,PacienteId,RazonSocialId,TipoComprobante,Serie,Folio,Fecha,FormaPago,Moneda,TipoDeCambio," +
                "MetodoPago,LugarExpedicion,UsoCFDi,Subtotal,Descuento,IVA,RetISR,RetIVA,uid,Cancelado,AcuseCan,IngresoId)" +
                " Values " +
                "(@EmisorId,@PacienteId,@RazonSocialId,@TipoComprobante,@Serie,@Folio,@Fecha,@FormaPago,@Moneda,@TipoDeCambio," +
                "@MetodoPago,@LugarExpedicion,@UsoCFDi,@Subtotal,@Descuento,@IVA,@RetISR,@RetIVA,@uid,@Cancelado,@AcuseCan,@IngresoId)" +
                " Returning CfdiId";
            return sql;
        }


        public static string CfdiCancela()
        {
            string sql = "";
            sql = "Update Cfdis " +
                " Set Cancelado=true, AcuseCan=@Acuse " +
                " Where CfdiId = @Id";
            return sql;
        }



        public static string CfdiDetalleInsert()
        {
            string sql = "";
            sql = "Insert Into CfdisDetalle " +
                "(CfdiId,ArticuloId,NoIden,Descripcion,Cantidad,ValorUnitario,CveProSer,CveUni,Descuento,TipoIVA,TasaIVA,IVA,RetIVA,RetISR)" +
                " Values " +
                "(@CfdiId,@ArticuloId,@NoIden,@Descripcion,@Cantidad,@ValorUnitario,@CveProSer,@CveUni,@Descuento,@TipoIVA,@TasaIVA,@IVA,@RetIVA,@RetISR)" +
                " Returning CfdiDetId";
            return sql;
        }


        #endregion

        #region Sucursales

        public static string SucursalesSelect()
        {
            string sql = "";
            sql = "Select SucursalId,Nombre From Sucursales Order By SucursalId ";
            return sql;
        }


        public static string SucursalSelect()
        {
            string sql = "";
            sql = "Select Nombre,DatosAdicionales, SerieIngresos,FolioIngresos From  Sucursales Where SucursalId = @SucursalId ";
            return sql;
        }


        public static string SucursalInsert()
        {
            string sql = "";
            sql = "Insert Into " +
                " Sucursales " +
                "(Nombre,DatosAdicionales, SerieIngresos,FolioIngresos) " +
                " Values " +
                "(@Nombre,@DatosAdicionales, @SerieIngresos,@FolioIngresos) " +
                "Returning SucursalId ";
            return sql;
        }


        public static string SucursalUpdate()
        {
            string sql = "";
            sql = "Update Sucursales Set " +
                "Nombre =@Nombre, " +
                "DatosAdicionales=@DatosAdicionales, " +
                "SerieIngresos=@SerieIngresos," +
                "FolioIngresos=@FolioIngresos " +
                "Where  SucursalId = @SucursalId ";
            return sql;
        }


        public static string SucursalDelete()
        {
            string sql = "";
            sql = "Delete From Sucursales " +
                "Where  SucursalId = @SucursalId ";
            return sql;
        }


        public static string SucursalSetSiguienteFolioIngresos()
        {
            string sql = "";
            sql = "update Sucursales Set FolioIngresos = FolioIngresos + 1 Where SucursalId = @SucursalId ";
            return sql;
        }

        #endregion
        #region Ingresos
        public static string IngresoSelect()
        {
            string sql = "";
            sql = " Select SucursalId,Serie,Folio,PacienteId,RazonSocialId,Fecha,Hora,SubTotal,Impuesto,Descuento,RetIVA,RetISR,Total,Cancelado," +
                "Pago1,Pago2,Pago3,Pago4,Pago5,Pago6,Pago7,Pago8,Pago9,Pago10,Webid From  Ingresos Where IngresoId = @IngresoId";
            return sql;
        }


        public static string IngresosSelectxSucursalYFechas()
        {
            string sql = "";
            sql = " Select IngresoId,SucursalId,Serie,Folio,Fecha,Hora,PacienteId,Pacientes.NombreCompleto as PacienteNombre, " +
                "Ingresos.RazonSocialId,RazonesSociales.RazonSoc,SubTotal,Impuesto,Descuento,RetIVA,RetISR,Total,Cancelado," +
                "Pago1,Pago2,Pago3,Pago4,Pago5,Pago6,Pago7,Pago8,Pago9,Pago10,Webid " +
                "From  Ingresos " +
                " Left Join Pacientes On Ingresos.PacienteId = Pacientes.Paciente_Id " +
                " Left Join razonesSociales On Ingresos.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where  " +
                " Ingresos.SucursalId = @SucursalId " +
                " And Ingresos.Fecha Between @FechaInicial and @FechaFinal ";
            return sql;
        }



        public static string IngresoInsert()
        {
            string sql = "";
            sql = "Insert Into Ingresos " +
                "(SucursalId,Serie,Folio,PacienteId,RazonSocialId,Fecha,Hora,SubTotal,Impuesto,Descuento,RetIVA,RetISR,Total,Cancelado," +
                "Pago1,Pago2,Pago3,Pago4,Pago5,Pago6,Pago7,Pago8,Pago9,Pago10,Webid)" +
                " values " +
                "(@SucursalId,@Serie,@Folio,@PacienteId,@RazonSocialId,@Fecha,@Hora,@SubTotal,@Impuesto,@Descuento,@RetIVA,@RetISR,@Total,@Cancelado," +
                "@Pago1,@Pago2,@Pago3,@Pago4,@Pago5,@Pago6,@Pago7,@Pago8,@Pago9,@Pago10,@WebId) " +
                "Returning IngresoId";
            return sql;
        }

        public static string IngresoDetalleInsert()
        {
            string sql = "";
            sql = "Insert Into IngresosDetalle " +
                "(IngresoId,ArticuloId,Clave,Descripcion,UDM,Cantidad,Precio,CveProSer,CveUni,PorceDes,Descuento,BaseIVA,TipoIVA,TasaIVA,IVA,BaseRetISR,PorceRetISR,RetISR,PorceRetIVA,RetIVA,EmisorId,Serie)" +
                " values " +
                "(@IngresoId,@ArticuloId,@Clave,@Descripcion,@UDM,@Cantidad,@Precio,@CveProSer,@CveUni,@PorceDes,@Descuento,@BaseIVA,@TipoIVA,@TasaIVA,@IVA,@BaseRetISR,@PorceRetISR,@RetISR,@PorceRetIVA,@RetIVA,@EmisorId,@Serie) " +
                "Returning IngresoDetalleId";
            return sql;
        }

        public static string IngresoDetallesSelect()
        {
            string sql = "";
            sql = " Select IngresoDetalleId,ArticuloId,Clave,Descripcion,UDM,Cantidad,Precio,CveProSer,CveUni," +
                "PorceDes,Descuento,BaseIVA,TipoIVA,TasaIVA,IVA,BaseRetISR,PorceRetISR,RetISR,PorceRetIVA,RetIVA,EmisorId,Serie From IngresosDetalle" +               
                " Where IngresoId=@IngresoId";
            return sql;
        }



        #endregion
        #region PacientesImagenes
        public static string PacienteImagenesSelect()
        {
            string sql = "";
            sql = "Select PacImId,PacienteId,RutaImagen,Fecha,DiagnosticoId,Descripciones.Descripcion as Diagnostico,PalabrasClave From PacientesImagenes" +
                " inner Join Descripciones On PacientesImagenes.DiagnosticoId = Descripciones.Descripcion_Id " +
                " Where PacienteId = @PacienteId";
            return sql;
        }


        public static string PacienteImagenSelect()
        {
            string sql = "";
            sql = "Select PacImId,PacienteId,RutaImagen,Fecha,DiagnosticoId,Descripciones.Descripcion as Diagnostico,PalabrasClave From PacientesImagenes" +
                " inner Join Descripciones On PacientesImagenes.DiagnosticoId = Descripciones.Descripcion_Id " +
                " Where PacImId = @PacImId";
            return sql;
        }

        public static string PacienteImagenInsert()
        {
            string sql = "";
            sql = "Insert Into PacientesImagenes (PacienteId,RutaImagen,Fecha,DiagnosticoId,PalabrasClave) Values "+
                " (@PacienteId,@RutaImagen,@Fecha,@DiagnosticoId,@PalabrasClave) Returning PacImId";
            return sql;
        }

        public static string PacienteImagenUpdate()
        {
            string sql = "";
            sql = "Update PacientesImagenes set " +
                "RutaImagen=@RutaImagen," +
                "Fecha=@Fecha," +
                "DiagnosticoId=@DiagnosticoId," +
                "PalabrasClave= @PalabrasClave  Where PacImId = @PacImId";
            return sql;
        }


        public static string PacienteImagenDelete()
        {
            string sql = "";
            sql = "Delete From  PacientesImagenes Where PacImId = @PacImId";
            return sql;
        }



        #endregion
        #region RazonesSociales

        public static string RazonesSocialesSelect()
        {
            string sql = "";
            sql = "Select RazonSocialId,RFC,RazonSoc,Direccion,LocalidadId,CiudadId,EstadoId,PaisId,CP,CveRef,CveUso,CveFop,Cvemep,Email From RazonesSociales Order By RazonSoc";
            return sql;
        }

        public static string RazonSocialSelect()
        {
            string sql = "";
            sql = "Select RazonSocialId,RFC,RazonSoc,Direccion,LocalidadId,CiudadId,EstadoId,PaisId,CP,CveRef,CveUso,CveFop,Cvemep,Email From RazonesSociales" +
                " Where RazonSocialId=@RazonSocialId";
            return sql;
        }

        public static string RazonSocialInsert()
        {
            string sql = "";
            sql = "Insert Into RazonesSociales (RFC,RazonSoc,Direccion,LocalidadId,CiudadId,EstadoId,PaisId,CP,CveRef,CveUso,CveFop,Cvemep,Email) " +
                " Values " +
                "(@RFC,@RazonSoc,@Direccion,@LocalidadId,@CiudadId,@EstadoId,@PaisId,@CP,@CveRef,@CveUso,@CveFop,@Cvemep,@Email)" +
                " Returning RazonSocialId";
            return sql;
        }

        public static string RazonSocialUpdate()
        {
            string sql = "";
            sql = "Update  RazonesSociales Set " +
                "RFC=@RFC," +
                "RazonSoc=@RazonSoc," +
                "Direccion=@Direccion," +
                "LocalidadId=@LocalidadId," +
                "CiudadId=@CiudadId," +
                "EstadoId=@EstadoId," +
                "PaisId=@PaisId," +
                "CP=@CP," +
                "CveRef=@CveRef," +
                "CveUso=@CveUso," +
                "CveFop=@CveFop," +
                "CveMep=@CveMep," +
                "Email= @Email" +
                " Where RazonSocialId=@RazonSocialId";
            return sql;
        }



        public static string RazonSocialDelete()
        {
            string sql = "";
            sql = "Delete From RazonesSociales Where RazonSocialId=@RazonSocialId";
            return sql;
        }



        #endregion
        #region SeriesConceptos

        public static string SeriesConceptosSelectXArticulo()
        {
            string sql = "";
            sql = "Select SeriesConceptos.SerieConceptoId,SeriesConceptos.SerieId, SeriesDocs.Serie, SeriesDocs.EmisorId," +
                "SeriesConceptos.ArticuloId,AgregaPaciente," +
                "Articulos.Clave,Articulos.Descripcion,Articulos.Precio1 As Precio,  PorceRetISR,PorceRetIVA " +
                " From SeriesConceptos " +
                " Inner Join SeriesDocs On SeriesConceptos.SerieId = SeriesDocs.SerieDocId " +
                " Inner Join Articulos on SeriesConceptos.ArticuloId = Articulos.ArticuloId" +
                " Where SeriesConceptos.ArticuloId = @ArticuloId" +
                " Order By Clave";

            return sql;
        }

        public static string SeriesConceptosSelectXSerie()
        {
            string sql = "";
            sql = "Select SerieConceptoId,SerieId,SeriesConceptos.ArticuloId,AgregaPaciente," +
                "Articulos.Clave,Articulos.Descripcion,Articulos.Precio1 As Precio, PorceRetISR,PorceRetIVA " +
                " From SeriesConceptos " +
                " Inner Join Articulos on SeriesConceptos.ArticuloId = Articulos.ArticuloId" +
                " Where SerieId = @SerieId" +
                " Order By Clave";

            return sql;
        }


        public static string SerieConceptoSelect()
        {
            string sql = "";
            sql = "Select SerieId,ArticuloId,PorceRetISR,PorceRetIVA,AgregaPaciente from SeriesConceptos Where  SerieConceptoId = @SerieConceptoId ";
            return sql;
        }


        public static string SerieConceptoInsert()
        {
            string sql = "";
            sql = "Insert Into SeriesConceptos (SerieId,ArticuloId,PorceRetISR,PorceRetIVA,AgregaPaciente) " +
                " Values (@SerieId,@ArticuloId,@PorceRetISR,@PorceRetIVA,@AgregaPaciente ) Returning  SerieConceptoId";
            return sql;
        }

        public static string SerieConceptoUpdate()
        {
            string sql = "";
            sql = "Update SeriesConceptos Set " +
                "ArticuloId=@ArticuloId," +
                "PorceRetISR=@PorceRetISR," +
                "PorceRetIVA=@PorceRetIVA, " +
                "AgregaPaciente=@AgregaPaciente " +
                "Where SerieConceptoId = @SerieConceptoId";
            return sql;
        }


        public static string SerieConceptoDelete()
        {
            string sql = "";
            sql = "Delete From SeriesConceptos Where SerieConceptoId = @SerieConceptoId";
            return sql;
        }


        #endregion
        #region Articulos

        public static string ArticulosSelectBuscar()
        {
            string sql = "";
            sql = "Select ArticuloId, Clave,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +

                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId From Articulos " +
                " Where Descripcion Like @Buscar Or Upper(Clave) like @Buscar " +
                "Order By Descripcion";
            return sql;
        }

        public static string ArticuloSelectEnSeriesConceptos()
        {
            string sql = "";
            sql = "Select First 1 ArticuloId From SeriesConceptos Where ArticuloId = @ArticuloId";
            return sql;
        }


        public static string ArticulosSelect()
        {
            string sql = "";
            sql = "Select ArticuloId, Clave,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +

                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId From Articulos Order By Descripcion";
            return sql;
        }
        public static string ArticuloSelect()
        {
            string sql = "";
            sql = "Select Clave,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId From Articulos Where ArticuloId=@ArticuloId";
            return sql;
        }

        public static string ArticuloSelectxClave()
        {
            string sql = "";
            sql = "Select ArticuloId,Clave,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId From Articulos " +
                "Where Clave=@Clave";
            return sql;
        }


        public static string ArticuloInsert()
        {
            string sql = "";
            sql = "Insert Into Articulos (Clave,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId) " +
                "values " +
                "(@Clave,@Descripcion,@Tipo,@UDM,@Moneda,@Costo,@Precio1,@Precio2,@Precio3,@Precio4,@Precio5," +
                "@CveProSer,@CveUni,@ImpuestoId,@MarcaId,@LineaId) Returning ArticuloId";
            return sql;
        }

        public static string ArticuloUpdate()
        {
            string sql = "";
            sql = "Update Articulos Set " +
                "Clave=@Clave," +
                "Descripcion=@Descripcion," +
                "Tipo=@Tipo," +
                "UDM=@UDM," +
                "Moneda=@Moneda," +
                "Costo=@Costo," +
                "Precio1=@Precio1," +
                "Precio2=@Precio2," +
                "Precio3=@Precio3," +
                "Precio4=@Precio4," +
                "Precio5=@Precio5," +
                "CveProSer=@CveProSer," +
                "CveUni=@CveUni," +
                "ImpuestoId=@ImpuestoId," +
                "MarcaId=@MarcaId," +
                "LineaId=@LineaId " +
                " Where ArticuloId=@ArticuloId";
            return sql;
        }

        public static string ArticuloDelete()
        {
            string sql = "";
            sql = "Delete from Articulos Where ArticuloId=@ArticuloId";
            return sql;
        }

        #endregion
        #region SeriesDocumentos


        public static string SerieFolioIncrementa()
        {
            string sql = "";
            sql = "Update SeriesDocs Set Folio = Folio+1" +
                "Where SerieDocId=@SerieDocId";
            return sql;
        }

        public static string SerieDefault()
        {
            string sql = "";
            sql = "Select SerieDocId,Serie,Folio,Defa,Activa From SeriesDocs " +
                "Where Emisorid=@EmisorId and Tipo =@Tipo and Defa=True";
            return sql;
        }


        public static string SerieDocSelectXEmisorTipoSerie()
        {
            string sql = "";
            sql = "Select SerieDocId,Serie,Folio,Defa,Activa From SeriesDocs " +
                "Where Emisorid=@EmisorId and Tipo =@Tipo and Serie=@Serie";
            return sql;
        }

        public static string SeriesDocsSelectXEmisorYTipo()
        {
            string sql = "";
            sql = "Select SerieDocId,Serie,Folio,Defa,Activa From SeriesDocs Where Emisorid=@EmisorId and Tipo =@Tipo Order By Serie";
            return sql;
        }

        public static string SerieDocSelect()
        {
            string sql = "";
            sql = "Select SerieDocId,Emisorid,Tipo,Serie,Folio,Defa,Activa From SeriesDocs Where SerieDocId = @SerieDocId";
            return sql;
        }

        public static string SerieDocInsert()
        {
            string sql = "";
            sql = "Insert Into SeriesDocs (Emisorid,Tipo,Serie,Folio,Defa,Activa) " +
                "values " +
                "(@Emisorid,@Tipo,@Serie,@Folio,@Defa,@Activa) Returning  SerieDocId ";
            return sql;
        }

        public static string SerieDocUpdate()
        {
            string sql = "";
            sql = "Update  SeriesDocs Set " +
                "Emisorid=@Emisorid," +
                "Tipo=@Tipo," +
                "Serie=@Serie," +
                "Folio=@Folio," +
                "Defa=@Defa," +
                "Activa=@Activa" +
                " Where SerieDocId=@SerieDocId ";
            return sql;
        }

        public static string SerieDocUpdateQuitaDefault()
        {
            string sql = "";
            sql = "Update SeriesDocs Set " +
                "Defa=False " +
                " Where SerieDocId <> @SerieDocId ";
            return sql;
        }


        public static string SerieDocDelete()
        {
            string sql = "";
            sql = "Delete From SeriesDocs"+
                " Where SerieDocId=@SerieDocId ";
            return sql;
        }

        #endregion
        #region ClavesSAT
        public static string ClavesSATSelectXTipo()
        {
            string sql = "";
            sql = "Select Clave,Descripcion From ClavesSAT Where Tipo =@Tipo Order By Clave";
            return sql;
        }

        public static string ClaveSATSelectXClave()
        {
            string sql = "";
            sql = "Select Clave,Descripcion From ClavesSAT Where Tipo =@Tipo and Clave=@Clave";
            return sql;
        }

        public static string ClavesSATSelectXDescripcion()
        {
            string sql = "";
            sql = "Select Clave,Descripcion From ClavesSAT Where Tipo =@Tipo and upper(Descripcion) like @Texto Order By Clave";
            return sql;
        }

        #endregion
        #region Emisores
        public static string EmisoresSelect()
        {
            string sql = "";
            sql = "Select EmisorId,RFC,Nombre,Direccion,Colonia,CiudadId,EstadoId,Paisid,CP,CveRef,Certificado,LlavePrivada,PassWord,Defa" +
                " From Emisores Order by Nombre";
            return sql; 
        }

        public static string EmisorSelect()
        {
            string sql = "";
            sql = "Select RFC,Nombre,Direccion,Colonia,CiudadId,EstadoId,Paisid,CP,CveRef,Certificado,LlavePrivada,PassWord,Defa" +
                " From Emisores Where EmisorId = @EmisorId";
            return sql;
        }

        public static string EmisorInsert()
        {
            string sql = "";
            sql = "Insert Into Emisores (RFC,Nombre,Direccion,Colonia,CiudadId,EstadoId,Paisid,CP,CveRef,Certificado,LlavePrivada,PassWord,Defa)" +
                " Values " +
                "(@RFC,@Nombre,@Direccion,@Colonia,@CiudadId,@EstadoId,@Paisid,@CP,@CveRef,@Certificado,@LlavePrivada,@PassWord,@Defa)" +
                " Returning EmisorId";
            return sql;
        }

        public static string EmisorUpdate()
        {
            string sql = "";
            sql = "Update  Emisores set" +
                " RFC=@RFC," +
                "Nombre=@Nombre," +
                "Direccion=@Direccion," +
                "Colonia=@Colonia," +
                "CiudadId=@CiudadId," +
                "EstadoId=@EstadoId," +
                "Paisid=@Paisid," +
                "CP=@CP," +
                "CveRef=@CveRef," +
                "Certificado=@Certificado," +
                "LlavePrivada=@LlavePrivada," +
                "PassWord=@PassWord," +
                "Defa=@Defa" +
                " Where EmisorId = @EmisorId";
            return sql;
        }

        public static string EmisorDelete()
        {
            string sql = "";
            sql = "Delete from Emisores Where EmisorId = @EmisorId";
            return sql;
        }

        #endregion

        #region Impuestos
        public static string ImpuestosSelect()
        {
            string sql = "";
            sql = "Select ImpuestoId,Descripcion,Porcentaje,Defa From Impuestos Order  By Descripcion";
            return sql;
        }

        public static string ImpuestoSelect()
        {
            string sql = "";
            sql = "Select Descripcion,Porcentaje,Defa From Impuestos Where ImpuestoId=@ImpuestoId";
            return sql;
        }

        public static string ImpuestoSelectDefault()
        {
            string sql = "";
            sql = "Select ImpuestoId,Descripcion,Porcentaje,Defa From Impuestos Where Defa=true";
            return sql;
        }

        public static string ImpuestoSelectxDes()
        {
            string sql = "";
            sql = "Select  ImpuestoId,Porcentaje,Defa From Impuestos Where Descripcion=@Descripcion";
            return sql;
        }

        public static string ImpuestoInsert()
        {
            string sql = "";
            sql = "Insert Into Impuestos (Descripcion,Porcentaje,Defa) Values (@Descripcion,@Porcentaje,@Defa) Returning ImpuestoId";
            return sql;
        }

        public static string ImpuestoUpdate()
        {
            string sql = "";
            sql = "Update Impuestos " +
                "Set Descripcion=@Descripcion," +
                "Porcentaje=@Porcentaje," +
                "Defa=@Defa" +
                " Where ImpuestoId=@ImpuestoId";
            return sql;
        }

        public static string ImpuestoDelete()
        {
            string sql = "";
            sql = "Delete From Impuestos Where ImpuestoId = @ImpuestoId";
            return sql;
        }

        #endregion
        #region Recetas
        public static string RecetasMedipielBuscar(string buscar)
        {


            string query = "Select RecetaId,Rece,Left(Completo,8000) as Completo From RecetasMedipiel ";
            string orderBy = " order by Left(TextoCompleto,100)";

            string[] palabras = buscar.Split(' ');
            string filtro = "";


            if (palabras.Length == 1)
            {
                query += $" where TextoCompleto like '%{buscar.ToUpper().Trim()}%'";
            }

            else
            {
                string condicion = " TextoCompleto like ";


                int i = 1;
                foreach (string palabra in palabras)
                {
                    if (i == 1)
                        filtro = " where " + condicion;
                    else
                        filtro += " and " + condicion;

                    filtro += $" '%{palabra.ToUpper().Trim()}%'";
                    i++;


                }

            }
            query += filtro;
            query += orderBy;


            return query;
        }



        public static string RecetasBuscar(string buscar)
        {


            string query = "Select PacienteRecetaId,PacienteId,Fecha,Texto,Etiquetas From PacienteRecetas ";
            string orderBy = " order by Fecha,PacienteRecetaId Desc";

            string[] palabras = buscar.Split(' ');
            string filtro = "";


            if (palabras.Length == 1)
            {
                query += $" where TextoCompleto like '%{buscar.ToUpper().Trim()}%'";
            }

            else
            {
                string condicion = " TextoCompleto like ";


                int i = 1;
                foreach (string palabra in palabras)
                {
                    if (i == 1)
                        filtro = " where " + condicion;
                    else
                        filtro += " and " + condicion;

                    filtro += $" '%{palabra.ToUpper().Trim()}%'";
                    i++;


                }

            }
            query += filtro;
            query += orderBy;


            return query;
        }


        public static string RecetasMedipielSelect()
        {
            string sql = "Select RecetaId,Left(Rece,1000) as Rece,Left(Completo,8000) as Completo From RecetasMedipiel";
            return sql;
        }


        public static string TRSelectByUsr()
        {
            string sql = "Select TextoId,Texto,Boton1,Boton2,Boton3,Boton4,Boton5,Boton6,Boton7 From TextosRapidos " +
                " Where UsuarioId = @UsuarioId"; 
            return sql;

        }

        public static string TRInsert()
        {
            string sql = "Insert into TextosRapidos (UsuarioId,Texto,Boton1,Boton2,Boton3,Boton4,Boton5,Boton6,Boton7)" +
                " Values (@UsuarioId,@Texto,@Boton1,@Boton2,@Boton3,@Boton4,@Boton5,@Boton6,@Boton7) Returning TextoId";
            return sql;

        }

        public static string TRUpdate()
        {
            string sql =
                "Update TextosRapidos " +
                "Set UsuarioId=@UsuarioId,Texto=@Texto,Boton1=@Boton1,Boton2=@Boton2," +
                "Boton3=@Boton3,Boton4=@Boton4,Boton5=@Boton5,Boton6=@Boton6,Boton7=@Boton7" +
                " Where TextoId=@TextoId";
            return sql;

        }

        public static string TRDelete()
        {
            string sql =
                "Delete From TextosRapidos " +
                " Where TextoId=@TextoId";
            return sql;

        }

        public static string RecetasPacienteSelect()
        {
            string sql = "Select PacienteRecetaId,PacienteId,Fecha,Texto,Etiquetas,UsuarioId From PacienteRecetas Where PacienteId = @PacienteId Order By Fecha desc,PacienteRecetaId Desc";
            return sql;
        }
        public static string RecetasPacienteSelectByPacAndFec()
        {
            string sql = "Select PacienteRecetaId,PacienteId,Fecha,Texto,Etiquetas,UsuarioId From PacienteRecetas Where PacienteId = @PacienteId and Fecha=@Fecha";
            return sql;
        }
        public static string RecetasPacienteSelectUltima()
        {
            string sql = "Select First 1 PacienteRecetaId,PacienteId,Fecha,Texto,Etiquetas,UsuarioId From PacienteRecetas Where PacienteId = @PacienteId Order By Fecha desc,PacienteRecetaId Desc";
            return sql;
        }


        public static string RecetaPacienteInsert()
        {
            string sql = "Insert Into PacienteRecetas (PacienteId,Fecha,Texto,Etiquetas,UsuarioId) values (@PacienteId,@Fecha,@Texto,@Etiquetas,@UsuarioId) Returning PacienteRecetaId";
            return sql;
        }

        public static string RecetaPacienteUpdate()
        {
            string sql = "Update PacienteRecetas set" +
                " PacienteId=@PacienteId," +
                "Fecha=@Fecha," +
                "Texto=@Texto," +
                "Etiquetas=@Etiquetas," +
                "UsuarioId=@UsuarioId" +
                "Where PacienteRecetaId=@PacienteRecetaId";
            return sql;
        }

        public static string RecetaPacienteDelete()
        {
            string sql = "Delete From PacienteRecetas Where PacienteRecetaId=@PacienteRecetaId";
            return sql;
        }



        #endregion

        #region Doctores
        public static string DoctoresSelect()
        {
            string sql;
            sql = "Select Doctor_Id,Nombres,Apellido_Paterno,Apellido_Materno,Correos,Telefonos,CedProf,CedEsp,Curriculum,UsuarioId,MostrarEnConsultaAgenda From Doctores ";
            sql += " Order By Apellido_Paterno,Apellido_Materno,Nombres";
            return sql;

        }

        public static string DoctorSelect()
        {
            string sql;
            sql = "Select Doctor_Id,Nombres,Apellido_Paterno,Apellido_Materno,Correos,Telefonos,CedProf,CedEsp,Curriculum,UsuarioId,MostrarEnConsultaAgenda From Doctores ";
            sql += " Where Doctor_id = @Doctor_Id";
            return sql;

        }

        public static string DoctorInsert()
        {
            string sql;
            sql = "Insert into Doctores (Nombres,Apellido_Paterno,Apellido_Materno,Correos,Telefonos,CedProf,CedEsp,Curriculum,UsuarioId,MostrarEnConsultaAgenda) values " +
                "(@Nombres,@Apellido_Paterno,@Apellido_Materno,@Correos,@Telefonos,@CedProf,@CedEsp,@Curriculum,@UsuarioId,@MostrarEnConsultaAgenda) Returning DOCTOR_ID";
            return sql;

        }
        public static string DoctoresUsuariosSelect()
        {
            string sql;
            sql = "Select UsuarioId From Doctores where UsuarioId is not NULL";
            return sql;

        }

        public static string DoctorUpdate()
        {
            string sql;
            sql = "Update Doctores Set Nombres = @Nombres, Apellido_Paterno=@Apellido_Paterno," +
                   "Apellido_Materno=@Apellido_Materno,Correos=@Correos,Telefonos=@Telefonos, " +
                   "CedProf=@CedProf," +
                   "CedEsp=@CedEsp," +
                   "Curriculum=@Curriculum," +
                   "UsuarioId=@UsuarioId, " +
                   "MostrarEnConsultaAgenda=@MostrarEnConsultaAgenda" +
                   " Where Doctor_id = @Doctor_Id";
            return sql;

        }
        #endregion

        #region Equipos
        public static string EquiposSelect()
        {
            string sql;
            sql = "Select Equipo_Id,Nombre,MostrarEnConsultaAgenda From Equipos ";
            sql += " Order By Nombre";
            return sql;

        }

        public static string EquipoSelect()
        {
            string sql;
            sql = "Select Equipo_Id,Nombre,MostrarEnConsultaAgenda From Equipos ";
            sql += " Where Equipo_id = @Equipo_Id";
            return sql;

        }

        public static string EquipoInsert()
        {
            string sql;
            sql = "Insert into Equipos (Nombre,MostrarEnConsultaAgenda) values (@Nombre,@MostrarEnConsultaAgenda) Returning EQUIPO_ID";
            return sql;

        }

        public static string EquipoUpdate()
        {
            string sql;
            sql = "Update Equipos Set Nombre = @Nombre,MostrarEnConsultaAgenda=@MostrarEnConsultaAgenda Where Equipo_id = @Equipo_Id";
            return sql;

        }
        #endregion

        #region Cuartos
        public static string CuartosSelect()
        {
            string sql;
            sql = "Select Cuarto_Id,Nombre,MostrarEnConsultaAgenda From Cuartos ";
            sql += " Order By Nombre";
            return sql;

        }

        public static string CuartoSelect()
        {
            string sql;
            sql = "Select Cuarto_Id,Nombre,MostrarEnConsultaAgenda  From Cuartos ";
            sql += " Where Cuarto_Id = @Cuarto_Id";
            return sql;

        }

        public static string CuartoInsert()
        {
            string sql;
            sql = "Insert into Cuartos (Nombre,MostrarEnConsultaAgenda) values (@Nombre,@MostrarEnConsultaAgenda ) Returning CUARTO_ID";
            return sql;

        }

        public static string CuartoUpdate()
        {
            string sql;
            sql = "Update Cuartos Set Nombre = @Nombre, MostrarEnConsultaAgenda=@MostrarEnConsultaAgenda   Where Cuarto_Id = @Cuarto_Id";
            return sql;

        }
        #endregion

        #region Pacientes
        public static string ActDatosSelect()
        {
            string sql = "";
            sql = "Select Prefijo,Saludo,Categoria,Titulo,EstadoCivil,Sexo," +
        "CiudadOrigen,Alergias1,Medico,TipoPiel,Alergias2,Medicamentos,Maquillaje,TxPrevio,Edad," +
        "Enfer1,Enfer2,Enfer3,Enfer4,Enfer5,Enfer6,Enfer7,Enfer8,Enfer9,Email,Email2,RFC,CURP,Telefono," +
        "Dir1,Dir2,Dir3,Ciudad,Estado,Cp,Pais From ActDatos Where PacienteId = @PacienteId ";

            return sql;

        }

        public static string PacientesNotas()
        {
            string sql = "";
            sql = "Select NotaId,Fecha,Texto From Notas Where PacienteId=@PacienteId Order By Fecha Desc,NotaId Desc";
            return sql;
        }

        public static string PacientesSelectBuscar(string buscar)
        {


            string query = "Select Paciente_Id,Nombres,Apellido_Paterno,Apellido_Materno,Telefonos,Correos,Origen,PassWord From Pacientes ";
            string orderBy = " order by upper(pacientes.APELLIDO_PATERNO)|| upper(pacientes.APELLIDO_MATERNO) || upper(pacientes.NOMBRES)";

            string[] palabras = buscar.Split(' ');
            string filtro = "";


            if (palabras.Length == 1)
            {
                query += $" where upper(NombreCompleto) like '%{buscar.ToUpper().Trim()}%'";
            }

            else
            {
                string condicion = " upper(NombreCompleto) like ";


                int i = 1;
                foreach (string palabra in palabras)
                {
                    if (i == 1)
                        filtro = " where " + condicion;
                    else
                        filtro += " and " + condicion;

                    filtro += $" '%{palabra.ToUpper().Trim()}%'";
                    i++;


                }

            }
            query += filtro;
            query += orderBy;


            return query;
        }


        public static string PacienteVisitas()
        {
            string sql = "";
            sql = "select count(citas.CITA_ID) as visitas from citas where citas.cita_id = citas.CITA_ORIGEN_ID and  PACIENTE_ID=@PacienteId ";
            return sql;
        }


        public static string PacientesSelect(bool agregarOrden = true)
        {
            string sql;
            sql = "Select Paciente_Id,Nombres,Apellido_Paterno,Apellido_Materno,Sexo,Fecha_Nacimiento,Telefonos,Correos," +
                "EdoCivilId,OcupacionId,ReferenteId,Origen,PassWord From Pacientes ";


            if (agregarOrden)
                sql += " Order By Apellido_Paterno,Apellido_Materno,Nombres";
            return sql;

        }

        public static string PacientesSelectxOrigen(bool agregarOrden = true)
        {
            string sql;
            sql = "Select Paciente_Id,Nombres,Apellido_Paterno,Apellido_Materno,Sexo,Fecha_Nacimiento,Telefonos,Correos," +
                "EdoCivilId,OcupacionId,ReferenteId,PassWord From Pacientes Where Origen=@Origen";

            if (agregarOrden)
                sql += " Order By Apellido_Paterno,Apellido_Materno,Nombres";
            return sql;

        }

        public static string PacienteSelect()
        {
            string sql;
            sql = "Select Paciente_Id,Nombres,Apellido_Paterno,Apellido_Materno,Sexo,Fecha_Nacimiento,Telefonos,Correos," +
                "EdoCivilId,OcupacionId,ReferenteId," +
                "CiudadOrigenId,Direccion,Colonia,LocalidadId,CiudadId,EstadoId,PaisId,CP," +
                "DiagnosticoId,PielId,SolarId,MedicoId,MaquillajeId,Medicamentos,Alergias,Antecedentes,Origen,PassWord From Pacientes ";
            sql += " Where Paciente_Id = @Paciente_Id";
            return sql;

        }
        public static string PacienteConsultaSelect()
        {
            string sql;
            sql = "Select Paciente_Id,Nombres,Apellido_Paterno,Apellido_Materno,Sexo,Fecha_Nacimiento,Telefonos,Correos," +
                "EdoCivilId,OcupacionId,ReferenteId," +
                "CiudadOrigenId,Direccion,Colonia,LocalidadId,CiudadId,EstadoId,PaisId,CP," +
                "DiagnosticoId,PielId,SolarId,MedicoId,MaquillajeId,Medicamentos,Alergias,Antecedentes,Origen,PassWord From Pacientes ";
            sql += " Where Paciente_Id = @Paciente_Id";
            return sql;

        }

        public static string PacienteInsert()
        {
            string sql;
            sql = "Insert into Pacientes (Nombres,Apellido_Paterno,Apellido_Materno,Sexo,Fecha_Nacimiento,Telefonos,Correos,EdoCivilId,OcupacionId,ReferenteId," +
                "CiudadOrigenId,Direccion,Colonia,LocalidadId,CiudadId,EstadoId,PaisId,CP," +
                "DiagnosticoId,PielId,SolarId,MedicoId,MaquillajeId,Medicamentos,Alergias,Antecedentes,Origen,PassWord,FechaHoraCreacion,UsuarioCreacionId) values " +
                "(@Nombres,@Apellido_Paterno,@Apellido_Materno,@Sexo,@Fecha_Nacimiento,@Telefonos,@Correos,@EdoCivilId,@OcupacionId,@ReferenteId," +
                "@CiudadOrigenId,@Direccion,@Colonia,@LocalidadId,@CiudadId,@EstadoId,@PaisId,@CP," +
                "@DiagnosticoId,@PielId,@SolarId,@MedicoId,@MaquillajeId,@Medicamentos,@Alergias,@Antecedentes,@Origen,@PassWord,@FechaHoraCreacion,@UsuarioCreacionId) Returning Paciente_Id";
            return sql;

        }

        public static string PacienteAgendaInsert()
        {
            string sql;
            sql = "Insert into Pacientes (Nombres,Apellido_Paterno,Apellido_Materno,Sexo,Telefonos,PassWord,FechaHoraCreacion,UsuarioCreacionId)" +
                "values " +
                "(@Nombres,@Apellido_Paterno,@Apellido_Materno,@Sexo,@Telefonos,@PassWord,@FechaHoraCreacion,@UsuarioCreacionId) Returning Paciente_Id";
            return sql;

        }


        public static string PacienteUpdate()
        {
            string sql;
            sql = "Update Pacientes " +
                "Set Nombres = @Nombres, " +
                "Apellido_Paterno=@Apellido_Paterno," +
                   "Apellido_Materno=@Apellido_Materno," +
                   "Sexo=@Sexo," +
                   "Fecha_Nacimiento=@Fecha_Nacimiento," +
                   "Telefonos=@Telefonos, " +
                   "Correos=@Correos," +
                   "EdoCivilId=@EdoCivilId," +
                   "OcupacionId=@OcupacionId," +
                   "ReferenteId=@ReferenteId," +
                   "CiudadOrigenId=@CiudadOrigenId," +
                   "Direccion=@Direccion," +
                   "Colonia=@Colonia," +
                   "LocalidadId=@LocalidadId," +
                   "CiudadId=@CiudadId," +
                   "EstadoId=@EstadoId," +
                   "PaisId=@PaisId," +
                   "CP=@CP," +
                   "DiagnosticoId=@DiagnosticoId," +
                   "PielId=@PielId," +
                   "SolarId=@SolarId," +
                   "MedicoId=@MedicoId," +
                   "MaquillajeId=@MaquillajeId," +
                   "Medicamentos=@Medicamentos," +
                   "Alergias=@Alergias," +
                   "Antecedentes=@Antecedentes," +
                   "Origen=@Origen, " +
                   "PassWord=@PassWord, " +
                   "FechaHoraEdicion=@FechaHoraEdicion," +
                   "UsuarioEdicionId = @UsuarioEdicionId" +

                   " Where Paciente_id = @Paciente_Id";
            return sql;

        }

        public static string PacienteAgendaUpdate()
        {
            string sql;
            sql = "Update Pacientes " +
                "Set Nombres = @Nombres, " +
                "Apellido_Paterno=@Apellido_Paterno," +
                   "Apellido_Materno=@Apellido_Materno," +
                   "Sexo=@Sexo," +
                   "Telefonos=@Telefonos, " +
                   "FechaHoraEdicion=@FechaHoraEdicion," +
                   "passWord=@PassWord," +
                   "UsuarioEdicionId = @UsuarioEdicionId" +
                   " Where Paciente_id = @Paciente_Id";
            return sql;

        }

        public static string PacienteReporteExpedienteSelect()
        {
            string sql="";
            sql =
                "Select Paciente_Id,NombreCompleto,Fecha_Nacimiento,EdosCiviles.Descripcion as EdoCivil," +
                "Ocupaciones.Descripcion as Ocupacion,Referentes.Descripcion as Referente," +
                "CiudadesOr.Descripcion as CiudadOri,Direccion,Colonia,Localidades.Descripcion as Localidad," +
                "Ciudades.Descripcion as Ciudad,Estados.Descripcion as Estado,Paises.Descripcion as Pais,Cp," +
                "Diagnosticos.Descripcion as Diagnostico,Pieles.Descripcion as Piel,Exposiciones.Descripcion as ExpSolar," +
                "Medicos.Descripcion as Medico,Maquillajes.Descripcion as Maquillaje,Medicamentos," +
                "Alergias,Antecedentes,Origen,Telefonos,Correos " +
                "From Pacientes " +
                "Left Join Descripciones EdosCiviles on Pacientes.EdoCivilId = EdosCiviles.Descripcion_Id " +
                "Left Join Descripciones Ocupaciones on Pacientes.OcupacionId = Ocupaciones.Descripcion_Id " +
                "Left Join Descripciones Referentes on Pacientes.ReferenteId = Referentes.Descripcion_Id " +
                "Left Join Descripciones CiudadesOr on Pacientes.CiudadOrigenId = CiudadesOr.Descripcion_Id " +
                "Left Join Descripciones Localidades on Pacientes.LocalidadId = Localidades.Descripcion_Id "  +
                "Left Join Descripciones Ciudades on Pacientes.CiudadId = Ciudades.Descripcion_Id " +
                "Left Join Descripciones Estados on Pacientes.EstadoId = Estados.Descripcion_Id " +
                "Left Join Descripciones Paises on Pacientes.PaisId = Paises.Descripcion_Id " +
                "Left Join Descripciones Diagnosticos on Pacientes.DiagnosticoId = Diagnosticos.Descripcion_Id " +
                "Left Join Descripciones Pieles on Pacientes.PielId = Pieles.Descripcion_Id " +
                "Left Join Descripciones Exposiciones on Pacientes.SolarId = Exposiciones.Descripcion_Id " +
                "Left Join Descripciones Medicos on Pacientes.MedicoId = Medicos.Descripcion_Id " +
                "Left Join Descripciones Maquillajes on Pacientes.MaquillajeId = Maquillajes.Descripcion_Id " +
                "Where Paciente_Id = @PacienteId";

            return sql;
        }

            #endregion

            #region Notas
            public static string NotaSelect()
        {
            string sql;
            sql = "Select  PacienteId,Fecha,Texto,FechaHoraCreacion,UsuarioCreacionId From Notas Where NotaId = @NotaId ";
            return sql;

        }


        public static string NotaInsert()
        {
            string sql;
            sql = "Insert Into Notas (PacienteId,Fecha,Texto,FechaHoraCreacion,UsuarioCreacionId) values (@PacienteId,@Fecha,@Texto,@FechaHoraCreacion,@UsuarioCreacionId) Returning NotaId ";
            return sql;

        }

        public static string NotaUpdate()
        {
            string sql;
            sql = "Update Notas Set Texto = @Texto, " +
                   "FechaHoraEdicion=@FechaHoraEdicion," +
                   "UsuarioEdicionId = @UsuarioEdicionId " +
                " Where NotaId=@NotaId ";
            return sql;

        }
        public static string NotaDelete()
        {
            string sql;
            sql = "Delete From Notas Where NotaId=@NotaId ";
            return sql;

        }

        #endregion


        #region Procedimientos
        public static string ProcedimientosSelect()
        {
            string sql;
            sql = "Select Procedimiento_Id,Descripcion,Precio From Procedimientos ";
            sql += " Order By Descripcion";
            return sql;

        }

        public static string ProcedimientoSelect()
        {
            string sql;
            sql = "Select Procedimiento_Id,Descripcion,Precio From Procedimientos ";
            sql += " Where Procedimiento_Id = @Procedimiento_Id";
            return sql;

        }

        public static string ProcedimientoInsert()
        {
            string sql;
            sql = "Insert into Procedimientos (Descripcion,Precio) values (@Descripcion,@Precio) Returning PROCEDIMIENTO_ID";
            return sql;

        }

        public static string ProcedimientoUpdate()
        {
            string sql;
            sql = "Update Procedimientos Set Descripcion = @Descripcion, Precio = @Precio Where Procedimiento_Id = @Procedimiento_Id";
            return sql;

        }
        #endregion

        #region Descripciones
        public static string DescripcionesSelect()
        {
            string sql;
            sql = "Select Descripcion_Id,Tipo, Descripcion From Descripciones Where Tipo=@Tipo ";
            sql += " Order By Descripcion";
            return sql;

        }

        public static string DescripcionSelect()
        {
            string sql;
            sql = "Select Descripcion_Id,Tipo, Descripcion From Descripciones ";
            sql += " Where Descripcion_Id = @Descripcion_Id";
            return sql;

        }

        public static string DescripcionesSelectxTipo()
        {
            string sql;
            sql = "Select Descripcion_Id,Tipo, Descripcion From Descripciones ";
            sql += " Where Tipo=@Tipo Order By Descripcion";
            return sql;

        }


        public static string DescripcionSelectxTipo()
        {
            string sql;
            sql = "Select Descripcion_Id,Tipo, Descripcion From Descripciones ";
            sql += " Where Tipo=@Tipo And Descripcion_Id = @Descripcion_Id";
            return sql;

        }
        public static string DescripcionSelectxDescripcion()
        {
            string sql;
            sql = "Select Descripcion_Id,Tipo, Descripcion From Descripciones ";
            sql += " Where Tipo=@Tipo And Descripcion = @Descripcion";
            return sql;

        }

        public static string DescripcionInsert()
        {
            string sql;
            sql = "Insert into Descripciones (Tipo, Descripcion) values (@Tipo, @Descripcion) Returning DESCRIPCION_ID";
            return sql;

        }

        public static string DescripcionUpdate()
        {
            string sql;
            sql = "Update Descripciones Set Descripcion = @Descripcion Where Descripcion_Id = @Descripcion_Id";
            return sql;

        }
        #endregion

        #region Parametros
        public static string ParametroSelect()
        {
            string sql ="";

            sql = "Select Parametro_Id,SysPassword,ColorCitaLetra,ColorCitaFondo,ColorMultipleLetra,ColorMultipleFondo,"+
                "ColorBloqueoLetra,ColorBloqueoFondo,ColorConfirmadoLetra,ColorConfirmadoFondo,ColorAsistioLetra,ColorAsistioFondo "+
                "From Parametros";

            return sql;

        }

        public static string ParametroUpdate()
        {
            string sql = "";

            sql = "Update Parametros Set "+
                "SysPassword = @SysPassword," +
                "ColorCitaLetra= @ColorCitaLetra,"+
                "ColorCitaFondo=@ColorCitaFondo,"+
                "ColorMultipleLetra = @ColorMultipleLetra,"+
                "ColorMultipleFondo = @ColorMultipleFondo," +
                "ColorBloqueoLetra = @ColorBloqueoLetra,"+
                "ColorBloqueoFondo = @ColorBloqueoFondo,"+
                "ColorConfirmadoLetra=@ColorConfirmadoLetra,"+
                "ColorConfirmadoFondo = @ColorConfirmadoFondo,"+
                "ColorAsistioLetra = @ColorAsistioLetra,"+
                "ColorAsistioFondo = @ColorAsistioFondo " +
                "Where Parametro_Id = @Parametro_Id";

            return sql;

        }

        public static string ParametroInsert()
        {
            string sql = "";

            sql = "Insert Into Parametros " +
                "(SysPassword,ColorCitaLetra,ColorCitaFondo,ColorMultipleLetra,ColorMultipleFondo," +
                "ColorBloqueoLetra,ColorBloqueoFondo,ColorConfirmadoLetra,ColorConfirmadoFondo," +
                "ColorAsistioLetra,ColorAsistioFondo)" +                
                "Values " +
                "(@SysPassword,@ColorCitaLetra,@ColorCitaFondo,@ColorMultipleLetra,@ColorMultipleFondo," +
                "@ColorBloqueoLetra,@ColorBloqueoFondo,@ColorConfirmadoLetra,@ColorConfirmadoFondo," +
                "@ColorAsistioLetra,@ColorAsistioFondo) " +
                "Returning Parametro_Id";



            return sql;

        }


        #endregion

        #region AgendaWEB
        #region CitasWEB
        public static string CitaWEBInsert() {
            string sql = "";
            sql = "insert Into CitasWEB (CitaInicialId,Fecha,Hora,TipoRecurso,RecursoId,RecursoNombre,PacienteId,PacienteNombre," +
                "PacienteSexo,PacienteFechaNac,Observaciones,Cancelada,CancelacionMotivoId,CancelacionMotivo,Bloqueada," +
                "BloqueoMotivoId,BloqueoMotivo,Confirmado,Asistio,OriginalId,Estatus) " +
                " Values" +
                "(@CitaInicialId,@Fecha,@Hora,@TipoRecurso,@RecursoId,@RecursoNombre,@PacienteId,@PacienteNombre," +
                "@PacienteSexo,@PacienteFechaNac,@Observaciones,@Cancelada,@CancelacionMotivoId,@CancelacionMotivo,@Bloqueada," +
                "@BloqueoMotivoId,@BloqueoMotivo,@Confirmado,@Asistio,@OriginalId,@Estatus) Returning CitaId";
            return sql;
        }

        #endregion
        #region DoctoresWEB
        public static string DoctorWEBInsert()
        {
            string sql = "";
            sql = "Insert Into Doctores (Nombres,ApellidoPaterno,ApellidoMaterno,Telefonos,Correos,OriginalId) Values " +
                "(@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Telefonos,@Correos,@OriginalId) Returning DoctorId";
            return sql;
        }

        public static string DoctoresWEBInicializa()
        {
            string sql = "";
            sql = "Delete From Doctores Where DoctorId >0";
            return sql;
        }
        #endregion
        #endregion

        #region Citas

        public static string CitaSelect() {
            string sql = "";
            sql = "Select Cita_Id,Cita_Origen_Id,SucursalId, TipoRecurso,Recurso_Id, Fecha,Hora, " +
                "Paciente_Id, Observaciones, UsuarioAlta, FechaHoraAlta, UsuarioModificacion,  FechaHoraModificacion," +
        "Cancelada,CancelacionMotivo_Id,UsuarioCancelacion,FechaHoraCancelacion,Bloqueada,BloqueoMotivo_Id,ColorCitaLetra," +
        "ColorCitaFondo, Confirmado,Asistio from Citas Where Cita_Id = @Cita_Id";

            return sql;
        }

        public static string CitasSelectDesdeFecha()
        {
            string sql = "";
            sql = "Select Cita_Id,Cita_Origen_Id,SucursalId, TipoRecurso,Recurso_Id, Fecha,Hora, " +
                "Paciente_Id, Observaciones, UsuarioAlta, FechaHoraAlta, UsuarioModificacion,  FechaHoraModificacion," +
        "Cancelada,CancelacionMotivo_Id,UsuarioCancelacion,FechaHoraCancelacion,Bloqueada,BloqueoMotivo_Id,ColorCitaLetra," +
        "ColorCitaFondo, Confirmado,Asistio from Citas Where Fecha >= @Fecha";

            return sql;
        }


        public static string CitasSelectOrigen()
        {
            string sql = "";
            sql = "Select Cita_Id,Cita_Origen_Id,SucursalId, TipoRecurso,Recurso_Id, Fecha,Hora, " +
                "Paciente_Id, Observaciones, UsuarioAlta, FechaHoraAlta, UsuarioModificacion,  FechaHoraModificacion," +
        "Cancelada,CancelacionMotivo_Id,UsuarioCancelacion,FechaHoraCancelacion,Bloqueada,BloqueoMotivo_Id,ColorCitaLetra," +
        "ColorCitaFondo, Confirmado,Asistio from Citas Where Cita_Origen_Id = @Cita_Origen_Id";

            return sql;
        }

        public static string CitaSelectRecursoFecha()
        {
            string sql = "";
            sql = "Select Cita_Id,Cita_Origen_Id,SucursalId, TipoRecurso,Recurso_Id, Fecha,Hora, " +
                "Paciente_Id, Observaciones, UsuarioAlta, FechaHoraAlta, UsuarioModificacion,  FechaHoraModificacion," +
        "Cancelada,CancelacionMotivo_Id,UsuarioCancelacion,FechaHoraCancelacion,Bloqueada,BloqueoMotivo_Id,ColorCitaLetra," +
        "ColorCitaFondo, Confirmado,Asistio from Citas";

            sql += " Where SucursalId=@SucursalId And  TipoRecurso = @TipoRecurso And Recurso_id = @Recurso_Id And Fecha = @Fecha and Hora = @Hora" +
                " Order By Fecha,Hora";
            return sql;
        }

        public static string CitaInsert()
        {
            string sql = "";
            sql = "Insert Into Citas (Cita_Origen_Id,SucursalId,TipoRecurso,Recurso_Id, Fecha,Hora, " +
                "Paciente_Id, Observaciones, UsuarioAlta, FechaHoraAlta, UsuarioModificacion,  FechaHoraModificacion," +
        "Cancelada,CancelacionMotivo_Id,UsuarioCancelacion,FechaHoraCancelacion,Bloqueada,BloqueoMotivo_Id,ColorCitaLetra," +
        "ColorCitaFondo, Confirmado,Asistio)" +
        " Values "+
        "(@Cita_Origen_Id,@SucursalId,@TipoRecurso,@Recurso_Id, @Fecha,@Hora, " +
                "@Paciente_Id, @Observaciones, @UsuarioAlta, @FechaHoraAlta, @UsuarioModificacion,  @FechaHoraModificacion," +
        "@Cancelada,@CancelacionMotivo_Id,@UsuarioCancelacion,@FechaHoraCancelacion,@Bloqueada,@BloqueoMotivo_Id,@ColorCitaLetra," +
        "@ColorCitaFondo, @Confirmado,@Asistio) Returning Cita_Id" 
        ;

            return sql;
        }


        public static string CitaUpdate()
        {
            string sql = "";
            sql = "Update Citas Set " +
                "Cita_Origen_Id=@Cita_Origen_Id, " +
                "TipoRecurso=@TipoRecurso," +
                "Recurso_Id=@Recurso_Id, " +
                "Fecha=@Fecha," +
                "Hora=@Hora, " +
                "Paciente_Id=@Paciente_Id, " +
                "Observaciones=@Observaciones, " +
                "UsuarioAlta=@UsuarioAlta, " +
                "FechaHoraAlta=@FechaHoraAlta, " +
                "UsuarioModificacion=@UsuarioModificacion,  " +
                "FechaHoraModificacion=@FechaHoraModificacion," +
                "Cancelada=@Cancelada," +
                "CancelacionMotivo_Id=@CancelacionMotivo_Id," +
                "UsuarioCancelacion=@UsuarioCancelacion," +
                "FechaHoraCancelacion=@FechaHoraCancelacion," +
                "Bloqueada=@Bloqueada," +
                "BloqueoMotivo_Id=@BloqueoMotivo_Id," +
                "ColorCitaLetra=@ColorCitaLetra," +
                "ColorCitaFondo=@ColorCitaFondo, " +
                "Confirmado=@Confirmado," +
                "Asistio=@Asistio" +
                " Where Cita_id = @Cita_id";

        ;

            return sql;
        }

        public static string CitaUpdateOrigenId()
        {
            string sql="";
            sql = "Update Citas Set Cita_Origen_ID = @Cita_Origen_Id Where Cita_Id = @Cita_id";
            return sql;
        }


        public static string CitaFechaSelect()
        {
            string _sql = "Select Citas.Cita_id, Citas.TipoRecurso, Citas.Recurso_Id, Citas.Hora, Pacientes.Nombres, Pacientes.Apellido_Paterno, Pacientes.Apellido_Materno," +
                    "Descripciones.Descripcion As BloqueoMotivo,Citas.Bloqueada,Citas.BloqueoMotivo_Id,Citas.Confirmado,Citas.Asistio" +
                    " From Citas " +
                    " Left Join Pacientes on Citas.Paciente_Id = Pacientes.Paciente_Id " +
                    " Left Join Descripciones on Citas.BloqueoMotivo_Id = Descripciones.Descripcion_Id " +
                    " Where Citas.SucursalId = @SucursalId and Citas.Fecha = @Fecha and Citas.Cancelada <> true";
            return _sql;

        }

        public static string CitaDelete() {
            string sql = "";
            sql = " Delete From Citas Where Cita_Id = @Cita_Id";
            return sql;
        }

        public static string CitaBloqueada()
        {
            string sql = "";
            sql = "Select Cita_id From Citas Where SucursalId = @SucursalId And  TipoRecurso = @TipoRecurso and Recurso_Id = @Recurso_Id and Fecha = @Fecha and Hora = @Hora and Bloqueada = true";
            return sql;
        }

        #endregion

        #region CitasProIns
        public static string CitaProInsSelect()
        {
            string sql = "";
            sql = "Select CitaProIns_Id, Cita_Id,Tipo,ProcIns_Id,Importe From CitasProIns Where CitaProIns_Id=@CitaProIns_Id";
            return sql;
        }

        public static string CitaProInsSelectxCita()
        {
            string sql = "";
            sql = "Select CitaProIns_Id, Cita_Id,Tipo,ProcIns_Id,Importe From CitasProIns Where Cita_Id=@Cita_Id";
            return sql;
        }
        public static string CitaProInsInsert()
        {
            string sql = "";
            sql = "Insert into CitasProIns " +
                "(Cita_Id,Tipo,ProcIns_Id,Importe)" +
                " Values " +
                "(@Cita_Id,@Tipo,@ProcIns_Id,@Importe) Returning CitaProIns_Id";
            return sql;
        }

        public static string CitaProInsUpdate()
        {
            string sql = "";
            sql = "update CitasProIns set " +
                "Cita_Id=@Cita_Id," +
                "Tipo=@Tipo," +
                "ProcIns_Id=@ProcIns_Id," +
                "Importe =@Importe" +
                " Where CitaProIns_Id = @CitaProIns_Id";
                
            return sql;
        }

        public static string CitaProInsDelete()
        {
            string sql = "";
            sql = "Delete From CitasProIns " +
                " Where CitaProIns_Id = @CitaProIns_Id";

            return sql;
        }

        public static string CitaProInsDeletexCita()
        {
            string sql = "";
            sql = "Delete From CitasProIns " +
                " Where Cita_Id = @Cita_Id";

            return sql;
        }


        #endregion
        #region RecursosColumnas
        public static string RecursosColumnasSelect()
        {
            string sql = "Select ColRecurso_Id,Usuario_Id,Numero,Tipo,Recurso_Id From ColsRecursos Where Usuario_Id = @Usuario_Id Order By Numero";
            return sql;
        }

        public static string RecursosColumnaSelect()
        {
            string sql = "Select ColRecurso_Id,Usuario_Id,Numero,Tipo,Recurso_Id From ColsRecursos Where Numero = @Numero and Usuario_Id = @Usuario_Id Order By Numero";
            return sql;
        }


        public static string RecursosColumnaInsert()
        {
            string sql = "Insert Into ColsRecursos (Usuario_Id,Numero,Tipo,Recurso_Id) Values " +
                "(@Usuario_Id,@Numero,@Tipo,@Recurso_Id) Returning Recurso_Id";
            return sql;
        }


        public static string RecursosColumnaUpdate()
        {
            string sql = "Update ColsRecursos Set " +
                "Usuario_Id=@Usuario_Id," +
                "Tipo=@Tipo," +
                "Recurso_Id=@Recurso_Id " +
                " Where ColRecurso_Id=@ColRecurso_Id";
            return sql;
        }


        #endregion

        #region DatosEmpresa
        public static string DatosEmpresaSelect()
        {
            string sql = "";
            sql = "Select Empresa_Id,Nombre,Direccion,Colonia,Localidad,Cp,Ciudad,Estado,Pais,Telefonos,Correos,Logotipo,"+
                "AvisosServidor,AvisosUsuario,AvisosPassword,AvisosCuenta,AvisosSSL,AvisosPuerto,CarpetaReportes From DatosEmpresa";
            return sql;
        }

        public static string DatosEmpresaInsert()
        {
            string sql = "";
            sql = "Insert Into DatosEmpresa(Nombre,Direccion,Colonia,Localidad,Cp,Ciudad,Estado,Pais,Telefonos,Correos,Logotipo," +
                "AvisosServidor,AvisosUsuario,AvisosPassword,AvisosCuenta,AvisosSSL,AvisosPuerto,CarpetaReportes) Values " +
                "(@Nombre,@Direccion,@Colonia,@Localidad,@Cp,@Ciudad,@Estado,@Pais,@Telefonos,@Correos,@Logotipo," +
                "@AvisosServidor,@AvisosUsuario,@AvisosPassword,@AvisosCuenta,@AvisosSSL,@AvisosPuerto,@CarpetaReportes) Returning Empresa_Id";
            return sql;
        }

        public static string DatosEmpresaUpdate()
        {
            string sql = "";
            sql = "Update DatosEmpresa Set " +
                "Nombre=@Nombre," +
                "Direccion=@Direccion," +
                "Colonia=@Colonia," +
                "Localidad=@Localidad," +
                "Cp=@Cp," +
                "Ciudad=@Ciudad," +
                "Estado=@Estado," +
                "Pais=@Pais," +
                "Telefonos=@Telefonos," +
                "Correos=@Correos," +
                "Logotipo=@Logotipo," +
                "AvisosServidor=@AvisosServidor," +
                "AvisosUsuario=@AvisosUsuario," +
                "AvisosPassword=@AvisosPassword," +
                "AvisosCuenta=@AvisosCuenta," +
                "AvisosSSL=@AvisosSSL," +
                "AvisosPuerto=@AvisosPuerto," +
                "CarpetaReportes =@CarpetaReportes " +
                " Where Empresa_Id = @Empresa_Id";
            return sql;
        }


        #endregion

        #region Empresas

        public static string EmpresasSelect()
        {
            string sql = "";
            sql = "Select Empresa_Id,Nombre,Nombre_Corto,Direccion,Colonia,Localidad,Ciudad,Estado,Cp,Logotipo," +
                "WebServiceURL,CarpetaWEB,BddWEB,CopiarWEB,CarpetaReportes,CarpetaImagenes From Empresas Order By Nombre";
            return sql;
        }

        public static string EmpresaSelect()
        {
            string sql = "";
            sql = "Select Empresa_Id,Nombre,Nombre_Corto,Direccion,Colonia,Localidad,Ciudad,Estado,Cp,Logotipo," +
                "WebServiceURL,CarpetaWEB,BddWEB,CopiarWEB,CarpetaReportes,CarpetaImagenes From Empresas Where Empresa_Id=@Empresa_Id";
            return sql;
        }

        public static string EmpresaInsert()
        {
            string sql = "";
            sql = "Insert Into Empresas (Nombre,Nombre_Corto,Direccion,Colonia,Localidad,Ciudad,Estado,Cp,Logotipo,WebServiceURL,CarpetaWEB,BddWEB,CopiarWEB,CarpetaReportes,CarpetaImagenes)" +
                "values" +
                "(@Nombre,@Nombre_Corto,@Direccion,@Colonia,@Localidad,@Ciudad,@Estado,@Cp,@Logotipo,@WebServiceURL,@CarpetaWEB,@BddWEB,@CopiarWEB,@CarpetaReportes,@CarpetaImagenes) returning Empresa_Id";
            return sql;
        }

        public static string EmpresaUpdate()
        {
            string sql = "";
            sql = "Update Empresas set Nombre=@Nombre,Nombre_Corto=@Nombre_Corto,Direccion=@Direccion," +
                "Colonia=@Colonia,Localidad=@Localidad,Ciudad=@Ciudad,Estado=@Estado,Cp=@Cp,Logotipo=@Logotipo, " +
                "WebServiceURL=@WebServiceURL,CarpetaWEB=@CarpetaWEB," +
                "BddWEB=@BddWEB,CopiarWEB=@CopiarWEB," +
                "CarpetaReportes = @CarpetaReportes," +
                "CarpetaImagenes = @CarpetaImagenes" +
                " Where Empresa_Id =@Empresa_Id";
            return sql;

        }

        #endregion

        #region Usuarios
        public static string UsuariosSelect()
        {
            string sql = "";
            sql = "Select Usuario_Id,Usr,Nombre,PassWord,ConsultaAgenda,SucursalId From Usuarios Order By Nombre";
            return sql;
        }
        public static string UsuarioSelect()
        {
            string sql = "";
            sql = "Select Usuario_Id,Usr,Nombre,PassWord,ConsultaAgenda,SucursalId   From Usuarios Where Usuario_Id = @Usuario_Id";
            return sql;
        }
        public static string UsuarioSelectxNombreyPassWord()
        {
            string sql = "";
            sql = "Select Usuario_Id,Usr,Nombre,PassWord,ConsultaAgenda,SucursalId   From Usuarios Where Usr = @Usuario and PassWord = @PassWord";
            return sql;
        }

        public static string UsuarioInsert()
        {
            string sql = "";
            sql = "Insert Into Usuarios(Usr,Nombre,PassWord,ConsultaAgenda,SucursalId ) Values (@Usr,@Nombre,@PassWord,@ConsultaAgenda,@SucursalId  ) Returning Usuario_Id";
            return sql;
        }


        public static string UsuarioUpdate()
        {
            string sql = "";
            sql = "Update Usuarios Set Nombre=@Nombre, PassWord =@PassWord, ConsultaAgenda=@ConsultaAgenda,SucursalId=@SucursalId  Where Usuario_Id = @Usuario_Id";
            return sql;
        }

        #endregion

    }
}
