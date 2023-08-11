using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simpleproject.Migrations
{
    /// <inheritdoc />
    public partial class mm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    reviewid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reviewrname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reviewscore = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.reviewid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "review");
        }
    }
}
