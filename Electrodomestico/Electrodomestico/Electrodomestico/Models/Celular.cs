using System;

using System.Collections.Generic;

namespace Electrodomestico.Models
{
    [Serializable]
    public class Celular : Electrodomesticos
    {

        public string SistemaOperativo { get; set; }
        public string OperadorRed { get; set; }
        public List<DateTime> FechasMantenimiento { get; } = new List<DateTime>();  // Inicialización de la colección

        public Celular(string nombre, string modelo, DateTime fechaLanzamiento, string voltaje, decimal precioCompra, string sistemaOperativo, string operadorRed, decimal precioVenta)
            : base(nombre, modelo, fechaLanzamiento, voltaje, precioCompra, precioVenta)
        {
            SistemaOperativo = sistemaOperativo;
            OperadorRed = operadorRed;
        }

        public Celular(string nombre, string modelo, DateTime fechaLanzamiento, string voltaje, decimal precioCompra, decimal precioVenta, string sistemaOperativo, string operadorRed)
            : base(nombre, modelo, fechaLanzamiento, voltaje, precioCompra, precioVenta)
        {
            SistemaOperativo = sistemaOperativo;
            OperadorRed = operadorRed;
        }

        public Celular()
        {

        }

        public void AgregarMantenimiento(DateTime fecha)
        {
            FechasMantenimiento.Add(fecha);
        }

        public override void CalcularPrecioVenta()
        {
            PrecioVenta = PrecioCompra * 1.35m;
        }

    }

}

