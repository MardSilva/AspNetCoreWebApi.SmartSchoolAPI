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
        private readonly IRepository _repositorio;

        public AlunoController(IRepository repo)
        {
            _repositorio = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _repositorio.GetAllAlunos(true);
            return Ok(resultado);
        }

        // api/aluno/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repositorio.GetAlunoById(id, false);
            
            //validação do aluno e retorno como bad request
            if(aluno == null) return BadRequest("O aluno informado com código " + id + " não foi encontrado.");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post (Aluno aluno)
        {
            //corrigindo a chamada
            _repositorio.Add(aluno);

            //melhoria na validação
            if(_repositorio.SaveChanges())
            {
                return Ok(aluno);
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O aluno informado não foi cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            //implementando de forma simplificada o PUT
            var alunoput = _repositorio.GetAlunoById(id);
            if(alunoput == null) return BadRequest("O Aluno informado para Atualização (PUT) não foi encontrado.");

            //corrigindo a chamada
            _repositorio.Update(aluno);

            //melhoria na validação
            if(_repositorio.SaveChanges())
            {
                return Ok(aluno);
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O Aluno informado para Atualização (PUT) não foi encontrado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            //implementando de forma simplificada o PATCH
            var alunopatch = _repositorio.GetAlunoById(id);
            if(alunopatch == null) return BadRequest("O Aluno informado para Atualização Parcial (PATCH) não foi encontrado.");

            //corrigindo a chamada
            _repositorio.Update(aluno);

            //melhoria na validação
            if(_repositorio.SaveChanges())
            {
                return Ok(aluno);
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O Aluno informado para Atualização (PUT) não foi encontrado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //implementando de forma simplificada o POST
            var alunoremover = _repositorio.GetAlunoById(id);
            if(alunoremover == null) return BadRequest("O Aluno informado para ser removido, não foi encontrado.");

            //corrigindo a chamada
            _repositorio.Delete(alunoremover);

            //melhoria na validação
            if(_repositorio.SaveChanges())
            {
                return Ok("O aluno informado foi removido.");
            }

            //validando ainda caso não consiga cadastrar
            return BadRequest("O Aluno informado para ser removido, não foi encontrado.");
        }
    }
}