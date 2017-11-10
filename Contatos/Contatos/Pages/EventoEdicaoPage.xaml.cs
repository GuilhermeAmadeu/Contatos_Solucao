using Contatos.Models;
using Contatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contatos.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventoEdicaoPage : ContentPage
    {
        public EventoViewModelMem ViewModel { get; set; }
        public EventoEdicaoPage()
        {
            InitializeComponent();

        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            Evento item = (Evento)this.BindingContext;


            ViewModel.Salvar(item);


            await Navigation.PopAsync();



        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}