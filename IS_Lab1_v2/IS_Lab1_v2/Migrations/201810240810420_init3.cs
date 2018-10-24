namespace IS_Lab1_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HardDisks", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HardDisks", "Name");
        }
    }
}
