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
    public class AlunoController : ControllerBase
    {
        private readonly SmartSchoolContext _context;

        public AlunoController(SmartSchoolContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // api/aluno/{id}
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.IdAluno == id);
            
            //validação do aluno e retorno como bad request
            if(aluno == null) return BadRequest("O aluno informado com código " + id + " não foi encontrado.");
            return Ok(aluno);
        }

        // api/aluno/byName?nome=nome_aqui
        // observação:  por padrão é string, não precisa por o tipo 'string'.
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a =>a.NomeAluno.Contains(nome));
            
            //validação do aluno e retorno como bad request
            if(aluno == null) return BadRequest("O aluno informado com nome " + nome + " não foi encontrado.");
            return Ok(aluno);
        }

        // api/aluno/byName?nome=nome_aqui&sobrenome=sobrenome_aqui
        // observação:  por padrão é string, não precisa por o tipo 'string'.
        [HttpGet("ByNameAndSurname")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a =>a.NomeAluno.Contains(nome) && a.SobrenomeAluno.Contains(sobrenome));
            
            //validação do aluno e retorno como bad request
            if(aluno == null) return BadRequest("O aluno informado com nome " + nome + " e de sobrenome: " + sobrenome + " não foi encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post (Aluno aluno)
        {
            //implementando de forma simplificada o POST
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            //implementando de forma simplificada o PUT
            var alunoput = _context.Alunos.AsNoTracking().FirstOrDefault(aput => aput.IdAluno == id);
            if(alunoput == null) return BadRequest("O Aluno informado para Atualização (PUT) não foi encontrado.");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            //implementando de forma simplificada o PATCH
            var alunopatch = _context.Alunos.AsNoTracking().FirstOrDefault(ap => ap.IdAluno == id);
            if(alunopatch == null) return BadRequest("O Aluno informado para Atualização Parcial (PATCH) não foi encontrado.");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //implementando de forma simplificada o POST
            var alunoremover = _context.Alunos.FirstOrDefault(ar => ar.IdAluno == id);
            if(alunoremover == null) return BadRequest("O Aluno informado para ser removido, não foi encontrado.");

            _context.Remove(alunoremover);
            _context.SaveChanges();
            return Ok();
        }
    }
}