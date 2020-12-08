using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartSchoolContext _context;
        public Repository(SmartSchoolContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            //o aluno ou professor é o nosso entity. O T precisa ser conhecido pelo DBContext.
            _context.Add(entity);

        }
        public void Update<T>(T entity) where T : class
        {
            //o aluno ou professor é o nosso entity. O T precisa ser conhecido pelo DBContext.
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            //o aluno ou professor é o nosso entity. O T precisa ser conhecido pelo DBContext.
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            //já que é booleano, eu posso verificar dessa forma se ele retorna alguma coisa (> 0) e ele irá salvar
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool blnIncluirProfessor = false)
        {
            IQueryable<Aluno> queryaluno = _context.Alunos;
            
            if(blnIncluirProfessor)
            {
                //uma ideia de SELECT com JOIN em Disciplina e Professor - ordenando por ID
                queryaluno = queryaluno.Include(a => a.AlunosDisciplinas)
                                       .ThenInclude(ad => ad.Disciplina)
                                       .ThenInclude(d => d.Professor);
            }
            queryaluno = queryaluno.AsNoTracking().OrderBy(a => a.IdAluno);

            return queryaluno.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int idDisciplina, bool blnIncluirProfessor = false)
        {
            IQueryable<Aluno> queryaluno = _context.Alunos;
            
            if(blnIncluirProfessor)
            {
                //uma ideia de SELECT com JOIN em Disciplina e Professor - ordenando por ID
                queryaluno = queryaluno.Include(a => a.AlunosDisciplinas)
                                       .ThenInclude(ad => ad.Disciplina)
                                       .ThenInclude(d => d.Professor);
            }
            queryaluno = queryaluno.AsNoTracking()
                                   .OrderBy(a => a.IdAluno)
                                   .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == idDisciplina));

            return queryaluno.ToArray();
        }

        public Aluno GetAlunoById(int idAluno, bool blnIncluirProfessor = false)
        {
            IQueryable<Aluno> queryaluno = _context.Alunos;
            
            if(blnIncluirProfessor)
            {
                //uma ideia de SELECT com JOIN em Disciplina e Professor - ordenando por ID
                queryaluno = queryaluno.Include(a => a.AlunosDisciplinas)
                                       .ThenInclude(ad => ad.Disciplina)
                                       .ThenInclude(d => d.Professor);
            }
            queryaluno = queryaluno.AsNoTracking()
                                   .OrderBy(a => a.IdAluno)
                                   .Where(aluno => aluno.IdAluno == idAluno);

            return queryaluno.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool blnIncluirAlunos = false)
        {
            IQueryable<Professor> queryProfessor = _context.Professores;

            if(blnIncluirAlunos)
            {
                //JOIN em Disciplinas, AlunoDisciplinas e por fim em ALuno
                queryProfessor = queryProfessor.Include(p => p.Disciplinas)
                                               .ThenInclude(d => d.AlunosDisciplinas)
                                               .ThenInclude(ad => ad.Aluno);
            }

            //ORDER BY idProfessor
            queryProfessor = queryProfessor.AsNoTracking().OrderBy(p => p.IdProfessor);

            return queryProfessor.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int idDisciplina, bool blnIncluirAlunos = false)
        {
            IQueryable<Professor> queryProfessor = _context.Professores;

            if(blnIncluirAlunos)
            {
                queryProfessor = queryProfessor.Include(p => p.Disciplinas)
                                               .ThenInclude(d => d.AlunosDisciplinas)
                                               .ThenInclude(ad => ad.Aluno);
            }

            queryProfessor = queryProfessor.AsNoTracking()
                                           .OrderBy(aluno => aluno.IdProfessor)
                                           .Where(aluno => aluno.Disciplinas.Any(
                                               d => d.AlunosDisciplinas.Any(ad => ad.DisciplinaId == idDisciplina)
                                           ));
            return queryProfessor.ToArray();
        }

        public Professor GetProfessorById(int idProfessor, bool blnIncluirProfessor = false)
        {
            IQueryable<Professor> queryProfessor = _context.Professores;

            if(blnIncluirProfessor)
            {
                queryProfessor = queryProfessor.Include(p => p.Disciplinas)
                                               .ThenInclude(d => d.AlunosDisciplinas)
                                               .ThenInclude(ad => ad.Aluno);
            }

            queryProfessor = queryProfessor.AsNoTracking()
                                           .OrderBy(a => a.IdProfessor)
                                           .Where(professor => professor.IdProfessor == idProfessor);
            
            return queryProfessor.FirstOrDefault();
        }

        public Professor[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.IdProfessor)
                         .Where(aluno => aluno.Disciplinas.Any(
                             d => d.AlunosDisciplinas.Any(ad => ad.AlunoId == alunoId)
                         ));

            return query.ToArray();
        }
    }
}