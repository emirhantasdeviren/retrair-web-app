using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Products.API.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreateAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    image_path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "created_at", "description", "image_path", "name", "price", "updated_at" },
                values: new object[,]
                {
                    { new Guid("06773c9a-9642-4947-bd42-f98a68cf2e12"), new DateTime(2023, 11, 24, 11, 27, 31, 238, DateTimeKind.Utc).AddTicks(74), null, "/images/travis-scott-x-air-jordan-1-retro-high-og-mocha.png", "Travis Scott x Air Jordan 1 Retro High OG \"Mocha\"", 31790.900000000001, new DateTime(2023, 11, 24, 11, 27, 31, 238, DateTimeKind.Utc).AddTicks(74) },
                    { new Guid("165cb929-3e26-4f60-b55b-4591da2b19fa"), new DateTime(2023, 11, 24, 11, 27, 31, 238, DateTimeKind.Utc).AddTicks(54), null, "/images/air-jordan-1-retro-high-og-gorge-green.png", "Air Jordan 1 Retro High OG \"Gorge Green\"", 3690.9000000000001, new DateTime(2023, 11, 24, 11, 27, 31, 238, DateTimeKind.Utc).AddTicks(54) },
                    { new Guid("4f84a4c9-d955-404f-84e4-b52af5ad7d03"), new DateTime(2023, 11, 24, 11, 27, 31, 238, DateTimeKind.Utc).AddTicks(64), null, "/images/air-jordan-1-retro-high-og-lucky-green.png", "Air Jordan 1 Retro High OG \"Lucky Green\"", 2890.9000000000001, new DateTime(2023, 11, 24, 11, 27, 31, 238, DateTimeKind.Utc).AddTicks(64) },
                    { new Guid("9bb8b7da-b8a6-4301-9ae3-9a3d329e74f9"), new DateTime(2023, 11, 24, 11, 27, 31, 237, DateTimeKind.Utc).AddTicks(9968), null, "/images/air-jordan-1-retro-high-og-washed-black.png", "Air Jordan 1 Retro High OG \"Washed Black\"", 4799.8999999999996, new DateTime(2023, 11, 24, 11, 27, 31, 237, DateTimeKind.Utc).AddTicks(9969) },
                    { new Guid("cce7aa8e-1941-4363-a6d6-7779b7140c13"), new DateTime(2023, 11, 24, 11, 27, 31, 238, DateTimeKind.Utc).AddTicks(42), null, "/images/air-jordan-1-retro-high-og-chicago-lost-and-found.png", "Air Jordan 1 Retro High OG \"Chicago Lost & Found\"", 5690.8999999999996, new DateTime(2023, 11, 24, 11, 27, 31, 238, DateTimeKind.Utc).AddTicks(42) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
