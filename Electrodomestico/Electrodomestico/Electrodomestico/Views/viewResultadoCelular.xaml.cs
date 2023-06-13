using Electrodomestico.ViewModels;
using Electrodomestico.Models;
using Xamarin.Forms;


namespace Electrodomestico.Views
{

    public partial class viewResultadoCelular : ContentPage
    {
        public viewResultadoCelular(Celular celular)
        {

            InitializeComponent();
            BindingContext = new ViewModelsResultadoCelular(celular);
        }
    }
}