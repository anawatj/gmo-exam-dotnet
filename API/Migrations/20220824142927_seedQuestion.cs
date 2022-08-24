using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class seedQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionDesc" },
                values: new object[] { 1, "Mbti" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionDesc" },
                values: new object[] { 2, "Blood Group" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerDesc", "AnswerScore", "QuestionID" },
                values: new object[,]
                {
                    { 1, "Infj", 5, 1 },
                    { 2, "Enfj", 8, 1 },
                    { 3, "Infp", 0, 1 },
                    { 4, "Enfp", 1, 1 },
                    { 5, "A", 5, 2 },
                    { 6, "B", 8, 2 },
                    { 7, "O", 0, 2 },
                    { 8, "AB", 1, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
