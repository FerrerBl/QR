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
    public partial class ListaAsistencias : ContentPage
    {
        int registro;
        public ListaAsistencias(int reg)
        {
            InitializeComponent();
            this.registro = reg;
            BindingContext = this.registro;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!string.IsNullOrEmpty(registro.ToString()))
            {
                var eventos = await App.sqLiteDb.GetAssistanceByIdAsync(registro);
                if (eventos != null)
                {
                    listaEventos.ItemsSource = eventos;
                }
                var nombre = await App.sqLiteDb.GetEventosByIdAsync(registro);
                if (nombre != null)
                    lblNombre.Text = nombre.NombreEvento;
            }
            
        }
    }
}