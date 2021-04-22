namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        divisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TB_M_Division", t => t.divisionId, cascadeDelete: true)
                .Index(t => t.divisionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departements", "divisionId", "dbo.TB_M_Division");
            DropIndex("dbo.Departements", new[] { "divisionId" });
            DropTable("dbo.Departements");
        }
    }
}
