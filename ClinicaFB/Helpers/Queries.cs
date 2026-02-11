using System.Windows.Forms;

namespace ClinicaFB.Helpers
{
    public static class Queries
    {
        #region Colaboradores
        public static string
            ColaboradorSelect = "Select ColaboradorId,Nombre From Colaboradores Where ColaboradorId = @ColaboradorId";
        public static string
            ColaboradoresSelect = "Select ColaboradorId,Nombre From Colaboradores Order By Nombre";
        public static string
            ColaboradorInsert = "Insert Into Colaboradores (Nombre) Values (@Nombre) Returning ColaboradorId";
        public static string
            ColaboradorUpdate = "Update Colaboradores Set Nombre = @Nombre Where ColaboradorId = @ColaboradorId";
        public static string
            ColaboradorDelete = "Delete From Colaboradores Where ColaboradorId = @ColaboradorId";

        #endregion
        #region ComplementosDePago
        public static string
            ComplementosDePagoSelect =
            "Select CompagId,EsPDV,EmisorId," +
            "ComplementosPago.RazonSocialId,RazonesSociales.razonSoc as ReceptorNombre,Serie,Folio,Fecha," +
            "ComplementosPago.CveFOP,CveMON,TipoDeCambio,Monto,UID,Cancelado,Acuse,CveMotCan " +
            "From ComplementosPago " +
            "Inner Join RazonesSociales On ComplementosPago.RazonSocialId = RazonesSociales.RazonSocialId " +
            "Where EmisorId = @EmisorId and Fecha Between @FechaIni and @FechaFin Order By Fecha Desc";

        public static string
            ComplementoDePagoInsert =
            "Insert Into ComplementosPago " +
            "(EsPDV,EmisorId,RazonSocialId,Serie,Folio,Fecha,CveFOP,CveMON,TipoDeCambio,Monto,UID,Cancelado,Acuse,CveMotCan,xml) " +
            "Values (@EsPDV,@EmisorId,@RazonSocialId,@Serie,@Folio,@Fecha,@CveFOP,@CveMON,@TipoDeCambio,@Monto,@UID,@Cancelado,@Acuse,@CveMotCan,@xml) " +
            "Returning CompagId";

        public static string
            ComplementoDePagoUpdate =
            "Update ComplementosPago Set " +
            "EsPDV = @EsPDV,EmisorId = @EmisorId,RazonSocialId = @RazonSocialId," +
            "Serie = @Serie,Folio = @Folio,Fecha = @Fecha,CveFOP = @CveFOP,CveMON = @CveMON," +
            "TipoDeCambio = @TipoDeCambio,Monto = @Monto,UID = @UID,Cancelado = @Cancelado,Acuse = @Acuse," +
            "CveMotCan = @CveMotCan," +
            "xml=@xml " +
            "Where CompagId = @CompagId";

        public static string
            ComplementoDePagoDelete = "Delete From ComplementosPago Where CompagId = @CompagId";


        public static string
            ComplementoDePagoSelect =
            "Select CompagId,EsPDV,EmisorId," +
            "ComplementosPago.RazonSocialId,RazonesSociales.razonSoc as ReceptorNombre,Serie,Folio,Fecha," +
            "ComplementosPago.CveFOP,ComplementosPago.CveMON,TipoDeCambio,Monto,UID,Cancelado,Acuse,CveMotCan,xml " +
            "From ComplementosPago " +
            "Inner Join RazonesSociales On ComplementosPago.RazonSocialId = RazonesSociales.RazonSocialId " +
            "Where CompagId = @CompagId";

        public static string
            ComplementoDePagoSelectXSerieYFolio =
            "Select CompagId,EsPDV,EmisorId," +
            "RazonSocialId,,Serie,Folio,Fecha," +
            "Monto,UID,Cancelado,Acuse,CveMotCan,xml " +
            "From ComplementosPago " +
            "Where Serie = @Serie And Folio = @Folio";


        public static string ComplementoDePagoUpdateTimbrado =
            "Update ComplementosPago Set UID=@uid, xml=@xml Where CompagId=@CompagId";


        public static string ComplementoDePagoUpdateCancelacion =
        "Update ComplementosPago Set Cancelado=True, Acuse=@Acuse Where CompagId=@CompagId";


        public static string
            ComPagRelsSelect =
            "Select ComPagRelId,ComPagoId,DocumentoId,UID,Serie,Folio,Fecha,CveMon,TipoDeCambio,CveMEP," +
            "Parcialidad,Importe,SaldoAnterior,Pagado,SaldoInsoluto,FechaPago,BaseIVA16,IVA16,BaseIVA0,BaseIVAExento " +
            "From ComPagosRelacionados " +
            "Where ComPagoId = @ComPagoId";

        public static string
            ComPagRelsInsert =
            "Insert Into ComPagosRelacionados " +
            "(ComPagoId,DocumentoId,UID,Serie,Folio,Fecha,CveMon,TipoDeCambio,CveMEP," +
            "Parcialidad,Importe,SaldoAnterior,Pagado,SaldoInsoluto,FechaPago,BaseIVA16,IVA16,BaseIVA0,BaseIVAExento) " +
            "Values " +
            "(@ComPagoId,@DocumentoId,@UID,@Serie,@Folio,@Fecha,@CveMon,@TipoDeCambio,@CveMEP," +
            "@Parcialidad,@Importe,@SaldoAnterior,@Pagado,@SaldoInsoluto,@FechaPago,@BaseIVA16,@IVA16,@BaseIVA0,@BaseIVAExento) " +
            "Returning ComPagRelId";


        public static string
        ComPagRelsDelete =
        "Delete From ComPagosRelacionados " +
        "Where ComPagoId = @ComPagoId";


        #endregion
        #region ArticulosClaves
        public static string
            ArticuloClaveSelect = "Select ArticuloClaveId,ProveedorId,ClaveProveedor,ArticuloId From ArticulosClaves Where ArticuloClaveId = @ArticuloClaveId";
        public static string
            ArticuloClaveInsert = "Insert Into ArticulosClaves (ProveedorId,ClaveProveedor,ArticuloId) Values (@ProveedorId,@ClaveProveedor,@ArticuloId) Returning ArticuloClaveId";
        public static string
            ArticuloClaveDelete = "Delete From ArticulosClaves Where ArticuloClaveId = @ArticuloClaveId";
        public static string
            ArticuloClaveSelectXCveProv = "Select ArticuloClaveId,ProveedorId,ClaveProveedor,ArticuloId From ArticulosClaves Where ProveedorId = @ProveedorId and ClaveProveedor = @ClaveProveedor";
        public static string
            ArticuloClaveDeleteXCveProv = "Delete From ArticulosClaves Where ProveedorId = @ProveedorId and ClaveProveedor = @ClaveProveedor";


        #endregion

        #region InventarioInicial
        public static string
            InventarioInicialSelect = "Select InventarioInicialId,ArticuloId,AlmacenId,Fecha,Cantidad From InventariosIniciales Where ArticuloId= @ArticuloId and AlmacenId = @AlmacenId";
        public static string
            InventarioInicialInsert = "Insert Into InventariosIniciales (ArticuloId,AlmacenId,Fecha,Cantidad) Values (@ArticuloId,@AlmacenId,@Fecha,@Cantidad) Returning InventarioInicialId";
        public static string
            InventarioInicialUpdate = "Update InventariosIniciales Set Cantidad = @Cantidad Where InventarioInicialId = @InventarioInicialId";
        public static string
            InventarioInicialDelete = "Delete From InventariosIniciales Where InventarioInicialId = @InventarioInicialId";

        #endregion
        #region PDV

        public static string
        VentasNoFacturadasSelect =
            "Select VentaId,Tipo,Serie,Folio,TipoComprobante,Fecha,FormaPago,Moneda,TipoCambio,MetodoPago," +
            "LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac,UID,Cancelada,WebId,CSD,xml " +
            "From Ventas " +
            "Where Tipo = 'TIC' And Cancelada = False and " +
            "(FacturaGlobalId  is null or FacturaGlobalId = 0) And " +
            "(FolioFac Is Null Or FolioFac=0) And " +
            "SucursalId = @SucursalId and AlmacenId = @AlmacenId And " +
            "Fecha Between @FechaIni and @FechaFin Order By Fecha Desc";



        public static string VentasDelete = "Delete From Ventas Where VentaId > 0";
        public static string VentasDetalleDelete = "Delete From VentasDetalle Where VentaDetId > 0";
        public static string DocumentosDelete = "Delete From Documentos Where DocumentoId > 0";
        public static string DocumentosDetalleDelete = "Delete From DocumentosDetalle Where DocsDetId > 0";
        public static string ArticulosExistenciasDelete = "Delete From ArticulosExistencias Where ArtExiId > 0";
        public static string ArticulosMovimientosDelete = "Delete From ArticulosMovimientos Where ArtMovId > 0";
        public static string VentaUpdateFacturaGlobal =
            "Update Ventas Set FacturaGlobalId = @FacturaGlobalId Where VentaId = @VentaId";

        public static string FormasPagoVentas =
            "Select Pagos.Tipo as FormaPagoId,Pagos.Importe, Ventas.Serie, Ventas.Folio,Ventas.Fecha," +
            "Ventas.ClienteId,RazonesSociales.RazonSoc as ClienteNombre " +
            "From Pagos " +
            "inner join Ventas on Pagos.DoctoOrigenId = Ventas.VentaId " +
            "Left Join RazonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            "Where " +
            "(Ventas.Tipo='TIC' Or Ventas.Tipo='FAC') and " +
            "Ventas.Cancelada = False and " +
            "Ventas.SucursalId = @SucursalId And " +
            "Ventas.AlmacenId = @AlmacenId And " +
            "Pagos.OrigenTipo = @OrigenTipo and " +
            "Ventas.Fecha Between @FechaIni and @FechaFin " +
            "Order By FormaPagoId,Fecha ";

        public static string FormasDePagoFechas =
        "select Sum(pagos.Importe) as Total, Sum(pagos.Cambio) as Cambio,Pagos.Tipo from pagos " +
        "inner join Ventas on Pagos.DoctoOrigenId = Ventas.VentaId " +
        "Where " +
            "(Ventas.Tipo='TIC' Or Ventas.Tipo='FAC') and " +
            "Ventas.Cancelada = False and " +
            "Ventas.SucursalId = @SucursalId And " +
            "Ventas.AlmacenId = @AlmacenId And " +
            "Pagos.ORIGENTIPO = @OrigenTipo and " +
            "Ventas.Fecha Between @FechaIni and @FechaFin " +
        "group by Pagos.Tipo " +
        "order by Pagos.Tipo ";


