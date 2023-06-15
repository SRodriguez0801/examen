using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using Electrodomestico.Models;
using Xamarin.Forms;

namespace Electrodomestico.ViewModels
{
    public class ViewModelsResultadoCelular : INotifyPropertyChanged
    {
        private Celular resultadoCelular;

        public ViewModelsResultadoCelular()
        {
            listaCelulares = new ObservableCollection<Celular>();

            // Cargar la lista de celulares serializados
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "celulares.bin");
            try
            {
                if (File.Exists(ruta))
                {
                    byte[] data = File.ReadAllBytes(ruta);
                    using (MemoryStream memory = new MemoryStream(data))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        listaCelulares = (ObservableCollection<Celular>)formatter.Deserialize(memory);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error al abrir el archivo: " + ex.Message);
            }
        }

        public ViewModelsResultadoCelular(Celular celular)
        {
            ResultadoCelular = celular;
        }
        Celular resultado;
        public Celular ResultadoCelular
        {
            get => resultadoCelular;
            set
            {
                resultadoCelular = value; OnPropertyChanged(nameof(ResultadoCelular));
            }
        }

        public ObservableCollection<Celular> listaCelulares { get; set; } = new ObservableCollection<Celular>();


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


