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
    public partial class ListaUsuarios : ContentPage
    {
        public ListaUsuarios()
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
            var usuarioList = await App.sqLiteDb.GetUsuarioAsync();
            if (usuarioList != null)
                listaUsuarios.ItemsSource = usuarioList;
        }

        private void RegistroUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroUsuario());

        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            var user = button.CommandParameter as Usuario;
            // Navegar a la página de edición y pasar el evento como parámetro
            if (user != null)
                await Navigation.PushAsync(new EditarUsuario(user));
        }

        private async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var item = button.CommandParameter as Usuario;
            item.Estado = false;
            await App.sqLiteDb.SaveUsuarioAsync(item);
            llenarDatos();
        }
    }
}