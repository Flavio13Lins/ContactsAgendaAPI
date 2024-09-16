using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAgendaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Name", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, "Flavio Lins", "flavio13lins@gmail.com", "+55-81-99926-1995" },
                    { 2, "Bernardo Bastos", "bernardobastos@gmail.com", "+55-81-9999-8888" },
                    { 3, "Abner Amaral", "aamaral@example.com", "+55-21-32132-1323" },
                    { 4, "Carlos Carrara", "ccarrara@example.com", "+55-12-4321-2222" },
                    { 5, "Daniela Dutra", "ddutra@example.com", "+55-13-4321-3333" },
                    { 6, "Eduardo Eustáquio", "eeustaquio@example.com", "+55-14-98765-4444" },
                    { 7, "Gustavo Guanabara", "gguanabara@example.com", "+55-15-98765-5555" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7 });
        }
    }
}
