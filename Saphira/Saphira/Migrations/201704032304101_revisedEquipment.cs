namespace Saphira.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revisedEquipment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipment", "ServiceRequested", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipment", "ServiceRequested", c => c.Boolean());
        }
    }
}
