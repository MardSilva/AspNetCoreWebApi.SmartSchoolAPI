using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Aluno
    {
        public Aluno() { }
        public Aluno(int idAluno, int matriculaAluno, string nomeAluno, string sobrenomeAluno, string telefoneAluno, DateTime dataNascimento)
        {
            this.IdAluno = idAluno;
            this.MatriculaAluno = matriculaAluno;
            this.NomeAluno = nomeAluno;
            this.SobrenomeAluno = sobrenomeAluno;
            this.TelefoneAluno = telefoneAluno;
            this.DataNascimento = dataNascimento;
        }
        public int IdAluno { get; set; }
        public int MatriculaAluno { get; set; }
        public string NomeAluno { get; set; }
        public string SobrenomeAluno { get; set; }
        public string TelefoneAluno { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool AlunoAtivo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}