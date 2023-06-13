using System;
using System.Collections.Generic;

namespace Electrodomestico.Models
{
    [Serializable]
    public class Electrodomesticos
    {

        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string Voltaje { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public List<DateTime> Mantenimientos { get; set; }

        public Electrodomesticos() { }

        public Electrodomesticos(string nombre, string modelo, DateTime fechaLanzamiento, string voltaje, decimal precioCompra, decimal precioVenta)
        {
            Nombre = nombre;
            Modelo = modelo;
            FechaLanzamiento = fechaLanzamiento;
            Voltaje = voltaje;
            PrecioCompra = precioCompra;
            PrecioVenta = precioVenta;
            Mantenimientos = new List<DateTime>();
        }

        public Electrodomesticos(string nombre, string modelo, DateTime fechaLanzamiento, string voltaje, decimal precioCompra)
        {
            Nombre = nombre;
            Modelo = modelo;
            FechaLanzamiento = fechaLanzamiento;
            Voltaje = voltaje;
            PrecioCompra = precioCompra;
            PrecioVenta = 0;
            Mantenimientos = new List<DateTime>();
        }

        public virtual void CalcularPrecioVenta()
        {

        }

    }
}

