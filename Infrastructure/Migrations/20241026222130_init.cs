﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "InteractionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CampaignType = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_CampaignTypes_CampaignType",
                        column: x => x.CampaignType,
                        principalTable: "CampaignTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    InteractionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionType = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.InteractionID);
                    table.ForeignKey(
                        name: "FK_Interactions_InteractionTypes_InteractionType",
                        column: x => x.InteractionType,
                        principalTable: "InteractionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interactions_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedTo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskStatus_Status",
                        column: x => x.Status,
                        principalTable: "TaskStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CampaignTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SEO" },
                    { 2, "PPC" },
                    { 3, "Social Media" },
                    { 4, "Email Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "Address", "Company", "CreateDate", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Buenos Aires, Quilmes, Av.Mitre 682", "Mercado Independiente", new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4317), "JhonDoe@Outlook.com", "Julian Dogas", "12345678" },
                    { 2, "Buenos Aires, Florencio Varela, Bartolomé Mitre 103", "Textiles TelaBuena", new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4330), "RoldanThiago92@Hotmail.com", "Thiago Roldan", "87654321" },
                    { 3, "Buenos Aires, Parque Patricios, Uspallata 2700", "CompuFast", new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4331), "MariaRamallo@Outlook.com", "Mariana Ramallo", "11223344" },
                    { 4, "Buenos Aires, Wilde, Zeballos 5869", "English Horizons ", new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4333), "Karioficial@hotmail.com", "Karina Rolón", "11115678" },
                    { 5, "Buenos Aires, Palermo, Godoy Cruz 2347", "Lo de Hugo", new DateTime(2024, 10, 26, 19, 21, 30, 544, DateTimeKind.Local).AddTicks(4334), "Lodehugo@Outlook.com", "Hugo Escobar", "8877665544" }
                });

            migrationBuilder.InsertData(
                table: "InteractionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Initial Meeting" },
                    { 2, "Phone call" },
                    { 3, "Email" },
                    { 4, "Presentation of Results" }
                });

            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "In Progress" },
                    { 3, "Blocked" },
                    { 4, "Done" },
                    { 5, "Cancel" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "jdone@marketing.com", "Joe Done" },
                    { 2, "namstrong@marketing.com", "Nill Amstrong" },
                    { 3, "mmorales@marketing.com", "Marlyn Morales" },
                    { 4, "aorue@marketing.com", "Antony Orué" },
                    { 5, "jfernandez@marketing.com", "Jazmin Fernandez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_InteractionType",
                table: "Interactions",
                column: "InteractionType");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_ProjectID",
                table: "Interactions",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CampaignType",
                table: "Projects",
                column: "CampaignType");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedTo",
                table: "Tasks",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectID",
                table: "Tasks",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Status",
                table: "Tasks",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "InteractionTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CampaignTypes");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
