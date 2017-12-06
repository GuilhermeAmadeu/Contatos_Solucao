using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Contatos.Services
{
    public abstract class ServiceBase
    {
        //acessar os serviços
        protected HttpClient cliente;

        //armazena o resultado da execucão
        public ResultadoOperacao Resultado { get; set; }

        public ServiceBase()
        {
            //instanciar o cliente
            cliente = new HttpClient();
            //definir o tamanho do buffer
            cliente.MaxResponseContentBufferSize = 256000;
        }

        protected void AdicionarToken()
        {
            var token = "";
            token = "de880996-93a5-4f63-a8a8-7bfa9a577704";

            //Definir o token no cabecalho da requisicao
            cliente.DefaultRequestHeaders.Add("token", token);
        }
    }
}
