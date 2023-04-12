using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMigration.Migrations
{
    /// <inheritdoc />
    public partial class njnaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_TaskCategory",
                table: "TaskList");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_TaskMode",
                table: "TaskList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task_List",
                table: "TaskList");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "TaskMode",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TaskList",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "TaskList",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "TaskList",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "TaskCategory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "TaskCategory",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList",
                column: "TaskListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_TaskCategory_TaskCategoryId",
                table: "TaskList",
                column: "TaskCategoryId",
                principalTable: "TaskCategory",
                principalColumn: "TaskCategortId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_TaskMode_TaskModeId",
                table: "TaskList",
                column: "TaskModeId",
                principalTable: "TaskMode",
                principalColumn: "TaskModeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_TaskCategory_TaskCategoryId",
                table: "TaskList");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskList_TaskMode_TaskModeId",
                table: "TaskList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskList",
                table: "TaskList");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "TaskMode",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TaskList",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "TaskList",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "TaskList",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "TaskCategory",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "TaskCategory",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task_List",
                table: "TaskList",
                column: "TaskListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_TaskCategory",
                table: "TaskList",
                column: "TaskCategoryId",
                principalTable: "TaskCategory",
                principalColumn: "TaskCategortId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskList_TaskMode",
                table: "TaskList",
                column: "TaskModeId",
                principalTable: "TaskMode",
                principalColumn: "TaskModeId");
        }
    }
}
