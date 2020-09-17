namespace LiquorBarn.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<LiquorBarn.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LiquorBarn.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var one = new Liquor() { Type = "Brandy" }; // 1
            var two = new Liquor() { Type = "Brandy", Subtype = "Apple Brandy" }; // 2
            var three = new Liquor() { Type = "Brandy", Subtype = "Cognac" }; // 3
            var four = new Liquor() { Type = "Cachaca" }; // 4
            var five = new Liquor() { Type = "Gin" }; // 5
            var six = new Liquor() { Type = "Rum" }; // 6
            var seven = new Liquor() { Type = "Rum", Subtype = "Dark Rum" }; // 7
            var eight = new Liquor() { Type = "Rum", Subtype = "Gold Rum" }; // 8
            var nine = new Liquor() { Type = "Rum", Subtype = "Light Rum" }; // 9
            var ten = new Liquor() { Type = "Vodka" }; // 10
            var eleven = new Liquor() { Type = "Vodka", Subtype = "Lemon Vodka" }; // 11
            var twelve = new Liquor() { Type = "Whiskey" }; // 12
            var thirteen = new Liquor() { Type = "Whiskey", Subtype = "Bourbon" }; // 13
            var fourteen = new Liquor() { Type = "Whiskey", Subtype = "Irish Whiskey" }; // 14
            var fifteen = new Liquor() { Type = "Whiskey", Subtype = "Scotch" }; // 15
            var sixteen = new Liquor() { Type = "Liqueur", Subtype = "Amaretto" }; // 16
            var seventeen = new Liquor() { Type = "Liqueur", Subtype = "Apricot Liqueur" }; // 17
            var eighteen = new Liquor() { Type = "Liqueur", Subtype = "Campari" }; // 18
            var nineteen = new Liquor() { Type = "Liqueur", Subtype = "Coffee Liqueur" }; // 19
            var twenty = new Liquor() { Type = "Liqueur", Subtype = "Creme de Cacao" }; // 20
            var twentyOne = new Liquor() { Type = "Liqueur", Subtype = "White Creme de Cacao" }; // 21
            var twentyTwo = new Liquor() { Type = "Liqueur", Subtype = "Creme de Menthe" }; // 22
            var twentyThree = new Liquor() { Type = "Liqueur", Subtype = "Creme de Violette" }; // 23
            var twentyFour = new Liquor() { Type = "Liqueur", Subtype = "Galliano" }; // 24
            var twentyFive = new Liquor() { Type = "Liqueur", Subtype = "Irish Cream" }; // 25
            var twentySix = new Liquor() { Type = "Liqueur", Subtype = "Maraschino Liqueur" }; // 26
            var twentySeven = new Liquor() { Type = "Liqueur", Subtype = "Orange Liqueur" }; // 27
            var twentyEight = new Liquor() { Type = "Vermouth", Subtype = "Dry Vermouth" }; // 28
            var twentyNine = new Liquor() { Type = "Vermouth", Subtype = "Sweet Vermouth" }; // 29

            context.Liquors.AddOrUpdate(x => x.Id,
                one,
                two,
                three,
                four,
                five,
                six,
                seven,
                eight,
                nine,
                ten,
                eleven,
                twelve,
                thirteen,
                fourteen,
                fifteen,
                sixteen,
                seventeen,
                eighteen,
                nineteen,
                twenty,
                twentyOne,
                twentyTwo,
                twentyThree,
                twentyFour,
                twentyFive,
                twentySix,
                twentySeven,
                twentyEight,
                twentyNine
                );

            context.Cocktails.AddOrUpdate(x => x.Id,
                new Cocktail()
                {
                    Name = "Alexander",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = five },
                        new CocktailLiquor() { Liquor = twentyOne }
                    },
                    Ingredients = "Cream, Nutmeg"
                },

                new Cocktail()
                {
                    Name = "Americano",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = eighteen },
                        new CocktailLiquor() { Liquor = twentyNine }
                    },
                    Ingredients = "Soda Water"
                },

                new Cocktail()
                {
                    Name = "Angel Face",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = five },
                        new CocktailLiquor() { Liquor = two },
                        new CocktailLiquor() { Liquor = seventeen }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Aviation",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = five },
                        new CocktailLiquor() { Liquor = twentySix },
                        new CocktailLiquor() { Liquor = twentyThree }
                    },
                    Ingredients = "Lemon Juice"
                }
                );
        }
    }
}
