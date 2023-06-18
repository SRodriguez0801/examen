using System;
using System.Collections.Generic;
using System.Text;

namespace Electrodomestico.Models
{
    [Serializable]
    public class VideoJuegos : Electrodomesticos
    {
        public string Nombre_Juego { get; set; }
        public string Empresa_Creadora { get; set; }
        public List<DateTime> FechasMantenimiento { get; } = new List<DateTime>();  // Inicialización de la colección

        public VideoJuegos(string Nombre, string Modelo, DateTime FechaLanzamiento,
            string Voltaje, decimal PrecioCompra, string nombrejuego, string empresacreadora)
            : base(Nombre, Modelo, FechaLanzamiento, Voltaje, PrecioCompra)
        {
            Nombre_Juego = nombrejuego;
            Empresa_Creadora = empresacreadora;
        }

        public VideoJuegos(string Nombre, string Modelo, DateTime FechaLanzamiento, string Voltaje, decimal PrecioCompra, decimal precioVenta, string nombrejuego, string empresacreadora) : 
            base(Nombre, Modelo, FechaLanzamiento, Voltaje, PrecioCompra, precioVenta)
        {
            Nombre_Juego = nombrejuego;
            Empresa_Creadora = empresacreadora;
        }
        public VideoJuegos() { }
        public void AgregarMantenimiento(DateTime fecha)
        {
            FechasMantenimiento.Add(fecha);
        }

        public override void CalcularPrecioVenta()
        {
            PrecioVenta = PrecioCompra * 1.50m;
        }

    }
}
