using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public  class Pitcher
    {
        public int cupsLeftInPitcher;

        public Pitcher()
        {
            cupsLeftInPitcher = 12;
         

        }
         public void DecreasePitcher()
        {
            cupsLeftInPitcher--;
        }
        public void ResetPitcher()
        {
            cupsLeftInPitcher = 12;


        }
    }
}
