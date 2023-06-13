using System.ComponentModel;
using System.Runtime.CompilerServices;
using Electrodomestico.Models;
using Xamarin.Forms;

namespace Electrodomestico.ViewModels
{
    public class ViewModelsResultadoCelular : INotifyPropertyChanged
    {
        private Celular resultadoCelular;

        public ViewModelsResultadoCelular()
        {
        }

        public ViewModelsResultadoCelular(Celular celular)
        {
            ResultadoCelular = celular;
        }
        public Celular ResultadoCelular
        {
            get { return resultadoCelular; }
            set
            {
                resultadoCelular = value;
                OnPropertyChanged(nameof(ResultadoCelular));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

