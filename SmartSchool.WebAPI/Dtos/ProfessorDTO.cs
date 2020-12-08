using System;
using System.Collections.Generic;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorDTO
    {
    public int IdProfessor { get; set; }
        public int Registro { get; set; }
        public string NomeProfessor { get; set; }
        public string TelefoneProfessor { get; set; }
        public bool AlunoAtivo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}