using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Contatos.Models;

namespace Contatos.Services
{
    public class PessoaService : ServiceBase
    {
        public PessoaService() : base()
        {
            //definir o endereço do cliente 
            cliente.BaseAddress = new Uri(string.Format(Constantes.URL_SERVICO, "pessoaapi"));
        }
        public async Task<List<Pessoa>> PesquisarAsync(string conteudo)
        {
            //itens que serão retornados pela pesquisa 
            var itens = new List<Pessoa>();

            //Instanciar o resultado da operacao 
            Resultado = new ResultadoOperacao()
            {
                Sucesso = false
            };

            //Criar o parametro para chamada
            var parametro = "?content=" + conteudo;

            try
            {
                //chamar o servico
                var resposta = await cliente.GetAsync(parametro);

                //verificar se executou com sucesso
                if (resposta.IsSuccessStatusCode)
                {
                    //obter o conteudo da resposta
                    var conteudoret = await resposta.Content.ReadAsStringAsync();

                    //transformar o conteudo retornado na lista de itens
                    itens = JsonConvert.DeserializeObject<List<Pessoa>>(conteudoret);

                    //assinalar o resultado com sucesso
                    Resultado.Sucesso = true;
                }
                else
                {
                    //obter a mensagem de rro
                    Resultado.Mensagem = await resposta.Content.ReadAsStringAsync();
                    Resultado.NumeroErro = (int)resposta.StatusCode;
                }
            }
            catch (Exception ex)
            {
                //obter a mensagem de erro 
                Resultado.Mensagem = ex.Message;
            }
            return itens;
        }
        public async Task SalvarAsync(Pessoa item, bool ehNovo = false)
        {
            //Inicializar o resultado da operaçao
            Resultado = new ResultadoOperacao()
            {
                Sucesso = false
            };

            try
            {
                //converter os dados para json
                var json = JsonConvert.SerializeObject(item);

                //criar o conteudo para o envio dos dados json
                var conteudo = new StringContent(json, Encoding.UTF8, Constantes.CONTEUDO_JSON);

                //declarar o objeto de resposta http da requisicao
                HttpResponseMessage resposta = null;

                //verificar se é um item para inclusão
                if (ehNovo == true)
                {
                    resposta = await cliente.PostAsync("", conteudo);
                }
                else
                {
                    resposta = await cliente.PutAsync("", conteudo);
                }

                //verificar se houve sucesso na chamada
                if (resposta.IsSuccessStatusCode)
                {
                    Resultado.Sucesso = true;
                }
                else
                {
                    //obter as informaçoes da requisiçao
                    Resultado.Mensagem = await resposta.Content.ReadAsStringAsync();
                    Resultado.NumeroErro = (int)resposta.StatusCode;
                }
            }
            catch (Exception ex)
            {
                Resultado.Mensagem = ex.Message;
            }
        }

        //deletar item
        public async Task ExcluirAsync(Pessoa item)
        {
            //Inicializar o resultado da operaçao
            Resultado = new ResultadoOperacao()
            {
                Sucesso = false
            };

            //criar o parametro para requisicao 
            var parametro = "?id=" + item.Id.ToString();

            try
            {

                var resposta = await cliente.DeleteAsync(parametro);

                //verificar se houve sucesso na chamada
                if (resposta.IsSuccessStatusCode)
                {
                    Resultado.Sucesso = true;
                }
                else
                {
                    //obter as informaçoes da requisiçao
                    Resultado.Mensagem = await resposta.Content.ReadAsStringAsync();
                    Resultado.NumeroErro = (int)resposta.StatusCode;
                }
            }
            catch (Exception ex)
            {
                Resultado.Mensagem = ex.Message;
            }

        }
    }
}
