using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackFocus.Infraestructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EstabelecendoRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercicios",
                table: "Exercicios");

            migrationBuilder.DropColumn(
                name: "ds_tipo",
                table: "Exercicios");

            migrationBuilder.RenameTable(
                name: "Exercicios",
                newName: "Exercicio");

            migrationBuilder.AddColumn<int>(
                name: "cd_categoriaId",
                table: "Exercicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercicio",
                table: "Exercicio",
                column: "cd_id");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    cd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nm_categoria = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.cd_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalheMusculacao",
                columns: table => new
                {
                    cd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    qt_repeticoes = table.Column<int>(type: "int", nullable: true),
                    qt_series = table.Column<int>(type: "int", nullable: true),
                    cd_serieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheMusculacao", x => x.cd_id);
                    table.ForeignKey(
                        name: "FK_DetalheMusculacao_Series_cd_serieId",
                        column: x => x.cd_serieId,
                        principalTable: "Series",
                        principalColumn: "cd_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalheMusculacaoExercicio",
                columns: table => new
                {
                    DetalhesId = table.Column<int>(type: "int", nullable: false),
                    ExerciciosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheMusculacaoExercicio", x => new { x.DetalhesId, x.ExerciciosId });
                    table.ForeignKey(
                        name: "FK_DetalheMusculacaoExercicio_DetalheMusculacao_DetalhesId",
                        column: x => x.DetalhesId,
                        principalTable: "DetalheMusculacao",
                        principalColumn: "cd_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalheMusculacaoExercicio_Exercicio_ExerciciosId",
                        column: x => x.ExerciciosId,
                        principalTable: "Exercicio",
                        principalColumn: "cd_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Treino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cd_userId = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treino_User_cd_userId",
                        column: x => x.cd_userId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ExercicioTreino",
                columns: table => new
                {
                    ExerciciosId = table.Column<int>(type: "int", nullable: false),
                    TreinosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioTreino", x => new { x.ExerciciosId, x.TreinosId });
                    table.ForeignKey(
                        name: "FK_ExercicioTreino_Exercicio_ExerciciosId",
                        column: x => x.ExerciciosId,
                        principalTable: "Exercicio",
                        principalColumn: "cd_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercicioTreino_Treino_TreinosId",
                        column: x => x.TreinosId,
                        principalTable: "Treino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_cd_categoriaId",
                table: "Exercicio",
                column: "cd_categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheMusculacao_cd_serieId",
                table: "DetalheMusculacao",
                column: "cd_serieId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheMusculacaoExercicio_ExerciciosId",
                table: "DetalheMusculacaoExercicio",
                column: "ExerciciosId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioTreino_TreinosId",
                table: "ExercicioTreino",
                column: "TreinosId");

            migrationBuilder.CreateIndex(
                name: "IX_Treino_cd_userId",
                table: "Treino",
                column: "cd_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercicio_Categoria_cd_categoriaId",
                table: "Exercicio",
                column: "cd_categoriaId",
                principalTable: "Categoria",
                principalColumn: "cd_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercicio_Categoria_cd_categoriaId",
                table: "Exercicio");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "DetalheMusculacaoExercicio");

            migrationBuilder.DropTable(
                name: "ExercicioTreino");

            migrationBuilder.DropTable(
                name: "DetalheMusculacao");

            migrationBuilder.DropTable(
                name: "Treino");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercicio",
                table: "Exercicio");

            migrationBuilder.DropIndex(
                name: "IX_Exercicio_cd_categoriaId",
                table: "Exercicio");

            migrationBuilder.DropColumn(
                name: "cd_categoriaId",
                table: "Exercicio");

            migrationBuilder.RenameTable(
                name: "Exercicio",
                newName: "Exercicios");

            migrationBuilder.AddColumn<string>(
                name: "ds_tipo",
                table: "Exercicios",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercicios",
                table: "Exercicios",
                column: "cd_id");
        }
    }
}
