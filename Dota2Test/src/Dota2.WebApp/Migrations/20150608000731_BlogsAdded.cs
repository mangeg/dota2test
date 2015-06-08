namespace Dota2.WebApp.Migrations
{
    using System;
    using Microsoft.Data.Entity.Relational.Migrations;
    using Microsoft.Data.Entity.Relational.Migrations.Builders;

    public partial class BlogsAdded : Migration
    {
        public override void Up( MigrationBuilder migration )
        {
            migration.CreateTable(
                "Blog",
                table => new {
                    Id = table.Column( "uniqueidentifier", nullable: false, defaultExpression: "NEWID()" ),
                    Name = table.Column( "nvarchar(max)", nullable: true ),
                    Url = table.Column( "nvarchar(max)", nullable: true )
                },
                constraints: table => { table.PrimaryKey( "PK_Blog", x => x.Id ); } );
        }
        public override void Down( MigrationBuilder migration )
        {
            migration.DropTable( "Blog" );
        }
    }
}
