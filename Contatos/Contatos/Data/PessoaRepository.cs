using Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Data
{
    public class PessoaRepository : RepositoyBase
    {
        public async Task<Pessoa> SelecionarAsync(int id)
        {
            //localizar pela chave primaria
            return await Conexao.FindAsync<Pessoa>(id);
        }

        public async Task<List<Pessoa>> ListarAsync()
        {
            //listar todos os registros cadastrados
            return await Conexao.Table<Pessoa>().ToListAsync();
        }

        public async Task<List<Pessoa>> PesquisaAsync(string conteudo)
        {
            //filtrar os registros
            return await Conexao.Table<Pessoa>()
                .Where(r => r.Nome.Contains(conteudo) || r.Email.Contains(conteudo) || r.Telefone.Contains(conteudo)).ToListAsync();

        }      
        public async Task<ResultadoOperacao> SalvarAsync(Pessoa item)
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
            catch(Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = ex.Message;
            }
            return resultado;
        }
    }
}
