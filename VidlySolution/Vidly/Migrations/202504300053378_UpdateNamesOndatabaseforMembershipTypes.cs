namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNamesOndatabaseforMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name='Pay As You Go' Where ID=1");
            Sql("Update MembershipTypes Set Name='Monthly' Where ID=2");
            Sql("Update MembershipTypes Set Name='Quarterly' Where ID=3");
            Sql("Update MembershipTypes Set Name='Annual' Where ID=4");
        }
        
        public override void Down()
        {
        }
    }
}
