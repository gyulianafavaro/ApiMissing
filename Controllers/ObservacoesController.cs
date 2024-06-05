using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacoesController : ControllerBase
    {
        private readonly IObservacoesRepositorio _observacoesRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
        {
            _observacoesRepositorio = observacoesRepositorio;
        }
        [HttpGet("GetAllObservacoes")]
        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoes()
        {
            List<ObservacoesModel> observacoes = await _observacoesRepositorio.GetAll();
            return Ok(observacoes);
        }
        [HttpGet("GetObservacaoId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetObservacaoId(int id)
        {
            ObservacoesModel observacao = await _observacoesRepositorio.GetById(id);
            return Ok(observacao);
        }
        [HttpPost("InsertObservacoes")]
        public async Task<ActionResult<ObservacoesModel>> InsertObservacoes([FromBody] ObservacoesModel observacoesModel)
        {
            ObservacoesModel observacao = await _observacoesRepositorio.InsertObservacoes(observacoesModel);
            return Ok(observacao);
        }
        [HttpPut("UpdateObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> UpdateObservacoes(int id, [FromBody] ObservacoesModel observacaoModel)
        {
            observacaoModel.ObservacaoId = id;
            ObservacoesModel observacao = await _observacoesRepositorio.UpdateObservacoes(observacaoModel, id);
            return Ok(observacao);
        }
        [HttpDelete("DeleteObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> DeleteObservacoes(int id)
        {
            bool deleted = await _observacoesRepositorio.DeleteObservacoes(id);
            return Ok(deleted);
        }

    }
}

