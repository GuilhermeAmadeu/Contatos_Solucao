using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Contatos.Data;
using Contatos.Models;

namespace Contatos.ViewModels
{
    public class PessoaViewModel : ViewModelBase
    {
        // Criar o repositório
        private PessoaRepository rep = new PessoaRepository();

        // Criar campo da lista
        private ObservableCollection<Pessoa> lista = new ObservableCollection<Pessoa>();
            
        // Criar a propriedade da lista
        public ObservableCollection<Pessoa> Lista
        {
            get
            {
                return lista;
            }
            set
            {
                lista = value;
                OnPropertyChanged();
            }
        }

        // Armazena o conteúdo para pesquisa
        public string ConteudoPesquisa { get; set; }

        // Método para instanciar novo item
        public Pessoa Novo()
        {
            var item = new Pessoa();

            return item;
        }

        // Método para realizar a pesquisa
        public async Task Pesquisar()
        {
            // Obet as pessoas cadastradas
            var itens = await rep.PesquisarAsync(ConteudoPesquisa);

            Lista = new ObservableCollection<Pessoa>(itens);
        }

        // Método para salvar o item
        public async Task<ResultadoOperacao> Salvar(Pessoa item)
        {
            ResultadoOperacao resultado = null;

            // Verificar se é um novo item
            bool novo = false;
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
                novo = true;
            }

            // Salvar no repositório
            resultado = await rep.SalvarAsync(item);

            // Se executou com sucesso
            if (resultado.Sucesso)
            {
                // Se for novo item
                if (novo == true)
                {
                    Lista.Add(item);
                }

                // Continuará no futuro
            }

            return resultado;
        }

        // Método para excluir o item
        public async Task<ResultadoOperacao> Excluir(Pessoa item)
        {
            ResultadoOperacao resultado = null;

            // Excliuir do repositório
            resultado = await rep.ExcluirAsync(item);

            // Se houve sucesso na exclusão
            if (resultado.Sucesso)
            {
                // Remover da lista
                Lista.Remove(item);
            }

            return resultado;
        }
    }
}
