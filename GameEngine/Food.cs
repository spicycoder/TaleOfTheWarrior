using System.Collections.Generic;

namespace GameEngine
{
    public enum FoodTypes
    {
        Carrot,
        Bread,
        Portion,
        Wine
    }

    public class Food
    {
        public static readonly Dictionary<FoodTypes, int> CalariesIndex =
            new Dictionary<FoodTypes, int>
            {
                { FoodTypes.Carrot, 10 },
                { FoodTypes.Bread, 20 },
                { FoodTypes.Portion, 30 },
                { FoodTypes.Wine, 40 }
            };
    }
}