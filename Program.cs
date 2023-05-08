namespace Bossfight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Initialize Hero */
            var hero = new GameCharacter(100, 20, 40);

            /* Initialize Boss */
            int randomStrength = new Random().Next(0, 31);
            var boss = new GameCharacter(225, randomStrength, 10);

            /* Fight */
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
                    hero.Fight(hero, boss);
                }
            }
            Console.ReadLine();
        }
    }
}