        public static string
            ArticulosVendidosXSucursalYFechas =
            "Select VentasDetalle.ArticuloId,VentasDetalle.Descripcion,Sum(VentasDetalle.Cantidad) as Cantidad," +
            "Sum(VentasDetalle.Cantidad * VentasDetalle.Precio) as Importe,Sum(VentasDetalle.IVA) as Impuesto " +
            "From VentasDetalle " +
            "Inner Join Articulos On VentasDetalle.ArticuloId = Articulos.ArticuloId " +
            "Inner Join Ventas On VentasDetalle.VentaId = Ventas.VentaID " +
            "Where " +
            "(Ventas.Tipo='TIC' Or Ventas.Tipo='FAC') and " +
            "Ventas.Cancelada = False and " +
            "Ventas.SucursalId = @SucursalId and " +
            "Ventas.AlmacenId = @AlmacenId And " +
            "Ventas.Fecha Between @FechaIni and @FechaFin " +
            "Group By VentasDetalle.ArticuloId,VentasDetalle.Descripcion " +
            "Order By VentasDetalle.Descripcion";

        public static string
            VentaSetDatosFacturacion =
            "Update Ventas " +
            "Set Tipo = 'FAC'," +
            "ClienteId=@ClienteId," +
            "SerieFac=@SerieFac," +
            "FolioFac=@FolioFac," +
            "FechaFac=@FechaFac," +
            "MetodoPago=@MetodoPago," +
            "FormaPago=@FormaPago," +
            "Uso=@Uso " +
            "Where VentaId = @VentaId";

        public static string
            VentaQuitaDatosFactura =
            "Update Ventas " +
            "Set Tipo = 'TIC'," +
            "SerieFac=''," +
            "FolioFac=0," +
            "MetodoPago=''," +
            "FormaPago=''," +
            "Uso='' " +
            "Where VentaId = @VentaId";




        public static string
            VentaSetDatosCancelacion = "Update Ventas Set Cancelada = true, Acuse=@Acuse Where VentaId = @VentaId";
        public static string
            VentasSelectxSucursalYFechas =
            "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId," +
            "RazonesSociales.RazonSoc as ClienteNombre, " +
            "Tipo,Serie,Folio,TipoComprobante,Fecha,FormaPago,Moneda,TipoCambio,MetodoPago," +
            "LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac,UID," +
            "Cancelada,WebId,CSD,FacturaGlobalId,Acuse,Observaciones " +
            "From Ventas " +
            "Left Join razonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            "Where " +
            "(Ventas.Tipo='TIC' Or Ventas.Tipo='FAC') and " +
            "SucursalId = @SucursalId And " +
            "Ventas.AlmacenId = @AlmacenId and " +
            "Fecha Between @FechaIni and @FechaFin " +
            "Order By Fecha Desc";

        public static string
            VentasSelectxSucursalYFechasSinCancelar =
            "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId," +
            "RazonesSociales.RazonSoc as ClienteNombre, Tipo,Serie,Folio,TipoComprobante," +
            "Fecha,FormaPago,Moneda,TipoCambio,MetodoPago," +
            "LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA,Total," +
            "SerieFac,FolioFac,UID,Cancelada,WebId,CSD,FacturaGlobalId,Observaciones,xml " +
            "From Ventas " +
            "Left Join razonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            "Where " +
            "(Ventas.Tipo='TIC' Or Ventas.Tipo='FAC') and " +
            "Ventas.Cancelada = false and " +
            "SucursalId = @SucursalId And " +
            "Ventas.AlmacenId = @AlmacenId and " +
            "Fecha Between @FechaIni and @FechaFin " +
            "Order By Fecha Desc";


        public static string
            FacturasGlobalesSelect =
            "Select Fecha,VentaId,SucursalId,EmisorId,AlmacenId,Tipo,Serie,Folio,Subtotal,IVA,Total,SerieFac,FolioFac,UID,Cancelada,xml " +
            "From Ventas " +
            "Where Tipo = 'GLO' and " +
            "SucursalId = @SucursalId and " +
            "Fecha Between @FechaIni and @FechaFin " +
            "Order By Fecha Desc";

        public static string FacturaGlobalIdReset = "Update Ventas Set FacturaGlobalId = 0 Where FacturaGlobalId = @VentaId";



        public static string
            FacturasReporteSelect =
            "Select VentaId,SucursalId,AlmacenId,DoctorId,ClienteId,RazonesSociales.RazonSoc As ClienteNombre," +
            "Tipo,Serie,Folio,TipoComprobante,Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal," +
            "Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac,FechaFac,UID,Cancelada,WebId,CSD,Observaciones,xml " +
                "From Ventas " +
            "Left Join RazonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            "Where AlmacenId = @AlmacenId And FechaFac Between @FechaIni and @FechaFin and Trim(UID) <>'' and UID is Not NULL " +
            "Order By SerieFac,FolioFac";



        public static string
            VentasSelect =
            "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId," +
            "Tipo,Serie,Folio,TipoComprobante,Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion," +
            "Uso,Subtotal,Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac,FechaFac,UID,Cancelada,WebId,CSD,Observaciones,xml " +
            "From Ventas Where EmisorId = @EmisorId and Fecha Between @FechaIni and @FechaFin Order By Fecha Desc";

        public static string
            VentasFacturasSelect =
            "Select VentaId,SucursalId,AlmacenId,DoctorId,ClienteId,RazonesSociales.RazonSoc As ClienteNombre," +
            "Tipo,Serie,Folio,TipoComprobante,Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal," +
            "Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac,FechaFac,UID,Cancelada,WebId,CSD,Observaciones,xml " +
                "From Ventas " +
            "Left Join RazonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            "Where AlmacenId = @AlmacenId And Fecha Between @FechaIni and @FechaFin and Trim(UID) <>'' and UID is Not NULL " +
            "Order By Fecha";



        public static string
        VentaSelectxSerieyFolio = "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId,Tipo,Serie,Folio,TipoComprobante," +
        "Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac," +
        "FechaFac,UID,Cancelada,WebId,CSD,Observaciones,xml " +
        "From Ventas Where EmisorId=@EmisorId And AlmacenId = @AlmacenId and Serie = @Serie and Folio=@Folio";


        public static string
        TicketSelectxSerieyFolio = "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId,Tipo,Serie,Folio,TipoComprobante," +
            "Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac," +
            "FechaFac,UID,Cancelada,WebId,CSD,Observaciones " +
            "From Ventas Where Tipo ='TIC' And EmisorId=@EmisorId And AlmacenId = @AlmacenId and Serie = @Serie and Folio=@Folio";

        public static string
        FacturaSelectxSerieyFolio = "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId,Tipo,Serie,Folio,TipoComprobante," +
        "Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac," +
        "FechaFac,UID,Cancelada,WebId,CSD,Observaciones,xml " +
        "From Ventas Where (Tipo ='FAC' or Tipo = 'GLO') And " +
            "EmisorId=@EmisorId And " +
            "AlmacenId = @AlmacenId and " +
            "SerieFac = @Serie and " +
            "FolioFac = @Folio";


        public static string
FacturaSelectxSerieyFolioSinAlmacen = "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId,Tipo,Serie,Folio,TipoComprobante," +
"Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA,Total,SerieFac,FolioFac," +
"FechaFac,UID,Cancelada,WebId,CSD,Observaciones,xml " +
"From Ventas Where (Tipo ='FAC' or Tipo = 'GLO') And " +
    "EmisorId=@EmisorId And " +
    "SerieFac = @Serie and " +
    "FolioFac = @Folio";


        public static string
            VentaSelect =
            "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId,Tipo,Serie,Folio," +
            "TipoComprobante,Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso," +
            "Subtotal,Descuento,IVA,RetISR,RetIVA,Total,SerieFac," +
            "FolioFac,FechaFac,UID,Cancelada,WebId,CSD,Observaciones,Acuse,FacturaGlobalId,Observaciones,CveREL,UIDREL,VentaIdREL,xml  " +
            "From Ventas Where VentaId = @VentaId";


        public static string
            VentaVisorSelect = "Select VentaId,Ventas.SucursalId,Ventas.EmisorId,Ventas.AlmacenId,Almacenes.Nombre as AlmacenNombre," +
            " DoctorId,Doctores.NombreCompleto as DoctorNombre," +
            " Emisores.Nombre as EmisorNombre, ClienteId,RazonesSociales.RazonSoc as ClienteNombre," +
            " Tipo,Serie,Folio,TipoComprobante,Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA," +
            " Total,Ventas.SerieFac,Ventas.FolioFac,FechaFac,UID,Cancelada,Acuse,WebId,CSD,Observaciones,xml  " +
            " From Ventas " +
            " Inner Join Emisores On Ventas.EmisorId = Emisores.EmisorId " +
            " Left Join razonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            " Inner Join Almacenes On Ventas.AlmacenId = Almacenes.AlmacenId " +
            " Left Join Doctores On Ventas.DoctorId = Doctores.Doctor_Id " +
            " Where VentaId = @VentaId";


        public static string
            VentaVisorSelectXSerieYFolio = "Select VentaId,Ventas.SucursalId,Ventas.EmisorId,Ventas.AlmacenId,Almacenes.Nombre as AlmacenNombre," +
            " DoctorId,Doctores.NombreCompleto as DoctorNombre," +
            " Emisores.Nombre as EmisorNombre, ClienteId,RazonesSociales.RazonSoc as ClienteNombre," +
            " Tipo,Serie,Folio,TipoComprobante,Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA,RetISR,RetIVA," +
            " Total,Ventas.SerieFac,Ventas.FolioFac,UID,Cancelada,WebId,CSD,Observaciones,xml  " +
            " From Ventas " +
            " Inner Join Emisores On Ventas.EmisorId = Emisores.EmisorId " +
            " Left Join razonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            " Inner Join Almacenes On Ventas.AlmacenId = Almacenes.AlmacenId " +
            " Left Join Doctores On Ventas.DoctorId = Doctores.Doctor_Id " +
            " Where Ventas.SerieFac = @Serie and Ventas.FolioFac =@Folio";


        public static string
            VentaInsert =
            "Insert Into Ventas " +
            "(SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId,Tipo,Serie,Folio,TipoComprobante,Fecha," +
            "FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA," +
            "RetISR,RetIVA,Total,SerieFac,FolioFac,FechaFac,UID,Cancelada,WebId,CSD,Observaciones,CveREL,UIDREL,VentaIdREL,xml) " +
            "Values (@SucursalId,@EmisorId,@AlmacenId,@DoctorId,@ClienteId,@Tipo,@Serie,@Folio,@TipoComprobante,@Fecha," +
            "@FormaPago,@Moneda,@TipoCambio,@MetodoPago,@LugarExpedicion,@Uso,@Subtotal,@Descuento,@IVA," +
            "@RetISR,@RetIVA,@Total,@SerieFac,@FolioFac,@FechaFac,@UID,@Cancelada,@WebId,@CSD,@Observaciones,@CveREL,@UIDREL,@VentaIdREL,@xml) Returning VentaId";

