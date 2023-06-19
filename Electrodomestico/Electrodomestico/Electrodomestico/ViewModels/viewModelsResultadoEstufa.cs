using Electrodomestico.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
<<<<<<< HEAD
using Xamarin.Forms;
=======
>>>>>>> e181ab3b14fb93811f6eb824f66127bcbcea8792
using static System.Net.Mime.MediaTypeNames;

namespace Electrodomestico.ViewModels
{
    public class viewModelsResultadoEstufa : INotifyPropertyChanged
    {
<<<<<<< HEAD
        public Command SalirEstufa { get; }

=======
>>>>>>> e181ab3b14fb93811f6eb824f66127bcbcea8792
        private Estufa resultadoEstufa;
        public viewModelsResultadoEstufa()
        {
            // Cargar la lista de Estufas serializados
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "celulares.bin");
            try
            {
                // Abrir y leer el archivo
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formatter = new BinaryFormatter();
                listaEstufa = (ObservableCollection<Estufa>)formatter.Deserialize(memory);
                memory.Close();
            }
            catch (FileNotFoundException)
            {
<<<<<<< HEAD

            }


            SalirEstufa = new Command(Salir);

        }

        public void Salir()
        {
            // Cerrar la aplicación
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        public Estufa ResultadoEstufa
=======
                
            }
        }
            public Estufa ResultadoEstufa
>>>>>>> e181ab3b14fb93811f6eb824f66127bcbcea8792
        {
            get => resultadoEstufa;
            set
            {
                resultadoEstufa = value; OnPropertyChanged(nameof(ResultadoEstufa));
            }
        }
        public ObservableCollection<Estufa> listaEstufa { get; set; } = new ObservableCollection<Estufa>();

        public event PropertyChangedEventHandler PropertyChanged;
<<<<<<< HEAD

=======
     
>>>>>>> e181ab3b14fb93811f6eb824f66127bcbcea8792

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

