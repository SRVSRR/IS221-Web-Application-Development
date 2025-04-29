using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab7_StudentRegistration.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Stu_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Stu_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Stu_Passwd = table.Column<string>(type: "TEXT", nullable: false),
                    Stu_Prog = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Stu_ID);
                });

            migrationBuilder.CreateTable(
                name: "StuMajors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stu_ID = table.Column<string>(type: "TEXT", nullable: false),
                    Stu_Majors = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuMajors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StuMajors");
        }
    }
}
