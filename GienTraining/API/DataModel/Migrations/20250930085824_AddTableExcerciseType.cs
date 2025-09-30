using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModel.Migrations
{
    /// <inheritdoc />
    public partial class AddTableExcerciseType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseType_ExerciseTypeId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseType",
                table: "ExerciseType");

            migrationBuilder.RenameTable(
                name: "ExerciseType",
                newName: "ExerciseTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseTypes",
                table: "ExerciseTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId",
                principalTable: "ExerciseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseTypes_ExerciseTypeId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseTypes",
                table: "ExerciseTypes");

            migrationBuilder.RenameTable(
                name: "ExerciseTypes",
                newName: "ExerciseType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseType",
                table: "ExerciseType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseType_ExerciseTypeId",
                table: "Exercises",
                column: "ExerciseTypeId",
                principalTable: "ExerciseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
