using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Electrodomestico.Models
{
    [Serializable]
    public class Estufa : Electrodomesticos
    {
        public int cantidad_Ornillas { get; set; }

        public List<DateTime> FechasMantenimiento { get; } = new List<DateTime>();  // Inicialización de la colección

        public Estufa(string Nombre, string Modelo, DateTime FechaLanzamiento, String Voltaje, decimal PrecioCompra,
            int cantidadOrnillas, decimal PrecioVenta)
            : base(Nombre, Modelo, FechaLanzamiento, Voltaje, PrecioCompra, PrecioVenta)
        {
            cantidad_Ornillas = cantidadOrnillas;
        }

        public Estufa(string Nombre, string Modelo, DateTime FechaLanzamiento, String Voltaje, decimal PrecioCompra, decimal precioVenta, int cantidadOrnillas) 
            : base(Nombre, Modelo, FechaLanzamiento, Voltaje, PrecioCompra, precioVenta)
        {
            cantidad_Ornillas = cantidadOrnillas;

        }
        public Estufa() { }
        public void AgregarMantenimiento(DateTime fecha)
        {
            FechasMantenimiento.Add(fecha);
        }

        public override void CalcularPrecioVenta()
        {
            PrecioVenta = PrecioCompra * 1.45m;
        }
       

    }
}
