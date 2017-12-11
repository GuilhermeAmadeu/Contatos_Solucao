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
        private PessoaViewModel vm;

        public PessoaListaPage()
        {
            InitializeComponent();

            Inicializar();

            //executar a pesquisa inicial
            Pesquisar();
        }

        private void Inicializar()
        {
            // Instanciar a viewmodel
            vm = new PessoaViewModel();

            //vincular a vm com a pagina
            BindingContext = vm;

            //// Definir a fonte de dados da lista
            //lvPessoa.ItemsSource = vm.Lista;

            // Criar registros de teste
            //var p1 = new Pessoa()
            //{
            //    Nome = "Fulano",
            //    Email = "fulano@mail.com",
            //    Telefone = "1234",
            //    Observacao = "Primeiro APP"
            //};

            //// Adicionar item na lista
            //vm.Salvar(p1);
        }

        private async void tbiNovo_Clicked(object sender, EventArgs e)
        {
            // Criar o objeto de binding
            var item = vm.Novo();

            // Criar a página de edição
            var pagina = new PessoaEdicaoPage();

            // Definir o binding
            pagina.BindingContext = item;

            // Atribuir os eventos
            pagina.Salvando += SalvarHandler;

            // Chamar a página
            await Navigation.PushAsync(pagina);
        }

        private async void lvPessoa_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Obter o objeto selecionado
            var item = (Pessoa)e.Item;

            // Criar a página de edição
            var pagina = new PessoaEdicaoPage();
            
            // Definir o binding
            pagina.BindingContext = item;

            // Atribuir os eventos
            pagina.Salvando += SalvarHandler;
            pagina.Excluindo += ExcluirHandler;

            // Chamar a página
            await Navigation.PushAsync(pagina);
        }

        private async void SalvarHandler(object sender,ItemEventArgs e)
        {
            //Obter o item passado como parametro
            var item = (e.Item as Pessoa);

            var resultado = await vm.Salvar(item);

            //verificar o resultado da execucao
            if (resultado.Sucesso)
            {
                await DisplayAlert("Sucesso", "Operação realizada com sucesso", "Fechar");
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Erro" ,resultado.Mensagem, "Fechar");
        }

        private async void ExcluirHandler(object sender, ItemEventArgs e)
        {
            // Solicitar confirmação
            var acao = await DisplayActionSheet("Confirma a exclusão?",
                "Cancelar", null, "Sim", "Não");

            // Verificar se a ação é diferente de Sim
            if (acao != "Sim")
            {
                return;
            }

            // Obter o item passado como parâmetro
            var item = (e.Item as Pessoa);

            // Executar a rotina de excluir
            var resultado = await vm.Excluir(item);

            // Verificar o resultado da execução
            if (resultado.Sucesso)
            {
                await DisplayAlert("Sucesso", "Operação realizada com sucesso!",
                    "Fechar");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro", resultado.Mensagem, "Fechar");
            }
        }

        private void txtPesquisa_SearchButtonPressed(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private async void Pesquisar()
        {
            await vm.Pesquisar();
        }

    }
}