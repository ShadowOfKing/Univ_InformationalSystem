namespace IS_Lab1_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HardDisks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Cost = c.Double(),
                        Manufacturer = c.String(),
                        Image = c.String(),
                        AccessTime = c.Double(),
                        Autonomous = c.Boolean(),
                        AutonomousTime = c.Double(),
                        BufferSize = c.Double(),
                        FlashSize = c.Double(),
                        FormFactor = c.Int(nullable: false),
                        HasSCSI = c.Boolean(),
                        IsM2 = c.Boolean(nullable: false),
                        Purpose = c.Int(),
                        ReadSpeed = c.Double(),
                        RotationSpeed = c.Double(),
                        Sata = c.Int(),
                        Size = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Usb = c.Int(),
                        WorkTime = c.Double(),
                        WriteSpeed = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HardDisks");
        }
    }
}