        public static string VentaUpdate =
            "Update Ventas Set " +
            "SucursalId = @SucursalId," +
            "EmisorId = @EmisorId," +
            "AlmacenId = @AlmacenId," +
            "DoctorId = @DoctorId," +
            "ClienteId = @ClienteId," +
            "Tipo = @Tipo," +
            "Serie = @Serie," +
            "Folio = @Folio," +
            "TipoComprobante = @TipoComprobante," +
            "Fecha = @Fecha," +
            "FormaPago = @FormaPago," +
            "Moneda = @Moneda," +
            "TipoCambio = @TipoCambio," +
            "MetodoPago = @MetodoPago," +
            "LugarExpedicion = @LugarExpedicion," +
            "Uso = @Uso," +
            "Subtotal = @Subtotal," +
            "Descuento = @Descuento," +
            "IVA = @IVA," +
            "RetISR = @RetISR," +
            "RetIVA = @RetIVA," +
            "Total = @Total," +
            "SerieFac = @SerieFac," +
            "FolioFac = @FolioFac," +
            "FechaFac = @FechaFac," +
            "UID = @UID," +
            "Cancelada = @Cancelada," +
            "WebId = @WebId," +
            "CSD = @CSD," +
            "Observaciones = @Observaciones," +
            "CveREL = @CveREL," +
            "UIDREL = @UIDREL," +
            "VentaIdREL = @VentaIdREL," +
            "xml =@xml " +
            "Where VentaId = @VentaId";

        public static string
            VentaDelete = "Delete From Ventas Where VentaId = @VentaId";

        public static string
            VentaUpdateTimbrado = "Update Ventas Set UId=@uid,CSD=@csd,xml = @xml Where VentaId=@VentaId";

        public static string
            VentaDetalleSelect = "Select VentaDetId,VentaId,ArticuloId,NoIden,Descripcion,UDM,Cantidad,Precio,Descuento,IVA,TipoIVA,TasaIVA,CveProSer,CveUni,RetIVA,RetISR " +
            "From VentasDetalle Where VentaDetId = @VentaDetId";
        public static string
            VentaDetallesSelect = "Select VentaDetId,VentaId,ArticuloId,NoIden,Descripcion,UDM,Cantidad,Precio,Descuento,IVA,TipoIVA,TasaIVA,CveProSer,CveUni,RetIVA,RetISR " +
            "From VentasDetalle Where VentaId = @VentaId";
        public static string
            VentaDetalleInsert = "Insert Into VentasDetalle (VentaId,ArticuloId,NoIden,Descripcion,UDM,Cantidad,Precio,Descuento,IVA,TipoIVA,TasaIVA,CveProSer,CveUni,RetIVA,RetISR,DetalleIdRel) " +
            "Values (@VentaId,@ArticuloId,@NoIden,@Descripcion,@UDM,@Cantidad,@Precio,@Descuento,@IVA,@TipoIVA,@TasaIVA,@CveProSer,@CveUni,@RetIVA,@RetISR,@DetalleIdRel) Returning VentaDetId";

        public static string
            VentaDetalleDelete = "Delete From VentasDetalle Where VentaDetId = @VentaDetId";
        public static string
            VentaDetallesDelete = "Delete From VentasDetalle Where VentaId = @VentaId";


        public static string
            NotasCreditoSelect =
            "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId," +
            "RazonesSociales.RazonSoc as CienteNombre, " +
            "Tipo,Serie,Folio,TipoComprobante," +
            "Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA," +
            "RetISR,RetIVA,Total,SerieFac,FolioFac,UID,Cancelada,WebId,CSD,xml " +
            "From Ventas " +
            "left Join RazonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            "Where EmisorId = @EmisorId and AlmacenId=@AlmacenId and Tipo = 'NDC' and " +
            "Fecha Between @FechaIni and @FechaFin Order By Fecha Desc";

        public static string
            NotasSelect =
            "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId," +
            "RazonesSociales.RazonSoc as CienteNombre, " +
            "Tipo,Serie,Folio,TipoComprobante," +
            "Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA," +
            "RetISR,RetIVA,Total,SerieFac,FolioFac,UID,Cancelada,WebId,CSD,xml " +
            "From Ventas " +
            "left Join RazonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            "Where EmisorId = @EmisorId and AlmacenId=@AlmacenId and Tipo = 'NDC' and " +
            "Fecha Between @FechaIni and @FechaFin Order By Fecha Desc";


        public static string NotasEmisorSelect =
            "Select VentaId,SucursalId,EmisorId,AlmacenId,DoctorId,ClienteId," +
            "RazonesSociales.RazonSoc as CienteNombre, " +
            "Tipo,Serie,Folio,TipoComprobante," +
            "Fecha,FormaPago,Moneda,TipoCambio,MetodoPago,LugarExpedicion,Uso,Subtotal,Descuento,IVA," +
            "RetISR,RetIVA,Total,SerieFac,FolioFac,UID,Cancelada,WebId,CSD,xml " +
            "From Ventas " +
            "left Join RazonesSociales On Ventas.ClienteId = RazonesSociales.RazonSocialId " +
            "Where EmisorId = @EmisorId and Tipo = 'NDC' and " +
            "Fecha Between @FechaIni and @FechaFin Order By Fecha Desc";

        #endregion

        #region ArticulosExistencias
        public static string ArticuloExistenciasSelect =
            "Select ArtExiId,ArticuloId,ArticulosExistencias.AlmacenId,Almacenes.Nombre as AlmacenNombre,Entradas,Salidas,Existencia " +
            "From ArticulosExistencias " +
            "Inner Join Almacenes On ArticulosExistencias.AlmacenId = Almacenes.AlmacenId " +
            "Where ArticuloId = @ArticuloId";
        public static string ArticuloExistenciaSelect =
            "Select ArtExiId,ArticuloId,AlmacenId,Entradas,Salidas,Existencia " +
            "From ArticulosExistencias " +
            "Where ArticuloId = @ArticuloId and AlmacenId = @AlmacenId";
        public static string ArticuloExistenciaInsert =
            "Insert Into ArticulosExistencias (ArticuloId,AlmacenId,Entradas,Salidas) Values (@ArticuloId,@AlmacenId,@Entradas,@Salidas) Returning ArtExiId";
        public static string ArticuloExistenciaUpdate =
            "Update ArticulosExistencias Set Entradas = @Entradas, Salidas = @Salidas Where ArtExiId = @ArtExiId";

        public static string ArticuloExistenciasDelete =
            "Delete From ArticulosExistencias Where ArticuloId = @ArticuloId and AlmacenId=@AlmacenId";

        #endregion

        #region CapasDeCostos
        public static string CapaDeCostoInsertSP = "SP_CAPADECOSTO_INS";
        public static string CapasDeCostosDeleteByDocSP = "SP_CAPASDECOSTOS_DELBYDOC";
        public static string CapasDeCostosRegistrarSalidaSP = "SP_CAPASDECOSTOS_REGISTRAR_SALIDA";
        public static string CapasDeCostosRegistrarEntradaSP = "SP_CAPASDECOSTOS_REGISTRAR_ENTRADA";
        public static string CapasDeCostosRevertirEntradaSP = "SP_CAPASDECOSTOS_REVERTIR_ENTRADA";


        public static string CapasDeCostoUtilizadasXDocSelect = 
            "Select First 1 CapaId " +
            "From CapasDeCostos " +
            "Where ConceptoId = @ConceptoId and DocumentoId = @DocumentoId And CantidadDisponible <> CantidadInicial";

        #endregion
        #region ArticulosMovimientos

        public static string
            DocumentoMovimientoInsert =
            "Insert Into ArticulosMovimientos " +
            "(ArticuloId,AlmacenId,ConceptoId,Tipo,Fecha,EsVenta,DocumentoId,Cantidad,Importe,UltimoCosto) " +
            "Values " +
            "(@ArticuloId,@AlmacenId,@ConceptoId,@Tipo,@Fecha,@EsVenta,@DocumentoId,@Cantidad,@Importe,@UltimoCosto) Returning ArtMovId";
        public static string
            ArticuloMovimientoDelete = "Delete From ArticulosMovimientos Where ArtMovId = @ArtMovId";

        public static string
            DocumentoMovimientosDelete = "Delete From ArticulosMovimientos Where EsVenta=@Esventa and DocumentoId = @DocumentoId";

        //public static string
        //    DocumentoMovimientosDeleteXId = "Delete From ArticulosMovimientos Where DocumentoId = @DocumentoId";

        public static string
            ArticuloMovimientosDelete = "Delete From ArticulosMovimientos Where ArticuloId = @ArticuloId and AlmacenId=@AlmacenId";

        public static string
            ArticuloMovimientoUltimoCostoUpdate = "Update ArticulosMovimientos set UltimoCosto =@UltimoCosto Where ArtMovId = @ArtMovId ";

        public static string
            ArticuloMovimientosSelect = "Select ArtMovId,ArticuloId,AlmacenId,EsVenta,ConceptoId,Tipo,Fecha,DocumentoId,Cantidad,Importe From ArticulosMovimientos Where ArticuloId = @ArticuloId Order By Fecha Desc";

        public static string
            ArticulosMovimientosSelect = "Select ArtMovId,ArticuloId,AlmacenId,EsVenta,ConceptoId,Tipo,Fecha,DocumentoId,Cantidad,Importe From ArticulosMovimientos order by ArticuloId";


        public static string
            ArticuloAlmacenMovimientosSelect =
            "Select ArtMovId,ArticuloId,AlmacenId,ArticulosMovimientos.EsVenta,ConceptoId,ConceptosMovInv.Tipo as ConceptoTipo,ConceptosMovInv.Descripcion as ConceptoNombre," +
            "ArticulosMovimientos.Tipo,Fecha,DocumentoId,Cantidad,Importe, ArticulosMovimientos.UltimoCosto " +
            "From ArticulosMovimientos " +
            "Inner Join ConceptosMovInv on ArticulosMovimientos.ConceptoId = ConceptosMovInv.ConMovInvId " +
            "Where ArticuloId = @ArticuloId And AlmacenId = @AlmacenId and Fecha Between @FechaIni and @FechaFin " +
            "Order By Fecha";


