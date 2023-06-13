using Electrodomestico.Models;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xamarin.Forms;

namespace Electrodomestico.ViewModels
{
    public class viewModelCreacionUsuario : INotifyPropertyChanged
    {
        public viewModelCreacionUsuario()
        {
            crearUsuario = new Command(() =>
            {

                Usuarios u = new Usuarios()
                {
                    password = this.Password,
                    correo = this.CorreoElectronico

                };

                /* Rutina de Serealizacion*/
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memory = new MemoryStream();
                formatter.Serialize(memory, u);
                byte[] serializedData = memory.ToArray();
                memory.Close();

                File.WriteAllBytes(ruta, serializedData);
                // PopAsync es para crear la opcion de regresar 

                var pagina = new MainPage();
                Application.Current.MainPage.Navigation.PushAsync(pagina);

            });

        } //ruta de serealizacion
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "usuario.bin");


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


        public Command crearUsuario { get; }

        //automotizar el metodo string correoElectronico para generar menos codigo 
        private void OnPropetyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
