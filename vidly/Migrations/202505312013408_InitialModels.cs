namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            AddColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DiscountRate", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.MembershipTypes", "IsSubscribedToNewsLetter");
            DropColumn("dbo.Movies", "Title");
            DropColumn("dbo.Movies", "Genre");
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Movies", "DurationMinutes");
            DropColumn("dbo.Movies", "IsAvailable");
            DropColumn("dbo.Movies", "RentalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "RentalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Movies", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "DurationMinutes", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "Title", c => c.String());
            AddColumn("dbo.MembershipTypes", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Int(nullable: false));
            AlterColumn("dbo.MembershipTypes", "DiscountRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Movies", "NumberAvailable");
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Movies", "Name");
            DropColumn("dbo.Customers", "Birthdate");
            DropTable("dbo.Genres");
        }
    }
}
