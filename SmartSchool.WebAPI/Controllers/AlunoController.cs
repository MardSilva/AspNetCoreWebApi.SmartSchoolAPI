using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                IdAluno = 1,
                NomeAluno = "Eymard",
                SobrenomeAluno = "Silva",
                TelefoneAluno = "123456789",
            },
            
            new Aluno()
            {
                IdAluno = 2,
                NomeAluno = "Virgínia",
                SobrenomeAluno = "Lorena",
                TelefoneAluno = "987654321"
            },

            new Aluno()
            {
                IdAluno = 3,
                NomeAluno = "Eduardo",
                SobrenomeAluno = "José",
                TelefoneAluno = "465798132"
            },
        };
        
        public AlunoController(){ }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // api/aluno/{id}
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.IdAluno == id);
            
            //validação do aluno e retorno como bad request
            if(aluno == null) return BadRequest("O aluno informado com código " + id + " não foi encontrado.");
            return Ok(aluno);
        }

        // api/aluno/byName?nome=nome_aqui
        // observação:  por padrão é string, não precisa por o tipo 'string'.
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var aluno = Alunos.FirstOrDefault(a =>a.NomeAluno.Contains(nome));
            
            //validação do aluno e retorno como bad request
            if(aluno == null) return BadRequest("O aluno informado com nome " + nome + " não foi encontrado.");
            return Ok(aluno);
        }

        // api/aluno/byName?nome=nome_aqui&sobrenome=sobrenome_aqui
        // observação:  por padrão é string, não precisa por o tipo 'string'.
        [HttpGet("ByNameAndSurname")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a =>a.NomeAluno.Contains(nome) && a.SobrenomeAluno.Contains(sobrenome));
            
            //validação do aluno e retorno como bad request
            if(aluno == null) return BadRequest("O aluno informado com nome " + nome + " e de sobrenome: " + sobrenome + " não foi encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post (Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}