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
    public partial class EditarUsuario : ContentPage
    {
        Usuario usuario;
        public EditarUsuario(Usuario user)
        {
            InitializeComponent();
            this.usuario = user;
            BindingContext = this.usuario;
        }
    }
}