namespace OnlineStoreRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class url : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Volume = c.Double(nullable: false),
                        TypeEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeEntities", t => t.TypeEntityId, cascadeDelete: true)
                .Index(t => t.TypeEntityId);
            
            CreateTable(
                "dbo.TypeEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductEntities", "TypeEntityId", "dbo.TypeEntities");
            DropIndex("dbo.ProductEntities", new[] { "TypeEntityId" });
            DropTable("dbo.TypeEntities");
            DropTable("dbo.ProductEntities");
        }
    }
}
