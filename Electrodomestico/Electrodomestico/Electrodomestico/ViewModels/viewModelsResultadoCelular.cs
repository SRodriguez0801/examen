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
            

            // Cargar la lista de celulares serializados
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "celulares.bin");
            try
            {
                // Abrir y leer el archivo
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formatter = new BinaryFormatter();
                listaCelulares = (ObservableCollection<Celular>)formatter.Deserialize(memory);
                memory.Close();
            }
            catch (FileNotFoundException)
            {
                Application.Current.MainPage.DisplayAlert("Error","Error cargando Lista de Celulares","ok");
            }

        }
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


