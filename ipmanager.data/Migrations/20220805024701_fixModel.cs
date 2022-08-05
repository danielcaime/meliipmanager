using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ipmanager.data.Migrations
{
    public partial class fixModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_IpModel",
                table: "IpModel",
                column: "Ip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IpModel",
                table: "IpModel");
        }
    }
}
