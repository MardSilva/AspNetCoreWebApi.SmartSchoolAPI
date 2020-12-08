using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor() { }
        public Professor(int idProfessor, int registro, string nomeProfessor, string sobrenomeprofessor)
        {
            this.IdProfessor = idProfessor;
            this.Registro = registro;
            this.NomeProfessor = nomeProfessor;
            this.SobrenomeProfessor = sobrenomeprofessor;

        }
        public int IdProfessor { get; set; }
        public int Registro { get; set; }
        public string NomeProfessor { get; set; }
        public string SobrenomeProfessor { get; set; }
        public string TelefoneProfessor { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool AlunoAtivo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}