using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class EntititesWithoutAuthenticationSystem_update01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_UserProfile_UserProfileId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_UserProfile_UserProfileId",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_UserProfile_UserProfileId",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_UserProfile_UserProfileId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_UserProfileId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_UserProfileId",
                table: "Hobbies");

            migrationBuilder.DropIndex(
                name: "IX_Experience_UserProfileId",
                table: "Experience");

            migrationBuilder.DropIndex(
                name: "IX_Education_UserProfileId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Education");

            migrationBuilder.CreateTable(
                name: "Education_UserProfile",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_UserProfile", x => new { x.EducationId, x.UserProfileId });
                    table.ForeignKey(
                        name: "FK_Education_UserProfile_Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Education_UserProfile_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experience_UserProfile",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience_UserProfile", x => new { x.ExperienceId, x.UserProfileId });
                    table.ForeignKey(
                        name: "FK_Experience_UserProfile_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experience_UserProfile_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies_UserProfile",
                columns: table => new
                {
                    HobbiesId = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies_UserProfile", x => new { x.HobbiesId, x.UserProfileId });
                    table.ForeignKey(
                        name: "FK_Hobbies_UserProfile_Hobbies_HobbiesId",
                        column: x => x.HobbiesId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hobbies_UserProfile_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages_UserProfile",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages_UserProfile", x => new { x.LanguagesId, x.UserProfileId });
                    table.ForeignKey(
                        name: "FK_Languages_UserProfile_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Languages_UserProfile_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_UserProfile_UserProfileId",
                table: "Education_UserProfile",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_UserProfile_UserProfileId",
                table: "Experience_UserProfile",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_UserProfile_UserProfileId",
                table: "Hobbies_UserProfile",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_UserProfile_UserProfileId",
                table: "Languages_UserProfile",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education_UserProfile");

            migrationBuilder.DropTable(
                name: "Experience_UserProfile");

            migrationBuilder.DropTable(
                name: "Hobbies_UserProfile");

            migrationBuilder.DropTable(
                name: "Languages_UserProfile");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Hobbies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Experience",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Education",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_UserProfileId",
                table: "Languages",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_UserProfileId",
                table: "Hobbies",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_UserProfileId",
                table: "Experience",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_UserProfileId",
                table: "Education",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_UserProfile_UserProfileId",
                table: "Education",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_UserProfile_UserProfileId",
                table: "Experience",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_UserProfile_UserProfileId",
                table: "Hobbies",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_UserProfile_UserProfileId",
                table: "Languages",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
