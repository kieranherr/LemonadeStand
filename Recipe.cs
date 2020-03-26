using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    public class Recipe
    {
        public int amountOfLemons;
        public int amountOfSugarCubes;
        public int amountOfIceCubes;
        public double pricePerCup;  
        public Recipe()
        {
            amountOfLemons = 4;
            amountOfSugarCubes = 4;
            amountOfIceCubes = 4;
            pricePerCup = .25;
        }
        public void ChangeRecipe(int lemon, int sugar, int ice)
        {
            amountOfLemons = lemon;
            amountOfSugarCubes = sugar;
            amountOfIceCubes = ice;
        }
        public void ChangePrice(double price)
        {
            pricePerCup = price;
        }

    }
}
   