        #endregion
        #region Documentos

        public static string
            ArticuloCostoUltimaCompraSelect =
            "Select First 1 Fecha,Precio From DocumentosDetalle  " +
            "Inner Join Documentos On DocumentosDetalle.DocumentoId = Documentos.DocumentoId  " +
            "Where ArticuloId = @ArticuloId and Documentos.Tipo = 'COM' " +
            "Order By Documentos.Fecha Desc";

        public static string ArticuloUltimoCostoByCapa =
            "SELECT FIRST 1 COSTOUNITARIO FROM CAPASDECOSTOS " +
            "WHERE ARTICULOID = @ARTICULOID " +
            "AND SUCURSALID = @SUCURSALID " +
            "AND ALMACENID  = @ALMACENID " +
            "AND NEGATIVA   = FALSE " +
            "ORDER BY FECHAINGRESO DESC, CAPAID DESC";

        public static string ConceptosMovInvSelect = "Select ConMovInvId,Descripcion,Tipo From ConceptosMovInv Where Tipo = @TipoCon Order By Descripcion";

        public static string
            EntradasSalidasSelect = "Select DocumentoId,Documentos.AlmacenId,Documentos.ConceptoId," +
            "ConceptosMovInv.Descripcion as ConceptoNombre,Almacenes.Nombre as AlmacenNombre," +
            "Documentos.Tipo,Fecha,Serie,Folio,SubTotal,IVA,Total " +
            "From Documentos " +
            "Inner Join Almacenes On Documentos.AlmacenId = Almacenes.AlmacenId " +
            "Inner Join ConceptosMovInv On Documentos.ConceptoId = ConceptosMovInv.ConMovInvId " +
            "Where  " +
            "ConceptosMovInv.Tipo = @TipoCon and " +
            "ConceptosMovInv.Reservado = False and " +
            "Documentos.AlmacenId = @AlmacenId and " +
            "Fecha Between @FechaIni and @FechaFin " +
            "Order By Fecha Desc";

        public static string
            SalidasSelect = "Select DocumentoId,Documentos.AlmacenId, Almacenes.Nombre as AlmacenNombre," +
            "Tipo,Fecha,Serie,Folio,SubTotal,IVA,Total " +
            "From Documentos " +
            "Inner Join Almacenes On Documentos.AlmacenId = Almacenes.AlmacenId " +
            "Where  " +
            "(Tipo = 'DEV'  or Tipo = 'AJU' or Tipo = 'CAD' or Tipo = 'DEP') " +
            " and " +
            "Fecha Between @FechaIni and @FechaFin " +
            "Order By Fecha Desc";



        public static string
            ComprasSelect = "Select DocumentoId,Documentos.AlmacenId, Almacenes.Nombre as AlmacenNombre, AlmacenesDestino.Nombre As AlmacenDestinoNombre," +
            "ConceptoId,Tipo,Fecha,Serie,Folio,SubTotal,IVA,Total," +
            "Documentos.ProveedorId,Proveedores.Nombre as ProveedorNombre,Documentos.Observaciones,Cancelado  " +
            "From Documentos " +
            "left Join Proveedores On Documentos.Proveedorid = Proveedores.ProveedorId " +
            "Inner Join Almacenes On Documentos.AlmacenId = Almacenes.AlmacenId " +
            "Left Join  Almacenes AlmacenesDestino On Documentos.AlmacenDestinoId = AlmacenesDestino.AlmacenId " +
            "Where  " +
            "Tipo = @Tipo and Documentos.AlmacenId = @AlmacenId and " +
            "Fecha Between @FechaIni and @FechaFin " +
            "Order By Fecha Desc";

        public static string
            ComprasSelectXProveedor = "Select DocumentoId,Documentos.AlmacenId, Almacenes.Nombre as AlmacenNombre, AlmacenesDestino.Nombre As AlmacenDestinoNombre," +
            "ConceptoId,Tipo,Fecha,Serie,Folio,SubTotal,IVA,Total," +
            "Documentos.ProveedorId,Proveedores.Nombre as ProveedorNombre,Documentos.Observaciones,Cancelado  " +
            "From Documentos " +
            "left Join Proveedores On Documentos.Proveedorid = Proveedores.ProveedorId " +
            "Inner Join Almacenes On Documentos.AlmacenId = Almacenes.AlmacenId " +
            "Left Join  Almacenes AlmacenesDestino On Documentos.AlmacenDestinoId = AlmacenesDestino.AlmacenId " +
            "Where  " +
            "Tipo = @Tipo and Documentos.AlmacenId = @AlmacenId and " +
            "Fecha Between @FechaIni and @FechaFin And Documentos.ProveedorId = @ProveedorId " +
            "Order By Fecha Desc";


        public static string
            DocumentosSelect = "Select DocumentoId,Documentos.SucursalId,Documentos.AlmacenId, Almacenes.Nombre as AlmacenNombre, AlmacenesDestino.Nombre As AlmacenDestinoNombre," +
            "ConceptoId,Tipo,Fecha,Serie,Folio,SubTotal,IVA,Total," +
            "Documentos.ProveedorId,Proveedores.Nombre as ProveedorNombre,Documentos.Observaciones,Cancelado  " +
            "From Documentos " +
            "left Join Proveedores On Documentos.Proveedorid = Proveedores.ProveedorId " +
            "Inner Join Almacenes On Documentos.AlmacenId = Almacenes.AlmacenId " +
            "Left Join  Almacenes AlmacenesDestino On Documentos.AlmacenDestinoId = AlmacenesDestino.AlmacenId " +
            "Where  " +
            "Tipo = @Tipo and " +
            "Fecha Between @FechaIni and @FechaFin " +
            "Order By Fecha Desc";
        public static string
            DocumentoSelect = "Select DocumentoId,SucursalId,AlmacenId,AlmacenDestinoId,ConceptoId,Tipo,Fecha,Serie,Folio,SubTotal,IVA,Total," +
            "Documentos.ProveedorId,Proveedores.Nombre as ProveedorNombre,Documentos.Observaciones,Cancelado " +
            "From Documentos " +
            "left Join Proveedores On Documentos.Proveedorid = Proveedores.ProveedorId " +
            "Where  " +
            "DocumentoId = @DocumentoId";
        public static string
            DocumentoInsert = "Insert Into Documentos (SucursalId,AlmacenId,AlmacenDestinoId,ConceptoId,Tipo,Fecha,Serie,Folio,SubTotal,IVA,Total,ProveedorId,Observaciones,Cancelado) " +
            "Values " +
            "(@SucursalId,@AlmacenId,@AlmacenDestinoId,@ConceptoId,@Tipo,@Fecha,@Serie,@Folio,@SubTotal,@IVA,@Total,@ProveedorId,@Observaciones,@Cancelado) " +
            "Returning DocumentoId";
        public static string
            DocumentoUpdate = "Update Documentos Set " +
            "SucursalId = @SucursalId," +
            "AlmacenId = @AlmacenId," +
            "ConceptoId = @ConceptoId," +
            "Tipo = @Tipo," +
            "Fecha = @Fecha," +
            "Serie = @Serie," +
            "Folio = @Folio," +
            "SubTotal = @SubTotal," +
            "IVA = @IVA," +
            "Total = @Total," +
            "ProveedorId = @ProveedorId, " +
            "Observaciones = @Observaciones," +
            "Cancelado  = @Cancelado " +
            "Where DocumentoId = @DocumentoId";

        public static string
        DocumentoSetCancelado = "Update Documentos Set Cancelado = True Where DocumentoId = @DocumentoId";

        public static string
            DocumentoDelete = "Delete From Documentos Where DocumentoId = @DocumentoId";
        public static string
            DocumentoDetalleDelete = "Delete From DocumentosDetalle Where DocumentoId = @DocumentoId";
        public static string
            DocumentoDetalleInsert = "Insert Into DocumentosDetalle (DocumentoId,ArticuloId,NoIden,CveProSer,CveUni,Cantidad,Precio,TipoIVA,TasaIVA,IVA, ExistenciaInicial) " +
            "Values " +
            "(@DocumentoId,@ArticuloId,@NoIden,@CveProSer,@CveUni,@Cantidad,@Precio,@TipoIVA,@TasaIVA,@IVA,@ExistenciaInicial) " +
            "Returning DocsDetId";
        public static string
            DocumentoDetalleSelect =
            "Select DocsDetId,DocumentoId,DocumentosDetalle.ArticuloId,Articulos.Clave," +
            "Articulos.Descripcion As ArticuloDescripcion,NoIden,Articulos.CveProSer,Articulos.CveUni,Cantidad,Precio,TipoIVA,TasaIVA,IVA,ExistenciaInicial " +
            "From DocumentosDetalle " +
            "Inner Join Articulos on DocumentosDetalle.ArticuloId = Articulos.ArticuloId " +
            "Where DocumentoId = @DocumentoId";
        public static string
            DocumentoTipoFolioMayor = "Select Max(Folio) as Mayor From Documentos Where Tipo = @Tipo";
        public static string
            SalidaFolioMayor = "Select Max(Folio) as Mayor From Documentos Where Tipo = 'DEV'  or Tipo = 'AJU' or Tipo = 'CAD' or Tipo = 'DEP'";
        public static string
            EntradaSalidaFolioMayor =
            "Select Max(FolioMayor) as Mayor From " +
            "(" +
            "Select Max(Folio) As FolioMayor, ConceptosMovInv.Descripcion From Documentos " +
            "Inner Join ConceptosMovInv ON Documentos.ConceptoId = ConceptosMovInv.ConMovInvId " +
            "Where  ConceptosMovInv.TIPO = @TipoCon " +
            "Group By ConceptosMovInv.Descripcion" +
            ")";


        #endregion

        #region Proveedores

        public static string ProveedoresSelect = "Select ProveedorId,RFC,Nombre From Proveedores Order By Nombre";
        public static string ProveedorSelect = "Select ProveedorId,RFC,Nombre From Proveedores Where ProveedorId = @ProveedorId";
        public static string ProveedorSelectXRFC = "Select ProveedorId,RFC,Nombre From Proveedores Where RFC = @RFC";

        public static string ProveedorInsert = "Insert Into Proveedores (RFC,Nombre) Values (@RFC,@Nombre) Returning ProveedorId";
        public static string ProveedorUpdate = "Update Proveedores Set RFC = @RFC, Nombre = @Nombre Where ProveedorId = @ProveedorId";
        public static string ProveedorDelete = "Delete From Proveedores Where ProveedorId = @ProveedorId";
        public static string ProveedorBuscar = "Select ProveedorId, RFC, Nombre From Proveedores Where Nombre like @Buscar Or  RFC Like  @Buscar Order By Nombre";

