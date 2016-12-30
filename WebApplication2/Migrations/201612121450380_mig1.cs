namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        IdMajor = c.Int(nullable: false, identity: true),
                        MajorName = c.String(),
                    })
                .PrimaryKey(t => t.IdMajor);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentCode = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LName = c.String(),
                        IdMajor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCode)
                .ForeignKey("dbo.Majors", t => t.IdMajor, cascadeDelete: true)
                .Index(t => t.IdMajor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "IdMajor", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "IdMajor" });
            DropTable("dbo.Students");
            DropTable("dbo.Majors");
        }
    }
}
