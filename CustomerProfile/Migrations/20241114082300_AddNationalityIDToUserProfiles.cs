using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerProfile.Migrations
{
    /// <inheritdoc />
    public partial class AddNationalityIDToUserProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "UserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "NationalityID",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_NationalityID",
                table: "UserProfiles",
                column: "NationalityID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Nationalities_NationalityID",
                table: "UserProfiles",
                column: "NationalityID",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Nationalities_NationalityID",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_NationalityID",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "NationalityID",
                table: "UserProfiles");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