        #endregion
        #region RecetasMedicamentos
        public static string MedicamentosSelect()
        {
            string sql = "";
            sql = "Select Medicamento From RecetasMedicamentos Order By Medicamento";
            return sql;

        }

        public static string MedicamentoInsert()
        {
            string sql = "";
            sql = "Insert Into RecetasMedicamentos (Medicamento) Values (@Medicamento) Returning MedicamentoId";
            return sql;
        }
        public static string MedicamentoExists()
        {
            string sql = "";
            sql = "Select MedicamentoId, Medicamento From RecetasMedicamentos Where Medicamento = @Medicamento";
            return sql;
        }
        #endregion
        #region PacientesFechas

        public static string PacientesXFecha()
        {
            string sql =
                "Select PacienteFechaId,DoctorId,Fecha,PacienteId,Hora,Pacientes.NombreCompleto as PacienteNombre" +
                " From PacientesFechas" +
                " Inner Join Pacientes On PacientesFechas.PacienteId = Pacientes.Paciente_Id" +
                " Where DoctorId = @DoctorId And Fecha = @Fecha Order By Hora";
            return sql;

        }

        public static string PacienteFechaInsert()
        {
            string sql = "";
            sql = "Insert Into PacientesFechas (DoctorId,Fecha,PacienteId,Hora) " +
                "Values " +
                "(@DoctorId,@Fecha,@PacienteId,@Hora) " +
                "Returning PacienteFechaId";
            return sql;
        }

        public static string PacienteFechaDelete()
        {
            string sql = "";
            sql = "Delete From PacientesFechas Where PacienteFechaId = @PacienteFechaId";
            return sql;
        }

        #endregion
        #region FormasPago
        public static string FormasPagoSelect()
        {
            string sql = "";
            sql = "Select FormaPagoId,Tipo,Nombre,CVEFOP From FormasPago Order By Tipo";
            return sql;
        }


        public static string FormaPagoSelect()
        {
            string sql = "";
            sql = "Select FormaPagoId,Tipo,Nombre,CVEFOP,Todos From FormasPago Where FormaPagoId = @FormaPagoId";
            return sql;
        }

        public static string FormaPagoInsert()
        {
            string sql = "";
            sql = "Insert Into FormasPago (Tipo,Nombre,CVEFOP,Todos) Values (@Tipo,@Nombre,@CVEFOP,@Todos) Returning FormaPagoId";
            return sql;
        }

        public static string FormaPagoUpdate()
        {
            string sql = "";
            sql = "Update FormasPago set Tipo = @Tipo, Nombre = @Nombre,CVEFOP=@CVEFOP,Todos = @Todos Where FormaPagoId = @FormaPagoId";
            return sql;
        }

        public static string FormaPagoDelete()
        {
            string sql = "";
            sql = "Delete From FormasPago Where FormaPagoId = @FormaPagoId";
            return sql;
        }



        #endregion
        #region Pagos
        public static string PagoInsert = "Insert Into Pagos (OrigenTipo,DoctoOrigenId,Tipo,Importe,Referencia,Cambio) Values (@OrigenTipo,@DoctoOrigenId,@Tipo,@Importe,@Referencia,@Cambio) Returning PagoId";
        public static string PagoSelect = "Select PagoId,OrigenTipo,DoctoOrigenId,Tipo,Importe,Referencia,Cambio From Pagos Where PagoId = @PagoId";
        public static string PagosSelect = "Select PagoId,OrigenTipo,DoctoOrigenId,Tipo,Importe,Referencia,Cambio From Pagos Where OrigenTipo=@OrigenTipo and DoctoOrigenId=@DoctoOrigenId";
        public static string PagoUpdate = "Update Pagos Set OrigenTipo = @OrigenTipo, DoctoOrigenId = @DoctoOrigenId, Tipo = @Tipo, Importe = @Importe, Referencia = @Referencia, Cambio = @Cambio Where PagoId = @PagoId";
        public static string PagoDelete = "Delete From Pagos Where PagoId = @PagoId";
        public static string PagosDelete = "Delete From Pagos Where OrigenTipo=@OrigenTipo And DoctoOrigenId=@DoctoOrigenId";
        public static string IngresoPagosSelect = "Select PagoId,OrigenTipo,DoctoOrigenId,Tipo,Importe,Referencia,Cambio From Pagos Where OrigenTipo=1 and DoctoOrigenId=@DoctoOrigenId";
        public static string
            VentaPagosSelect
            = "Select PagoId,OrigenTipo,DoctoOrigenId,Tipo,Importe,Referencia,Cambio From Pagos Where OrigenTipo=2 and DoctoOrigenId=@DoctoOrigenId";
        public static string IngresoPagosTarjetaOTransferenciaSelect =
            "Select PagoId,OrigenTipo,DoctoOrigenId,Tipo,Importe,Referencia,Cambio From Pagos " +
            "Where OrigenTipo=1 and DoctoOrigenId=@DoctoOrigenId and Tipo Between 2 and 3";
        #endregion

        #region Conceptos

        public static string ConceptoSelect = "Select ConMovInvId,Tipo,Descripcion,EsVenta,Reservado,PrecioCosto From ConceptosMovInv Where ConMovInvId = @ConMovInvId";
        public static string ConceptoSelectByDescripcion = "Select ConMovInvId,Tipo,Descripcion,PrecioCosto  From ConceptosMovInv Where Descripcion = @Descripcion and Tipo = @Tipo";
        public static string ConceptosSelect = "Select ConMovInvId,Tipo,Descripcion,EsVenta,Reservado,PrecioCosto  From ConceptosMovInv Where Tipo = @Tipo and Reservado = false";
        public static string ConceptoInsert = "Insert Into ConceptosMovInv (Tipo,Descripcion,EsVenta,Reservado,PrecioCosto ) Values (@Tipo,@Descripcion,@EsVenta,@Reservado,@PrecioCosto) Returning ConMovInvId";
        public static string ConceptoUpdate = "Update ConceptosMovInv Set Tipo = @Tipo, Descripcion = @Descripcion, EsVenta = @EsVenta, Reservado = @Reservado, PrecioCosto=@PrecioCosto Where ConMovInvId = @ConMovInvId";
        public static string ConceptoDelete = "Delete From ConceptosMovInv Where ConMovInvId = @ConMovInvId";

        #endregion

        #region ConceptosInvFolios
        public static string ConceptoInvFolioSelect = "Select ConInvFolId,SucursalId, ConceptoId,Serie,Folio From ConceptosInvFolios Where ConInvFolId = @ConInvFolId";
        public static string ConceptoInvFolioSelectBySucursal = "Select ConInvFolId,SucursalId, ConceptoId,Serie,Folio From ConceptosInvFolios Where SucursalId = @SucursalId and ConceptoId = @ConceptoId";
        public static string ConceptoInvFolioInsert = "Insert Into ConceptosInvFolios (SucursalId,ConceptoId,Serie,Folio) Values (@SucursalId,@ConceptoId,@Serie,@Folio) Returning ConInvFolId";
        public static string ConceptoInvFolioUpdate = "Update ConceptosInvFolios Set Serie = @Serie, Folio = @Folio Where ConInvFolId = @ConInvFolId";
        public static string ConceptoInvFolioDelete = "Delete From ConceptosInvFolios Where ConInvFolId = @ConInvFolId";
        #endregion
        #region Almacenes
        public static string AlmacenesSelect()
        {
            string sql = "";
            sql = "Select AlmacenId,Nombre,Defa,SerieVen,FolioVen,SerieFac,FolioFac,SerieNC,FolioNC From Almacenes Order By Nombre";
            return sql;
        }

        public static string AlmacenSelect()
        {
            string sql = "";
            sql = "Select AlmacenId,Nombre,Defa,SerieVen,FolioVen,SerieFac,FolioFac,SerieNC,FolioNC,FormatoFac From Almacenes Where AlmacenId=@AlmacenId";
            return sql;
        }


        public static string AlmacenInsert()
        {
            string sql = "";
            sql = "Insert Into Almacenes " +
                "(Nombre,Defa,SerieVen,FolioVen,SerieFac,FolioFac,SerieNC,FolioNC) " +
                "Values (@Nombre,@Defa,@SerieVen,@FolioVen,@SerieFac,@FolioFac,@SerieNC,@FolioNC) Returning AlmacenId";
            return sql;
        }


        public static string AlmacenUpdate()
        {
            string sql = "";
            sql = "Update Almacenes Set Nombre = @Nombre, defa = @Defa," +
                "SerieVen=@SerieVen," +
                "FolioVen=@FolioVen, " +
                "SerieFac=@SerieFac," +
                "FolioFac=@FolioFac, " +
                "SerieNC=@SerieNC," +
                "FolioNC=@FolioNC " +
                "Where AlmacenId=@AlmacenId";
            return sql;
        }

        public static string AlmacenesQuitaDefault()
        {
            string sql = "";
            sql = "Update Almacenes Set defa = false Where AlmacenId>0";
            return sql;
        }


        public static string AlmacenDelete()
        {
            string sql = "";
            sql = "Delete From Almacenes Where AlmacenId=@AlmacenId";
            return sql;
        }

        public static string AlmacenDefaultSelect()
        {
            string sql = "";
            sql = "Select AlmacenId,Nombre,Defa,SerieVen,FolioVen,SerieFac,FolioFac From Almacenes Where Defa = true";
            return sql;
        }

        public static string AlmacenIncrementaFolioVenta =
            "Update Almacenes Set FolioVen = FolioVen + 1 Where AlmacenId = @AlmacenId";
        public static string AlmacenIncrementaFolioFactura =
            "Update Almacenes Set FolioFac = FolioFac + 1 Where AlmacenId = @AlmacenId";

        public static string AlmacenIncrementaFolioNC =
            "Update Almacenes Set FolioNC = FolioNC + 1 Where AlmacenId = @AlmacenId";

        #endregion

        #region SucursalesAlmacenes
        public static string SucursalAlmacenesSelect = "Select SucAlmaId,SucursalId,AlmacenId,Defa From SucursalesAlmacenes Where SucursalId = @SucursalId";
        #endregion
        #region SucursalesEmisores
        public static string SucursalEmisoresSelect = "Select SucEmiId,SucursalId,EmisorId From SucursalesEmisores Where SucursalId = @SucursalId";
        #endregion

        #region CFDi

