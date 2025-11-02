using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TomekReads.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemPropertyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Books",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
