using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Job.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "3748e9be-485b-42f5-b0f7-eefab46b34ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "966670df-7b96-45b1-9c3a-26752d24f397");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26f0964f-eb05-4a1a-b320-87ed04331d3a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9920d50-64c2-43bd-b6c3-9ce269664b06", "AQAAAAEAACcQAAAAEO6hq8Ig0nIxjeIgROdbCZ0/AMtMn09BgxMh9N72PIt8QKfMBIYtg44ezfdIGA257g==", "85a3f023-6d72-4fcc-ace1-02244c9f8d3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf55d92-6d2d-459f-a628-e6d14bc3b33e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d2550e4-cc24-4905-b070-25c74d9a7a25", "AQAAAAEAACcQAAAAEJ0HVDU9xvl3v5Afj3+8N2qcajU515MfVHTtdiArihK+lDDWAIWzJDvT+iEnBnZmlA==", "590d9fb0-a2f1-4fea-8378-9e8e9ed44944" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "0a7343db-86ac-44dd-ac0d-787df2010dea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "eaa12533-bd98-49ba-8e9e-d7100a962bec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26f0964f-eb05-4a1a-b320-87ed04331d3a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0fd0e93-f90d-4b6e-9a1c-2d98bede5e63", "AQAAAAEAACcQAAAAEEUrHrtcVK1ThoeGyirmQRU6AB1oNdsGDnP2MXALt/txxxK8K4CfVGCLN7KgF38fzQ==", "0eab5561-c0a0-4dec-9d8d-22469f072dc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf55d92-6d2d-459f-a628-e6d14bc3b33e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "379a61a3-4e73-4503-a036-e66b2dd2df5d", "AQAAAAEAACcQAAAAEGR4ndHocqn6ZfTxLofdR+VzW5rB4fg1c4ukjUDqdaANFozF5WH9RbflmCU4bB9+MQ==", "45c97ab7-5ba2-4012-acd5-089670c1980f" });
        }
    }
}
