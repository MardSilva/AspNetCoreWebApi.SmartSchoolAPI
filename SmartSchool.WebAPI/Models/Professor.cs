using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor() { }
        public Professor(int idProfessor, string nomeProfessor)
        {
            this.IdProfessor = idProfessor;
            this.NomeProfessor = nomeProfessor;

        }
        public int IdProfessor { get; set; }
        public string NomeProfessor { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}