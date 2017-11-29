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
            // Localizar pela chave primária
            return await Conexao.FindAsync<Pessoa>(id);
        }

        public async Task<List<Pessoa>> ListarAsync()
        {
            // Listar todos os registros cadastrados
            return await Conexao.Table<Pessoa>().ToListAsync();
        }

        public async Task<List<Pessoa>> PesquisarAsync(string conteudo)
        {
            // Filtrar os registros
            return await Conexao.Table<Pessoa>()
                .Where(r =>
                    r.Nome.Contains(conteudo) ||
                    r.Email.Contains(conteudo) ||
                    r.Telefone.Contains(conteudo))
                .ToListAsync();
        }

        public async Task<ResultadoOperacao> SalvarAsync(Pessoa item)
        {
            var resultado = new ResultadoOperacao()
            {
                Sucesso = true
            };

            // Executar o comando para salvar
            try
            {
                var qtd = await Conexao.InsertOrReplaceAsync(item);

                // Verificar se incluiu / alterou
                if (qtd == 0)
                {
                    resultado.Sucesso = false;
                    resultado.Mensagem = "Não foi possível salvar!";
                }
            }
            catch (Exception ex)
            {
                resultado.Sucesso = false;
                resultado.Mensagem = ex.Message;
            }

            return resultado;
        }

        public async Task<ResultadoOperacao> ExcluirAsync(Pessoa item)
        {
            var resultado = new ResultadoOperacao()
            {
                Sucesso = true
            };

            // Executar o comando para excluir
            try
            {
                var qtd = await Conexao.DeleteAsync(item);

                // Verificar se incluiu / alterou
                if (qtd == 0)
                {
                    resultado.Sucesso = false;
                    resultado.Mensagem = "Não foi possível excluir!";
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
