namespace IS_Lab1_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HardDisks", "Color", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HardDisks", "Color", c => c.String());
        }
    }
}
