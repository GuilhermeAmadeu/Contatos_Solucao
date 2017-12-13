using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contatos.Models;
using Contatos.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Contatos.ViewModels
{
    public class AnotacaoViewModel:ViewModelBase
    {
        //declarar o objeto do serviço genérico
        private ServicoGenerico<Anotacao> srv;

        private ObservableCollection<Anotacao> lista;

        // Criar a propriedade da lista
        public ObservableCollection<Anotacao> Lista
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

        public string ConteudoPesquisa { get; set; }

        //criar o construtor da classe
        public AnotacaoViewModel()
        {
            string url = Constantes.URL_SERVICO + "anotacaoapi/";
            //acessar o sevico online
            //url = "http://contatosedu.azurewebsites.net/api/anotacaoapi/";

            //Instanciar o serviço genérico
            srv = new ServicoGenerico<Anotacao>(url);

            //Instanciar lista
            Lista = new ObservableCollection<Anotacao>();
        }

        public async Task PesquisarAsync()
        {
            string parametro = "?content=" + ConteudoPesquisa;

            //Executar o metodo get
            var retorno = await srv.PesquisarAsync(parametro);

            //verificar se foi executado com sucesso
            if(srv.Status.Sucesso == true)
            {
                var itens = JsonConvert.DeserializeObject<List<Anotacao>>(retorno);
                Lista = new ObservableCollection<Anotacao>(itens);
            }
        }

        public async Task<ResultadoOperacao> SalvarAsync(Anotacao item)
        {
            //verificar se é um novo registro 
            bool novo = (item.Id == 0);
            //obter o resultado da rotina de salvar 
            string retorno = await srv.SalvarAsync(item, novo);
            //obter o resultado da execucao 
            ResultadoOperacao resultado = srv.Status;
            //verificar se o servico foi executado com sucesso
            if(resultado.Sucesso == true)
            {
                Anotacao itemsalvo = JsonConvert.DeserializeObject<Anotacao>(retorno);
                if(novo == true)
                {
                    Lista.Add(itemsalvo);
                }
            }

            return resultado;
        }

        public async Task<ResultadoOperacao> ExcluirAsync(Anotacao item)
        {
            //criar o parametro 
            string parametro = "?id=" + item.Id;

            //executar a exclusao 
            string retorno = await srv.ExcluirAsync(parametro);

            //obter o resultado da execucao
            ResultadoOperacao resultado = srv.Status;
            if (resultado.Sucesso == true)
            {
                Lista.Remove(item);
            }
            return resultado;
        }

        public Anotacao Novo()
        {
            Anotacao item = new Anotacao();
            return item;
        }
    }
}
