using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repositorio;

        public ProfessorController(IRepository repo)
        {
            _repositorio = repo;
        }

        //GET
        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _repositorio.GetAllProfessores(true);
            return Ok(resultado);
        }

        // api/Professor/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repositorio.GetProfessorById(id, false);
            
            //validação do aluno e retorno como bad request
            if(professor == null) return BadRequest("O Professor informado com código " + id + " não foi encontrado.");
            return Ok(professor);
        }

        //POST
        // api/Professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            //corrigindo a chamada
            _repositorio.Add(professor);

            //melhoria na validação
            if(_repositorio.SaveChanges())
            {
                return Ok(professor);
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O professor informado não foi cadastrado.");
        }

        //PUT
        // api/Professor/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var profput = _repositorio.GetProfessorById(id, false);
            if(profput == null) return BadRequest("O Professor informado não foi encontrado.");

            _repositorio.Update(professor);

            if(_repositorio.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("O Professor informado não foi encontrado.");
        }

        //PATCH
        // api/Professor/{id}
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var profpatch = _repositorio.GetProfessorById(id, false);
            if(profpatch == null) return BadRequest("O Professor informado para a atualização não foi encontrado.");

            _repositorio.Update(professor);

            if(_repositorio.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("O Professor informado para atualização não foi encontrado.");
        }

        //DELETE
        // api/Professor
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var profremover = _repositorio.GetProfessorById(id, false);
            if(profremover == null) return BadRequest("O Professor para remoção informado não foi encontrado.");

            _repositorio.Delete(profremover);

            if(_repositorio.SaveChanges())
            {
                return Ok();
            }

            return BadRequest("O Professor informado para remoção não foi encontrado.");
        }
    }
}