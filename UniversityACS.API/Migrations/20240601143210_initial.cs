﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Courses = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionToCertificationThemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionToCertificationThemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionToTheCommittees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionToTheCommittees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionToTheHeadOfCommittees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionToTheHeadOfCommittees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DepartmentEmail = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    StudentsGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_StudentsGroups_StudentsGroupId",
                        column: x => x.StudentsGroupId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curricula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curricula_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HeadOfDepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Contacts = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_HeadOfDepartmentId",
                        column: x => x.HeadOfDepartmentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DevelopmentPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopmentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevelopmentPlans_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExchangeVisitsPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeVisitsPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeVisitsPlans_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsChecked = table.Column<bool>(type: "boolean", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uuid", nullable: true),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: true),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeWorks_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HomeWorks_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HomeWorks_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IndividualPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualPlans_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScientificAndPedagogicalActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAndPedagogicalActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificAndPedagogicalActivities_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Syllabi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Syllabi_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeacherDisciplines",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDisciplines", x => new { x.DisciplineId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherDisciplines_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    TestTheme = table.Column<string>(type: "text", nullable: true),
                    TestUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherTests_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeachingLoads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingLoads_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Traineeships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TraineeId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traineeships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traineeships_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkingCurricula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingCurricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingCurricula_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMeetingPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMeetingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingPlans_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMeetingProtocols",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMeetingProtocols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMeetingProtocols_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsFromDepartment = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SubjectName = table.Column<string>(type: "text", nullable: true),
                    LessonName = table.Column<string>(type: "text", nullable: true),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    HomeWorkId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_HomeWorks_HomeWorkId",
                        column: x => x.HomeWorkId,
                        principalTable: "HomeWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAttendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPresent = table.Column<bool>(type: "boolean", nullable: false),
                    IsLate = table.Column<bool>(type: "boolean", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1577fd47-47e9-4884-949d-c8932382631c"), null, "Teacher", null },
                    { new Guid("5890b8ca-a2fd-48e4-a9b7-9e1ba1bd4b9f"), null, "Admin", null },
                    { new Guid("77348823-4700-468b-a4ae-8ae52e99ee08"), null, "Student", null },
                    { new Guid("f68b52f3-713e-48e7-968a-6be47c9ce300"), null, "DepartHead", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DepartmentEmail", "DepartmentId", "Email", "EmailConfirmed", "FirstName", "GroupId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StudentsGroupId", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"), 0, null, "cfecaf83-e6af-4268-a7bc-b8dbfe358a78", null, null, "admin@gmail.com", false, null, null, null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEHtMx+Fd07lnfNZFbkyDIP04RiFsej9S2MnzLg4sIjN0Sx6uHkx7mk+6qa7uwclrPg==", null, false, "", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5890b8ca-a2fd-48e4-a9b7-9e1ba1bd4b9f"), new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentsGroupId",
                table: "AspNetUsers",
                column: "StudentsGroupId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_TeacherId",
                table: "Curricula",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingPlans_DepartmentId",
                table: "DepartmentMeetingPlans",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMeetingProtocols_DepartmentId",
                table: "DepartmentMeetingProtocols",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments",
                column: "HeadOfDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DevelopmentPlans_TeacherId",
                table: "DevelopmentPlans",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeVisitsPlans_TeacherId",
                table: "ExchangeVisitsPlans",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_DisciplineId",
                table: "HomeWorks",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_StudentId",
                table: "HomeWorks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_TeacherId",
                table: "HomeWorks",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualPlans_TeacherId",
                table: "IndividualPlans",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_HomeWorkId",
                table: "Lessons",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_News_DepartmentId",
                table: "News",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DepartmentId",
                table: "Schedules",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAndPedagogicalActivities_TeacherId",
                table: "ScientificAndPedagogicalActivities",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_LessonId",
                table: "StudentAttendances",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabi_TeacherId",
                table: "Syllabi",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDisciplines_TeacherId",
                table: "TeacherDisciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTests_TeacherId",
                table: "TeacherTests",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingLoads_TeacherId",
                table: "TeachingLoads",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Traineeships_TraineeId",
                table: "Traineeships",
                column: "TraineeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingCurricula_TeacherId",
                table: "WorkingCurricula",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_HeadOfDepartmentId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CertificationReports");

            migrationBuilder.DropTable(
                name: "Curricula");

            migrationBuilder.DropTable(
                name: "DepartmentMeetingPlans");

            migrationBuilder.DropTable(
                name: "DepartmentMeetingProtocols");

            migrationBuilder.DropTable(
                name: "DevelopmentPlans");

            migrationBuilder.DropTable(
                name: "ExchangeVisitsPlans");

            migrationBuilder.DropTable(
                name: "IndividualPlans");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "ScientificAndPedagogicalActivities");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "SubmissionToCertificationThemes");

            migrationBuilder.DropTable(
                name: "SubmissionToTheCommittees");

            migrationBuilder.DropTable(
                name: "SubmissionToTheHeadOfCommittees");

            migrationBuilder.DropTable(
                name: "Syllabi");

            migrationBuilder.DropTable(
                name: "TeacherDisciplines");

            migrationBuilder.DropTable(
                name: "TeacherTests");

            migrationBuilder.DropTable(
                name: "TeachingLoads");

            migrationBuilder.DropTable(
                name: "Traineeships");

            migrationBuilder.DropTable(
                name: "WorkingCurricula");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "HomeWorks");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "StudentsGroups");
        }
    }
}
