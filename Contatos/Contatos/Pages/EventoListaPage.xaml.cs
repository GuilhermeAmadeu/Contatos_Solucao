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
    public partial class EventoListaPage : ContentPage
    {

        private EventoViewModelMem vm;

        public EventoListaPage()
        {
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            // Instanciar a viewmodel
            vm = new EventoViewModelMem();

            // Definir a fonte de dados da lista
            ListaEdicao.ItemsSource = vm.Lista;
            // Criar registros de teste
            var e1 = new Evento()
            {
                Nome = "Fulano",
                Local = "Rua Nilo Aldo Zechin - 2221 - Mirassol",
                Anotacoes = "Primeiro app"
            };
            // Adicionar item na lista
            vm.Salvar(e1);



        }

        private async void ListaEdicao_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Obter o objeto selecionado
            var evento = (Evento)e.Item;

            // Criar a página de edição
            var pagina = new EventoEdicaoPage();
            // Definir o binding    
            pagina.BindingContext = evento;
            // Atribuir a viewmodel
            pagina.ViewModel = vm;

            // Chamar a página
            await Navigation.PushAsync(pagina);

        }

        private async void tbiNovo_Clicked(object sender, EventArgs e)
        {
            // Criar o objeto de binding
            var evento = new Evento();

            // Criar a página de edição
            var pagina = new EventoEdicaoPage();
            // Definir o binding
            pagina.BindingContext = evento;
            // Atribuir a viewmodel
            pagina.ViewModel = vm;

            // Chamar a página
            await Navigation.PushAsync(pagina);
        }
    }
}