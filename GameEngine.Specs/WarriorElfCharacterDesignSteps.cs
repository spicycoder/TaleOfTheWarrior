using NFluent;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace GameEngine.Specs
{
    [Binding]
    public class WarriorElfCharacterDesignSteps
    {
        private ElfWarrior _player;

        [Given(@"A new player")]
        public void GivenANewPlayer()
        {
            _player = new ElfWarrior();
        }

        [When(@"Eat a (.*)")]
        public void WhenEatA(FoodTypes food)
        {
            _player.Eat(food);
        }

        [Then(@"Health should be (.*)")]
        public void ThenHealthShouldBe(int health)
        {
            Check.That<int>(_player.Health).IsEqualTo(health);
        }

        [When(@"Attacked (.*) times")]
        public void WhenAttackedTimes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _player.Hit();
            }
        }

    }
}
