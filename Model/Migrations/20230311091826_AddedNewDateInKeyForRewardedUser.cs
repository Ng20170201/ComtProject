using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewDateInKeyForRewardedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RewardedUsers",
                table: "RewardedUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RewardedUsers",
                table: "RewardedUsers",
                columns: new[] { "UserId", "CostumerId", "DateRewarded" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RewardedUsers",
                table: "RewardedUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RewardedUsers",
                table: "RewardedUsers",
                columns: new[] { "UserId", "CostumerId" });
        }
    }
}
