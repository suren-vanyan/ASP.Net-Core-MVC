using Microsoft.EntityFrameworkCore.Migrations;

namespace VegaStarter.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Makes (Name) values ('Makes1')");
            migrationBuilder.Sql("Insert Into Makes (Name) values ('Makes2')");
            migrationBuilder.Sql("Insert Into Makes (Name) values ('Makes3')");

            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make1-ModelA', (Select Id From Makes Where Name='Makes1'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make1-ModelB', (Select Id From Makes Where Name='Makes1'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make1-ModelC', (Select Id From Makes Where Name='Makes1'))");

            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make2-ModelA', (Select Id From Makes Where Name='Makes2'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make2-ModelB', (Select Id From Makes Where Name='Makes2'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make2-ModelC', (Select Id From Makes Where Name='Makes2'))");

            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make3-ModelA', (Select Id From Makes Where Name='Makes3'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make3-ModelB', (Select Id From Makes Where Name='Makes3'))");
            migrationBuilder.Sql("Insert Into Models (Name, MakeId) Values ('Make3-ModelC', (Select Id From Makes Where Name='Makes3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From Makes");
            migrationBuilder.Sql("Delete From Models");
        }
    }
}