        public static string CFDisCanceladosSinCancelarSelect()
        {
            string sql = "Select CfdiId,Serie,Folio,Fecha," +
                "Cfdis.EmisorId,Emisores.RFC As EmisorRFC," +
                "Emisores.Nombre As EmisorNombre," +
                "Cfdis.PacienteId, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cancelado,AcuseCan From cfdis " +
                "Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                "Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                "Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                "Where  " +
                "Fecha BetWeen @FechaIni and @FechaFin And " +
                "Cancelado = true " +
                "And (" +
                "AcuseCan='' or " +
                "AcuseCan is null or " +
                "Position('201',acusecan)=0 and " +
                "Position('202',acusecan)=0) " +
                "Order By Serie,Folio";
            return sql;
        }

        public static string FacturasReporte()
        {
            string sql = "";
            sql = "Select Cfdis.CfdiId,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.FormaPago,Cfdis.MetodoPago,cfdis.UsoCfdi," +
                "Cfdis.IngresoId," +
                "Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre," +
                "Cfdis.Cancelado, cfdis.AcuseCan," +
                "Cfdis.PacienteId, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.SubTotal,Cfdis.IVA, Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.TipoComprobante='I' and " +
                " cfdis.EmisorId = @EmisorId and  Cfdis.Fecha Between @FechaIni and @FechaFin " +
                " Order By cfdis.EmisorId,Cfdis.Serie, Cfdis.Folio,Cfdis.Fecha";
            return sql;


        }

        public static string FacturasSelect()
        {
            string sql = "";
            sql = "Select Cfdis.CfdiId,Cfdis.IngresoId,Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.PacienteId,Cfdis.Cancelado, Cfdis.AcuseCan,Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.SubTotal,Cfdis.IVA, Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.TipoComprobante='I' and " +
                " Cfdis.Emisorid = @Emisorid and Cfdis.Fecha Between @FechaIni and @FechaFin " +
                " Order By Cfdis.Fecha Desc";
            return sql;


        }

        public static string FacturasSelectXRazonSocial=           
           "Select Cfdis.CfdiId,Cfdis.IngresoId,Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.PacienteId,Cfdis.Cancelado, Cfdis.AcuseCan,Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.SubTotal,Cfdis.IVA, Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.TipoComprobante='I' and " +
                " Cfdis.Emisorid = @Emisorid and Cfdis.Fecha Between @FechaIni and @FechaFin " +
                " And Cfdis.RazonSocialId = @RazonSocialId " +
                " Order By Cfdis.Fecha Desc";
           


        


        public static string FacturasSelectxFechas()
        {
            string sql = "";
            sql = "Select Cfdis.CfdiId,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.FormaPago,Cfdis.MetodoPago,cfdis.UsoCfdi," +
                "Cfdis.IngresoId," +
                "Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre," +
                "Cfdis.Cancelado, cfdis.AcuseCan," +
                "Cfdis.PacienteId, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.SubTotal,Cfdis.IVA, Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.TipoComprobante='I' and " +
                " Cfdis.Fecha Between @FechaIni and @FechaFin " +
                " Order By Cfdis.Fecha Desc";
            return sql;


        }

        public static string FacturasSelectxFechasYRazonSocial =        
            "Select Cfdis.CfdiId,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.FormaPago,Cfdis.MetodoPago,cfdis.UsoCfdi," +
                "Cfdis.IngresoId," +
                "Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre," +
                "Cfdis.Cancelado, cfdis.AcuseCan," +
                "Cfdis.PacienteId, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.SubTotal,Cfdis.IVA, Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.TipoComprobante='I' and " +
                " Cfdis.Fecha Between @FechaIni and @FechaFin " +
                " And Cfdis.RazonSocialId = @RazonSocialId " +
                " Order By Cfdis.Fecha Desc";
           


       


        public static string FacturaSelect()
        {
            string sql = "";
            sql = "Select Cfdis.CfdiId,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.FormaPago,Cfdis.MetodoPago,cfdis.UsoCfdi," +
                "Cfdis.IngresoId," +
                "Cfdis.EmisorId,Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre," +
                "Cfdis.UID,Cfdis.Cancelado, cfdis.AcuseCan," +
                "Cfdis.PacienteId, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.CfdiId = @CfdiId";
            return sql;


        }


        public static string CfdiSelect()
        {
            string sql = "";
            sql = "Select Cfdis.CfdiId,Cfdis.IngresoId,Cfdis.EmisorId,Cfdis.FormaPago,Cfdis.MetodoPago, Cfdis.UsoCfdi," +
                "Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.PacienteId,Cfdis.uid, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RFC as ReceptorRFC, RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.SubTotal, Cfdis.IVA,Cfdis.Total,Cfdis.AcuseCan " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where CfdiId = @Id";
            return sql;


        }

