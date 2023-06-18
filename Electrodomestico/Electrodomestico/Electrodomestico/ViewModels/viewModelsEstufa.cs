using Electrodomestico.Models;
using Electrodomestico.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Electrodomestico.ViewModels
{
    public class viewModelsEstufa : INotifyPropertyChanged
    {
        public List<DateTime> FechasMantenimiento { get; } = new List<DateTime>();


        public Command AgregarEstufa { get; }

        public viewModelsEstufa()
        {
            // Rutina para abrir el archivo de lista de celulares
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "celulares.bin");
            try
            {
                if (File.Exists(ruta))
                {
                    // Abrir y leer el archivo
                    byte[] data = File.ReadAllBytes(ruta);
                    MemoryStream memory = new MemoryStream(data);
                    BinaryFormatter formatter = new BinaryFormatter();
                    listaEstufa = (ObservableCollection<Models.Estufa>)formatter.Deserialize(memory);
                    memory.Close();
                }
                else
                {
                    // El archivo no existe, se crea una nueva lista vacía
                    listaEstufa = new ObservableCollection<Models.Estufa>();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción al abrir el archivo
                // Aquí puedes agregar tu lógica personalizada para manejar el error
                Console.WriteLine("Error al abrir el archivo: " + ex.Message);
                listaEstufa = new ObservableCollection<Models.Estufa>();
            }
            AgregarEstufa = new Command(async () =>
            {
                Models.Estufa estufa = new Models.Estufa()
                {
                    Nombre = this.Nombre,
                    Modelo = this.Modelo,
                    FechaLanzamiento = this.FechaLanzamiento,
                    Voltaje = this.Voltaje,
                    PrecioCompra = this.PrecioCompra,
                    cantidad_Ornillas = this.cantidad_Ornillas

                };
                CalcularPrecioVenta(estufa);
                listaEstufa.Add(estufa);
                AgregarMantenimiento(DateTime.Now);

                ResultadoEstufa = estufa;

                // Rutina para serializar la lista de celulares
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (MemoryStream memory = new MemoryStream())
                    {
                        formatter.Serialize(memory, listaEstufa);
                        byte[] serializedData = memory.ToArray();
                        File.WriteAllBytes(ruta, serializedData);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción al serializar y guardar en el archivo
                    // Aquí puedes agregar tu lógica personalizada para manejar el error
                    Console.WriteLine("Error al guardar en el archivo: " + ex.Message);
                }

                LimpiarCampos();

                //nos dirije a otra pagina
                var pagina1 = new viewResultadoCelular();
                await Application.Current.MainPage.Navigation.PushAsync(pagina1);

            });
        }

            public void AgregarMantenimiento(DateTime fecha)
            {
                if (listaEstufa.Count > 0)
                {
                listaEstufa[listaEstufa.Count - 1].FechasMantenimiento.Add(fecha);
                }
            }

        public ObservableCollection<Models.Estufa> listaEstufa { get; set; }

        string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }
        string modelo;
        public string Modelo
        {   get => modelo;
            set
            {
                modelo = value;
                OnPropertyChanged(nameof(Modelo));
            }
        }

        DateTime fechaLanzamiento;
        public DateTime FechaLanzamiento
        {
            get => fechaLanzamiento;
            set
            {
                fechaLanzamiento = value;
                OnPropertyChanged(nameof(FechaLanzamiento));
            }
        }

        string voltaje;
        public string Voltaje
        {
            get => voltaje;
            set
            {
                voltaje = value;
                OnPropertyChanged(nameof(Voltaje));
            }
        }

        decimal precioCompra;
        public decimal PrecioCompra
        {
            get => precioCompra;
            set
            {
                precioCompra = value;
                OnPropertyChanged(nameof(PrecioCompra));
            }
        }

        int cantidad_ornillas;
        public int cantidad_Ornillas
        {
            get => cantidad_ornillas;
            set
            {
                cantidad_ornillas = value;
                OnPropertyChanged(nameof(cantidad_Ornillas));
            }
        }
        Models.Estufa resultadoEstufa;
        public Models.Estufa ResultadoEstufa
        {
            get => resultadoEstufa;
            set
            {
                resultadoEstufa = value;
                OnPropertyChanged(nameof (ResultadoEstufa));
            }
        }
        public void LimpiarCampos()
        {
            Nombre = string.Empty;
            Modelo = string.Empty;
            FechaLanzamiento = DateTime.MinValue;
            Voltaje = string.Empty;
            PrecioCompra = 0.0m;

        }
        public void CalcularPrecioVenta(Models.Estufa estufa)
        {
            estufa.PrecioVenta = estufa.PrecioCompra * 1.45m;
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
