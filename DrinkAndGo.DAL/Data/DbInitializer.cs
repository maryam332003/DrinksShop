using DrinkAndGo.DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DrinkAndGo.DAL.Data
{
    public static class DbInitializer
    {
        public static  void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context), "AppDbContext cannot be null");
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Categories.Select(c => c.Value));
                }

                if (!context.Drinks.Any())
                {
                    context.Drinks.AddRange
                    (
                    #region MyRegion
                        //new Drink
                        //    {
                        //        Name = "Beer",
                        //        Price = 7.95M,
                        //        ShortDescription = "The most widely consumed alcohol",
                        //        LongDescription = "Beer is the world's oldest[1][2][3] and most widely consumed[4] alcoholic drink; it is the third most popular drink overall, after water and tea.[5] The production of beer is called brewing, which involves the fermentation of starches, mainly derived from cereal grains—most commonly malted barley, although wheat, maize (corn), and rice are widely used.[6] Most beer is flavoured with hops, which add bitterness and act as a natural preservative, though other flavourings such as herbs or fruit may occasionally be included. The fermentation process causes a natural carbonation effect, although this is often removed during processing, and replaced with forced carbonation.[7] Some of humanity's earliest known writings refer to the production and distribution of beer: the Code of Hammurabi included laws regulating beer and beer parlours.",
                        //        Category = Categories["Alcoholic"],
                        //        ImageUrl = "https://images.pexels.com/photos/6223373/pexels-photo-6223373.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //        InStock = true,
                        //        IsPreferredDrink = true,
                        //        ImageThumbnailUrl = "https://images.pexels.com/photos/5055192/pexels-photo-5055192.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //    },
                        //new Drink
                        //{
                        //    Name = "Rum & Coke",
                        //    Price = 12.95M,
                        //    ShortDescription = "Cocktail made of cola, lime and rum.",
                        //    LongDescription = "The world's second most popular drink was born in a collision between the United States and Spain. It happened during the Spanish-American War at the turn of the century when Teddy Roosevelt, the Rough Riders, and Americans in large numbers arrived in Cuba. One afternoon, a group of off-duty soldiers from the U.S. Signal Corps were gathered in a bar in Old Havana. Fausto Rodriguez, a young messenger, later recalled that Captain Russell came in and ordered Bacardi (Gold) rum and Coca-Cola on ice with a wedge of lime. The captain drank the concoction with such pleasure that it sparked the interest of the soldiers around him. They had the bartender prepare a round of the captain's drink for them. The Bacardi rum and Coke was an instant hit. As it does to this day, the drink united the crowd in a spirit of fun and good fellowship. When they ordered another round, one soldier suggested that they toast ¡Por Cuba Libre! in celebration of the newly freed Cuba.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/2789328/pexels-photo-2789328.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/3417441/pexels-photo-3417441.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Tequila ",
                        //    Price = 12.95M,
                        //    ShortDescription = "Beverage made from the blue agave plant.",
                        //    LongDescription = "Tequila (Spanish About this sound [teˈkila] (help·info)) is a regionally specific name for a distilled beverage made from the blue agave plant, primarily in the area surrounding the city of Tequila, 65 km (40 mi) northwest of Guadalajara, and in the highlands (Los Altos) of the central western Mexican state of Jalisco. Although tequila is similar to mezcal, modern tequila differs somewhat in the method of its production, in the use of only blue agave plants, as well as in its regional specificity. Tequila is commonly served neat in Mexico and as a shot with salt and lime across the rest of the world.The red volcanic soil in the surrounding region is particularly well suited to the growing of the blue agave, and more than 300 million of the plants are harvested there each year.[1] Agave tequila grows differently depending on the region. Blue agaves grown in the highlands Los Altos region are larger in size and sweeter in aroma and taste. Agaves harvested in the lowlands, on the other hand, have a more herbaceous fragrance and flavor.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/4279096/pexels-photo-4279096.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "http://imgh.us/tequilaS.jpg"
                        //},
                        //new Drink
                        //{
                        //    Name = "Wine ",
                        //    Price = 16.75M,
                        //    ShortDescription = "A very elegant alcoholic drink",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/33265/wine-bottle-wine-glasses-wine-ambience.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "http://imgh.us/wineS.jpg"
                        //},
                        //new Drink
                        //{
                        //    Name = "Margarita",
                        //    Price = 17.95M,
                        //    ShortDescription = "A cocktail with sec, tequila and lime",
                        //    Category = Categories["Alcoholic"],
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    ImageUrl = "https://images.pexels.com/photos/3073970/pexels-photo-3073970.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "http://imgh.us/margaritaS.jpg"
                        //},
                        //new Drink
                        //{
                        //    Name = "Whiskey with Ice",
                        //    Price = 15.95M,
                        //    ShortDescription = "The best way to taste whiskey",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/6087430/pexels-photo-6087430.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/20234694/pexels-photo-20234694/free-photo-of-glass-of-whisky-with-ice.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Jägermeister",
                        //    Price = 15.95M,
                        //    ShortDescription = "A German digestif made with 56 herbs",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/7427261/pexels-photo-7427261.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "http://imgh.us/jagermeisterS.jpg"
                        //},
                        //new Drink
                        //{
                        //    Name = "Champagne",
                        //    Price = 15.95M,
                        //    ShortDescription = "That is how sparkling wine can be called",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/239466/pexels-photo-239466.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/2145/sea-sunset-beach-couple.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Piña colada ",
                        //    Price = 15.95M,
                        //    ShortDescription = "A sweet cocktail made with rum.",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/19034780/pexels-photo-19034780/free-photo-of-pineapple-and-coconut-cocktail-with-ice-cubes-and-little-umbrella.jpeg?auto=compress&cs=tinysrgb&w=600",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/19034793/pexels-photo-19034793/free-photo-of-pina-colada-with-ice-cubes-and-a-small-umbrella.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "White Russian",
                        //    Price = 15.95M,
                        //    ShortDescription = "A cocktail made with vodka ",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/7259083/pexels-photo-7259083.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/14537767/pexels-photo-14537767.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Long Island Iced Tea",
                        //    Price = 15.95M,
                        //    ShortDescription = "Aa mixed drink made with tequila.",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "http://imgh.us/longTeaL.jpg",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "http://imgh.us/islandTeaS.jpg"
                        //},
                        //new Drink
                        //{
                        //    Name = "Vodka",
                        //    Price = 15.95M,
                        //    ShortDescription = "A distilled beverage with water and ethanol.",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/1170598/pexels-photo-1170598.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/9405015/pexels-photo-9405015.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Gin and tonic",
                        //    Price = 15.95M,
                        //    ShortDescription = "Made with gin and tonic water poured over ice.",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/13999929/pexels-photo-13999929.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/13439099/pexels-photo-13439099.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Cosmopolitan",
                        //    Price = 15.95M,
                        //    ShortDescription = "Made with vodka, triple sec, cranberry juice.",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/3039671/pexels-photo-3039671.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = false,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/1441122/pexels-photo-1441122.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Tea ",
                        //    Price = 12.95M,
                        //    ShortDescription = "Made by leaves of the tea plant in hot water.",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Non-alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/230477/pexels-photo-230477.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = true,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/10627257/pexels-photo-10627257.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Water ",
                        //    Price = 12.95M,
                        //    ShortDescription = " It makes up more than half of your body weight ",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Non-alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/416528/pexels-photo-416528.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/8074426/pexels-photo-8074426.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Coffee ",
                        //    Price = 12.95M,
                        //    ShortDescription = " A beverage prepared from coffee beans",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Non-alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/312418/pexels-photo-312418.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = true,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/1695052/pexels-photo-1695052.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Kvass",
                        //    Price = 12.95M,
                        //    ShortDescription = "A very refreshing Russian beverage",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Non-alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/338713/pexels-photo-338713.jpeg?auto=compress&cs=tinysrgb&w=600",
                        //    InStock = true,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/128242/pexels-photo-128242.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Juice ",
                        //    Price = 12.95M,
                        //    ShortDescription = "Naturally contained in fruit or vegetable tissue.",
                        //    LongDescription = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in section 1.10.32. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        //    Category = Categories["Non-alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/1233319/pexels-photo-1233319.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/2842876/pexels-photo-2842876.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "Iced Coffee ",
                        //    Price = 15.95M,
                        //    ShortDescription = "popular cold beverage that offers a refreshing ",
                        //    LongDescription = " Iced coffee is a versatile drink, perfect for cooling down on hot summer days or as a refreshing pick-me-up at any time of the year. It can be enjoyed black for a bold, straightforward flavor, or customized with various ingredients to create a unique, delicious experience. Whether you're a coffee purist or someone who enjoys experimenting with different flavors, iced coffee offers a delightful way to enjoy your favorite brew.",
                        //    Category = Categories["Non-alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/11100423/pexels-photo-11100423.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = false,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/8605915/pexels-photo-8605915.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "cappuccino",
                        //    Price = 9.95M,
                        //    ShortDescription = "classic Italian coffee drink made with espresso and steamed milk",
                        //    LongDescription = " Cappuccino is a beloved coffee beverage originating from Italy, renowned for its harmonious blend of espresso, steamed milk, and milk foam. Traditionally served in a small, porcelain cup, the drink is prepared by first brewing a shot of espresso, which forms the base. This is then combined with equal parts of steamed milk, creating a smooth and velvety texture that enhances the coffee's bold flavor. The distinguishing feature of a cappuccino lies in its topping—a thick layer of milk foam, often dusted with cocoa powder or cinnamon, adding a touch of visual appeal and a hint of additional flavor. The balance between espresso's robust intensity, creamy milk, and airy foam makes cappuccino a favorite among coffee enthusiasts seeking both depth of flavor and indulgent texture.\"\r\n\r\n\r\n\r\n\r\n\r\n\r\n",
                        //    Category = Categories["Non-alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/2396220/pexels-photo-2396220.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = true,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/290975/pexels-photo-290975.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //},
                        //new Drink
                        //{
                        //    Name = "mocha",
                        //    Price = 11.95M,
                        //    ShortDescription = "coffee  combines espresso, steamed milk, and chocolate, topped with whipped cream",
                        //    LongDescription = " Cappuccino is a beloved coffee beverage originating from Italy, renowned for its harmonious blend of espresso, steamed milk, and milk foam. Traditionally served in a small, porcelain cup, the drink is prepared by first brewing a shot of espresso, which forms the base. This is then combined with equal parts of steamed milk, creating a smooth and velvety texture that enhances the coffee's bold flavor. The distinguishing feature of a cappuccino lies in its topping—a thick layer of milk foam, often dusted with cocoa powder or cinnamon, adding a touch of visual appeal and a hint of additional flavor. The balance between espresso's robust intensity, creamy milk, and airy foam makes cappuccino a favorite among coffee enthusiasts seeking both depth of flavor and indulgent texture.\"\r\n\r\n\r\n\r\n\r\n\r\n\r\n",
                        //    Category = Categories["Non-alcoholic"],
                        //    ImageUrl = "https://images.pexels.com/photos/1006297/pexels-photo-1006297.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                        //    InStock = true,
                        //    IsPreferredDrink = true,
                        //    ImageThumbnailUrl = "https://images.pexels.com/photos/350478/pexels-photo-350478.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        //}

                    #endregion

                    #region Cold-Drinks

                        new Drink
                        {
                            Name = "Iced Coffee",
                            Price = 4.50M,
                            ShortDescription = "A refreshing coffee beverage served cold",
                            LongDescription = "Iced coffee is a type of coffee beverage served chilled, brewed variously with the fundamental division being cold brew – brewing the coffee cold, yielding a different flavor, but not requiring cooling – or brewing normally (hot) and then cooling. Iced coffee is known for its invigorating taste and ability to cool you down during hot weather.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://media.istockphoto.com/id/497863160/photo/iced-coffee-in-takeaway-cup.jpg?s=612x612&w=0&k=20&c=oGMD3GYBJ03HnIr0xHbp4IC0QnTxTl0d_2RnxYugC1U=",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://media.istockphoto.com/id/497863160/photo/iced-coffee-in-takeaway-cup.jpg?s=612x612&w=0&k=20&c=oGMD3GYBJ03HnIr0xHbp4IC0QnTxTl0d_2RnxYugC1U="
                        },
                        new Drink
                        {
                            Name = "Lemonade",
                            Price = 3.00M,
                            ShortDescription = "A classic refreshing citrus drink",
                            LongDescription = "Lemonade is a sweetened lemon-flavored beverage. There are varieties of lemonade found throughout the world. In North America and South Asia, cloudy lemonade dominates, which is traditionally a homemade drink using lemon juice, water, and a sweetener such as cane sugar or honey. In the United Kingdom and Australia, a carbonated version dominates.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/1233319/pexels-photo-1233319.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/1233319/pexels-photo-1233319.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new Drink
                        {
                            Name = "Iced Tea",
                            Price = 3.75M,
                            ShortDescription = "A cool and refreshing tea beverage",
                            LongDescription = "Iced tea is a form of cold tea. Though usually served in a glass with ice, it can refer to any tea that has been chilled or cooled. It may be sweetened with sugar or syrup. Iced tea is also a popular packaged drink.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/128242/pexels-photo-128242.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/128242/pexels-photo-128242.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new Drink
                        {
                            Name = "Smoothie",
                            Price = 5.50M,
                            ShortDescription = "A thick, creamy beverage blended with fruit",
                            LongDescription = "A smoothie is a beverage made from pureed raw fruit and/or vegetables, typically using a blender. A smoothie often has a liquid base such as water, fruit juice, plant milk, or dairy products, such as milk, yogurt, ice cream, or cottage cheese. Smoothies may also be sweetened with sugar, syrup, or honey, or be sugar-free.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/8181548/pexels-photo-8181548.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/8181548/pexels-photo-8181548.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Coconut Water",
                            Price = 2.75M,
                            ShortDescription = "A natural, hydrating tropical drink",
                            LongDescription = "Coconut water is the clear liquid inside coconuts (fruits of the coconut palm). In early development, it serves as a suspension for the endosperm of the coconut during the nuclear phase of development. Coconut water is a popular drink in the tropics and is known for its hydrating properties.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/1917838/pexels-photo-1917838.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/1917838/pexels-photo-1917838.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new Drink
                        {
                            Name = "Cold Brew Coffee",
                            Price = 5.00M,
                            ShortDescription = "Smooth and refreshing coffee",
                            LongDescription = "Cold brew coffee is made by steeping coarse-ground coffee beans in room temperature water for an extended period, typically 12 hours or more. This process results in a coffee that is smoother and less acidic than hot-brewed coffee, and it is often served over ice.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/4552181/pexels-photo-4552181.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/4552181/pexels-photo-4552181.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Milkshake",
                            Price = 6.00M,
                            ShortDescription = "A creamy, thick shake",
                            LongDescription = "A milkshake is a sweet, cold beverage made from milk, ice cream, and flavorings or sweeteners such as fruit syrup or chocolate sauce. Milkshakes can be made in a variety of flavors, including vanilla, chocolate, strawberry, and many others.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://media.istockphoto.com/id/926990564/photo/chocolate-milk-and-whipped-cream.jpg?s=612x612&w=0&k=20&c=LabS3iGKio9kYS7OUGsosTm0Bb4XKY8WkXPer_RU3IQ=",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://media.istockphoto.com/id/926990564/photo/chocolate-milk-and-whipped-cream.jpg?s=612x612&w=0&k=20&c=LabS3iGKio9kYS7OUGsosTm0Bb4XKY8WkXPer_RU3IQ="
                        },

                        new Drink
                        {
                            Name = "Iced Matcha Latte",
                            Price = 5.50M,
                            ShortDescription = "A refreshing green tea drink",
                            LongDescription = "Iced matcha latte is a beverage made with matcha, a finely ground powder of specially grown and processed green tea leaves. It is mixed with milk (dairy or non-dairy) and served over ice, offering a vibrant green color and a unique, slightly sweet flavor.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/5946979/pexels-photo-5946979.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/5946979/pexels-photo-5946979.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Frappe",
                            Price = 4.75M,
                            ShortDescription = "A chilled coffee drink",
                            LongDescription = "A frappe is a Greek iced coffee drink made from instant coffee, water, sugar, and milk. It is shaken to produce a foam, and then served over ice. Frappes can also be made with espresso, creating a richer flavor.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/4282717/pexels-photo-4282717.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/4282717/pexels-photo-4282717.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Berry Smoothie",
                            Price = 6.25M,
                            ShortDescription = "A fruity, blended beverage",
                            LongDescription = "Berry smoothie is a delicious and nutritious drink made from blending various berries like strawberries, blueberries, and raspberries with yogurt or milk. It's a thick and creamy beverage packed with vitamins and antioxidants, making it a healthy choice.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/4551179/pexels-photo-4551179.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/4551179/pexels-photo-4551179.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Iced Chai Latte",
                            Price = 4.50M,
                            ShortDescription = "A spiced tea latte served cold",
                            LongDescription = "Iced chai latte is a delightful blend of black tea, spices like cinnamon, cardamom, and cloves, mixed with milk and served over ice. This cold version of the classic chai tea offers a refreshing and flavorful drink.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/5305639/pexels-photo-5305639.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/5305639/pexels-photo-5305639.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Pina Colada",
                            Price = 6.50M,
                            ShortDescription = "A tropical coconut and pineapple blend",
                            LongDescription = "Pina colada is a classic tropical drink made with coconut cream, pineapple juice, and crushed ice. Often garnished with a pineapple slice or cherry, this drink is a perfect escape to a tropical paradise.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/10986581/pexels-photo-10986581.jpeg",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/10986581/pexels-photo-10986581.jpeg"
                        },

                        new Drink
                        {
                            Name = "Cucumber Mint Cooler",
                            Price = 3.75M,
                            ShortDescription = "A refreshing blend of cucumber and mint",
                            LongDescription = "Cucumber mint cooler is a refreshing and hydrating drink made with fresh cucumber slices, mint leaves, and a splash of lemon juice, all mixed with cold water. It is perfect for hot days and a great way to stay hydrated.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/7377018/pexels-photo-7377018.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/7377018/pexels-photo-7377018.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Watermelon Slush",
                            Price = 4.25M,
                            ShortDescription = "A frozen treat made with fresh watermelon",
                            LongDescription = "Watermelon slush is a cool and fruity drink made by blending fresh watermelon with ice and a touch of sweetener. It's a perfect drink for cooling off during the summer and enjoying the natural sweetness of watermelon.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/8755221/pexels-photo-8755221.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/8755221/pexels-photo-8755221.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Mango Smoothie",
                            Price = 5.95M,
                            ShortDescription = "A creamy and tropical mango delight",
                            LongDescription = "Mango smoothie is a delicious and creamy drink made with fresh mangoes, yogurt, and a touch of honey. It's a perfect refreshing beverage for hot days, packed with tropical flavor and nutrients.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/8211179/pexels-photo-8211179.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/8211179/pexels-photo-8211179.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Peach Iced Tea",
                            Price = 3.75M,
                            ShortDescription = "A sweet and fruity iced tea",
                            LongDescription = "Peach iced tea is a deliciously sweet and refreshing beverage made by combining fresh peach slices and peach syrup with traditional iced tea. It's a perfect summer drink that offers a sweet and fruity twist on classic iced tea.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/8375246/pexels-photo-8375246.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/8375246/pexels-photo-8375246.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Raspberry Lemonade",
                            Price = 3.95M,
                            ShortDescription = "A tangy and sweet berry-infused lemonade",
                            LongDescription = "Raspberry lemonade is a vibrant and refreshing drink made by combining fresh raspberries and lemon juice with a bit of sweetener. Served over ice, it delivers a delightful balance of tangy and sweet flavors, perfect for a hot day.",
                            Category = Categories["Cold-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/5817609/pexels-photo-5817609.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/5817609/pexels-photo-5817609.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        #endregion

                    #region Hot-Drinks
                        new Drink
                        {
                            Name = "Hot Chocolate",
                            Price = 4.50M,
                            ShortDescription = "A rich and creamy chocolate drink",
                            LongDescription = "Hot chocolate is a warm and comforting beverage made by mixing chocolate or cocoa powder with hot milk or water. It's often topped with whipped cream or marshmallows for extra indulgence, making it a perfect treat for cold days.",
                            Category = Categories["Hot-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/6119112/pexels-photo-6119112.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/6119112/pexels-photo-6119112.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Espresso",
                            Price = 2.95M,
                            ShortDescription = "A strong and bold coffee",
                            LongDescription = "Espresso is a concentrated form of coffee served in small, strong shots. It's made by forcing hot water through finely-ground coffee beans, resulting in a rich, intense flavor. It's the base for many coffee drinks like lattes, cappuccinos, and macchiatos.",
                            Category = Categories["Hot-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/1749303/pexels-photo-1749303.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/1749303/pexels-photo-1749303.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Green Tea",
                            Price = 2.50M,
                            ShortDescription = "A soothing and healthy tea",
                            LongDescription = "Green tea is a type of tea that is made from Camellia sinensis leaves and buds that have not undergone the same withering and oxidation process used to make oolong and black tea. It's known for its numerous health benefits and refreshing taste.",
                            Category = Categories["Hot-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/1638280/pexels-photo-1638280.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/1638280/pexels-photo-1638280.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Matcha Latte",
                            Price = 4.25M,
                            ShortDescription = "A creamy blend of matcha and milk",
                            LongDescription = "Matcha latte is a creamy and frothy beverage made by blending high-quality powdered green tea (matcha) with steamed milk. It's known for its vibrant green color, rich flavor, and health benefits.",
                            Category = Categories["Hot-Drinks"],
                            ImageUrl = "https://thumbs.dreamstime.com/b/matcha-latte-art-heart-shape-top-wooden-table-some-gr-green-tea-powder-tools-tea-making-japanese-style-87708022.jpg",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://thumbs.dreamstime.com/b/matcha-latte-art-heart-shape-top-wooden-table-some-gr-green-tea-powder-tools-tea-making-japanese-style-87708022.jpg"
                        },

                        new Drink
                        {
                            Name = "Peppermint Mocha",
                            Price = 4.75M,
                            ShortDescription = "A festive blend of coffee, chocolate, and peppermint",
                            LongDescription = "Peppermint mocha is a seasonal favorite that combines the rich flavors of espresso and chocolate with a hint of refreshing peppermint. Topped with whipped cream and chocolate shavings, it's a perfect treat for the holiday season.",
                            Category = Categories["Hot-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/302899/pexels-photo-302899.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = true,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/302899/pexels-photo-302899.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Cappuccino",
                            Price = 3.50M,
                            ShortDescription = "A classic Italian coffee",
                            LongDescription = "Cappuccino is a popular coffee drink that is made with equal parts espresso, steamed milk, and milk foam. It is often enjoyed in the morning and known for its rich flavor and velvety texture.",
                            Category = Categories["Hot-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/437716/pexels-photo-437716.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/437716/pexels-photo-437716.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Latte",
                            Price = 3.75M,
                            ShortDescription = "A smooth and creamy coffee",
                            LongDescription = "Latte is a coffee drink made with espresso and steamed milk. It is typically served with a small amount of milk foam on top and can be flavored with syrups like vanilla, caramel, or hazelnut.",
                            Category = Categories["Hot-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/302905/pexels-photo-302905.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/302905/pexels-photo-302905.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },

                        new Drink
                        {
                            Name = "Americano",
                            Price = 2.95M,
                            ShortDescription = "A simple and strong coffee",
                            LongDescription = "Americano is a type of coffee prepared by diluting an espresso with hot water. This results in a drink with a similar strength but different flavor from traditionally brewed coffee.",
                            Category = Categories["Hot-Drinks"],
                            ImageUrl = "https://images.pexels.com/photos/7578170/pexels-photo-7578170.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            InStock = true,
                            IsPreferredDrink = false,
                            ImageThumbnailUrl = "https://images.pexels.com/photos/7578170/pexels-photo-7578170.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        }


                        #endregion

                    ) ;
                }

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Category> _categories;

        private static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new Dictionary<string, Category>
                    {
                        { "Cold-Drinks", new Category { CategoryName = "Cold-Drinks", Description = "All Cold Drinks" } },
                        { "Hot-Drinks", new Category { CategoryName = "Hot-Drinks", Description = "All Hot Drinks" } }
                        //{ "Dessert", new Category { CategoryName = "Dessert", Description = "Desserts" } }
                    };
                }

                return _categories;
            }
        }

    }
}
