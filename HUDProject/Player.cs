using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    internal class Player
    {
        static Random RNG = new Random();

        //Heath/Shield System varibles
        public int health;
        public int maxHealth;
        public int attack;
        public int luck;
        public int coins;
        private float missChance = 7.5f;

        //Level up System varibles
        public int level;
        public int xp;
        public int xpToNextLevelUp;

        private int healthIncreaseOnLvl;
        private int luckIncreaseOnLvl;

        //Weapon Arrays and Ints
        public int currentWeapon;
        public int[] ammo = new int[5];
        public int[] ammoMax = new int[5];
        public string[] weapons = new string[5];

        //OverWorld Movement
        public int x;
        public int y;

        //Setup Variables
        public Player()
        {
            maxHealth = 40;
            health = maxHealth;
            attack = 15;
            luck = 5;
            coins = 0;

            level = 1;
            xp = 0;
            xpToNextLevelUp = 100;

            healthIncreaseOnLvl = 10;
            luckIncreaseOnLvl = 1;

            currentWeapon = 0;

            //Array Setup
            weapons[0] = "Sword";
            weapons[1] = "Shotgun";
            weapons[2] = "Crossbow";
            weapons[3] = "Minigun";
            weapons[4] = "Dart Pistol";

            ammoMax[0] = 0;
            ammoMax[1] = 2;
            ammoMax[2] = 5;
            ammoMax[3] = 200;
            ammoMax[4] = 11;

            ammo[0] = ammoMax[0];
            ammo[1] = ammoMax[1];
            ammo[2] = ammoMax[2];
            ammo[3] = ammoMax[3];
            ammo[4] = ammoMax[4];
        }

        //Handles XP Gaining and Level ups
        public void AddXPLevelUp(int XPAdded)
        {
            int numberOfTimesLeveled = 0;
            xp += XPAdded;

            while (xp >= xpToNextLevelUp)
            {
                level += 1;
                maxHealth += healthIncreaseOnLvl;
                luck += luckIncreaseOnLvl;
                health = maxHealth;
                xp -= xpToNextLevelUp;
                numberOfTimesLeveled += 1;
            }

            if (numberOfTimesLeveled > 0)
            {
                Program.DisplayText("LEVEL UP!!!", true);
                //DisplayText("Player gained " + numberOfTimesLeveled + " Levels",true);
                Program.DisplayText("Player gained +" + (numberOfTimesLeveled * healthIncreaseOnLvl) + " Max Health", false);
                Program.DisplayText("Player gained +" + (numberOfTimesLeveled * luckIncreaseOnLvl) + " Luck", false);
                Program.DisplayText("Player's Health Restored", false);
                Console.ReadKey(true);
            }
        }

        //Takes a number and subtracts it form health
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0)
                health = 0;
        }

        //Generates a Number of Damage to deal to an Enemy
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
    }
}
