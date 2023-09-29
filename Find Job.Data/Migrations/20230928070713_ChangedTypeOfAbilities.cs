using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Job.Data.Migrations
{
    public partial class ChangedTypeOfAbilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "40f55eaa-69d1-4d80-a284-9ba482c53ceb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "bf5fa7af-a6dc-46e6-beb7-e192eb260da5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26f0964f-eb05-4a1a-b320-87ed04331d3a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "260722bd-7759-4a8c-a894-de2809dcb134", "AQAAAAEAACcQAAAAECZc/vxSLxvb8sFarNNVPEPzBvdULmybbSo7PuFTLlesaizI8Fy2xCPHq5jNkRAV4A==", "af54aa00-75bb-42c2-973c-51e6bf80db8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf55d92-6d2d-459f-a628-e6d14bc3b33e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9894abfa-3a93-4331-9047-1ad737779b08", "AQAAAAEAACcQAAAAEObRGw/xsh4jTmEsdxfacEVm9DfySDOI8rea4AX1Rq5c+jaTAlib1K84XMGEapdHtg==", "2074b115-1ac0-4ebd-b5b5-73380769efb5" });

            migrationBuilder.UpdateData(
                table: "Programmers",
                keyColumn: "Id",
                keyValue: "a2063af2-2e07-42af-8121-9dc6ec8e5ad6",
                column: "Abilities",
                value: "C#, ASP.NET, Entity Framework, JavaScript, Pyton, PHP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                column: "ConcurrencyStamp",
                value: "ccdaf704-4418-414e-8fe6-dfa56f7a7afe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c34ebc61-94a5-40c5-a310-798532235d8e",
                column: "ConcurrencyStamp",
                value: "ee1a2afa-0032-415d-9b91-34b6bcdd4079");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26f0964f-eb05-4a1a-b320-87ed04331d3a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da6480e7-34d6-48cc-9b74-d5f58fad0dfc", "AQAAAAEAACcQAAAAEFUr2dptjETd/THfdFhvJ7xzASa+rPvZ66a4ai85MTlG1NEnOFhFFa638STXHt9fqg==", "fab548ad-3acb-4057-aab6-e71029103fe1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adf55d92-6d2d-459f-a628-e6d14bc3b33e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c214152-7dd4-4712-b97c-a77d0ea95c47", "AQAAAAEAACcQAAAAEG1OPX6DIdtkBIfFXjRKW3oxt6S+MUZ3Jdbku+8W/H94llTWe+rQmMV9oTzrRoEYng==", "c82f3969-a218-4447-89da-87a4bddf78cd" });

            migrationBuilder.UpdateData(
                table: "Programmers",
                keyColumn: "Id",
                keyValue: "a2063af2-2e07-42af-8121-9dc6ec8e5ad6",
                column: "Abilities",
                value: "System.Collections.Generic.List`1[System.String]");
        }
    }
}
