using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public class Game
    {
        public Player player = new Player();
        public List<Day> days;
        public Weather weather = new Weather();
        public int currentDay; 
        public Game()
        {

        }
        public void RunGame()
        {
            Day day = new Day();
            day.NumOfDays();
            StorePage();
            priceAndRecipe();
            


        }

        public void StorePage()
        {
            Store store = new Store();
            double money = player.wallet.ReturnMoney();
            int i = 4;
            Console.WriteLine("Welcome to the store!");
            while (i != 0){
                money = player.wallet.ReturnMoney();
               
                Console.WriteLine("If you would like to continue in the store, type 1.");
                Console.WriteLine("If you would like to exit the store, type 0");
                i = Convert.ToInt32(Console.ReadLine());
                if (i == 1)
                {
                    Console.WriteLine("You have " + money + " dollars");
                    Console.WriteLine("You have " + player.inventory.lemons.Count + " Lemons. Press 1 if you would like to buy more");
                    Console.WriteLine("You have " + player.inventory.iceCubes.Count + " Ice Cubes. Press 2 if you would like to buy more");
                    Console.WriteLine("You have " + player.inventory.sugarCubes.Count + " Sugar Cubes. Press 3 if you would like to buy more");
                    Console.WriteLine("You have " + player.inventory.cups.Count + " Cups. Press 4 if you would like to buy more"); 
                    int choice = Int32.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            store.SellLemons(player);
                            break;
                        case 2:
                            store.SellIceCubes(player);
                            break;
                        case 3:
                            store.SellSugarCubes(player);
                            break;
                        case 4:
                            store.SellCups(player);
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option.");
                            break;

                    }
                }
                   
                
               
                
   
            }
        }
        public void priceAndRecipe()
        {
            int choice = 0;
            while (choice != 3)
            {
                Console.WriteLine("The recipe is currently:");
                Console.WriteLine(player.recipe.amountOfLemons + " Lemons");
                Console.WriteLine(player.recipe.amountOfSugarCubes + " Cubes of Sugar");
                Console.WriteLine(player.recipe.amountOfIceCubes + " Ice Cubes");
                Console.WriteLine("The price is currently: " + player.recipe.pricePerCup);
                Console.WriteLine("If you would like to change the recipe, type 1. If you would like to change the price, type 2. If you would like to keep the current recipe and price, type 3.");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please input the number of lemons you would like to use.");
                        int amtOfLemons = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please input the number of sugar cubes you would like to use.");
                        int amtOfSugar = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please input the number of ice cubes you would like to use.");
                        int amtOfIce = Convert.ToInt32(Console.ReadLine());
                        player.recipe.ChangeRecipe(amtOfLemons, amtOfSugar, amtOfIce);
                        break;
                    case 2:
                        Console.WriteLine("How much would you like to charge per cup?");
                        double price = Convert.ToDouble(Console.ReadLine());
                        player.recipe.ChangePrice(price);
                        break;
                    case 3:
                        Console.WriteLine("Time to start the day!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Please choose a number between 1 and 3.");
                        break;

                }
            }
        }
        public void WillingToBuy()
        {
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                weather.RandomTemp();
                weather.RandomWeather();
                if ((weather.temperature <= rnd.Next(65, 85) && weather.temperature >= 90) && (player.recipe.pricePerCup <= rnd.NextDouble() && player.recipe.pricePerCup >= (rnd.NextDouble() * (rnd.Next(1, 3) - 1 + 1))))
                {
                    player.pitcher.DecreasePitcher();
                    player.inventory.cups.RemoveAt(0);
                }
                else if (weather.condition == "Snowy" || weather.condition == "Rainy")
                {
                    Console.WriteLine("Didn't buy!");
                }
                OutOfLemonade();
            }
        }

        public void OutOfLemonade()
        {
            if (player.pitcher.cupsLeftInPitcher == 0)
            {
                Console.WriteLine("You are sold out!");
                player.pitcher.ResetPitcher();
                subtractRecipe();
            }
            
           
            Console.WriteLine(player.inventory.lemons.Count);
            Console.WriteLine(player.inventory.sugarCubes.Count);
            Console.WriteLine(player.inventory.sugarCubes.Count);

        }
        public void subtractRecipe()
        {
            int lem = player.recipe.amountOfLemons;
            int ice = player.recipe.amountOfIceCubes;
            int sugar = player.recipe.amountOfSugarCubes;
            for(int i = 0; i<lem; i++)
            {
                player.inventory.lemons.RemoveAt(0);
            }
            for(int i = 0; i<ice; i++)
            {
                player.inventory.iceCubes.RemoveAt(0);
            }
            for(int i = 0; i<sugar; i++)
            {
                player.inventory.sugarCubes.RemoveAt(0);
            }

        }
    }
}

