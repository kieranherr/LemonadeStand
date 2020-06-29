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
        public int currentDay; 
        public Game()
        {

        }
        public void RunGame()
        {
            Day day = new Day();
            day.NumOfDays();
            StorePage();
        }

        public void StorePage()
        {
            Store store = new Store();
            double money = player.wallet.ReturnMoney();
            int i = 0;
            while(i != 1)
            {
                money = player.wallet.ReturnMoney(); 
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
                Console.WriteLine("Type 1 to exit the store. Type 0 to stay in the store.");
                    i = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
