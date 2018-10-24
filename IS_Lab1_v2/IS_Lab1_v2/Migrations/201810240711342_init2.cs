namespace IS_Lab1_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HardDisks", "FormFactor", c => c.Int());
            AlterColumn("dbo.HardDisks", "IsM2", c => c.Boolean());
            AlterColumn("dbo.HardDisks", "Size", c => c.Double());
            AlterColumn("dbo.HardDisks", "Type", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HardDisks", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.HardDisks", "Size", c => c.Double(nullable: false));
            AlterColumn("dbo.HardDisks", "IsM2", c => c.Boolean(nullable: false));
            AlterColumn("dbo.HardDisks", "FormFactor", c => c.Int(nullable: false));
        }
    }
}
