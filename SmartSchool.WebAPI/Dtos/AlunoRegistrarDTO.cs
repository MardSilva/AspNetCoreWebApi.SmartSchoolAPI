using System;

namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoRegistrarDTO
    {
        public int IdAluno { get; set; }
        public int MatriculaAluno { get; set; }
        public string NomeAluno { get; set; }
        public string SobrenomeAluno { get; set; }
        public string TelefoneAluno { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool AlunoAtivo { get; set; } = true;
    }
}