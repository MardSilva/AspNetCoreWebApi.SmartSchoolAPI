using System;

namespace SmartSchool.WebAPI.V1.Dtos
{
    public class ProfessorRegistrarDTO
    {
        /// <summary>
        /// ID do Professor
        /// </summary>
        public int IdProfessor { get; set; }
        /// <summary>
        /// Registro na Institui��o Acad�mica do Professor
        /// </summary>
        public int Registro { get; set; }
        /// <summary>
        /// Nome e sobrenome do Professor
        /// </summary>
        public string NomeProfessor { get; set; }
        public string SobrenomeProfessor { get; set; }
        /// <summary>
        /// Telefone do Professor
        /// </summary>
        public string TelefoneProfessor { get; set; }
        /// <summary>
        /// Data de In�cio do Professor
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data Fim do Professor
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Valida��o/verifica��o dos alunos Ativos do Professor
        /// </summary>
        public bool AlunoAtivo { get; set; } = true;
    }
}