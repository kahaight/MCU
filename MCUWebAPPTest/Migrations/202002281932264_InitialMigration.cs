namespace MCUWebAPPTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharacterMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RealName = c.String(),
                        AlterEgo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterMovies", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.CharacterMovies", "CharacterId", "dbo.Characters");
            DropIndex("dbo.CharacterMovies", new[] { "CharacterId" });
            DropIndex("dbo.CharacterMovies", new[] { "MovieId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterMovies");
        }
    }
}
