using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoStoreManagmentAPI.Migrations
{
    public partial class cart_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideosVideoId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_VideosVideoId",
                table: "CartItems",
                column: "VideosVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Videos_VideosVideoId",
                table: "CartItems",
                column: "VideosVideoId",
                principalTable: "Videos",
                principalColumn: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Videos_VideosVideoId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_VideosVideoId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "VideosVideoId",
                table: "CartItems");
        }
    }
}
