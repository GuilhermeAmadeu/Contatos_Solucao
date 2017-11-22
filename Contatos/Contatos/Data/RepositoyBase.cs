using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contatos.Data
{
    public class RepositoyBase
    {
        public RepositoyBase()
        {

        }
        private void Inicializar()
        {
            //obter a implementaçao da interface de acordo com a app
            IFileHelper fh = DependencyService.Get<IFileHelper>();

            //caminho do arquivo do banco
            var caminho = fh.GetLocalFilePath("ContatosSQLite.db3");

            //instanciar a conexao
        }
    }
}
