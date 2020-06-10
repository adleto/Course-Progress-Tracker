using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourse.Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    SkraceniNaziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opcina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipUplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipUplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    OpcinaId = table.Column<int>(nullable: false),
                    JMBG = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    DatumRegistracije = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Opcina_OpcinaId",
                        column: x => x.OpcinaId,
                        principalTable: "Opcina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KursTag",
                columns: table => new
                {
                    KursId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursTag", x => new { x.KursId, x.TagId });
                    table.ForeignKey(
                        name: "FK_KursTag_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserRole",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserRole", x => new { x.ApplicationUserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klijent_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uposlenik_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KursInstanca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(nullable: false),
                    PocetakDatum = table.Column<DateTime>(nullable: false),
                    PrijaveDoDatum = table.Column<DateTime>(nullable: false),
                    KrajDatum = table.Column<DateTime>(nullable: true),
                    Kapacitet = table.Column<int>(nullable: true),
                    Cijena = table.Column<decimal>(nullable: true),
                    UposlenikId = table.Column<int>(nullable: false),
                    BrojCasova = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursInstanca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KursInstanca_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursInstanca_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursInstancaId = table.Column<int>(nullable: false),
                    DatumVrijemeOdrzavanja = table.Column<DateTime>(nullable: false),
                    Lokacija = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Odrzan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cas_KursInstanca_KursInstancaId",
                        column: x => x.KursInstancaId,
                        principalTable: "KursInstanca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ispit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursInstancaId = table.Column<int>(nullable: false),
                    DatumVrijemeIspita = table.Column<DateTime>(nullable: false),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ispit_KursInstanca_KursInstancaId",
                        column: x => x.KursInstancaId,
                        principalTable: "KursInstanca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KlijentKursInstanca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlijentId = table.Column<int>(nullable: false),
                    KursInstancaId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UplataIzvrsena = table.Column<bool>(nullable: true),
                    Polozen = table.Column<bool>(nullable: true),
                    Rejting = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlijentKursInstanca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KlijentKursInstanca_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlijentKursInstanca_KursInstanca_KursInstancaId",
                        column: x => x.KursInstancaId,
                        principalTable: "KursInstanca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipUplateId = table.Column<int>(nullable: false),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<decimal>(nullable: false),
                    KlijentId = table.Column<int>(nullable: false),
                    KursInstancaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplata_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uplata_KursInstanca_KursInstancaId",
                        column: x => x.KursInstancaId,
                        principalTable: "KursInstanca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uplata_TipUplate_TipUplateId",
                        column: x => x.TipUplateId,
                        principalTable: "TipUplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IspitKlijentKursInstanca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IspitId = table.Column<int>(nullable: false),
                    KlijentKursInstancaId = table.Column<int>(nullable: false),
                    Prisustvovao = table.Column<bool>(nullable: true),
                    Bodovi = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IspitKlijentKursInstanca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IspitKlijentKursInstanca_Ispit_IspitId",
                        column: x => x.IspitId,
                        principalTable: "Ispit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IspitKlijentKursInstanca_KlijentKursInstanca_KlijentKursInstancaId",
                        column: x => x.KlijentKursInstancaId,
                        principalTable: "KlijentKursInstanca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clanarina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlijentId = table.Column<int>(nullable: false),
                    DatumIsteka = table.Column<DateTime>(nullable: false),
                    UplataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clanarina_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clanarina_Uplata_UplataId",
                        column: x => x.UplataId,
                        principalTable: "Uplata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_OpcinaId",
                table: "ApplicationUser",
                column: "OpcinaId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_RoleId",
                table: "ApplicationUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cas_KursInstancaId",
                table: "Cas",
                column: "KursInstancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_KlijentId",
                table: "Clanarina",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_UplataId",
                table: "Clanarina",
                column: "UplataId");

            migrationBuilder.CreateIndex(
                name: "IX_Ispit_KursInstancaId",
                table: "Ispit",
                column: "KursInstancaId");

            migrationBuilder.CreateIndex(
                name: "IX_IspitKlijentKursInstanca_IspitId",
                table: "IspitKlijentKursInstanca",
                column: "IspitId");

            migrationBuilder.CreateIndex(
                name: "IX_IspitKlijentKursInstanca_KlijentKursInstancaId",
                table: "IspitKlijentKursInstanca",
                column: "KlijentKursInstancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_ApplicationUserId",
                table: "Klijent",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentKursInstanca_KlijentId",
                table: "KlijentKursInstanca",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_KlijentKursInstanca_KursInstancaId",
                table: "KlijentKursInstanca",
                column: "KursInstancaId");

            migrationBuilder.CreateIndex(
                name: "IX_KursInstanca_KursId",
                table: "KursInstanca",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursInstanca_UposlenikId",
                table: "KursInstanca",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_KursTag_TagId",
                table: "KursTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_KlijentId",
                table: "Uplata",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_KursInstancaId",
                table: "Uplata",
                column: "KursInstancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_TipUplateId",
                table: "Uplata",
                column: "TipUplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenik_ApplicationUserId",
                table: "Uposlenik",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserRole");

            migrationBuilder.DropTable(
                name: "Cas");

            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "IspitKlijentKursInstanca");

            migrationBuilder.DropTable(
                name: "KursTag");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "Ispit");

            migrationBuilder.DropTable(
                name: "KlijentKursInstanca");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "TipUplate");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "KursInstanca");

            migrationBuilder.DropTable(
                name: "Kurs");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Opcina");
        }
    }
}
