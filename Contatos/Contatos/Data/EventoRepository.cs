using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contatos.Models;

namespace Contatos.Data
{
    public class EventoRepository : RepositoyBase
    {
        public async Task<Evento> SelecionarAsync(int id)
        {
            //localizar pela chave primaria
            return await Conexao.FindAsync<Evento>(id);
        }

        public async Task<List<Evento>> ListarAsync()
        {
            //listar todos os registros cadastrados
            return await Conexao.Table<Evento>().ToListAsync();
        }

        public async Task<List<Evento>> PesquisarAsync(string conteudo)
        {
            //filtrar os registros
            return await Conexao.Table<Evento>()
                .Where(r => r.Nome.Contains(conteudo) || r.Local.Contains(conteudo) || r.Status.Contains(conteudo) || r.Id.Equals(conteudo)).ToListAsync();

        }
        public async Task<ResultadoOperacao> SalvarAsync(Evento item)
        {
            var resultado = new ResultadoOperacao()
            {
                Sucesso = true
            };

            //executar o comando para salvar
            try
            {
                var qtd = await Conexao.InsertOrReplaceAsync(item);

                //verifica se incluiu /alterou
                if (qtd == 0)
                {
                    resultado.Sucesso = false;
                    resultado.Mensagem = "Não foi possivel salvar!";
                }
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = ex.Message;
            }
            return resultado;
        }

       
        public async Task<ResultadoOperacao> ExcluirAsync(Evento item)
        {
            var resultado = new ResultadoOperacao()
            {
                Sucesso = true
            };

            //executar o comando para excluir
            try
            {
                var qtd = await Conexao.DeleteAsync(item);

                //verifica se incluiu /alterou
                if (qtd == 0)
                {
                    resultado.Sucesso = false;
                    resultado.Mensagem = "Não foi possivel excluir!";
                }
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = ex.Message;
            }
            return resultado;
        }
    }
}
