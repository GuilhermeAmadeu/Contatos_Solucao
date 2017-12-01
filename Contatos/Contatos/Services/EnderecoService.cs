using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contatos.Models;


namespace Contatos.Services
{
    public class EnderecoService : ServiceBase
    {
        public EnderecoService(): base()
        {
            cliente.BaseAddress = new Uri("https://viacep.com.br/ws/");
        }
    }
}
