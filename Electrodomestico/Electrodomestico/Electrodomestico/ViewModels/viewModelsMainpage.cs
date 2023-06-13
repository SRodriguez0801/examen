using Electrodomestico.Models;
using Electrodomestico.Views;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xamarin.Forms;

namespace Electrodomestico.ViewModels
{
    public class ViewModelsMainpage : INotifyPropertyChanged
    {
        //Constructor de la clase viewModelsMainpage
        public ViewModelsMainpage()

        {
            // Rutina para abrir el archivo de lista de celulares
            try
            {
                // Abrir y leer el archivo
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formatter = new BinaryFormatter();
                u = (Usuarios)formatter.Deserialize(memory);
                memory.Close();
            }
            catch (FileNotFoundException)
            {
                // El archivo no existe, se crea una nueva lista vacía
                u = new Usuarios();
            }



            navegarCrearUsuario = new Command(async () =>

            {
                var pagina = new viewCreacionUsuario();
                //PushAsync es redirigir a otra pagina 
                await Application.Current.MainPage.Navigation.PushAsync(pagina);

            });
            //aqui se guarda el ususario y contraseña cuando se crea
            autenticar = new Command(() =>
            {
                if (u.autenticador(this.CorreoElectronico, this.Password) == true)
                {
                    // nos envia ala pagina de categodiras 
                    var pagina = new viewCategorias();
                    Application.Current.MainPage.Navigation.PushAsync(pagina);
                }
                else
                {
                    ResultadoAutenticacion = "Autenticacion Erronea";
                }
            });

        }
        //ruta de serealizacion
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "usuario.bin");

        Usuarios u = new Usuarios();
        string correoElectronico;
        public string CorreoElectronico
        {
            get => correoElectronico;
            set
            {
                correoElectronico = value;
                OnPropetyChanged(nameof(CorreoElectronico));
            }
        }
        string resultadoAutenticacion;
        public string ResultadoAutenticacion
        {
            get => resultadoAutenticacion;
            set
            {
                resultadoAutenticacion = value;
                OnPropetyChanged(nameof(ResultadoAutenticacion));
            }
        }



        string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropetyChanged(nameof(Password));
            }
        }

        //crearemos un comando 
        public Command navegarCrearUsuario { get; }

        public Command autenticar { get; }

        //automotisar el metodo string correoElectronico para generar menos codigo 
        private void OnPropetyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
