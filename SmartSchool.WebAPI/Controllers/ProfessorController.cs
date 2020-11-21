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
        private readonly SmartSchoolContext _context;

        public ProfessorController(SmartSchoolContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // api/Professor/{id}
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.IdProfessor == id);
            
            //validação do aluno e retorno como bad request
            if(professor == null) return BadRequest("O Professor informado com código " + id + " não foi encontrado.");
            return Ok(professor);
        }

        // api/Professor/byName?nome=nome_aqui
        // observação:  por padrão é string, não precisa por o tipo 'string'.
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p =>p.NomeProfessor.Contains(nome));
            
            //validação do aluno e retorno como bad request
            if(professor == null) return BadRequest("O Professor informado com nome " + nome + " não foi encontrado.");
            return Ok(professor);
        }

        //POST
        // api/Professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //PUT
        // api/Professor/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var profput = _context.Professores.AsNoTracking().FirstOrDefault(prof => prof.IdProfessor == id);
            if(profput == null) return BadRequest("O Professor informado não foi encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //PATCH
        // api/Professor/{id}
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var profpatch = _context.Professores.AsNoTracking().FirstOrDefault(pp => pp.IdProfessor == id);
            if(profpatch == null) return BadRequest("O Professor informado não foi encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //DELETE
        // api/Professor
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var profremover = _context.Professores.FirstOrDefault(pr => pr.IdProfessor == id);
            if(profremover == null) return BadRequest("O Professor para remoção informado não foi encontrado.");

            _context.Remove(profremover);
            _context.SaveChanges();
            return Ok();
        }
    }
}