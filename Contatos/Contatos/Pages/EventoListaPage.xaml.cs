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

        private EventoViewModel vm;

        public EventoListaPage()
        {
            InitializeComponent();
            Inicializar();
        }
        private void Inicializar()
        {
            // Instanciar a viewmodel
            vm = new EventoViewModel();

            //vincular a vm com a pagina
            BindingContext = vm;

            // Definir a fonte de dados da lista
            lvEdicao.ItemsSource = vm.Lista;

            //// Definir a fonte de dados da lista
            //ListaEdicao.ItemsSource = vm.Lista;
            //// Criar registros de teste
            //var e1 = new Evento()
            //{
            //    Nome = "Fulano",
            //    Local = "Rua Nilo Aldo Zechin - 2221 - Mirassol",
            //    Anotacoes = "Primeiro app"
            //};
            //// Adicionar item na lista
            //vm.Salvar(e1);

        }

        private async void tbiNovo_Clicked(object sender, EventArgs e)
        {
            // Criar o objeto de binding
            var item = vm.Novo();

            // Criar a página de edição
            var pagina = new EventoEdicaoPage();

            // Definir o binding
            pagina.BindingContext = item;

            // Atribuir os eventos
            pagina.Salvando += SalvarHandler;

            // Chamar a página
            await Navigation.PushAsync(pagina);


        }
        private async void ListaEdicao_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Obter o objeto selecionado
            var evento = (Evento)e.Item;

            // Criar a página de edição
            var pagina = new EventoEdicaoPage();
            // Definir o binding
            pagina.BindingContext = evento;

            // Atribuir os eventos
            pagina.Salvando += SalvarHandler;
            pagina.Excluindo += ExcluirHandler;

            // Chamar a página
            await Navigation.PushAsync(pagina);


        }
        private async void SalvarHandler(object sender, ItemEventArgs e)
        {
            //Obter o item passado como parametro
            var item = (e.Item as Evento);

            // Executar a rotina de salvar
            var resultado = await vm.Salvar(item);

            //verificar o resultado da execucao
            if (resultado.Sucesso)
            {
                await DisplayAlert("Sucesso", "Operação realizada com sucesso", "Fechar");
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Erro", resultado.Mensagem, "Fechar");
        }

        private async void ExcluirHandler(object sender, ItemEventArgs e)
        {

            //Obter o item passado como parametro
            var item = (e.Item as Evento);

            var resultado = await vm.Excluir(item);

            //verificar o resultado da execucao
            if (resultado.Sucesso)
            {
                await DisplayAlert("Sucesso", "Operação realizada com sucesso", "Fechar");
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Erro", resultado.Mensagem, "Fechar");

        }
    }
}