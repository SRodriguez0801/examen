using Electrodomestico.Models;
using Electrodomestico.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Electrodomestico.ViewModels
{
    public class viewModelsCategoria : INotifyPropertyChanged
    {
        public viewModelsCategoria()
        {
            lista.Add(new Categorias()
            {

                nombre = "Celular",
                imagen = "https://img.freepik.com/vector-gratis/maqueta-dispositivo-digital_53876-89354.jpg?w=2000"
            });

            lista.Add(new Categorias()
            {

                nombre = "Estufa",
                imagen = "https://servicio.mabeglobal.com/medias/Mabe-Estufa-61cm-Plata-Mercury-EM6145BAIS0A-Frente.jpg-1200Wx1200H?context=bWFzdGVyfGltYWdlc3wzNDc3MDN8aW1hZ2UvanBlZ3xpbWFnZXMvaDc2L2g4MS84ODM1MTA3ODgwOTkwLmpwZ3wxNzA0NmU2ZTA3MTIxOTIyZWM3OWQ3N2U1NjBmMmEyNDE1MzM1ZWQ4NjA4Zjk2NTdiNGUxZDY2ZDg0ZDI4YzVl"
            });

            lista.Add(new Categorias()
            {

                nombre = "Videojuegos",
                imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2M1O1UxKmtMKJNlfVkBimhiQDkDRFGMLFRDMcZsKatCHwebwY6csKdrNomFExPcVxzwM&usqp=CAU"
            });
            //accion que realiza el comando cuando seleccione una case
            redirigieCategoria = new Command(() =>
            {
                switch (ObjetoSelecionado.nombre)
                {
                    case "Celular":
                        var pagina = new viewCrearCelular();
                        Application.Current.MainPage.Navigation.PushAsync(pagina);

                        break;

                    case "Estufa":
                        var pagina1 = new viewCrearEstufa();
                        Application.Current.MainPage.Navigation.PushAsync(pagina1);
                        break;

                    case "Videojuegos":
                        var pagina2 = new viewCrearVideoJuego();
                        Application.Current.MainPage.Navigation.PushAsync(pagina2);
                        break;

                    default:
                        Application.Current.MainPage.DisplayAlert("Alerta", "No se encontro el Objeto", "Cancel");
                        break;
                }
            });
        }//Enlace para mandar a otra pagina de categoria a CrearCelular
        Categorias objetoSelecionado;
        public Categorias ObjetoSelecionado
        {
            get => objetoSelecionado;
            set
            {
                objetoSelecionado = value; OnPropetyChanged(nameof(ObjetoSelecionado));

            }
        }
        private void OnPropetyChanged(string propetyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
        }
        public ObservableCollection<Categorias> lista { get; set; } = new ObservableCollection<Categorias>();
        //este comando nos redirigue a otra pagina 
        public Command redirigieCategoria { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
