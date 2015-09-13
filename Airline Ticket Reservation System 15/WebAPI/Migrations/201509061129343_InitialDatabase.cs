namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aircraft",
                c => new
                    {
                        AircraftID = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        CabinID = c.Int(nullable: false),
                        CarrierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AircraftID)
                .ForeignKey("dbo.Cabin", t => t.CabinID, cascadeDelete: true)
                .ForeignKey("dbo.Carrier", t => t.CarrierID, cascadeDelete: true)
                .Index(t => t.CabinID)
                .Index(t => t.CarrierID);
            
            CreateTable(
                "dbo.Cabin",
                c => new
                    {
                        CabinID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CabinID);
            
            CreateTable(
                "dbo.Carrier",
                c => new
                    {
                        CarrierID = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarrierID)
                .ForeignKey("dbo.Country", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryID = c.Int(nullable: false),
                        Name = c.String(),
                        ISOCode = c.String(),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityID = c.Int(nullable: false),
                        Name = c.String(),
                        IATA = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.Country", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Airport",
                c => new
                    {
                        AirportID = c.Int(nullable: false),
                        IATA = c.String(),
                        Name = c.String(),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AirportID)
                .ForeignKey("dbo.City", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        RouteID = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        DepartureAirportID = c.Int(nullable: false),
                        DestinationAirportID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteID)
                .ForeignKey("dbo.Airport", t => t.DepartureAirportID)
                .ForeignKey("dbo.Airport", t => t.DestinationAirportID, cascadeDelete: true)
                .Index(t => t.DepartureAirportID)
                .Index(t => t.DestinationAirportID);
            
            CreateTable(
                "dbo.Flight",
                c => new
                    {
                        FlightID = c.Int(nullable: false),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        SeatCountLeft = c.Int(nullable: false),
                        Code = c.String(),
                        AircraftID = c.Int(nullable: false),
                        RouteID = c.Int(nullable: false),
                        MealID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightID)
                .ForeignKey("dbo.Aircraft", t => t.AircraftID, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealID, cascadeDelete: true)
                .ForeignKey("dbo.Route", t => t.RouteID, cascadeDelete: true)
                .Index(t => t.AircraftID)
                .Index(t => t.RouteID)
                .Index(t => t.MealID);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        MealID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MealID);
            
            CreateTable(
                "dbo.RouteTax",
                c => new
                    {
                        RouteTaxID = c.Int(nullable: false),
                        IdNumber = c.String(),
                        Name = c.String(),
                        RouteID = c.Int(nullable: false),
                        TaxID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RouteTaxID)
                .ForeignKey("dbo.Route", t => t.RouteID, cascadeDelete: true)
                .ForeignKey("dbo.Tax", t => t.TaxID, cascadeDelete: true)
                .Index(t => t.RouteID)
                .Index(t => t.TaxID);
            
            CreateTable(
                "dbo.Tax",
                c => new
                    {
                        TaxID = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Code = c.String(),
                        ChargeTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaxID)
                .ForeignKey("dbo.ChargeType", t => t.ChargeTypeID, cascadeDelete: true)
                .Index(t => t.ChargeTypeID);
            
            CreateTable(
                "dbo.ChargeType",
                c => new
                    {
                        ChargeTypeID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ChargeTypeID);
            
            CreateTable(
                "dbo.Terminal",
                c => new
                    {
                        TerminalID = c.Int(nullable: false),
                        Name = c.String(),
                        AirportID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TerminalID)
                .ForeignKey("dbo.Airport", t => t.AirportID, cascadeDelete: true)
                .Index(t => t.AirportID);
            
            CreateTable(
                "dbo.Gate",
                c => new
                    {
                        GateID = c.Int(nullable: false),
                        Name = c.String(),
                        TerminalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GateID)
                .ForeignKey("dbo.Terminal", t => t.TerminalID, cascadeDelete: true)
                .Index(t => t.TerminalID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "CountryID", "dbo.Country");
            DropForeignKey("dbo.Gate", "TerminalID", "dbo.Terminal");
            DropForeignKey("dbo.Terminal", "AirportID", "dbo.Airport");
            DropForeignKey("dbo.RouteTax", "TaxID", "dbo.Tax");
            DropForeignKey("dbo.Tax", "ChargeTypeID", "dbo.ChargeType");
            DropForeignKey("dbo.RouteTax", "RouteID", "dbo.Route");
            DropForeignKey("dbo.Flight", "RouteID", "dbo.Route");
            DropForeignKey("dbo.Flight", "MealID", "dbo.Meal");
            DropForeignKey("dbo.Flight", "AircraftID", "dbo.Aircraft");
            DropForeignKey("dbo.Route", "DestinationAirportID", "dbo.Airport");
            DropForeignKey("dbo.Route", "DepartureAirportID", "dbo.Airport");
            DropForeignKey("dbo.Airport", "CityID", "dbo.City");
            DropForeignKey("dbo.Carrier", "CountryID", "dbo.Country");
            DropForeignKey("dbo.Aircraft", "CarrierID", "dbo.Carrier");
            DropForeignKey("dbo.Aircraft", "CabinID", "dbo.Cabin");
            DropIndex("dbo.Gate", new[] { "TerminalID" });
            DropIndex("dbo.Terminal", new[] { "AirportID" });
            DropIndex("dbo.Tax", new[] { "ChargeTypeID" });
            DropIndex("dbo.RouteTax", new[] { "TaxID" });
            DropIndex("dbo.RouteTax", new[] { "RouteID" });
            DropIndex("dbo.Flight", new[] { "MealID" });
            DropIndex("dbo.Flight", new[] { "RouteID" });
            DropIndex("dbo.Flight", new[] { "AircraftID" });
            DropIndex("dbo.Route", new[] { "DestinationAirportID" });
            DropIndex("dbo.Route", new[] { "DepartureAirportID" });
            DropIndex("dbo.Airport", new[] { "CityID" });
            DropIndex("dbo.City", new[] { "CountryID" });
            DropIndex("dbo.Carrier", new[] { "CountryID" });
            DropIndex("dbo.Aircraft", new[] { "CarrierID" });
            DropIndex("dbo.Aircraft", new[] { "CabinID" });
            DropTable("dbo.Gate");
            DropTable("dbo.Terminal");
            DropTable("dbo.ChargeType");
            DropTable("dbo.Tax");
            DropTable("dbo.RouteTax");
            DropTable("dbo.Meal");
            DropTable("dbo.Flight");
            DropTable("dbo.Route");
            DropTable("dbo.Airport");
            DropTable("dbo.City");
            DropTable("dbo.Country");
            DropTable("dbo.Carrier");
            DropTable("dbo.Cabin");
            DropTable("dbo.Aircraft");
        }
    }
}
