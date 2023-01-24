using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    

    internal class Enemy
    {
        private static Random RNG = new Random();

        public string name;
        public int health;
        public int maxHealth;
        public int attack;
        public int xp;
        private int luck;
        public int coins;
        private float missChance = 7.5f;

        //Setup Variables
        public Enemy(string name = "none", int health = 0, int attack = 0, int xp =0, int luck = 0, int coins = 0)
        {
            this.name = name;
            this.health = health;
            maxHealth = health;
            this.attack = attack;
            this.xp = xp;
            this.luck = luck;
            this.coins = coins;
        }

        //Takes a number and subtracts it form health
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
        }

        //Generates a Number of Damage to deal to the player
        public int DealDamage()
        {
            int damage;
            float randomNum;
            randomNum = (RNG.Next(0, 1001) / 10);

            if (randomNum < missChance - (luck * 0.1)) damage = 0;
            else if (randomNum >= 97 - (luck / 2)) damage = attack * 2;
            else damage = attack;

            return damage;
        }

        //Debug most Variables
        public string VariableDebug()
        {
            return "Name: " + name + "  Health: " + health + "  Attack: " + attack + "  Xp: " + xp + "  Luck: " + luck;
        }
    }
}
