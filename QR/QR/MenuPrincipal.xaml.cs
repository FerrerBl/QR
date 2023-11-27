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
namespace QR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : ContentPage
    {

        public  MenuPrincipal()
        {
            InitializeComponent();
            


        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var eventoList = await App.sqLiteDb.GetEventosAsync();
            if (eventoList != null)
                listaEventos.ItemsSource = eventoList;
        }




        private async void Editar_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button.CommandParameter as Eventos;
            await Navigation.PushAsync(new EditarEvento(item));
        }

        private void Eliminar_Clicked(object sender, EventArgs e)
        {

        }

      

        private void RegistroEvento_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroEventos());

        }

        private void btnCapturar_Clicked(object sender, EventArgs e)
        {

        }
    }
}