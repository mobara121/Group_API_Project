namespace LiquorBarn.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net.Http.Headers;
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

            var abs = new Liquor() { Type = "Absinthe" };
            var bra = new Liquor() { Type = "Brandy" };
            var appBra = new Liquor() { Type = "Brandy", Subtype = "Apple Brandy" };
            var aprBra = new Liquor() { Type = "Brandy", Subtype = "Apricot Brandy" };
            var cogn = new Liquor() { Type = "Brandy", Subtype = "Cognac" };
            var pis = new Liquor() { Type = "Brandy", Subtype = "Pisco" };
            var kir = new Liquor() { Type = "Brandy", Subtype = "Kirsch" };
            var cach = new Liquor() { Type = "Cachaca" };
            var gin = new Liquor() { Type = "Gin" };
            var mez = new Liquor() { Type = "Mezcal" };
            var rum = new Liquor() { Type = "Rum" };
            var darRum = new Liquor() { Type = "Rum", Subtype = "Dark Rum" };
            var golRum = new Liquor() { Type = "Rum", Subtype = "Gold Rum" };
            var ligRum = new Liquor() { Type = "Rum", Subtype = "Light Rum" };
            var teq = new Liquor() { Type = "Tequila" };
            var vod = new Liquor() { Type = "Vodka" };
            var lemVod = new Liquor() { Type = "Vodka", Subtype = "Lemon Vodka" };
            var whis = new Liquor() { Type = "Whiskey" };
            var bour = new Liquor() { Type = "Whiskey", Subtype = "Bourbon" };
            var iriWhis = new Liquor() { Type = "Whiskey", Subtype = "Irish Whiskey" };
            var ryeWhis = new Liquor() { Type = "Whiskey", Subtype = "Rye Whiskey" };
            var sco = new Liquor() { Type = "Whiskey", Subtype = "Scotch" };
            var ama = new Liquor() { Type = "Liqueur", Subtype = "Amaretto" };
            var ape = new Liquor() { Type = "Liqueur", Subtype = "Aperol" };
            var aprLiq = new Liquor() { Type = "Liqueur", Subtype = "Apricot Liqueur" };
            var ben = new Liquor() { Type = "Liqueur", Subtype = "Benedictine" };
            var cam = new Liquor() { Type = "Liqueur", Subtype = "Campari" };
            var cofLiq = new Liquor() { Type = "Liqueur", Subtype = "Coffee Liqueur" };
            var cherLiq = new Liquor() { Type = "Liqueur", Subtype = "Cherry Liqueur" };
            var creCac = new Liquor() { Type = "Liqueur", Subtype = "Creme de Cacao" };
            var wcreCac = new Liquor() { Type = "Liqueur", Subtype = "White Creme de Cacao" };
            var creCas = new Liquor() { Type = "Liqueur", Subtype = "Creme de Cassis" };
            var creMen = new Liquor() { Type = "Liqueur", Subtype = "Creme de Menthe" };
            var creMur = new Liquor() { Type = "Liqueur", Subtype = "Creme de Mure" };
            var creViol = new Liquor() { Type = "Liqueur", Subtype = "Creme de Violette" };
            var dra = new Liquor() { Type = "Liqueur", Subtype = "Drambuie" };
            var gal = new Liquor() { Type = "Liqueur", Subtype = "Galliano" };
            var iriCre = new Liquor() { Type = "Liqueur", Subtype = "Irish Cream" };
            var lilBla = new Liquor() { Type = "Liqueur", Subtype = "Lillet Blanc" };
            var marLiq = new Liquor() { Type = "Liqueur", Subtype = "Maraschino Liqueur" };
            var oraLiq = new Liquor() { Type = "Liqueur", Subtype = "Orange Liqueur" };
            var rasLiq = new Liquor() { Type = "Liqueur", Subtype = "Raspberry Liqueur" };
            var peachSchna = new Liquor() { Type = "Schnapps", Subtype = "Peach Schnapps" };
            var dryVer = new Liquor() { Type = "Vermouth", Subtype = "Dry Vermouth" };
            var sweVer = new Liquor() { Type = "Vermouth", Subtype = "Sweet Vermouth" };

            context.Liquors.AddOrUpdate(x => x.Id,
                abs,
                bra,
                appBra,
                aprBra,
                cogn,
                pis,
                kir,
                cach,
                gin,
                mez,
                rum,
                darRum,
                golRum,
                ligRum,
                teq,
                vod,
                lemVod,
                whis,
                bour,
                iriWhis,
                ryeWhis,
                sco,
                ama,
                ape,
                aprLiq,
                ben,
                cam,
                cofLiq,
                cherLiq,
                creCac,
                wcreCac,
                creCas,
                creMen,
                creMur,
                creViol,
                dra,
                gal,
                iriCre,
                marLiq,
                oraLiq,
                rasLiq,
                peachSchna,
                dryVer,
                sweVer
                );

            context.Cocktails.AddOrUpdate(x => x.Id,
                new Cocktail()
                {
                    Name = "Alexander",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = wcreCac }
                    },
                    Ingredients = "Cream, Nutmeg"
                },

                new Cocktail()
                {
                    Name = "Americano",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = cam },
                        new CocktailLiquor() { Liquor = sweVer }
                    },
                    Ingredients = "Soda Water"
                },

                new Cocktail()
                {
                    Name = "Angel Face",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = appBra },
                        new CocktailLiquor() { Liquor = aprLiq }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Aviation",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = marLiq },
                        new CocktailLiquor() { Liquor = creViol }
                    },
                    Ingredients = "Lemon Juice"
                },

                new Cocktail()
                {
                    Name = "B 52",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = cofLiq },
                        new CocktailLiquor() { Liquor = iriCre },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Bacardi",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum }
                    },
                    Ingredients = "Lime Juice, Grenadine"
                },

                new Cocktail()
                {
                    Name = "Between The Sheets",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum },
                        new CocktailLiquor() { Liquor = cogn },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Lemon Juice"
                },

                new Cocktail()
                {
                    Name = "Black Russian",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = cofLiq }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Bloody Mary",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod }
                    },
                    Ingredients = "Tomato Juice, Lemon Juice, Worcestershire Sauce, Tabasco Sauce, Celery Salt, Pepper"
                },

                new Cocktail()
                {
                    Name = "Bramble",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = creMur }
                    },
                    Ingredients = "Lemon Juice, Simple Syrup"
                },

                new Cocktail()
                {
                    Name = "Caipirinha",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = cach }
                    },
                    Ingredients = "Sugar, Lime"
                },

                new Cocktail()
                {
                    Name = "Casino",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = marLiq }
                    },
                    Ingredients = "Lemon Juice, Orange Bitters"
                },

                new Cocktail()
                {
                    Name = "Clover Club",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin }
                    },
                    Ingredients = "Egg White, Lemon Juice, Raspberry Syrup"
                },

                new Cocktail()
                {
                    Name = "Cosmopolitan",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = lemVod },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Cranberry Juice, Lime Juice"
                },

                new Cocktail()
                {
                    Name = "Cuba Libre",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = rum }
                    },
                    Ingredients = "Cola, Lime"
                },

                new Cocktail()
                {
                    Name = "Daiquiri",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum }
                    },
                    Ingredients = "Lime Juice, Simple Syrup"
                },

                new Cocktail()
                {
                    Name = "Dark N Stormy",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = darRum }
                    },
                    Ingredients = "Ginger Beer, Lime Juice"
                },

                new Cocktail()
                {
                    Name = "Derby",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin }
                    },
                    Ingredients = "Peach Bitters, Mint"
                },

                new Cocktail()
                {
                    Name = "Dirty Martini",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = dryVer }
                    },
                    Ingredients = "Olive Juice"
                },

                new Cocktail()
                {
                    Name = "Dry Martini",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = dryVer }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Espresso Martini",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = cofLiq }
                    },
                    Ingredients = "Espresso, Simple Syrup"
                },

                new Cocktail()
                {
                    Name = "French Connection",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = cogn },
                        new CocktailLiquor() { Liquor = ama }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "French Martini",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = rasLiq }
                    },
                    Ingredients = "Pineapple Juice"
                },

                new Cocktail()
                {
                    Name = "Gin Fizz",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin }
                    },
                    Ingredients = "Lemon Juice, Simple Syrup, Soda Water"
                },

                new Cocktail()
                {
                    Name = "Godfather",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = sco },
                        new CocktailLiquor() { Liquor = ama }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Godmother",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = ama }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Golden Dream",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gal },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Orange Juice, Cream"
                },

                new Cocktail()
                {
                    Name = "Grasshopper",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = creMen },
                        new CocktailLiquor() { Liquor = wcreCac }
                    },
                    Ingredients = "Cream"
                },

                new Cocktail()
                {
                    Name = "Harvey Wallbanger",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = gal }
                    },
                    Ingredients = "Orange Juice"
                },

                new Cocktail()
                {
                    Name = "Hemingway Special",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum },
                        new CocktailLiquor() { Liquor = marLiq }
                    },
                    Ingredients = "Grapefruit Juice, Lime Juice"
                },

                new Cocktail()
                {
                    Name = "Horses Neck",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = bra }
                    },
                    Ingredients = "Ginger Ale, Angostura Bitters"
                },

                new Cocktail()
                {
                    Name = "Irish Coffee",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = iriWhis }
                    },
                    Ingredients = "Hot Coffee, Sugar, Cream"
                },

                new Cocktail()
                {
                    Name = "John Collins",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin }
                    },
                    Ingredients = "Simple Syrup, Lemon Juice, Soda Water"
                },

                new Cocktail()
                {
                    Name = "Kamikaze",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Lime Juice"
                },

                new Cocktail()
                {
                    Name = "Lemon Drop Martini",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = lemVod },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Lemon Juice, Simple Syrup"
                },

                new Cocktail()
                {
                    Name = "Long Island Iced Tea",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = teq },
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = ligRum },
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Lemon Juice, Simple Syrup, Cola"
                },

                new Cocktail()
                {
                    Name = "Mai Tai",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum },
                        new CocktailLiquor() { Liquor = darRum },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Orgeat Syrup, Lime Juice"
                },

                new Cocktail()
                {
                    Name = "Manhattan",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ryeWhis },
                        new CocktailLiquor() { Liquor = sweVer }
                    },
                    Ingredients = "Angostura Bitters"
                },

                new Cocktail()
                {
                    Name = "Margarita",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = teq },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Lime Juice"
                },

                new Cocktail()
                {
                    Name = "Mary Pickford",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum },
                        new CocktailLiquor() { Liquor = marLiq }
                    },
                    Ingredients = "Grenadine, Pineapple Juice"
                },

                new Cocktail()
                {
                    Name = "Mint Julep",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = bour }
                    },
                    Ingredients = "Mint, Powdered Sugar, Water"
                },

                new Cocktail()
                {
                    Name = "Mojito",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum }
                    },
                    Ingredients = "Lime Juice, Mint, Sugar, Soda Water"
                },

                new Cocktail()
                {
                    Name = "Monkey Gland",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = abs }
                    },
                    Ingredients = "Orange Juice, Grenadine"
                },

                new Cocktail()
                {
                    Name = "Moscow Mule",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod }
                    },
                    Ingredients = "Ginger Beer, Lime Juice"
                },

                new Cocktail()
                {
                    Name = "Negroni",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = cam },
                        new CocktailLiquor() { Liquor = sweVer }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Old Fashioned",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = whis }
                    },
                    Ingredients = "Angostura Bitters, Sugar, Water"
                },

                new Cocktail()
                {
                    Name = "Paradise",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = aprBra }
                    },
                    Ingredients = "Orange Juice"
                },

                new Cocktail()
                {
                    Name = "Pina Colada",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum }
                    },
                    Ingredients = "Pineapple Juice, Coconut Cream"
                },

                new Cocktail()
                {
                    Name = "Pisco Sour",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = pis }
                    },
                    Ingredients = "Simple Syrup, Lemon Juice, Egg White"
                },

                new Cocktail()
                {
                    Name = "Planters Punch",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = darRum }
                    },
                    Ingredients = "Lime Juice, Sugar, Water"
                },

                new Cocktail()
                {
                    Name = "Ramos Gin Fizz",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin }
                    },
                    Ingredients = "Simple Syrup, Lime Juice, Lemon Juice, Cream, Egg White, Orange Flower Water, Vanilla Extract, Soda Water"
                },

                new Cocktail()
                {
                    Name = "Rose",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = kir },
                        new CocktailLiquor() { Liquor = dryVer }
                    },
                    Ingredients = "Strawberry Syrup"
                },

                new Cocktail()
                {
                    Name = "Rusty Nail",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = sco },
                        new CocktailLiquor() { Liquor = dra }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Sazerac",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = cogn },
                        new CocktailLiquor() { Liquor = abs }
                    },
                    Ingredients = "Sugar, Peychaud's Bitters"
                },

                new Cocktail()
                {
                    Name = "Screwdriver",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod }
                    },
                    Ingredients = "Orange Juice"
                },

                new Cocktail()
                {
                    Name = "Sea Breeze",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod }
                    },
                    Ingredients = "Cranberry Juice, Grapefruit Juice"
                },

                new Cocktail()
                {
                    Name = "Sex On The Beach",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = peachSchna }
                    },
                    Ingredients = "Cranberry Juice, Orange Juice"
                },

                new Cocktail()
                {
                    Name = "Sidecar",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = cogn },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Lemon Juice"
                },

                new Cocktail()
                {
                    Name = "Singapore Sling",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = cherLiq },
                        new CocktailLiquor() { Liquor = oraLiq },
                        new CocktailLiquor() { Liquor = ben }
                    },
                    Ingredients = "Grenadine, Pineapple Juice, Lime Juice, Angostura Bitters"
                },

                new Cocktail()
                {
                    Name = "Stinger",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = cogn },
                        new CocktailLiquor() { Liquor = creMen }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Tequila Sunrise",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = teq }
                    },
                    Ingredients = "Orange Juice, Grenadine"
                },

                new Cocktail()
                {
                    Name = "Tommys Margarita",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = teq }
                    },
                    Ingredients = "Lime Juice, Agave Nectar"
                },

                new Cocktail()
                {
                    Name = "Tuxedo",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = dryVer },
                        new CocktailLiquor() { Liquor = marLiq },
                        new CocktailLiquor() { Liquor = abs }
                    },
                    Ingredients = "Orange Bitters"
                },

                new Cocktail()
                {
                    Name = "Vampiro",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = teq }
                    },
                    Ingredients = "Tomato Juice, Orange Juice, Lime Juice, Grenadine, Hot Sauce, Salt, Pepper"
                },

                new Cocktail()
                {
                    Name = "Vesper Martini",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = vod },
                        new CocktailLiquor() { Liquor = lilBla }
                    },
                    Ingredients = "N/A"
                },

                new Cocktail()
                {
                    Name = "Whiskey Sour",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = bour }
                    },
                    Ingredients = "Simple Syrup, Lemon Juice, Egg White"
                },

                new Cocktail()
                {
                    Name = "White Lady",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = gin },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Lemon Juice, Egg White"
                },

                new Cocktail()
                {
                    Name = "Yellow Bird",
                    LiquorsInCocktail = new List<CocktailLiquor>()
                    {
                        new CocktailLiquor() { Liquor = ligRum },
                        new CocktailLiquor() { Liquor = gal },
                        new CocktailLiquor() { Liquor = oraLiq }
                    },
                    Ingredients = "Lime Juice"
                }
                );
        }
    }
}
