namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_draftmessage_column : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DraftMessages",
                c => new
                    {
                        DraftMessageID = c.Int(nullable: false, identity: true),
                        Receiver = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.DraftMessageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DraftMessages");
        }
    }
}
