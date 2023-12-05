using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using System.Net.Http;
using System.Runtime.InteropServices;
using QR.Models;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace QR.Vistas_CRUD_Eventos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CapturaAsistencias : ContentPage
    {

        private ModeloCaptura _viewModel;
        Eventos even;

        public CapturaAsistencias(Eventos eventos)
        {
            InitializeComponent();
            _viewModel = new ModeloCaptura();

            BindingContext = _viewModel;
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
                    lblNombre.Text = eventos.NombreEvento;
                    
                }
            }
        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushModalAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async ()=>
                {
                    await Navigation.PopModalAsync();
                    await _viewModel.GetTheData(result.Text, even.IdEventos);

                }

                );
            };
        }

        private async void BackBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }
    }
}