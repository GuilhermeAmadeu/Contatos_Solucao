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
    }
}
