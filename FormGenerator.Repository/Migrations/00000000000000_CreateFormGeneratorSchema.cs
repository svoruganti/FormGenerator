using System;
using Microsoft.EntityFrameworkCore.Migrations;
namespace FormGenerator.Repository.Migrations
{
    public partial class CreateFormGeneratorSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
//            migrationBuilder.CreateTable(
//                name: "AspNetRoles",
//                columns: table => new
//                {
//                    Id = table.Column<string>(nullable: false),
//                    ConcurrencyStamp = table.Column<string>(nullable: true),
//                    Name = table.Column<string>(nullable: true),
//                    NormalizedName = table.Column<string>(nullable: true)
//                },
//                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });
//
//            migrationBuilder.CreateTable(
//                name: "AspNetUserTokens",
//                columns: table => new
//                {
//                    UserId = table.Column<string>(nullable: false),
//                    LoginProvider = table.Column<string>(nullable: false),
//                    Name = table.Column<string>(nullable: false),
//                    BranchingValue = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
//                });
//
//            migrationBuilder.CreateTable(
//                name: "AspNetUsers",
//                columns: table => new
//                {
//                    Id = table.Column<string>(nullable: false),
//                    AccessFailedCount = table.Column<int>(nullable: false),
//                    ConcurrencyStamp = table.Column<string>(nullable: true),
//                    Email = table.Column<string>(nullable: true),
//                    EmailConfirmed = table.Column<bool>(nullable: false),
//                    LockoutEnabled = table.Column<bool>(nullable: false),
//                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
//                    NormalizedEmail = table.Column<string>(nullable: true),
//                    NormalizedUserName = table.Column<string>(nullable: true),
//                    PasswordHash = table.Column<string>(nullable: true),
//                    PhoneNumber = table.Column<string>(nullable: true),
//                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
//                    SecurityStamp = table.Column<string>(nullable: true),
//                    TwoFactorEnabled = table.Column<bool>(nullable: false),
//                    UserName = table.Column<string>(nullable: true)
//                },
//                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });
//
//            migrationBuilder.CreateTable(
//                name: "AspNetRoleClaims",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("Autoincrement", true),
//                    ClaimType = table.Column<string>(nullable: true),
//                    ClaimValue = table.Column<string>(nullable: true),
//                    RoleId = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "AspNetRoles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "AspNetUserClaims",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("Autoincrement", true),
//                    ClaimType = table.Column<string>(nullable: true),
//                    ClaimValue = table.Column<string>(nullable: true),
//                    UserId = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "AspNetUserLogins",
//                columns: table => new
//                {
//                    LoginProvider = table.Column<string>(nullable: false),
//                    ProviderKey = table.Column<string>(nullable: false),
//                    ProviderDisplayName = table.Column<string>(nullable: true),
//                    UserId = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
//                    table.ForeignKey(
//                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "AspNetUserRoles",
//                columns: table => new
//                {
//                    UserId = table.Column<string>(nullable: false),
//                    RoleId = table.Column<string>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
//                    table.ForeignKey(
//                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "AspNetRoles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//
//            migrationBuilder.CreateIndex(
//                name: "RoleNameIndex",
//                table: "AspNetRoles",
//                column: "NormalizedName");
//
//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetRoleClaims_RoleId",
//                table: "AspNetRoleClaims",
//                column: "RoleId");
//
//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserClaims_UserId",
//                table: "AspNetUserClaims",
//                column: "UserId");
//
//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserLogins_UserId",
//                table: "AspNetUserLogins",
//                column: "UserId");
//
//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserRoles_RoleId",
//                table: "AspNetUserRoles",
//                column: "RoleId");
//
//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserRoles_UserId",
//                table: "AspNetUserRoles",
//                column: "UserId");
//
//            migrationBuilder.CreateIndex(
//                name: "EmailIndex",
//                table: "AspNetUsers",
//                column: "NormalizedEmail");
//
//            migrationBuilder.CreateIndex(
//                name: "UserNameIndex",
//                table: "AspNetUsers",
//                column: "NormalizedUserName");
            const string autoincrement = "AutoIncrement";
            migrationBuilder.CreateTable(
                    name:"Form",
                    columns: table => new
                    {
                        Id = table.Column<Int32>().Annotation(autoincrement, true),
                        Description = table.Column<String>(nullable:true),
                        Code = table.Column<String>()
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Form", x => x.Id);
                    }
            );
            migrationBuilder.CreateTable(
                    name: "FormField",
                    columns: table => new
                    {
                        Id = table.Column<Int32>().Annotation(autoincrement, true),
                        Code = table.Column<String>(),
                        Label = table.Column<String>(nullable:true),
                        IsReadOnly = table.Column<bool>(),
                        Style = table.Column<String>(nullable:true),
                        Apperance = table.Column<String>(nullable:true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_FormField", x => x.Id);
                    }
            );
            migrationBuilder.CreateTable(
                    name: "FormFieldValidationRule",
                    columns: table => new
                    {
                        Id = table.Column<Int32>().Annotation(autoincrement, true),
                        Code = table.Column<String>(),
                        Description = table.Column<String>(nullable:true),
                        FormFieldId = table.Column<Int32>(nullable:true),
                        FormConfigurationId = table.Column<Int32>()
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_ValidationRule", x => x.Id);
                        table.ForeignKey("FK_ValidationRule_FormField", x => x.FormFieldId, "FormField", "Id");
                        table.ForeignKey("FK_ValidationRule_FormConfigurationId", x => x.FormConfigurationId,
                            "FormConfiguration", "Id");
                    }
            );
            migrationBuilder.CreateTable(
                    name:"ControlType",
                    columns: table => new
                    {
                        Id = table.Column<Int32>().Annotation(autoincrement, true),
                        Code = table.Column<String>(),
                        Description = table.Column<String>(nullable:true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_ControlType", x => x.Id);
                    }
            );
            migrationBuilder.CreateTable(
                    name:"FormConfiguration",
                    columns:table => new
                    {
                        Id = table.Column<Int32>(),
                        FormId = table.Column<Int32>(),
                        ControlTypeId = table.Column<Int32>(),
                        FormFieldId = table.Column<Int32>()
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_FormConfiguration", x => x.Id).Annotation(autoincrement, true);
                        table.ForeignKey("FK_FormConfiguration_Form", x => x.FormId, "Form", "Id");
                        table.ForeignKey("FK_FormConfiguration_FormField", x => x.FormFieldId, "FormField", "Id");
                        table.ForeignKey("FK_FormConfiguration_ControlType", x => x.ControlTypeId, "ControlType", "Id");
                    }
            );

            migrationBuilder.CreateTable("FormReferenceData", table => new
                {
                    Id = table.Column<Int32>(),
                    tableName = table.Column<String>(),
                    whereClause = table.Column<String>(nullable: true),
                    formConfigurationId = table.Column<Int32>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormReferenceData", x => x.Id).Annotation(autoincrement, true);
                    table.ForeignKey("FK_FormReferenceData_FormConfiguration", x => x.formConfigurationId,
                        "FormConfiguration", "Id");
                }
            );

            migrationBuilder.CreateTable("FormFieldBranching", table => new
                {
                    Id = table.Column<Int32>(),
                    childFieldId = table.Column<Int32>(),
                    parentFieldId = table.Column<Int32>(),
                    formId = table.Column<Int32>(),
                    value = table.Column<String>(),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFeildBranching", x => x.Id).Annotation(autoincrement, true);
                    table.ForeignKey("FK_FormFieldBranching_ChildField_FormField", x => x.childFieldId, "FormField", "Id");
                    table.ForeignKey("FK_FormFieldBranching_ParentField_FormField", x => x.parentFieldId, "FormField", "Id");
                    table.ForeignKey("FK_FormFieldBranching_Form", x => x.formId, "Form", "Id");
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
//            migrationBuilder.DropTable(
//                name: "AspNetRoleClaims");
//
//            migrationBuilder.DropTable(
//                name: "AspNetUserClaims");
//
//            migrationBuilder.DropTable(
//                name: "AspNetUserLogins");
//
//            migrationBuilder.DropTable(
//                name: "AspNetUserRoles");
//
//            migrationBuilder.DropTable(
//                name: "AspNetUserTokens");
//
//            migrationBuilder.DropTable(
//                name: "AspNetRoles");
//
//            migrationBuilder.DropTable(
//                name: "AspNetUsers");
            migrationBuilder.DropTable("FormFieldValidationRule");
            migrationBuilder.DropTable("FormConfiguration");
            migrationBuilder.DropTable("FormField");
            migrationBuilder.DropTable("Form");
            migrationBuilder.DropTable("ControlType");
        }
    }
}