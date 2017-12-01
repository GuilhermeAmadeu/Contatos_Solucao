using Contatos.Models;
using Contatos.Services;
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
    public partial class PessoaEdicaoPage : ContentPage
    {
        //Declarar os Eventos 
        public EventHandler<ItemEventArgs> Salvando { get; set; }
        public EventHandler<ItemEventArgs> Excluindo { get; set; }

        public PessoaEdicaoPage()
        {
            InitializeComponent();

            Inicializar();
        }

        private void Inicializar()
        {
            //// Instanciar o objeto
            //item = new Pessoa();

            //// Definir a ligação com os controles
            //this.BindingContext = item;

            //// Instanciar a viewmodel
            //vm = new PessoaViewModelMem();
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
                       
            // Fazer a operação de conversão
            Pessoa item = (Pessoa)this.BindingContext;

            //executar o evento de salvar
            Salvando?.Invoke(sender, new ItemEventArgs(item));
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            // Retornar para a página anterior
            await Navigation.PopAsync();
        }

        
        private async void txtCep_Unfocused(object sender, FocusEventArgs e)
        {
            //verificr a quantidade de caracteres do cep 
            if (txtCep.Text.Length < 8)
            {
                return;
            }

            //instanciar o servico de endereco
            var es = new EnderecoService();
            var endereco = await es.Pesquisar(txtCep.Text);
            //verificar se retornnou com sucesso
            if (es.Resultado.Sucesso == true)
            {
                txtEndereco.Text = endereco.Logradouro;
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Localidade;
                txtUf.Text = endereco.Uf;
            }
            else
            {
                //exibir menssagem de erro
                await DisplayAlert("Erro", es.Resultado.Mensagem, "Fechar");
            }
        }
    }
}