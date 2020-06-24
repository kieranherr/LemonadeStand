﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public class Day
    {
        public Weather weather;
        public List<Customer> customers;
        public Store store;
        public int days;
        public Pitcher pitcher;
        public Inventory inventory;
        Random rnd = new Random();
        public Day()
        {

        }
        public void NumOfDays()
        {
            Console.WriteLine("How many days would you like to go for? 1. 7 days, 2. 14 days, or 3. 30 days.");
            int ans = Convert.ToInt32(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    days = 7;
                    break;
                case 2:
                    days = 14;
                    break;
                case 3:
                    days = 30;
                    break;
                default:
                    break;

            }
        }
        public void WillingToBuy()
        {
            for(int i = 0; i<30; i++)
            {
                weather.RandomTemp();
                weather.RandomWeather();
                if ((weather.temperature <= rnd.Next(65, 85) && weather.temperature >= 90) && (store.pricePerCup <= rnd.NextDouble() && store.pricePerCup >= (rnd.NextDouble() * (rnd.Next(1, 3) - 1 + 1))))
                {
                    pitcher.DecreasePitcher();
                }
                else if (weather.condition == "Snowy" || weather.condition == "Rainy")
                {
                    Console.WriteLine("Didn't buy!");
                }

                // move to seperate method
                    if (inventory.lemons.Count() >= 0 || inventory.iceCubes.Count() >= 0 || inventory.sugarCubes.Count() >= 0 || inventory.cups.Count() >= 0)
                    {
                        Console.WriteLine("You are sold out!");
                        break;
                    }
                    else
                    {
                        pitcher.ResetPitcher();
                    }
            }

        }
    }
}
