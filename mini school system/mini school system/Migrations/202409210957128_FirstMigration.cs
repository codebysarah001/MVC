namespace mini_school_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskDescription = c.String(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropIndex("dbo.Task", new[] { "ClassId" });
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropTable("dbo.Subject");
            DropTable("dbo.Task");
            DropTable("dbo.Student");
            DropTable("dbo.Class");
        }
    }
}
