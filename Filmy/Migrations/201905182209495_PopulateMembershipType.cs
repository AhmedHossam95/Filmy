namespace Filmy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonth,DiscountRate) VALUES ('Pay As You Go',0,0,0)");
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonth,DiscountRate) VALUES ('Monthly',30,1,10)");
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonth,DiscountRate) VALUES ('Quarterly',90,3,15)");
            Sql("INSERT INTO MembershipTypes (Name,SignUpFee,DurationInMonth,DiscountRate) VALUES ('Annually',300,12,20)");
            

        }

        public override void Down()
        {
        }
    }
}
