using System;

namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoDTO
    {
        public int IdAluno { get; set; }
        public int MatriculaAluno { get; set; }
        public string NomeAluno { get; set; }
        public string TelefoneAluno { get; set; }
        public int Idade { get; set; }
        public DateTime DataInicio { get; set; }
        public bool AlunoAtivo { get; set; }
    }
}