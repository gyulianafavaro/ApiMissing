using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPessoasRepositorio
    {
        Task<List<PessoasModel>> GetAll();

        Task<PessoasModel> GetById(int id);

        Task<PessoasModel> InsertPessoas(PessoasModel pessoa);

        Task<PessoasModel> UpdatePessoas(PessoasModel pessoa, int id);

        Task<bool> DeletePessoas(int id);
    }
}
