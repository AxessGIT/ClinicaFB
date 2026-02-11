using System;
namespace ClinicaFB.Modelo
{
    public class CapaDeCosto
    {
        public long CapaId { get; set; }
        public long ArticuloId { get; set; }
        public long SucursalId { get; set; }
        public long AlmacenId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoDoc { get; set; }
        public long DocumentoId { get; set; } // ID de la compra/venta/ajuste
        public decimal CantidadInicial { get; set; }
        public decimal CantidadDisponible { get; set; } // Cantidad que aún no se ha consumido
        public decimal CostoUnitario { get; set; }
        public bool Negativa { get; set; }
        public bool Activa { get; set; }
        public bool Agotada => CantidadDisponible <= 0;
        public decimal ValorDisponible => CantidadDisponible * CostoUnitario;
    }
}