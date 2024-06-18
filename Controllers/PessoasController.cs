using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasRepositorio _pessoasRepositorio;

        public PessoasController(IPessoasRepositorio pessoasRepositorio)
        {
            _pessoasRepositorio = pessoasRepositorio;
        }

        [HttpGet("GetAllPessoas")]
        public async Task<ActionResult<List<PessoasModel>>> GetAllPessoas()
        {
            List<PessoasModel> pessoas = await _pessoasRepositorio.GetAll();
            return Ok(pessoas);
        }

        [HttpGet("GetPessoasId/{id}")]
        public async Task<ActionResult<PessoasModel>> GetPessoaId(int id)
        {
            PessoasModel pessoa = await _pessoasRepositorio.GetById(id);
            return Ok(pessoa);
        }

        [HttpPost("CreatePessoas")]
        public async Task<ActionResult<PessoasModel>> InsertUsuario([FromBody] PessoasModel pessoasModel)
        {
            PessoasModel pessoa = await _pessoasRepositorio.InsertPessoas(pessoasModel);
            return Ok(pessoa);
        }
        [HttpPost("InsertPessoas")]
        public async Task<ActionResult<PessoasModel>> InsertPessoas([FromBody] PessoasModel pessoasModel)
        {
            PessoasModel pessoa = await _pessoasRepositorio.InsertPessoas(pessoasModel);
            return Ok(pessoa);
        }

    }
}
