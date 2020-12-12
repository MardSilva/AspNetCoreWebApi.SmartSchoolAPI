using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// Controller de Alunos
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repositorio = repo;
        }

        /// <summary>
        /// Método responsável por retornar todos os alunos do SmartSchool API.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repositorio.GetAllAlunos(false);

            //Mapper
            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));
        }


        /// <summary>
        /// Método responsável por retornar apenas um aluno por meio do parâmetro ID do SmartSchool API.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // api/aluno/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repositorio.GetAlunoById(id, false);

            //validação do aluno e retorno como bad request
            if (aluno == null) return BadRequest("O aluno informado com código " + id + " não foi encontrado.");

            //retornando com o mapper
            var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

            return Ok(alunoDTO);
        }

        /// <summary>
        /// Método responsável por submeter a requisição de envio dos dados de um Aluno para a SmartSchool API.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDTO model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            //corrigindo a chamada
            _repositorio.Add(aluno);

            //melhoria na validação
            if (_repositorio.SaveChanges())
            {
                return Created($"/api/aluno/{model.IdAluno}", _mapper.Map<AlunoDTO>(aluno));
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O aluno informado não foi cadastrado.");
        }


        /// <summary>
        /// Método responsável pela atualização dos dados de um Aluno para a SmartSchool API.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDTO model)
        {
            //implementando de forma simplificada o PUT
            var alunoput = _repositorio.GetAlunoById(id);
            if (alunoput == null) return BadRequest("O Aluno informado para Atualização (PUT) não foi encontrado.");

            //corringdo o Mapper (mapeamento)
            _mapper.Map(model, alunoput);

            //corrigindo a chamada
            _repositorio.Update(alunoput);

            //melhoria na validação
            if (_repositorio.SaveChanges())
            {
                return Created($"/api/aluno/{model.IdAluno}", _mapper.Map<AlunoDTO>(alunoput));
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O Aluno informado para Atualização (PUT) não foi encontrado.");
        }


        /// <summary>
        /// Método responsável pela atualização parcial dos dados de um Aluno para a SmartSchool API.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDTO model)
        {
            //implementando de forma simplificada o PATCH
            var alunopatch = _repositorio.GetAlunoById(id);
            if (alunopatch == null) return BadRequest("O Aluno informado para Atualização Parcial (PATCH) não foi encontrado.");

            //corringdo o Mapper (mapeamento)
            _mapper.Map(model, alunopatch);

            //corrigindo a chamada
            _repositorio.Update(alunopatch);

            //melhoria na validação
            if (_repositorio.SaveChanges())
            {
                return Created($"/api/aluno/{model.IdAluno}", _mapper.Map<AlunoDTO>(alunopatch));
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O Aluno informado para Atualização (PUT) não foi encontrado.");
        }


        /// <summary>
        /// Método responsável pela remoção dos dados de um Aluno para a SmartSchool API.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //implementando de forma simplificada o POST
            var alunoremover = _repositorio.GetAlunoById(id);
            if (alunoremover == null) return BadRequest("O Aluno informado para ser removido, não foi encontrado.");

            //corrigindo a chamada
            _repositorio.Delete(alunoremover);

            //melhoria na validação
            if (_repositorio.SaveChanges())
            {
                return Ok("O aluno informado foi removido.");
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O Aluno informado para ser removido, não foi encontrado.");
        }
    }
}