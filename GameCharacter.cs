namespace Bossfight
{
    internal class GameCharacter
    {
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }

        public GameCharacter(int health, int strength, int stamina)
        {
            Health = health;
            Strength = strength;
            Stamina = stamina;
        }

        public void Fight(GameCharacter hero, GameCharacter boss)
        {
            if (hero.Stamina == 0)
            {
                Console.WriteLine("The hero is out of breath and needs a recharge.");
                Rechange(hero, 0);
            }
            else
            {
                boss.Health = boss.Health - hero.Strength;
                Console.WriteLine($"Hero hit enemy with {hero.Strength},enemy now has {boss.Health} health left.");
                hero.Stamina = hero.Stamina - 10;
			}

            if (boss.Stamina == 0)
            {
                Console.WriteLine("The enemy is out of breath and needs a recharge.");
				Rechange(boss, 1);
			}
            else
            {
				hero.Health = hero.Health - boss.Strength;
                Console.WriteLine($"Enemy hit hero with {boss.Strength},Hero now has {hero.Health} health left.");
                boss.Strength = new Random().Next(0, 31);
                boss.Stamina = boss.Stamina - 10;
			}
        }

        public void Rechange(GameCharacter heroOrBoss, int Id)
        {
            if (Id == 0)
            {
                heroOrBoss.Stamina = 40;
            }
            else
            {
                heroOrBoss.Stamina = 10;
			}
            

		}
    }
}