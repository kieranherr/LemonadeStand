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
        public Player player;
        public List<Day> days;
        public Weather weather;
        public int currentDay;
        public int cupsSold = 0;
        public Game()
        {
            player = new Player();
        }
        public void RunGame()
        {
            Day day = new Day();
            day.NumOfDays();
            StorePage();
            priceAndRecipe();
            WillingToBuy();


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
            Weather weather = new Weather();
            Random rnd = new Random();
            cupsSold = 0;
#pragma warning disable CS0162 // Unreachable code detected
            for (int i = 0; i < 30; i++)
#pragma warning restore CS0162 // Unreachable code detected
            {
                weather.RandomTemp();
                weather.RandomWeather();
               
                
                    if ((weather.temperature <= rnd.Next(65, 85) || weather.temperature >= 90) || (player.recipe.pricePerCup <= rnd.NextDouble() && player.recipe.pricePerCup >= (rnd.NextDouble() * (rnd.Next(1, 3) - 1 + 1))))
                    {
                        player.pitcher.DecreasePitcher();
                        player.inventory.cups.RemoveAt(0);
                        SellLemonade();
                        cupsSold++;
                    }
                    else //if (weather.condition == "Snowy" || weather.condition == "Rainy")
                    {
                        Console.WriteLine("Didn't buy!");
                    }
                
                //if (OutOfLemonade() == true)
                //{
                    break;
                //}
            }
            EndOfDay();
        }

        public bool OutOfLemonade()
        {
            
                
                        if (player.inventory.cups.Count != 0 || player.inventory.lemons.Count <= player.recipe.amountOfLemons && player.inventory.iceCubes.Count <= player.recipe.amountOfIceCubes && player.inventory.sugarCubes.Count <= player.recipe.amountOfSugarCubes || player.pitcher.cupsLeftInPitcher == 0)
                        {
                            player.pitcher.ResetPitcher();
                            subtractRecipe();

                        }

                        else
                        {
                            Console.WriteLine("You are sold out!");
                            Console.WriteLine(player.inventory.lemons.Count);
                            Console.WriteLine(player.inventory.sugarCubes.Count);
                            Console.WriteLine(player.inventory.sugarCubes.Count);
                            Console.ReadLine();
                return true;
                            

                        }
            return false;
        }
                


        

        
        // SOLID Principles Open-Closed Principle
        public void subtractRecipe()
        {
            int lem = player.recipe.amountOfLemons;
            int ice = player.recipe.amountOfIceCubes;
            int sugar = player.recipe.amountOfSugarCubes;
            for(int i = 0; i<lem; i++)
            {
                if (player.inventory.lemons.Count == 0)
                {
                    break;
                }
                else
                {
                    player.inventory.lemons.RemoveAt(0);
                }
            }
            for(int i = 0; i<ice; i++)
            {
                if (player.inventory.iceCubes.Count == 0)
                {
                    break;
                }
                else
                {
                    player.inventory.iceCubes.RemoveAt(0);
                }
            }
            for(int i = 0; i<sugar; i++)
            {
                if (player.inventory.sugarCubes.Count == 0)
                {
                    break;
                }
                else
                {
                    player.inventory.sugarCubes.RemoveAt(0);
                }
            }

        }

        // SOLID Principle Single Responsibility
        public void SellLemonade()
        {
            player.wallet.PayMoneyForItems(player.recipe.pricePerCup);
        }
        public void EndOfDay()
        {
            Console.WriteLine("You sold " + cupsSold + " cups today!");
            Console.WriteLine("Press enter to go to the start of the next day!");
            Console.ReadLine();

        }
    }
}

