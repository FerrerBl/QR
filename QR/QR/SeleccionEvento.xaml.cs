using QR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeleccionEvento : ContentPage
    {
        public SeleccionEvento()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            llenarDatos();
        }

        public async void llenarDatos()
        {
            var eventoList = await App.sqLiteDb.GetEventosAsync();
            if (eventoList != null)
                listaEventos.ItemsSource = eventoList;
        }

        private async void listaEventos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Eventos registro)
            {
                // Obtén el ID del registro seleccionado
                var idRegistro = registro.IdEventos;

                // Navega a la nueva página y pasa el ID como parámetro
               await Navigation.PushAsync(new ListaAsistencias(idRegistro));
            }

                      // Desactiva la selección de la fila
                 ((ListView)sender).SelectedItem = null;
        }
    }
    
}