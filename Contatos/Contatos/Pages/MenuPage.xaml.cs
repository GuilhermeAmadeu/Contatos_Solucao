﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contatos.Models;

namespace Contatos.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            // Inicializa os dados do usuário
            ExibirUsuario();
            // Inicializa o menu
            ListarMenu();
        }

        // Metodo para listar o menu
        private void ListarMenu()
        {
            // Cria uma lista de menus
            List<Menu> listaMenu = new List<Menu>();
            // Adiciona um menu na lista
            listaMenu.Add( new Menu()
            {
                Titulo = "Contatos",
                Imagem = "ic_chevron_right.png",
                Pagina = typeof(PessoaListaPage)
            });
            listaMenu.Add(new Menu {
                Titulo = "Eventos",
                Imagem = "ic_chevron_right.png",
                Pagina = typeof(EventoListaPage)
            });
            listaMenu.Add(new Menu
            {
                Titulo = "Usuario",
                Imagem = "ic_chevron_right.png",
                Pagina = typeof(UsuarioPage)
            });

            // Adiciona a lista no controle listview
            lvMenu.ItemsSource = listaMenu;

            // Define o evento 
            lvMenu.ItemSelected += LvMenu_ItemSelected;
        }

        private async void LvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Pega o elemento selecionado e faz a conversão
            Menu menuItem = e.SelectedItem as Menu;

            // Verifica se veio um menu selecionado
            if (menuItem != null)
            {
                // Inicializa a navegação partindo da página home
                await App.NavegacaoPaginaInicialAsync();
                // Cria a instancia a partir do Type e converte em uma página
                Page pagina = (Page)Activator.CreateInstance(menuItem.Pagina);
                // Faz a navegação para a pagina selecionada
                await App.NavegacaoPaginaAsync(pagina);
                // Desmarca a pagina selecionada
                lvMenu.SelectedItem = null;
            }
        }

        private void ExibirUsuario()
        {
            // Pega a imagem comportilhada por embeded (embutido)
            imgFoto.Source = ImageSource.FromResource("Contatos.Resources.Imagens.foto.png");
            lblNome.Text = "Nome do usuário";
            lblEmail.Text = "usuario@email.com.br";
        }

        private async void tgrVoltar_Tapped(object sender, EventArgs e)
        {
            // Volta para a página inicial (Home)
            await App.NavegacaoPaginaInicialAsync();
        }

        private async  void tgrEditar_Tapped(object sender, EventArgs e)
        {
            //exibe dialogo com as opcoes personalizadas e pega a opcao selecionada
            var opcao =await App.DialogoOpcoes("Opções do úsuario", "Fechar", "Editar", "Foto");
            //verifica a opcao selecionada
            if (opcao == "Editar")
            {
                await App.NavegacaoPaginaAsync(new UsuarioPage());
            }
            if(opcao == "Foto")
            {
                //exibe dialogo com opçoes de confirmar ou cancelar 
                //e pega o retorno true ou false 
                var verifica = await App.DialogoAlerta("Mensagem", "Teste de confirmar ou cancelar", "Confirmar", "Cancelar");
                //verifica a opcao selecionada 
                if (verifica == true)
                {
                    await App.DialogoAlerta("Alerta", "Voce escolher o confirmar", "Fechar");
                }
                else
                {
                    await App.DialogoAlerta("Alerta", "Voce escolher o confirmar", "Fechar");
                }
            }
        }
    }
}