using System;
using System.Collections.Generic;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V2.Dtos
{
    public class ProfessorDTO
    {
        /// <summary>
        /// ID do Professor
        /// </summary>
        public int IdProfessor { get; set; }
        /// <summary>
        /// Registro do Professor na Instituicao
        /// </summary>
        public int Registro { get; set; }
        /// <summary>
        /// Nome do Professor
        /// </summary>
        public string NomeProfessor { get; set; }
        /// <summary>
        /// Telefone do Professor
        /// </summary>
        public string TelefoneProfessor { get; set; }
        /// <summary>
        /// Valida��o do Aluno de determinado Professor
        /// </summary>
        public bool AlunoAtivo { get; set; } = true;
        /// <summary>
        /// Disciplinas de um Aluno e do Professor
        /// </summary>
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}