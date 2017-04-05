namespace Saphira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneRefactor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "PrimaryPhone", c => c.Long(nullable: false));
            AlterColumn("dbo.Employees", "SecondaryPhone", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "SecondaryPhone", c => c.String());
            AlterColumn("dbo.Employees", "PrimaryPhone", c => c.String());
        }
    }
}
