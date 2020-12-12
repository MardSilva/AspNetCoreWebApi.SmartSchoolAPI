using System;

namespace SmartSchool.WebAPI.V2.Dtos
{
    /// <summary>
    /// DTO do Aluno para cadastrar/registrar algum dado ou informacao.
    /// </summary>
    public class AlunoDTO
    {
        /// <summary>
        /// ID do Aluno
        /// </summary>
        public int IdAluno { get; set; }
        /// <summary>
        /// Matricula do Aluno
        /// </summary>
        public int MatriculaAluno { get; set; }
        /// <summary>
        /// Nome do Aluno
        /// </summary>
        public string NomeAluno { get; set; }
        /// <summary>
        /// Telefone do Aluno
        /// </summary>
        public string TelefoneAluno { get; set; }
        /// <summary>
        /// Idade do Aluno
        /// </summary>
        public int Idade { get; set; }
        /// <summary>
        /// Data de inicio do Aluno
        /// </summary>
        public DateTime DataInicio { get; set; }
        /// <summary>
        /// Validar do Aluno
        /// </summary>
        public bool AlunoAtivo { get; set; }
    }
}