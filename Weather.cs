using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public class Weather
    {
        public string condition;
        public int temperature;
        public List<string> listOfConditions = new List<string>();
        public Weather()
        {
            listOfConditions.Add("Sunny");
            listOfConditions.Add("Cloudy");
            listOfConditions.Add("Rainy");
            listOfConditions.Add("Snowy");
        }

        public void RandomTemp()
        {
            Random rnd = new Random();
            temperature = rnd.Next(15, 91);
        }

        public void RandomWeather()
        {
            Random rnd = new Random();
            condition = listOfConditions[rnd.Next(4)];
        } 
    }
}

