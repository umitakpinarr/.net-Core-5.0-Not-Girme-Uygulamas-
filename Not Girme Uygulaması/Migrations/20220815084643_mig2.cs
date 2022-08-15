using Microsoft.EntityFrameworkCore.Migrations;

namespace Not_Girme_Uygulaması.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNo = table.Column<int>(type: "int", nullable: false),
                    lessonId = table.Column<int>(type: "int", nullable: false),
                    Not1 = table.Column<int>(type: "int", nullable: false),
                    Not2 = table.Column<int>(type: "int", nullable: false),
                    Per1 = table.Column<int>(type: "int", nullable: false),
                    Per2 = table.Column<int>(type: "int", nullable: false),
                    average = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notes");
        }
    }
}
