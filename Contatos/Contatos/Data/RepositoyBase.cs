using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Contatos.Models;

namespace Contatos.Data
{
    public class RepositoyBase
    {
        protected static SQLiteAsyncConnection Conexao { get; set; }
        public RepositoyBase()
        {
            
            //verificar se a conexao esta nula
            if(Conexao == null)
            {
                Inicializar();
            }
        }
        private void Inicializar()
        {
            //obter a implementaçao da interface de acordo com a app
            IFileHelper fh = DependencyService.Get<IFileHelper>();

            //caminho do arquivo do banco
            var caminho = fh.GetLocalFilePath("ContatosSQLite.db3");

            //instanciar a conexao
            Conexao = new SQLiteAsyncConnection(caminho);

            //criar tabelas
            Conexao.CreateTableAsync<Pessoa>().Wait();
            Conexao.CreateTableAsync<Evento>().Wait();
        }
    }
}
