namespace Saphira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuildPersonTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persons", "PrimaryPhone", c => c.Long());
            AlterColumn("dbo.Persons", "SecondaryPhone", c => c.Long());
            DropColumn("dbo.Persons", "Middle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persons", "Middle", c => c.String());
            AlterColumn("dbo.Persons", "SecondaryPhone", c => c.String());
            AlterColumn("dbo.Persons", "PrimaryPhone", c => c.String());
        }
    }
}
