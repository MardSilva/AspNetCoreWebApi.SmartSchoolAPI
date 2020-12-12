using System;

namespace SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    /// DTO do Aluno responsavel por registrar/cadastrar informacoes
    /// </summary>
    public class AlunoRegistrarDTO
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
        /// Nome e sobrenome do Aluno
        /// </summary>
        public string NomeAluno { get; set; }
        public string SobrenomeAluno { get; set; }
        /// <summary>
        /// Telefone do Aluno
        /// </summary>
        public string TelefoneAluno { get; set; }
        /// <summary>
        /// Data de Nascimento do Aluno
        /// </summary>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Data de In�cio do Aluno
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data Fim do Aluno
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Verifica��o/valida��o do status do Aluno
        /// </summary>
        public bool AlunoAtivo { get; set; } = true;
    }
}