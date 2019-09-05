using Microsoft.EntityFrameworkCore.Migrations;

namespace SGQ.Infra.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EnumBase",
                columns: new[] { "Id", "Codigo", "DataCadastro", "DataModificacao", "TipoEnum", "UsuarioCadastroId", "UsuarioModificacaoId", "Valor" },
                values: new object[,]
                {
                    { 2, null, null, null, "PeriodicidadeVerificacaoProcesso", null, null, "Semanal" },
                    { 3, null, null, null, "PeriodicidadeVerificacaoProcesso", null, null, "Mensal" },
                    { 4, null, null, null, "StatusProcesso", null, null, "Pré Cadastrado" },
                    { 5, null, null, null, "StatusProcesso", null, null, "Ativo" },
                    { 6, null, null, null, "StatusProcesso", null, null, "Cancelado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EnumBase",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EnumBase",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EnumBase",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EnumBase",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EnumBase",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
