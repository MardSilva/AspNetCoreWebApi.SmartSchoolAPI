using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Disciplina
    {
        public Disciplina() { }
        public Disciplina(int idDisciplina, string nomeDisciplina, int professorId)
        {
            this.IdDisciplina = idDisciplina;
            this.NomeDisciplina = nomeDisciplina;
            this.ProfessorId = professorId;
        }
        public int IdDisciplina { get; set; }
        public string NomeDisciplina { get; set; }

        // Referência à chave primária do Professor. Por padrão do EntityFramework, fica sempre dessa forma. 
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}