namespace AngularBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        empid = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.empid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
