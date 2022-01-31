using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaasHesap2022.Dal.Migrations
{
    public partial class InitialCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AylikBordrolar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Ay = table.Column<string>(nullable: true),
                    BrutUcret = table.Column<decimal>(nullable: false),
                    SgkIsci = table.Column<decimal>(nullable: false),
                    IssizlikIsci = table.Column<decimal>(nullable: false),
                    KumulatifGelirVergisiMatrahi = table.Column<decimal>(nullable: false),
                    GelirVergisiMatrahi = table.Column<decimal>(nullable: false),
                    GelirVergisi = table.Column<decimal>(nullable: false),
                    DamgaVergisi = table.Column<decimal>(nullable: false),
                    KesintilerToplami = table.Column<decimal>(nullable: false),
                    NetUcret = table.Column<decimal>(nullable: false),
                    GelirVergisiIstisnaTutar = table.Column<decimal>(nullable: false),
                    DamgaVergisiIstisnaTutar = table.Column<decimal>(nullable: false),
                    NetEleGecenUcret = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AylikBordrolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrutAsgariUcret",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Yil = table.Column<string>(nullable: true),
                    Tutar = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrutAsgariUcret", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GelirVergisiDilimleri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AltDilim = table.Column<decimal>(nullable: false),
                    UstDilim = table.Column<decimal>(nullable: false),
                    Oran = table.Column<decimal>(nullable: false),
                    Yil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GelirVergisiDilimleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SgkMatrahTavan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Yil = table.Column<string>(nullable: true),
                    Tutar = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SgkMatrahTavan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    IsEvli = table.Column<bool>(nullable: false),
                    CocukSayisi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BrutAsgariUcret",
                columns: new[] { "Id", "CreatedAt", "Tutar", "Yil" },
                values: new object[] { 1, new DateTime(2022, 1, 31, 21, 20, 4, 945, DateTimeKind.Local).AddTicks(6486), 5004m, "2022" });

            migrationBuilder.InsertData(
                table: "GelirVergisiDilimleri",
                columns: new[] { "Id", "AltDilim", "CreatedAt", "Name", "Oran", "UstDilim", "Yil" },
                values: new object[,]
                {
                    { 1, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32.000 TL’ye kadar", 0.15m, 32000m, "2022" },
                    { 2, 32000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "70.000 TL’nin 32.000 TL’si için 4800 TL. Fazlası", 0.20m, 70000m, "2022" },
                    { 3, 70000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "250.000 TL’nin 70.000 TL’si için 12.400 TL. Fazlası", 0.27m, 250000m, "2022" },
                    { 4, 250000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "880.000 TL’nin 250.000 TL’si için 61.000 TL. Fazlası", 0.35m, 880000m, "2022" },
                    { 5, 880000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "880.000 TL’den fazlasının 880.000 TL’si için 281.500 TL. Fazlası", 0.40m, 250000m, "2022" }
                });

            migrationBuilder.InsertData(
                table: "SgkMatrahTavan",
                columns: new[] { "Id", "CreatedAt", "Tutar", "Yil" },
                values: new object[] { 1, new DateTime(2022, 1, 31, 21, 20, 4, 949, DateTimeKind.Local).AddTicks(8397), 37350m, "2022" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AylikBordrolar");

            migrationBuilder.DropTable(
                name: "BrutAsgariUcret");

            migrationBuilder.DropTable(
                name: "GelirVergisiDilimleri");

            migrationBuilder.DropTable(
                name: "SgkMatrahTavan");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
