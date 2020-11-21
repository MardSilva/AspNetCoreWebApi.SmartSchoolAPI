using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeAluno = table.Column<string>(nullable: true),
                    SobrenomeAluno = table.Column<string>(nullable: true),
                    TelefoneAluno = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    IdProfessor = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeProfessor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.IdProfessor);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    IdDisciplina = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeDisciplina = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.IdDisciplina);
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
                    DisciplinaId = table.Column<int>(nullable: false)
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
                columns: new[] { "IdAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "IdAluno", "NomeAluno", "SobrenomeAluno", "TelefoneAluno" },
                values: new object[] { 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "NomeProfessor" },
                values: new object[] { 1, "Lauro" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "NomeProfessor" },
                values: new object[] { 2, "Roberto" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "NomeProfessor" },
                values: new object[] { 3, "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "NomeProfessor" },
                values: new object[] { 4, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "IdProfessor", "NomeProfessor" },
                values: new object[] { 5, "Alexandre" });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "NomeDisciplina", "ProfessorId" },
                values: new object[] { 1, "Matemática", 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "NomeDisciplina", "ProfessorId" },
                values: new object[] { 2, "Física", 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "NomeDisciplina", "ProfessorId" },
                values: new object[] { 3, "Português", 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "NomeDisciplina", "ProfessorId" },
                values: new object[] { 4, "Inglês", 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "IdDisciplina", "NomeDisciplina", "ProfessorId" },
                values: new object[] { 5, "Programação", 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
