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
            //miDatePicker.DateSelected += MiDatePicker_DateSelected;
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
                
                    Eventos even = new Eventos
                    {
                        NombreEvento = txtNombre.Text,
                        FechaEvento = SeleccionarFecha.Date,
                        HoraEvento = txtHora.Text   ,
                    };
                    await App.sqLiteDb.SaveEventoAsync(even);
                    txtNombre.Text = "";
                    txtHora.Text = "";
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
            else if (string.IsNullOrEmpty(txtHora.Text))
                validado = false;
            

            else
                validado = true;
            return validado;
          

        }
    }
}