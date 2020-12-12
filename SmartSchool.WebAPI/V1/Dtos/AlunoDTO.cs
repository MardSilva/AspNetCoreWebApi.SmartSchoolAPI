using System;

namespace SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    /// DTO do Aluno para cadastrar/registrar algum dado ou informa��o.
    /// </summary>
    public class AlunoDTO
    {
        /// <summary>
        /// ID do Aluno
        /// </summary>
        public int IdAluno { get; set; }
        /// <summary>
        /// Matr�cula do Aluno
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
        /// Data de In�cio do Aluno
        /// </summary>
        public DateTime DataInicio { get; set; }
        /// <summary>
        /// Valida��o do Aluno
        /// </summary>
        public bool AlunoAtivo { get; set; }
    }
}