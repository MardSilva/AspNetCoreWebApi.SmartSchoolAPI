using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class InicialDtoMapper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MatriculaAluno = table.Column<int>(nullable: false),
                    NomeAluno = table.Column<string>(nullable: true),
                    SobrenomeAluno = table.Column<string>(nullable: true),
                    TelefoneAluno = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    AlunoAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCurso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    IdProfessor = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    NomeProfessor = table.Column<string>(nullable: true),
                    SobrenomeProfessor = table.Column<string>(nullable: true),
                    TelefoneProfessor = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    AlunoAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.IdProfessor);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    IdDisciplina = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDisciplina = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.IdDisciplina);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "IdDisciplina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "IdProfessor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "IdDisciplina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "AlunoAtivo", "DataFim", "DataInicio", "DataNascimento", "MatriculaAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 1, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(3966), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "AlunoAtivo", "DataFim", "DataInicio", "DataNascimento", "MatriculaAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 2, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(5770), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "AlunoAtivo", "DataFim", "DataInicio", "DataNascimento", "MatriculaAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 3, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(5834), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "AlunoAtivo", "DataFim", "DataInicio", "DataNascimento", "MatriculaAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 4, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(5841), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "AlunoAtivo", "DataFim", "DataInicio", "DataNascimento", "MatriculaAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 5, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(5846), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "AlunoAtivo", "DataFim", "DataInicio", "DataNascimento", "MatriculaAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 6, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(5857), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "AlunoAtivo", "DataFim", "DataInicio", "DataNascimento", "MatriculaAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 7, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(5861), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "IdCurso", "NomeCurso" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "IdCurso", "NomeCurso" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "IdCurso", "NomeCurso" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "AlunoAtivo", "DataFim", "DataInicio", "NomeProfessor", "Registro", "SobrenomeProfessor", "TelefoneProfessor" },
                values: new object[] { 1, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 965, DateTimeKind.Local).AddTicks(7576), "Lauro", 1, "Oliveira", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "AlunoAtivo", "DataFim", "DataInicio", "NomeProfessor", "Registro", "SobrenomeProfessor", "TelefoneProfessor" },
                values: new object[] { 2, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 966, DateTimeKind.Local).AddTicks(9701), "Roberto", 2, "Soares", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "AlunoAtivo", "DataFim", "DataInicio", "NomeProfessor", "Registro", "SobrenomeProfessor", "TelefoneProfessor" },
                values: new object[] { 3, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 966, DateTimeKind.Local).AddTicks(9746), "Ronaldo", 3, "Marconi", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "AlunoAtivo", "DataFim", "DataInicio", "NomeProfessor", "Registro", "SobrenomeProfessor", "TelefoneProfessor" },
                values: new object[] { 4, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 966, DateTimeKind.Local).AddTicks(9749), "Rodrigo", 4, "Carvalho", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "AlunoAtivo", "DataFim", "DataInicio", "NomeProfessor", "Registro", "SobrenomeProfessor", "TelefoneProfessor" },
                values: new object[] { 5, true, null, new DateTime(2020, 12, 8, 10, 59, 26, 966, DateTimeKind.Local).AddTicks(9751), "Alexandre", 5, "Montanha", null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "CargaHoraria", "CursoId", "NomeDisciplina", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8383), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8399), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8389), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8381), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8415), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8410), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8401), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8398), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8344), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8414), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8402), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8407), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8413), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8405), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8392), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8384), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(7427), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8411), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8404), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8397), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8391), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8394), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2020, 12, 8, 10, 59, 26, 970, DateTimeKind.Local).AddTicks(8417), null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
