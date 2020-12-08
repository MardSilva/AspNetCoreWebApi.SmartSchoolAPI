using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repositorio = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repositorio.GetAllAlunos(false);

            //Mapper
            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));
        }

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