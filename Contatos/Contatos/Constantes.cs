using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos
{
    public static class Constantes
    {
        //url do serviço
        public const string URL_SERVICO = "http://localhost:2502/api/"; // alterar conforme a url
        public const string CONTEUDO_JSON = "application/json";
        public const string MENSAGEM_SALVO_SUCESSO ="Item salvo com sucesso.";
        public const string MENSAGEM_ERRO_SALVAR ="Erro ao salvar o item:{0}.";
        public const string MENSAGEM_EXCLUIDO_SUCESSO ="Item excluído com sucesso.";
        public const string MENSAGEM_ERRO_EXCLUIR ="Erro ao exlcuir o item: {0}.";
        public const string MENSAGEM_ERRO ="Erro ao realizar a operação: {0}.";
    }
}
