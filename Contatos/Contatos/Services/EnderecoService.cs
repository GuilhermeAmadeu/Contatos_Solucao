using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contatos.Models;
using Newtonsoft.Json;

namespace Contatos.Services
{
    public class EnderecoService : ServiceBase
    {
        public EnderecoService(): base()
        {
            cliente.BaseAddress = new Uri("https://viacep.com.br/ws/");
            
        }


        //metodo para pesquisar o cep
        public async Task<Endereco> Pesquisar(string cep)
        {
            //declarar o objeto de retorno
            Endereco end = null;
            //inicializar o resultado da chamada do seviço
            Resultado = new ResultadoOperacao()
            {
                Sucesso = true
            };

            //Criar o parametro para consulta
            var parametro = cep + "/json";

            try
            {
                //chamar o serviço
                var resposta = await cliente.GetAsync(parametro);

                //ler o conteudo da resposta
                var conteudo = await resposta.Content.ReadAsStringAsync();

                //verificar se executou com sucesso
                if (resposta.IsSuccessStatusCode)
                {
                    //verificar se o servico nao encontrou o cep
                    if (!conteudo.Contains("\"erro\":true"))
                    {
                        //desserializar o endereco
                        end = JsonConvert.DeserializeObject<Endereco>(conteudo);
                    }
                    else
                    {
                        //se nao localizou o cep
                        Resultado.Sucesso = false;
                        Resultado.Mensagem = "CEP (" + cep + ") não localizado!";
                    }
                }
                else
                {
                    //se a execucao nao foi realizada com sucesso.
                    Resultado.Sucesso = false;
                    Resultado.Mensagem = conteudo;
                    Resultado.NumeroErro = (int)resposta.StatusCode;
                }
            }
            catch(Exception ex)
            {
                //se ocorreu erro na execucao
                Resultado.Sucesso = false;
                Resultado.Mensagem = ex.Message;
                Resultado.NumeroErro = ex.HResult;
            }
            return end;
        }
    }
}
