using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Infra.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetRoles VALUES (1, 'admin', 'ADMIN', null)");
            migrationBuilder.Sql("INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (1, 'admin', 'ADMIN', 'admin@email.com', 'ADMIN@EMAIL.COM', 1, 'AQAAAAEAACcQAAAAEHpdl3T7gwkSwH7KPGg1jbRELjFgUd40qmjDXL4L8YntSa9U+9enNByza3D3TY0VEQ==', '2LMUXE44F7EF6ZBTSJPY3NDJPJZIOCK5', 'fed89141-e145-411d-aed4-e8d982b03636', NULL, 0, 0, NULL, 1, 0);");
            migrationBuilder.Sql("INSERT INTO AspNetUserRoles VALUES (1, 1, 'AdminUser'); ");
            migrationBuilder.Sql("INSERT INTO DadosPortfolios VALUES (1, 'Daniel Pereira Sanches', 'Mensagem de apresentação', null, 'https://url.aqui', 'https://url.aqui', 'https://url.aqui', 'https://url.aqui', 'https://url.aqui', '(01) 234567890)', 'email@email.com', 1, NOW());");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
