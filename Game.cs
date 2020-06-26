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
        public int currentDay; 
        public Game()
        {

        }
        public static void RunGame()
        {
            Day day = new Day();
            day.NumOfDays();

        }

        public static void StorePage()
        {
            Wallet wallet = new Wallet();
            double money = wallet.ReturnMoney();

        }
    }
}
