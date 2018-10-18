using System;

namespace GameEngine
{
    public class ElfWarrior
    {
        public int Health { get; set; }

        public ElfWarrior()
        {
            Health = 30;
        }

        public void Eat(FoodTypes food)
        {
            Health = Math.Min(Health + Food.CalariesIndex[food], 100);
        }

        public void Hit()
        {
            Health = Math.Max(Health - 10, 0);
        }
    }
}
