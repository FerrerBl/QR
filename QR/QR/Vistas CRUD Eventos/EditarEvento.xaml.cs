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
	public partial class EditarEvento : ContentPage
	{
		Eventos even;
		public EditarEvento (Eventos eventos)
		{
			InitializeComponent();
            this.even = eventos;
            BindingContext = this.even;
        }
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			if (!string.IsNullOrEmpty(even.IdEventos.ToString()))
			{
				var eventos = await App.sqLiteDb.GetEventosByIdAsync(even.IdEventos);
				if (eventos != null)
				{
					txtIDEvento.Text = eventos.IdEventos.ToString();	
					txtNombre.Text = eventos.NombreEvento;
					SeleccionarFecha.Date = eventos.FechaHoraEvento.Date;
					timePicker.Time = eventos.FechaHoraEvento.TimeOfDay;
				}
			}
		}
		
		
        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
			if (!string.IsNullOrEmpty(txtIDEvento.Text))
			{
				Eventos even = new Eventos()
				{
					IdEventos = Convert.ToInt32(txtIDEvento.Text),
					NombreEvento = txtNombre.Text,
					FechaHoraEvento = SeleccionarFecha.Date.Add(timePicker.Time),

				};
				await App.sqLiteDb.SaveEventoAsync(even);
				await DisplayAlert("Actualizacion", "Se actualizo de manera exitosa", "Ok");
			}

        }
    }
}