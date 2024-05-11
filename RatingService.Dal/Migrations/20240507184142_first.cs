using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RatingService.Dal.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Point = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProviderId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "CreatedAt", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9269), "Ilyas", "Salman" },
                    { 2, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9270), "Adile", "Nasit" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CreatedAt", "Point", "ProviderId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9078), 4.5, 1, 1 },
                    { 2, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9081), 5.0, 1, 2 },
                    { 3, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9082), 3.0, 1, 3 },
                    { 4, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9084), 3.5, 1, 4 },
                    { 5, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9085), 2.5, 1, 5 },
                    { 6, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9086), 4.5, 2, 1 },
                    { 7, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9087), 5.0, 2, 2 },
                    { 8, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9089), 3.0, 2, 3 },
                    { 9, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9090), 3.5, 2, 4 },
                    { 10, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9091), 2.5, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9242), "Abuzer", "Kadayif" },
                    { 2, new DateTime(2024, 5, 7, 18, 41, 42, 11, DateTimeKind.Utc).AddTicks(9243), "Temel", "Reis" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
