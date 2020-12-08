using System;

namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorRegistrarDTO
    {
        public int IdProfessor { get; set; }
        public int Registro { get; set; }
        public string NomeProfessor { get; set; }
        public string SobrenomeProfessor { get; set; }
        public string TelefoneProfessor { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool AlunoAtivo { get; set; } = true;
    }
}