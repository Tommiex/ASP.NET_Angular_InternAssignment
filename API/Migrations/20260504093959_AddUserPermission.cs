using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePulse.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permissions_SuperAdmin_Read = table.Column<bool>(type: "bit", nullable: false),
                    Permissions_SuperAdmin_Write = table.Column<bool>(type: "bit", nullable: false),
                    Permissions_SuperAdmin_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permissions_Admin_Read = table.Column<bool>(type: "bit", nullable: false),
                    Permissions_Admin_Write = table.Column<bool>(type: "bit", nullable: false),
                    Permissions_Admin_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permissions_Employee_Read = table.Column<bool>(type: "bit", nullable: false),
                    Permissions_Employee_Write = table.Column<bool>(type: "bit", nullable: false),
                    Permissions_Employee_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
