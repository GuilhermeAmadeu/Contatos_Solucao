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
        public EventHandler<ItemEventArgs> Salvando { get; set; }
        public EventHandler<ItemEventArgs> Excluindo { get; set; }
        
        public EventoEdicaoPage()
        {
            InitializeComponent();

        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            // Fazer a operação de conversão
            Evento item = (Evento)this.BindingContext;

            //executar o evento de salvar
            Salvando?.Invoke(sender, new ItemEventArgs(item));
            
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}