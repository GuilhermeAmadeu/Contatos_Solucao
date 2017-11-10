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
    public partial class PessoaListaPage : ContentPage
    {
        private PessoaViewModelMem vm;

        public PessoaListaPage()
        {
            InitializeComponent();

            Inicializar();
        }

        private void Inicializar()
        {
            // Instanciar a viewmodel
            vm = new PessoaViewModelMem();

            // Definir a fonte de dados da lista
            lvPessoa.ItemsSource = vm.Lista;

            // Criar registros de teste
            var p1 = new Pessoa()
            {
                Nome = "Fulano",
                Email = "fulano@mail.com",
                Telefone = "1234"
            };

            // Adicionar item na lista
            vm.Salvar(p1);
        }

        private async void tbiNovo_Clicked(object sender, EventArgs e)
        {
            // Criar o objeto de binding
            var pessoa = new Pessoa();

            // Criar a página de edição
            var pagina = new PessoaEdicaoPage();
            // Definir o binding
            pagina.BindingContext = pessoa;
            // Atribuir a viewmodel
            pagina.ViewModel = vm;

            // Chamar a página
            await Navigation.PushAsync(pagina);
        }

        private async void lvPessoa_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Obter o objeto selecionado
            var pessoa = (Pessoa)e.Item;

            // Criar a página de edição
            var pagina = new PessoaEdicaoPage();
            // Definir o binding
            pagina.BindingContext = pessoa;
            // Atribuir a viewmodel
            pagina.ViewModel = vm;

            // Chamar a página
            await Navigation.PushAsync(pagina);
        }
    }
}