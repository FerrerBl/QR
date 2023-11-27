using Microsoft.Extensions.Logging;
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
    public partial class RegistroEventos : ContentPage
    {
      
        public RegistroEventos()
        {
            InitializeComponent();
            SeleccionarFecha.DateSelected += SeleccionarFecha_FechaSeleccionada;

        }
        private void SeleccionarFecha_FechaSeleccionada(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
        }

        private async void btnRegistrarEvento_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DateTime fechaYHora = SeleccionarFecha.Date.Add(timePicker.Time);

                Eventos even = new Eventos
                    {
                        NombreEvento = txtNombre.Text,
                        FechaHoraEvento = fechaYHora,
                    };
               
                    await App.sqLiteDb.SaveEventoAsync(even);

                    txtNombre.Text = "";
                    await DisplayAlert("Registro", "Se ha registrado el evento correctamente", "ok");
                
            }
            else
            await DisplayAlert("Advertencia", "Favor de ingresar todos los datos", "Ok");

        }
        
        public bool ValidarDatos()
        {
            bool validado;
            if (string.IsNullOrEmpty(txtNombre.Text))
                validado = false;

           

            else
                validado = true;
            return validado;
          

        }
    }
}