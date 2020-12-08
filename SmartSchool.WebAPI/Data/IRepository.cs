using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        //criando a interface de forma genérica
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         bool SaveChanges();

         //Métodos para Alunos
         Aluno[] GetAllAlunos(bool blnIncluirProfessor = false);
         Aluno[] GetAllAlunosByDisciplinaId(int idDisciplina, bool blnIncluirProfessor = false);
         Aluno GetAlunoById(int idAluno, bool blnIncluirProfessor = false);

         //Métodos para Professores
         Professor[] GetAllProfessores(bool blnIncluirAlunos = false);
         Professor[] GetAllProfessoresByDisciplinaId(int idDisciplina, bool blnIncluirAlunos = false);
         Professor GetProfessorById(int idProfessor, bool blnIncluirProfessor = false);
         Professor[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false);
    }
}