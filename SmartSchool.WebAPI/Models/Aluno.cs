using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Aluno
    {
        public Aluno() { }
        public Aluno(int idAluno, string nomeAluno, string sobrenomeAluno, string telefoneAluno)
        {
            this.IdAluno = idAluno;
            this.NomeAluno = nomeAluno;
            this.SobrenomeAluno = sobrenomeAluno;
            this.TelefoneAluno = telefoneAluno;

        }
        public int IdAluno { get; set; }
        public string NomeAluno { get; set; }
        public string SobrenomeAluno { get; set; }
        public string TelefoneAluno { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}