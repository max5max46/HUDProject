using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    internal class Program
    {
        //Heath/Shield System varibles
        static int Health;
        static int Shield;
        static int MaxHealth;
        static int MaxShield;

        //Lives System varibles
        static int Lives;
        static int MaxLives;

        //Level up System varibles
        static int Level;
        static int XP;
        static int XPToNextLevelUp;
        static int HealthIncreaseOnLvl;
        static int ShieldIncreaseOnLvl;

        static void Main(string[] args)
        {
            //Varible Setup
            MaxHealth = 100;
            MaxShield = 100;
            Health = MaxHealth;
            Shield = MaxShield;

            Lives = 3;
            MaxLives = 99;

            Level = 1;
            XP = 0;
            XPToNextLevelUp = 100;
            HealthIncreaseOnLvl = 20;
            ShieldIncreaseOnLvl = 20;


            // Varibles Given by theoretical Game
            int Damage = 150;
            int HealAmount = 10;
            int RegenShieldAmount = 15;
            int XPAdded = 10;
            int LivesAdded = 100;

            //Testing
            ShowHUD();
            Console.ReadKey(true);
            AddLives(LivesAdded);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);




            ShowHUD();
            Console.ReadKey(true);
            AddXPLevelUp(XPAdded);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);

            TakeDamage(Damage);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);

            Heal(HealAmount);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);

            RegenerateShield(RegenShieldAmount);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);

            TakeDamage(Damage);
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);

            ResetGame();
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);

        }

        //Displays the HUD
        static void ShowHUD()
        {
            Console.WriteLine("\n Lives: " + Lives + "   Level: " + Level + "   XP: " + XP + "   XP to Next Level: " + (XPToNextLevelUp - XP));
            Console.WriteLine("\n ----------------------------------------------------------------\n");
            Console.WriteLine(" Health: " + Health + "  Shield:  " + Shield + "\n");
        }

        //Takes Shield, Health, and Lives Away Based on Inputed Value Also handles Game Over
        static void TakeDamage(int DamageAmount)
        {
            int TempDamage;
            Console.WriteLine("Player is about to take (" + DamageAmount + ") Damage");
            if (DamageAmount < 0)
            {
                Console.WriteLine("Error - DamageAmount Varible Does not equel a Positive Number");
            }
            else
            {
                TempDamage = DamageAmount - Shield;

                Shield = Shield - DamageAmount;

                if (Shield <= 0)
                {
                    Shield = 0;

                    if (TempDamage > 0)  Health = Health - TempDamage;
                }

                Console.WriteLine("Player Took (" + DamageAmount + ") Damage");

                if (Health <= 0)
                {
                    Health = MaxHealth;
                    Lives = Lives - 1;

                    if (Lives != 0)
                    {
                        Health = MaxHealth;
                        Shield = MaxShield;
                        Console.WriteLine("Player Lost a Live (-1)");
                        Console.WriteLine("Player's Health and Shield are reset to Max");
                    }
                    //Game Over
                    else
                    {
                        Console.WriteLine("Player Lives have Reached (0)");
                        Console.WriteLine("Game Over Has Occurred Reseting Game");
                        ResetGame();
                    }
                    
                }
                    
            }
        }

        static void Heal(int HealAmount)
        {
            int TempHealth;
            Console.WriteLine("Player is about to Heal (" + HealAmount + ") Health");

            if (HealAmount < 0)
            {
                Console.WriteLine("Error - HealAmount Varible Does not equel a Positive Number");
            }
            else
            {
                TempHealth = Health;
                Health = Health + HealAmount;
                if (Health >= MaxHealth)
                {
                    TempHealth = MaxHealth - TempHealth; 
                    Health = MaxHealth;
                    Console.WriteLine("Player Healed (" + TempHealth + ") Health");
                }
                else
                {
                    Console.WriteLine("Player Healed (" + HealAmount + ") Health");
                }
                
            }
            
        }

        static void RegenerateShield(int RegenShieldAmount)
        {
            int TempShield;
            Console.WriteLine("Player is about to Regenerate (" + RegenShieldAmount + ") Shield");

            if (RegenShieldAmount < 0)
            {
                Console.WriteLine("Error - RegenShieldAmount Varible Does not equel a Positive Number");
            }
            else
            {
                TempShield = Shield;
                Shield = Shield + RegenShieldAmount;
                if (Shield >= MaxShield)
                {
                    TempShield = MaxShield - TempShield;
                    Shield = MaxShield;
                    Console.WriteLine("Player Regenerated (" + TempShield + ") Shield");
                }
                else
                {
                    Console.WriteLine("Player Regenerated (" + RegenShieldAmount + ") Shield");
                }
            }
        }

        static void AddXPLevelUp(int XPAdded)
        {
            int NumberOfTimesLeveled = 0;
            Console.WriteLine("Player is about to Receive (" + XPAdded + ") XP");

            if (XPAdded < 0)
            {
                Console.WriteLine("Error - XPAdded Varible Does not equel a Positive Number");
            }
            else
            {
                XP += XPAdded;
                Console.WriteLine("Player gained (" + XPAdded + ") XP");

                while (XP >= XPToNextLevelUp)
                {
                    Level += 1;
                    MaxHealth += HealthIncreaseOnLvl;
                    Health = MaxHealth;
                    MaxShield += ShieldIncreaseOnLvl;
                    Shield = MaxShield;
                    XP -= XPToNextLevelUp;
                    NumberOfTimesLeveled += 1;
                }

                if (NumberOfTimesLeveled > 0)
                {
                    Console.WriteLine("Player gained (" + NumberOfTimesLeveled + ") Levels");
                    Console.WriteLine("Player gained (" + (NumberOfTimesLeveled * HealthIncreaseOnLvl) + ") Max Health");
                    Console.WriteLine("Player gained (" + (NumberOfTimesLeveled * ShieldIncreaseOnLvl) + ") Max Shield");
                    Console.WriteLine("Player's Health and Shield are set to Max");
                }
                    
            }
        }

        static void ResetGame()
        {
            Console.WriteLine("Player Stats are about to Reset");

            MaxHealth = 100;
            MaxShield = 100;
            Health = MaxHealth;
            Shield = MaxShield;

            Lives = 3;

            Level = 1;
            XP = 0;
            XPToNextLevelUp = 100;
            HealthIncreaseOnLvl = 20;
            ShieldIncreaseOnLvl = 20;

            Console.WriteLine("Player Stats are Successfully Reset");
        }

        static void AddLives(int AddedLives)
        {
            int TempLives;
            Console.WriteLine("Player is about to Receive (" + AddedLives + ") Lives");

            if (AddedLives < 0)
            {
                Console.WriteLine("Error - AddedLives Varible Does not equel a Positive Number");
            }
            else
            {
                TempLives = Lives;
                Lives += AddedLives;
                if (Lives >= MaxLives)
                {
                    TempLives = MaxLives - TempLives;
                    Lives = MaxLives;
                    Console.WriteLine("Player Gained (" + TempLives + ") Lives");
                }
                else
                {
                    Console.WriteLine("Player Gained (" + AddedLives + ") Lives");
                }
            }
        }
    }
}
