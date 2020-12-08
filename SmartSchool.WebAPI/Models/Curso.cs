using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Curso
    {
        public Curso() { }
        public Curso(int idCurso, string nomeCurso)
        {
            this.IdCurso = idCurso;
            this.NomeCurso = nomeCurso;

        }
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}