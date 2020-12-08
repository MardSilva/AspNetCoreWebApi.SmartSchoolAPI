using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Disciplina
    {
        public Disciplina() { }
        public Disciplina(int idDisciplina, string nomeDisciplina, int professorId, int cursoId)
        {
            this.IdDisciplina = idDisciplina;
            this.NomeDisciplina = nomeDisciplina;
            this.ProfessorId = professorId;
            this.CursoId = cursoId;
        }
        public int IdDisciplina { get; set; }
        public string NomeDisciplina { get; set; }
        public int CargaHoraria { get; set; }
        public int? PrerequisitoId { get; set; } = null;
        public Disciplina Prerequisito { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        // Referência à chave primária do Professor. Por padrão do EntityFramework, fica sempre dessa forma. 
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}