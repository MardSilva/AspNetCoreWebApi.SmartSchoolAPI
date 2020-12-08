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
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repositorio;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repositorio = repo;
        }

        //GET
        [HttpGet]
        public IActionResult Get()
        {
            var professor = _repositorio.GetAllProfessores(true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(professor));
        }

        // api/Professor/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repositorio.GetProfessorById(id, false);

            //validação do aluno e retorno como bad request
            if (professor == null) return BadRequest("O Professor informado com código " + id + " não foi encontrado.");

            //Mapper
            var professorDTO = _mapper.Map<ProfessorDTO>(professor);

            return Ok(professor);
        }

        // api/Professor
        [HttpGet("byaluno/{alunoId}")]
        public IActionResult GetByAlunoId(int alunoId)
        {
            var Professores = _repositorio.GetProfessoresByAlunoId(alunoId, true);
            if (Professores == null) return BadRequest("Professores não encontrados");

            return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(Professores));
        }

        //POST
        // api/Professor
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDTO model)
        {
            var professor = _mapper.Map<Professor>(model);

            //corrigindo a chamada
            _repositorio.Add(professor);

            //melhoria na validação
            if (_repositorio.SaveChanges())
            {
                return Created($"/api/professor/{model.IdProfessor}", _mapper.Map<ProfessorDTO>(professor));
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O professor informado não foi cadastrado.");
        }

        //PUT
        // api/Professor/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDTO model)
        {
            var profput = _repositorio.GetProfessorById(id, false);
            if (profput == null) return BadRequest("O Professor informado não foi encontrado.");

            _mapper.Map(model, profput);

            _repositorio.Update(profput);

            if (_repositorio.SaveChanges())
            {
                return Created($"/api/professor/{model.IdProfessor}", _mapper.Map<ProfessorDTO>(profput));
            }

            return BadRequest("O Professor informado não foi encontrado.");
        }

        //PATCH
        // api/Professor/{id}
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDTO model)
        {
            var profpatch = _repositorio.GetProfessorById(id, false);
            if (profpatch == null) return BadRequest("O Professor informado para a atualização não foi encontrado.");

            _mapper.Map(model, profpatch);

            _repositorio.Update(profpatch);

            if (_repositorio.SaveChanges())
            {
                return Created($"/api/professor/{model.IdProfessor}", _mapper.Map<ProfessorDTO>(profpatch));
            }

            return BadRequest("O Professor informado para atualização não foi encontrado.");
        }

        //DELETE
        // api/Professor
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var profremover = _repositorio.GetProfessorById(id, false);
            if (profremover == null) return BadRequest("O Professor para remoção informado não foi encontrado.");

            _repositorio.Delete(profremover);

            if (_repositorio.SaveChanges())
            {
                return Ok();
            }

            return BadRequest("O Professor informado para remoção não foi encontrado.");
        }
    }
}