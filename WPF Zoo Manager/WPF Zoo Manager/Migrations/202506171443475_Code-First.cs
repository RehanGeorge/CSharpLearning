namespace WPF_Zoo_Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirst : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Animals", "Species");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Species", c => c.String());
        }
    }
}
