using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
   
        public class ObservacoesRepositorio : IObservacoesRepositorio
        {
            private readonly Contexto _dbContext;

            public ObservacoesRepositorio(Contexto dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<ObservacoesModel>> GetAll()
            {
                return await _dbContext.Observacao.ToListAsync();
            }
            public async Task<ObservacoesModel> GetById(int id)
            {
                return await _dbContext.Observacao
                                       .FirstOrDefaultAsync(x => x.ObservacaoId == id);
            }
            public async Task<ObservacoesModel> InsertObservacoes(ObservacoesModel observacao)
            {
                await _dbContext.Observacao.AddAsync(observacao);
                await _dbContext.SaveChangesAsync();
                return observacao;
            }
            public async Task<ObservacoesModel> UpdateObservacoes(ObservacoesModel observacao, int id)
            {
                ObservacoesModel observacoes = await GetById(id);
                if (observacoes == null)
                {
                    throw new Exception("Não encontrado.");
                }
                else
                {
                    
                    observacoes.ObservacaoDescricao = observacao.ObservacaoDescricao;
                    observacoes.ObservacaoLocal = observacao.ObservacaoLocal;
                    observacoes.ObservacaoData = observacao.ObservacaoData;
                    observacoes.UsuarioId = observacao.UsuarioId;
                    observacoes.PessoaId = observacao.PessoaId;
                    _dbContext.Observacao.Update(observacoes);
                    await _dbContext.SaveChangesAsync();
                }
                return observacao;
            }

            public async Task<bool> DeleteObservacoes(int id)
            {
                ObservacoesModel observacoes = await GetById(id);
                if (observacoes == null)
                {
                    throw new Exception("Não encontrado.");
                }

                _dbContext.Observacao.Remove(observacoes);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
    }

