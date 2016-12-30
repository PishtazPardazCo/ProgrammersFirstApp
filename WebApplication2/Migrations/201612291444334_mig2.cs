namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Majors", "MajorName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Majors", "MajorName", c => c.String());
        }
    }
}
