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
		Eventos item;
		public EditarEvento (Eventos item)
		{
			InitializeComponent ();
			this.item = item;
			txtNombre.Text = item.NombreEvento.ToString ();
			SeleccionarFecha.Date = item.FechaHoraEvento.Date;
			timePicker.Time = item.FechaHoraEvento.TimeOfDay;
		}
	}
}