namespace EBazarSols.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NEW1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_Id" });
            RenameColumn(table: "dbo.Products", name: "category_Id", newName: "CategoryId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "category_Id");
            CreateIndex("dbo.Products", "category_Id");
            AddForeignKey("dbo.Products", "category_Id", "dbo.Categories", "Id");
        }
    }
}
