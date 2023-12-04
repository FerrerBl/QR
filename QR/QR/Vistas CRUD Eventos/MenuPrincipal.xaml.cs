using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.SqlClient;
using QR;
using QR.Models;
using Microsoft.Extensions.Logging;
using QR.Vistas_CRUD_Eventos;
namespace QR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {

        public  MenuPrincipal()
        {
            InitializeComponent();
            


        }
        protected override  void OnAppearing()
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


        private async void Editar_Clicked(object sender, EventArgs e)
        {

            var button = sender as ImageButton;
           
                var evento = button.CommandParameter as Eventos;
                // Navegar a la página de edición y pasar el evento como parámetro
                if (evento != null)
                    await Navigation.PushAsync(new EditarEvento(evento));
                
          

        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var item = button.CommandParameter as Eventos;
            item.Estado = false;
            await App.sqLiteDb.SaveEventoAsync(item);
            llenarDatos();
        }

      

        private void RegistroEvento_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroEventos());

        }

        private async void btnCapturar_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            var evento = button.CommandParameter as Eventos;
            // Navegar a la página de edición y pasar el evento como parámetro
            if (evento != null)
                await Navigation.PushAsync(new CapturaAsistencias(evento));
        }
    }
}