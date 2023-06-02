namespace Bossfight

{
    public class Program
    {
        static void Main(string[] args)
        {
            /* Initialize Hero */
            var hero = new GameCharacter(100, 20, 40);

            /* Initialize Boss */
            int randomStrength = new Random().Next(0, 31);
            var boss = new GameCharacter(500, randomStrength, 10);

            /* Creates a list with Random Potions */
            var itemList = new List<Item>();
            for (int i = 0; i < 9; i++)
            {
                itemList.Add(new Item());
            }

            /* Startval for strengthpot and turn number */
            bool strengthPot = false;
            int turnNum = 0;

            /* Start Fight */
            var gameOver = false;

            while (!gameOver)
            {
                if (hero.Health <= 0 && boss.Health <= 0)
                {
                    Console.WriteLine("Both You And The Boss Died");
                    gameOver = true;
                }
                else if (hero.Health <= 0)
                {
                    Console.WriteLine("The Boss Was Victorious!");
                    gameOver = true;
                }
                else if (boss.Health <= 0)
                {
                    Console.WriteLine("The Hero Was Victorious!");
                    gameOver = true;
                }
                else
                {
                    if (strengthPot)
                    {
                        hero.Strength -= 30;
                        strengthPot = false;
                    }
                    if (turnNum % 3 == 0 && RandomNum(3) == 1)
                    {
                        /* Hero might find a random Potion */
                        string randomItem = itemList[RandomNum(itemList.Count)].ItemType;
                        if (randomItem == "HealthPotion" || hero.Health <= 30)
                        {
                            /* Hero gets full health */
                            hero.HealthPotion(hero);
                            Console.WriteLine("The hero found a HealthPotion drop, and has gained full HP!");
                        }
                        else if (randomItem == "StaminaPotion")
                        {
                            /* Hero gets full stamina */
                            hero.Rechange(hero, 0);
                            Console.WriteLine("The hero found a StaminaPotion drop, and has gained full stamina!");
                        }
                        else
                        {
                            /* Hero gets temporary 30 strength */
                            hero.StrengthPotion(hero);
                            Console.WriteLine("The hero found a StrengthPotion drop, and has temporary gained 30 strength!");
                            strengthPot = true;
                        }
                    }
                    hero.Fight(hero, boss);
                    turnNum++;
                }
            }
            Console.ReadLine();
        }
        private static int RandomNum(int length)
        {
            var random = new Random();
            return random.Next(0, length);
        }
    }
}