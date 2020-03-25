using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        public Weather weather;
        public List<Customer> customers;
        public Store store;
        public int days;
        public Pitcher pitcher;
        Random rnd = new Random();
        public Day()
        {

        }
        public void NumOfDays()
        {
            Console.WriteLine("How many days would you like to go for? 7 days, 14 days, or 30 days.");
            days = int.Parse(Console.ReadLine());
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
                if(pitcher.cupsLeftInPitcher == 0)
                {
                    pitcher.ResetPitcher();
                }
            }

        }
    }
}
