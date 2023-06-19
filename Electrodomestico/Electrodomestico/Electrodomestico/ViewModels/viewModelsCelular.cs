using Electrodomestico.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;
using Xamarin.Forms;

namespace Electrodomestico.ViewModels
{
    public class ViewModelsCelular : INotifyPropertyChanged
    {
        public List<DateTime> FechasMantenimiento { get; } = new List<DateTime>();

       
        public Command AgregarCelular { get; }

        public ViewModelsCelular()
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
                    listaCelulares = (ObservableCollection<Models.Celular>)formatter.Deserialize(memory);
                    memory.Close();
                }
                else
                {
                    // El archivo no existe, se crea una nueva lista vacía
                    listaCelulares = new ObservableCollection<Models.Celular>();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción al abrir el archivo
                // Aquí puedes agregar tu lógica personalizada para manejar el error
                Console.WriteLine("Error al abrir el archivo: " + ex.Message);
                listaCelulares = new ObservableCollection<Models.Celular>();
            }

            AgregarCelular = new Command(async () =>
            {
                Models.Celular celular = new Models.Celular()
                {
                    Nombre = this.Nombre,
                    Modelo = this.Modelo,
                    FechaLanzamiento = this.FechaLanzamiento,
                    Voltaje = this.Voltaje,
                    PrecioCompra = this.PrecioCompra,
                    SistemaOperativo = this.SistemaOperativo,
                    OperadorRed = this.OperadorRed
                };

                CalcularPrecioVenta(celular);
                listaCelulares.Add(celular);
                AgregarMantenimiento(DateTime.Now);

                ResultadoCelular = celular;

                // Rutina para serializar la lista de celulares
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (MemoryStream memory = new MemoryStream())
                    {
                        formatter.Serialize(memory, listaCelulares);
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

                var pagina = new viewResultadoCelular();
                await Application.Current.MainPage.Navigation.PushAsync(pagina);

            });

          

        }

        public void AgregarMantenimiento(DateTime fecha)
        {
            if (listaCelulares.Count > 0)
            {
                listaCelulares[listaCelulares.Count - 1].FechasMantenimiento.Add(fecha);
            }
        }

        public ObservableCollection<Models.Celular> listaCelulares { get; set; }

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
        {
            get => modelo;
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

        string sistemaOperativo;
        public string SistemaOperativo
        {
            get => sistemaOperativo;
            set
            {
                sistemaOperativo = value;
                OnPropertyChanged(nameof(SistemaOperativo));
            }
        }

        string operadorRed;
        public string OperadorRed
        {
            get => operadorRed;
            set
            {
                operadorRed = value;
                OnPropertyChanged(nameof(OperadorRed));
            }
        }

        Models.Celular resultadoCelular;
        public Models.Celular ResultadoCelular
        {
            get => resultadoCelular;
            set
            {
                resultadoCelular = value;
                OnPropertyChanged(nameof(ResultadoCelular));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LimpiarCampos()
        {
            Nombre = string.Empty;
            Modelo = string.Empty;
            FechaLanzamiento = DateTime.MinValue;
            Voltaje = string.Empty;
            PrecioCompra = 0.0m;
        }

        public void CalcularPrecioVenta(Models.Celular celular)
        {
            celular.PrecioVenta = celular.PrecioCompra * 1.35m;
        }


    }
}
