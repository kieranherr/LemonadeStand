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
            Wallet wallet = new Wallet();
            Inventory inventory = new Inventory();
            Store store = new Store();
            double money = wallet.ReturnMoney();
            int i = 0;
            while(i != 1)
            {
                money = wallet.ReturnMoney();
                int lemons = inventory.lemons.Count;
                int iceCubes = inventory.iceCubes.Count;
                int sugarCubes = inventory.sugarCubes.Count;
                int cups = inventory.cups.Count;
                Console.WriteLine("You have " + money + " dollars");
                Console.WriteLine("You have " + lemons + " Lemons. Press 1 if you would like to buy more");
                Console.WriteLine("You have " + iceCubes + " Ice Cubes. Press 2 if you would like to buy more");
                Console.WriteLine("You have " + sugarCubes + " Sugar Cubes. Press 3 if you would like to buy more");
                Console.WriteLine("You have " + cups + " Cups. Press 4 if you would like to buy more");
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
                Console.ReadLine();
            }
        }
    }
}
