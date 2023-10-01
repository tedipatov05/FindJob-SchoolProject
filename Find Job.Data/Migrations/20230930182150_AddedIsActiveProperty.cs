using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Find_Job.Data.Migrations
{
    public partial class AddedIsActiveProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobOffers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is Active");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobOffers");

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
        }
    }
}
