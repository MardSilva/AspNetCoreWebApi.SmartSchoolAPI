using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class SmartSchoolContext : DbContext
    {
        public SmartSchoolContext(DbContextOptions<SmartSchoolContext> options) : base(options){ }
        
        //inicialização do Contexto para cada classe das Models.
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        //Relacionamentos
        protected override void OnModelCreating(ModelBuilder mdBuilder)
        {
            mdBuilder.Entity<Aluno>()
                .HasKey(a => new {a.IdAluno});
            //muitos para muitos
            mdBuilder.Entity<AlunoDisciplina>()
                .HasKey(ad => new {ad.AlunoId, ad.DisciplinaId});
            
            mdBuilder.Entity<AlunoCurso>()
                     .HasKey(ac => new {ac.AlunoId, ac.CursoId});
            
            mdBuilder.Entity<Curso>()
                     .HasKey(c => new{c.IdCurso});

            mdBuilder.Entity<Disciplina>()
                .HasKey(d => new {d.IdDisciplina});

            mdBuilder.Entity<Professor>()
                .HasKey(p => new {p.IdProfessor});

            //Carga inicial
            mdBuilder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, 1, "Lauro", "Oliveira"),
                    new Professor(2, 2, "Roberto", "Soares"),
                    new Professor(3, 3, "Ronaldo", "Marconi"),
                    new Professor(4, 4, "Rodrigo","Carvalho"),
                    new Professor(5, 5, "Alexandre","Montanha"),
                });

            mdBuilder.Entity<Curso>()
            .HasData(new List<Curso> {
                new Curso(1, "Tecnologia da Informação"),
                new Curso(2, "Sistemas de Informação"),
                new Curso(3, "Ciência da Computação")
            });
            
            mdBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1, 1),
                    new Disciplina(2, "Matemática", 1, 3),
                    new Disciplina(3, "Física", 2, 3),
                    new Disciplina(4, "Português", 3, 1),
                    new Disciplina(5, "Inglês", 4, 1),
                    new Disciplina(6, "Inglês", 4, 2),
                    new Disciplina(7, "Inglês", 4, 3),
                    new Disciplina(8, "Programação", 5, 1),
                    new Disciplina(9, "Programação", 5, 2),
                    new Disciplina(10, "Programação", 5, 3)
                });
            
            mdBuilder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, 1, "Marta", "Kent", "33225555", DateTime.Parse("28/05/2005")),
                    new Aluno(2, 2, "Paula", "Isabela", "3354288", DateTime.Parse("28/05/2005")),
                    new Aluno(3, 3, "Laura", "Antonia", "55668899", DateTime.Parse("28/05/2005")),
                    new Aluno(4, 4, "Luiza", "Maria", "6565659", DateTime.Parse("28/05/2005")),
                    new Aluno(5, 5, "Lucas", "Machado", "565685415",DateTime.Parse("28/05/2005")),
                    new Aluno(6, 6, "Pedro", "Alvares", "456454545", DateTime.Parse("28/05/2005")),
                    new Aluno(7, 7, "Paulo", "José", "9874512", DateTime.Parse("28/05/2005"))
                });

            mdBuilder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });
        }
    }
}