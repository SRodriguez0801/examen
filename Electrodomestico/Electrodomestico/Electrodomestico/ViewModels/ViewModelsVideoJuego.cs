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
    public class ViewModelsVideoJuego : INotifyPropertyChanged
    {
        public List<DateTime> FechasMantenimiento { get; } = new List<DateTime>();
        public Command AgregarVideo { get; }

        public ViewModelsVideoJuego()
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
                    listaVideo = (ObservableCollection<Models.VideoJuegos>)formatter.Deserialize(memory);
                    memory.Close();
                }
                else
                {
                    // El archivo no existe, se crea una nueva lista vacía
                    listaVideo = new ObservableCollection<Models.VideoJuegos>();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción al abrir el archivo
                // Aquí puedes agregar tu lógica personalizada para manejar el error
                Console.WriteLine("Error al abrir el archivo: " + ex.Message);
                listaVideo = new ObservableCollection<Models.VideoJuegos>();
            }

            AgregarVideo = new Command(async () =>
            {
                Models.VideoJuegos videoJuegos = new Models.VideoJuegos()
                {
                    Nombre_Juego = this.Nombre_Juego,
                    Modelo = this.Modelo,
                    FechaLanzamiento = this.FechaLanzamiento,
                    Voltaje = this.Voltaje,
                    PrecioCompra = this.PrecioCompra,
                    Empresa_Creadora = this.Empresa_Creadora,

                    
                };

                CalcularPrecioVenta(videoJuegos);
                listaVideo.Add(videoJuegos);
                AgregarMantenimiento(DateTime.Now);

                Resultadovideo = videoJuegos;

                // Rutina para serializar la lista de celulares
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (MemoryStream memory = new MemoryStream())
                    {
                        formatter.Serialize(memory, listaVideo);
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
                var pagina = new viewResultadoVideoJuego();
                await Application.Current.MainPage.Navigation.PushAsync(pagina);

            });

        }
        public void AgregarMantenimiento(DateTime fecha)
        {
            if (listaVideo.Count > 0)
            {
                listaVideo[listaVideo.Count - 1].FechasMantenimiento.Add(fecha);
            }
        }
        public ObservableCollection<Models.VideoJuegos> listaVideo { get; set; }

        string nombre_juego;
        public string Nombre_Juego
        {
            get => nombre_juego;
            set
            {
                nombre_juego = value;
                OnPropertyChanged(nameof(Nombre_Juego));
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
        

        string empresa_creadora;
        public string Empresa_Creadora
        {
            get => empresa_creadora;
            set
            {
                empresa_creadora = value;
                OnPropertyChanged(nameof(Empresa_Creadora));
            }
        }
        Models.VideoJuegos  resultadovideo;
        public Models.VideoJuegos Resultadovideo
        {
            get => resultadovideo;
            set
            {
                resultadovideo = value;
                OnPropertyChanged(nameof(Resultadovideo));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void LimpiarCampos()
        {
            Nombre_Juego = string.Empty;
            Modelo = string.Empty;
            FechaLanzamiento = DateTime.MinValue;
            Voltaje = string.Empty;
            PrecioCompra = 0.0m;
            Empresa_Creadora = string.Empty;
        }
        public void CalcularPrecioVenta(Models.VideoJuegos videoJuegos)
        {
            videoJuegos.PrecioVenta = videoJuegos.PrecioCompra * 1.50m;
        }

    }
}
