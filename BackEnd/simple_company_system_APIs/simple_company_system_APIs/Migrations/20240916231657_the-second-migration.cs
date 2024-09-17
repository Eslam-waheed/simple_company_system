using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_company_system_APIs.Migrations
{
    /// <inheritdoc />
    public partial class thesecondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfHoursInthisProject",
                table: "EmployeeProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NumberOfHoursInthisProject",
                table: "EmployeeProjects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");
        }
    }
}
