using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        
        Console.WriteLine("Hero and Monster have 10 health points at the start!\n");
        
        int heroHealth = 10;
        int monsterHealth = 10;
        string attacker = "hero";

        void DisplayHealthBars()
        {
            Console.WriteLine("\nHero Health: [" + new string('=', heroHealth) + new string(' ', 10 - heroHealth) + "] " + heroHealth + "/10");
            Console.WriteLine("Monster Health: [" + new string('=', monsterHealth) + new string(' ', 10 - monsterHealth) + "] " + monsterHealth + "/10\n");
        }

        string GetRandomAttackMessage(string attacker, int damage)
        {
            string[] heroMessages = {
                $"Hero strikes fiercely for {damage} damage!",
                $"Hero lands a crushing blow for {damage} damage!",
                $"Hero's swift attack deals {damage} damage!"
            };

            string[] monsterMessages = {
                $"Monster claws savagely for {damage} damage!",
                $"Monster bites viciously for {damage} damage!",
                $"Monster's powerful attack causes {damage} damage!"
            };

            return attacker == "hero" ? heroMessages[random.Next(heroMessages.Length)] : monsterMessages[random.Next(monsterMessages.Length)];
        }

        DisplayHealthBars();

        do
        {
            int hit = random.Next(1, 11);

            if (attacker == "hero")
            {
                Console.WriteLine("Hero's turn to attack! (Press Enter)");
                Console.ReadLine();
                string attackMessage = GetRandomAttackMessage("hero", hit);
                Console.WriteLine(attackMessage);
                monsterHealth -= hit;
                if (monsterHealth < 0) monsterHealth = 0;
                attacker = "monster";
            }
            else
            {
                Console.WriteLine("Monster's turn to attack! (Press Enter)");
                Console.ReadLine();
                string attackMessage = GetRandomAttackMessage("monster", hit);
                Console.WriteLine(attackMessage);
                heroHealth -= hit;
                if (heroHealth < 0) heroHealth = 0;
                attacker = "hero";
            }

            DisplayHealthBars();

        } while (heroHealth > 0 && monsterHealth > 0);

        if (heroHealth <= 0)
        {
            Console.WriteLine("\nBad Luck! The Monster has won!");
            Console.WriteLine(@"
                 /\_/\
                ( o.o )
                 > ^ <
            ");
        }
        else if (monsterHealth <= 0)
        {
            Console.WriteLine("\nGreat! The Hero has won!!!");
            Console.WriteLine(@"
             /\
            /__\  
           ( o.o )
            > ^ <
            ");
        }
    }
}
