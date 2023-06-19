using Electrodomestico.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Electrodomestico.ViewModels
{
    public class viewModelsResultadoVideoJuego : INotifyPropertyChanged
    {
        private VideoJuegos resultadoVideoJuego;

        public viewModelsResultadoVideoJuego()
        {
            // Cargar la lista de celulares serializados
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "celulares.bin");
            try
            {
                // Abrir y leer el archivo
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formatter = new BinaryFormatter();
                listaVideo = (ObservableCollection<VideoJuegos>)formatter.Deserialize(memory);
                memory.Close();
            }
            catch (FileNotFoundException)
            {
          
            }

        }
        public VideoJuegos ResultadoVideoJuego { 
            
            get => resultadoVideoJuego;
            set
            {
                resultadoVideoJuego = value; OnPropertyChanged(nameof(ResultadoVideoJuego));
            }
        
        }
        public ObservableCollection<VideoJuegos> listaVideo { get; set; } = new ObservableCollection<VideoJuegos>();


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