        public static string CfdiSelectXSerieYFolio()
        {
            string sql = "";
            sql = "Select Cfdis.CfdiId,Cfdis.IngresoId,Cfdis.EmisorId,Cfdis.FormaPago,Cfdis.MetodoPago, Cfdis.UsoCfdi," +
                "Emisores.RFC As EmisorRFC,Emisores.Nombre As EmisorNombre,Cfdis.Fecha,Cfdis.Serie,Cfdis.Folio," +
                "Cfdis.PacienteId,Cfdis.uid, Pacientes.NombreCompleto As PacienteNombre, " +
                "Cfdis.RazonSocialId,RazonesSociales.RFC as ReceptorRFC, RazonesSociales.RazonSoc as ReceptorNombre," +
                "Cfdis.SubTotal, Cfdis.IVA,Cfdis.Total " +
                "From cfdis " +
                " Left Join Emisores On Cfdis.Emisorid = Emisores.EmisorId " +
                " Left Join Pacientes On Cfdis.Pacienteid = Pacientes.Paciente_Id " +
                " Left Join RazonesSociales On Cfdis.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where Cfdis.Serie = @Serie And Cfdis.Folio=@Folio";
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


        public static string CfdiFiscalUpdate()
        {
            string sql = "";
            sql = "Update Cfdis Set uid = @uid Where CfdiId = @CfdiId";
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
            sql =
                "Select SucursalId,Nombre,DatosAdicionales, SerieIngresos,FolioIngresos," +
                "SerieFacGlobal,FolioFacGlobal,SerieFacPDV,FolioFacPDV," +
                "SerieVentas,FolioVentas,SeriePagos,FolioPagos, CarpetaReportes,Carpetaimagenes,SerieNC,FolioNC " +
                "From  Sucursales Where SucursalId = @SucursalId ";
            return sql;
        }


        public static string SucursalInsert()
        {
            string sql = "";
            sql = "Insert Into " +
                " Sucursales " +
                "(Nombre,DatosAdicionales, SerieIngresos,FolioIngresos,SerieFacGlobal,FolioFacGlobal,SerieFacPDV,FolioFacPDV,SerieVentas,FolioVentas,CarpetaReportes,Carpetaimagenes,SerieNC,FolioNC) " +
                " Values " +
                "(@Nombre,@DatosAdicionales, @SerieIngresos,@FolioIngresos,@SerieFacGlobal,@FolioFacGlobal,@SerieFacPDV,@FolioFacPDV,@SerieVentas,@FolioVentas,@CarpetaReportes,@Carpetaimagenes,@SerieNC,@FolioNC) " +
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
                "FolioIngresos=@FolioIngresos, " +
                "SerieFacGlobal=@SerieFacGlobal," +
                "FolioFacGlobal=@FolioFacGlobal, " +
                "SerieFacPDV=@SerieFacPDV," +
                "FolioFacPDV=@FolioFacPDV, " +
                "SerieVentas=@SerieVentas," +
                "FolioVentas=@FolioVentas, " +
                "CarpetaReportes= CarpetaReportes," +
                "Carpetaimagenes= @CarpetaImagenes, " +
                "SerieNC = @SerieNC," +
                "FolioNC = @FolioNC " +
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


        public static string
            SucursalSetSiguienteFolioNC = "Update Sucursales Set FolioNC = FolioNC + 1 Where SucursalId = @SucursalId ";



        public static string SucursalSetSiguienteFolioIngresos()
        {
            string sql = "";
            sql = "update Sucursales Set FolioIngresos = FolioIngresos + 1 Where SucursalId = @SucursalId ";
            return sql;
        }

        public static string SucursalSetSiguienteFolioGlobal()
        {
            string sql = "";
            sql = "update Sucursales Set FolioFacGlobal = FolioFacGlobal + 1 Where SucursalId = @SucursalId ";
            return sql;
        }

        public static string SucursalSetSiguienteFolioFacPDV =
                "update Sucursales Set FolioFacPDV = FolioFacPDV + 1 Where SucursalId = @SucursalId ";

        public static string SucursalSetSiguienteFolioVentas =
                "update Sucursales Set FolioVentas = FolioVentas + 1 Where SucursalId = @SucursalId ";

        public static string SucursalSetSiguienteFolioPagos =
        "update Sucursales Set FolioPagos = FolioPagos + 1 Where SucursalId = @SucursalId ";


        #endregion
        #region Ingresos

        public static string IngresoSetFacturado = "Update Ingresos Set FacturaGlobalId = @CFDiId Where IngresoId = @IngresoId";

        public static string IngresosNoFacturadosSelect()
        {
            string sql = "";
            sql =
                "Select CFDis.EmisorId as CFDiEmisorId, CFDis.CFDiId, CFDis.SERIE, CFDis.FOLIO," +
                "Ingresos.IngresoId, Ingresos.Serie as TicketSerie,Ingresos.folio as TicketFolio, " +
                "Ingresos.Fecha, Ingresos.SubTotal, Ingresos.Impuesto, Ingresos.Total " +
                "from Ingresos " +
                "Left join cfdis On cfdis.ingresoid = Ingresos.IngresoId " +
                "Where Ingresos.Cancelado = false " +
                "And Ingresos.FacturaGlobalId = 0 " +
                "and CFDis.CFDiId is null " +
                "and Ingresos.EmisorId =@EmisorId " +
                "And Ingresos.Fecha Between @FechaIni and @FechaFin";
            return sql;
        }
        public static string IngresoSelect()
        {
            string sql = "";
            sql = " Select IngresoId,EmisorId,Tipo,SucursalId,Serie,Folio,Fecha,Hora,PacienteId,Pacientes.NombreCompleto as PacienteNombre, " +
                "Ingresos.RazonSocialId,Ingresos.CveFOP,Ingresos.CveMEP, Ingresos.CveUSO,RazonesSociales.RazonSoc,SubTotal,Impuesto,Descuento," +
                "RetIVA,RetISR,Total,Cancelado,WebId,FacturaGlobalId " +
                "From  Ingresos " +
                " Left Join Pacientes On Ingresos.PacienteId = Pacientes.Paciente_Id " +
                " Left Join razonesSociales On Ingresos.RazonSocialId = RazonesSociales.RazonSocialId " +
                "Where IngresoId = @IngresoId";
            return sql;
        }

        public static string IngresoCancelar()
        {
            string sql = "Update Ingresos set Cancelado = true Where IngresoId = @IngresoId";
            return sql;
        }

        public static string IngresoUpdateFacturacion()
        {
            string sql = "";
            sql = "Update Ingresos Set " +
                "RazonSocialId = @RazonSocialId," +
                "CveFOP = @CveFop," +
                "CveMEP = @CveMEP," +
                "CveUSO = @CveUso " +
                "Where IngresoId = @IngresoId";
            return sql;
        }


        public static string IngresoFacturado()
        {
            string sql = "Select * from Cfdis Where IngresoId = @IngresoId";
            return sql;
        }

        public static string IngresosSelectxSucursalYFechas()
        {
            string sql = "";
            sql = " Select IngresoId,Tipo,SucursalId,Serie,Folio,Fecha,Hora,PacienteId,Pacientes.NombreCompleto as PacienteNombre, " +
                "Ingresos.RazonSocialId,Ingresos.CveFOP,Ingresos.CveMEP, Ingresos.CveUSO,RazonesSociales.RazonSoc,SubTotal,Impuesto,Descuento,RetIVA,RetISR,Total,Cancelado,WebId " +
                "From  Ingresos " +
                " Left Join Pacientes On Ingresos.PacienteId = Pacientes.Paciente_Id " +
                " Left Join razonesSociales On Ingresos.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where  " +
                " Ingresos.SucursalId = @SucursalId " +
                " And Tipo = @Tipo " +
                " And Ingresos.Fecha Between @FechaInicial and @FechaFinal ";
            return sql;
        }

        public static string IngresosSelectxSucursalFechasYRazonSocial = 
            " Select IngresoId,Tipo,SucursalId,Serie,Folio,Fecha,Hora,PacienteId,Pacientes.NombreCompleto as PacienteNombre, " +
                "Ingresos.RazonSocialId,Ingresos.CveFOP,Ingresos.CveMEP, Ingresos.CveUSO,RazonesSociales.RazonSoc,SubTotal,Impuesto,Descuento,RetIVA,RetISR,Total,Cancelado,WebId " +
                "From  Ingresos " +
                " Left Join Pacientes On Ingresos.PacienteId = Pacientes.Paciente_Id " +
                " Left Join razonesSociales On Ingresos.RazonSocialId = RazonesSociales.RazonSocialId " +
                " Where  " +
                " Ingresos.SucursalId = @SucursalId " +
                " And Tipo = @Tipo " +
                " And Ingresos.Fecha Between @FechaInicial and @FechaFinal " +
                " And Ingresos.RazonSocialId = @RazonSocialId";
           
         

        public static string IngresoInsert()
        {
            string sql = "";
            sql = "Insert Into Ingresos " +
                "(SucursalId,Emisorid,Tipo,Serie,Folio,PacienteId,RazonSocialId,CveFOP,CveMEP, CveUSO,Fecha,Hora,SubTotal,Impuesto,Descuento,RetIVA,RetISR,Total,Cancelado,WebId,FacturaGlobalId)" +
                " values " +
                "(@SucursalId,@EmisorId,@Tipo,@Serie,@Folio,@PacienteId,@RazonSocialId,@CveFOP,@CveMEP,@CveUSO,@Fecha,@Hora,@SubTotal,@Impuesto,@Descuento,@RetIVA,@RetISR,@Total,@Cancelado,@WebId,@FacturaGlobalId)" +
                " Returning IngresoId";
            return sql;
        }

        public static string IngresoDetalleInsert()
        {
            string sql = "";
            sql = "Insert Into IngresosDetalle " +
                "(IngresoId,ArticuloId,Clave,Descripcion,UDM,Cantidad,Precio,CveProSer,CveUni,PorceDes,Descuento,BaseIVA,TipoIVA,TasaIVA,IVA,BaseRetISR,PorceRetISR,RetISR,PorceRetIVA,RetIVA,EmisorId,Serie)" +
                " values " +
                "(@IngresoId,@ArticuloId,@Clave,@Descripcion,@UDM,@Cantidad,@Precio,@CveProSer,@CveUni,@PorceDes,@Descuento,@BaseIVA,@TipoIVA,@TasaIVA,@IVA,@BaseRetISR,@PorceRetISR,@RetISR,@PorceRetIVA,@RetIVA,@EmisorId,@Serie) " +
                " Returning IngresoDetalleId";
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
            sql = "Insert Into PacientesImagenes (PacienteId,RutaImagen,Fecha,DiagnosticoId,PalabrasClave) Values " +
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

        public static string RazonesSocialesBuscar()
        {
            string sql = "";
            sql = "Select RazonSocialId,RFC,RazonSoc,Direccion,LocalidadId,CiudadId,EstadoId,PaisId,CP,CveRef,CveUso,CveFop,Cvemep,Email From RazonesSociales" +
                " Where Upper(RFC) like @Buscar Or Upper(RazonSoc) Like @Buscar";
            return sql;
        }


        public static string RazonSocialSelectXRFC()
        {
            string sql = "";
            sql = "Select RazonSocialId,RFC,RazonSoc,Direccion,LocalidadId,CiudadId,EstadoId,PaisId,CP,CveRef,CveUso,CveFop,Cvemep,Email From RazonesSociales" +
                " Where RFC=@RFC";
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

        public static string RazonSocialTieneIngresos =
            "Select Count(*) From Ingresos Where RazonSocialId=@RazonSocialId";

        public static string RazonSocialTieneCFDis =
            "Select Count(*) From Cfdis Where RazonSocialId=@RazonSocialId";

        public static string RazonSocialDelete = "Delete From RazonesSociales Where RazonSocialId=@RazonSocialId";

       
       



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

        public static string SerieConceptosDelete()
        {
            string sql = "";
            sql = "Delete From SeriesConceptos Where SerieId = @SerieId";
            return sql;
        }


        #endregion
        #region Articulos

        public static string ArticulosSinCostoSelect =
            "Select ArticuloId, Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
                "Where Costo = 0 " +
                "Order By Descripcion";

        public static string ArticulosSelectxDes =
            "Select ArticuloId, Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
                "Where UPPER(Descripcion) LIKE @Filtro " +
                "Order By Descripcion";

        public static string ArticulosSelectxDesYTipo =
            "Select ArticuloId, Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
                "Where Tipo = @Tipo And UPPER(Descripcion) LIKE @Filtro " +
                "Order By Descripcion";


        public static string ArticulosSelectBuscar()
        {
            string sql = "";
            sql = "Select ArticuloId, Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5,FechaUltimaCompra, " +

                "CveProSer,CveUni,Articulos.ImpuestoId,MarcaId,LineaId,Impuestos.Porcentaje as PorceIVA " +
                "From Articulos " +
                "Inner Join Impuestos on Articulos.ImpuestoId = Impuestos.ImpuestoId " +
                " Where Articulos.Descripcion Like @Buscar Or Upper(Clave) like @Buscar Or Upper(CodiGoBarras) like @Buscar" +
                " Order By Descripcion";
            return sql;
        }

        public static string ArticuloSelectEnSeriesConceptos()
        {
            string sql = "";
            sql = "Select First 1 ArticuloId From SeriesConceptos Where ArticuloId = @ArticuloId";
            return sql;
        }


        public static string
            ArticulosSelectxClaveDescripcionCodigo =
            "Select ArticuloId, Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
            "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
            "Where UPPER(Clave) LIKE @Filtro OR UPPER(Descripcion) LIKE @Filtro OR UPPER(CodigoBarras) LIKE @Filtro " +
            "Order By Descripcion";

        public static string ArticulosSelect()
        {
            string sql = "";
            sql = "Select ArticuloId, Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,SKU,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos Order By Descripcion";
            return sql;
        }
        public static string ArticuloSelect()
        {
            string sql = "";
            sql = "Select ArticuloId,Clave,CodigoBarras,Articulos.Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5,FechaUltimaCompra," +
                "CveProSer,CveUni,SKU,Articulos.ImpuestoId,MarcaId,LineaId,Impuestos.Porcentaje as PorceIVA From Articulos " +
                "Left Join Impuestos On Articulos.ImpuestoId = Impuestos.ImpuestoId " +
                "Where ArticuloId=@ArticuloId";
            return sql;
        }

        public static string ArticuloSelectXSKU = 
            "Select ArticuloId,Clave,CodigoBarras,Articulos.Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5,FechaUltimaCompra," +
                "CveProSer,CveUni,SKU,Articulos.ImpuestoId,MarcaId,LineaId,Impuestos.Porcentaje as PorceIVA From Articulos " +
                "Left Join Impuestos On Articulos.ImpuestoId = Impuestos.ImpuestoId " +
                "Where SKU=@SKU";

        public static string ArticulosSelectBetweenDescripciones
        {
            get
            {
                return "Select ArticuloId,Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
                "Where Descripcion Between @DescripcionInicial And @DescripcionFinal";
            }
        }

        public static string ArticuloSelectxClave()
        {
            string sql = "";
            sql = "Select ArticuloId,Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
                "Where Clave=@Clave";
            return sql;
        }

        public static string ArticuloSelectxCodigo =
            "Select ArticuloId,Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
                "Where CodigoBarras=@CodigoBarras";

        public static string ArticuloSelectExisteClave
            = "Select ArticuloId,Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
                "Where ArticuloId <> @ArticuloId And Clave=@Clave";

        public static string ArticuloSelectExisteCodigo =
            "Select ArticuloId,Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra From Articulos " +
                "Where ArticuloId <> @ArticuloId And  CodigoBarras=@CodigoBarras";


        public static string ArticuloInsert()
        {
            string sql = "";
            sql = "Insert Into Articulos (Clave,CodigoBarras,Descripcion,Tipo,UDM,Moneda,Costo,Precio1,Precio2,Precio3,Precio4,Precio5," +
                "CveProSer,CveUni,ImpuestoId,MarcaId,LineaId,FechaUltimaCompra,SKU) " +
                "values " +
                "(@Clave,@CodigoBarras,@Descripcion,@Tipo,@UDM,@Moneda,@Costo,@Precio1,@Precio2,@Precio3,@Precio4,@Precio5," +
                "@CveProSer,@CveUni,@ImpuestoId,@MarcaId,@LineaId,@FechaUltimaCompra,@SKU) Returning ArticuloId";
            return sql;
        }

        public static string ArticuloUpdate()
        {
            string sql = "";
            sql = "Update Articulos Set " +
                "Clave=@Clave," +
                "CodigoBarras=@CodigoBarras," +
                "SKU=@SKU," +
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
                "LineaId=@LineaId," +
                "FechaUltimaCompra = @FechaUltimaCompra " +
                " Where ArticuloId=@ArticuloId";
            return sql;
        }
        public static string ArticuloSKUUpdate
             = "Update Articulos Set " +
                "SKU=@SKU " +
                " Where ArticuloId=@ArticuloId";

        public static string ArticulosInit = "Delete From Articulos Where ArticuloId>0";
        public static string ArticuloDelete()
        {
            string sql = "";
            sql = "Delete from Articulos Where ArticuloId=@ArticuloId";
            return sql;
        }

        public static string
            ArticuloUpdateFechaUltimaCompra = "Update Articulos Set FechaUltimaCompra = @FechaUltimaCompra Where ArticuloId = @ArticuloId";
        public static string
              ArticuloUpdateCosto = "Update Articulos Set Costo = @Costo Where ArticuloId = @ArticuloId";
        public static string
            ArticuloUltimoCostoFromCompras = "Select Fecha,Importe as Costo From ArticulosMovimientos Desc" +
            " Where AlmacenId=@AlmacenId and ArticuloId = @ArticuloId And  ConceptoId = @ConceptoId And Fecha <=@Fecha And Importe>1";
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
                " Where EmisorId=@EmisorId And SerieDocId <> @SerieDocId ";
            return sql;
        }


        public static string SerieDocDelete()
        {
            string sql = "";
            sql = "Delete From SeriesDocs" +
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
            sql = "Select EmisorId,RFC,Nombre,Direccion,Colonia,CiudadId,EstadoId,Paisid,CP,CveRef,Certificado,LlavePrivada,PassWord,Defa,PDV" +
                " From Emisores Order by Nombre";
            return sql;
        }

        public static string
            EmisoresPDVSelect = "Select EmisorId,RFC,Nombre,Direccion,Colonia,CiudadId,EstadoId,Paisid,CP,CveRef,Certificado,LlavePrivada,PassWord,Defa,PDV" +
                " From Emisores Where PDV = True and Defa = True";

        public static string
    EmisoresNoPDVSelect = "Select EmisorId,RFC,Nombre,Direccion,Colonia,CiudadId,EstadoId,Paisid,CP,CveRef,Certificado,LlavePrivada,PassWord,Defa,PDV" +
        " From Emisores Where PDV = false";

        public static string EmisorSelect()
        {
            string sql = "";
            sql = "Select EmisorId,RFC,Nombre,Direccion,Colonia,CiudadId,EstadoId,Paisid,CP,CveRef,Certificado,LlavePrivada,PassWord,Defa,PDV,Cer,Llave" +
                " From Emisores Where EmisorId = @EmisorId";
            return sql;
        }

        public static string EmisorInsert()
        {
            string sql = "";
            sql = "Insert Into Emisores (RFC,Nombre,Direccion,Colonia,CiudadId,EstadoId,Paisid,CP,CveRef,Certificado,LlavePrivada,PassWord,Defa,PDV)" +
                " Values " +
                "(@RFC,@Nombre,@Direccion,@Colonia,@CiudadId,@EstadoId,@Paisid,@CP,@CveRef,@Certificado,@LlavePrivada,@PassWord,@Defa,@PDV)" +
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
                "Defa=@Defa," +
                "PDV=@PDV " +
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

        public static string RecetasDoctorSelect()
        {
            string sql = "Select PacienteRecetaId,PacienteId,Fecha,Texto,Etiquetas,UsuarioId From PacienteRecetas Where UsuarioId = @UsuarioId Order By Fecha desc,PacienteRecetaId Desc";
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
        public static string DoctorSelectXUsuario()
        {
            string sql;
            sql = "Select Doctor_Id,Nombres,Apellido_Paterno,Apellido_Materno,Correos,Telefonos,CedProf,CedEsp,Curriculum,UsuarioId,MostrarEnConsultaAgenda From Doctores ";
            sql += " Where UsuarioId = @UsuarioId";
            return sql;

        }

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
                "DiagnosticoId,PielId,SolarId,MedicoId,MaquillajeId,Medicamentos,Alergias,Antecedentes,Origen,PassWord,Observaciones From Pacientes ";
            sql += " Where Paciente_Id = @Paciente_Id";
            return sql;

        }
        public static string PacienteConsultaSelect()
        {
            string sql;
            sql = "Select Paciente_Id,Nombres,Apellido_Paterno,Apellido_Materno,Sexo,Fecha_Nacimiento,Telefonos,Correos," +
                "EdoCivilId,OcupacionId,ReferenteId," +
                "CiudadOrigenId,Direccion,Colonia,LocalidadId,CiudadId,EstadoId,PaisId,CP," +
                "DiagnosticoId,PielId,SolarId,MedicoId,MaquillajeId,Medicamentos,Alergias,Antecedentes,Origen,PassWord,Observaciones From Pacientes ";
            sql += " Where Paciente_Id = @Paciente_Id";
            return sql;

        }

        public static string PacienteInsert()
        {
            string sql;
            sql = "Insert into Pacientes (Nombres,Apellido_Paterno,Apellido_Materno,Sexo,Fecha_Nacimiento,Telefonos,Correos,EdoCivilId,OcupacionId,ReferenteId," +
                "CiudadOrigenId,Direccion,Colonia,LocalidadId,CiudadId,EstadoId,PaisId,CP," +
                "DiagnosticoId,PielId,SolarId,MedicoId,MaquillajeId,Medicamentos,Alergias,Antecedentes,Origen,PassWord,Observaciones,FechaHoraCreacion,UsuarioCreacionId) values " +
                "(@Nombres,@Apellido_Paterno,@Apellido_Materno,@Sexo,@Fecha_Nacimiento,@Telefonos,@Correos,@EdoCivilId,@OcupacionId,@ReferenteId," +
                "@CiudadOrigenId,@Direccion,@Colonia,@LocalidadId,@CiudadId,@EstadoId,@PaisId,@CP," +
                "@DiagnosticoId,@PielId,@SolarId,@MedicoId,@MaquillajeId,@Medicamentos,@Alergias,@Antecedentes,@Origen,@PassWord,@Observaciones,@FechaHoraCreacion,@UsuarioCreacionId) Returning Paciente_Id";
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
                   "Observaciones=@Observaciones," +
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
            string sql = "";
            sql =
                "Select Paciente_Id,NombreCompleto,Fecha_Nacimiento,EdosCiviles.Descripcion as EdoCivil," +
                "Ocupaciones.Descripcion as Ocupacion,Referentes.Descripcion as Referente," +
                "CiudadesOr.Descripcion as CiudadOri,Direccion,Colonia,Localidades.Descripcion as Localidad," +
                "Ciudades.Descripcion as Ciudad,Estados.Descripcion as Estado,Paises.Descripcion as Pais,Cp," +
                "Diagnosticos.Descripcion as Diagnostico,Pieles.Descripcion as Piel,Exposiciones.Descripcion as ExpSolar," +
                "Medicos.Descripcion as Medico,Maquillajes.Descripcion as Maquillaje,Medicamentos," +
                "Alergias,Antecedentes,Origen,Telefonos,Correos,Observaciones " +
                "From Pacientes " +
                "Left Join Descripciones EdosCiviles on Pacientes.EdoCivilId = EdosCiviles.Descripcion_Id " +
                "Left Join Descripciones Ocupaciones on Pacientes.OcupacionId = Ocupaciones.Descripcion_Id " +
                "Left Join Descripciones Referentes on Pacientes.ReferenteId = Referentes.Descripcion_Id " +
                "Left Join Descripciones CiudadesOr on Pacientes.CiudadOrigenId = CiudadesOr.Descripcion_Id " +
                "Left Join Descripciones Localidades on Pacientes.LocalidadId = Localidades.Descripcion_Id " +
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
            string sql = "";

            sql = "Select Parametro_Id,SysPassword,ColorCitaLetra,ColorCitaFondo,ColorMultipleLetra,ColorMultipleFondo," +
                "ColorBloqueoLetra,ColorBloqueoFondo,ColorConfirmadoLetra,ColorConfirmadoFondo,ColorAsistioLetra,ColorAsistioFondo " +
                "From Parametros";

            return sql;

        }

        public static string ParametroUpdate()
        {
            string sql = "";

            sql = "Update Parametros Set " +
                "SysPassword = @SysPassword," +
                "ColorCitaLetra= @ColorCitaLetra," +
                "ColorCitaFondo=@ColorCitaFondo," +
                "ColorMultipleLetra = @ColorMultipleLetra," +
                "ColorMultipleFondo = @ColorMultipleFondo," +
                "ColorBloqueoLetra = @ColorBloqueoLetra," +
                "ColorBloqueoFondo = @ColorBloqueoFondo," +
                "ColorConfirmadoLetra=@ColorConfirmadoLetra," +
                "ColorConfirmadoFondo = @ColorConfirmadoFondo," +
                "ColorAsistioLetra = @ColorAsistioLetra," +
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
        public static string CitaWEBInsert()
        {
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

        public static string CitaSelect()
        {
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
        " Values " +
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
            string sql = "";
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

        public static string CitaDelete()
        {
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
            sql = "Select Empresa_Id,Nombre,Direccion,Colonia,Localidad,Cp,Ciudad,Estado,Pais,Telefonos,Correos,Logotipo," +
                "AvisosServidor,AvisosUsuario,AvisosPassword,AvisosCuenta,AvisosSSL,AvisosPuerto,CarpetaReportes,IncImpVta From DatosEmpresa";
            return sql;
        }

        public static string DatosEmpresaInsert()
        {
            string sql = "";
            sql = "Insert Into DatosEmpresa(Nombre,Direccion,Colonia,Localidad,Cp,Ciudad,Estado,Pais,Telefonos,Correos,Logotipo," +
                "AvisosServidor,AvisosUsuario,AvisosPassword,AvisosCuenta,AvisosSSL,AvisosPuerto,CarpetaReportes,IncImpVta) Values " +
                "(@Nombre,@Direccion,@Colonia,@Localidad,@Cp,@Ciudad,@Estado,@Pais,@Telefonos,@Correos,@Logotipo," +
                "@AvisosServidor,@AvisosUsuario,@AvisosPassword,@AvisosCuenta,@AvisosSSL,@AvisosPuerto,@CarpetaReportes,@IncImpVta) Returning Empresa_Id";
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
                "CarpetaReportes =@CarpetaReportes," +
                "IncImpVta = @IncImpVta " +
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
                "WebServiceURL,CarpetaWEB,BddWEB,CopiarWEB,CarpetaReportes,CarpetaImagenes,IncImpVta From Empresas Where Empresa_Id=@Empresa_Id";
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
