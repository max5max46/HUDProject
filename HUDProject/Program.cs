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
        static string HealthStatus;

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

            bool YourStuck = true;
            int MakeItStop = 43;

            //Testing
            while (YourStuck == true)

            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Hello Test Subject (" + MakeItStop + ")\n Let have Some Fun Today (:\n Testing Mode Active\n Loading Normal Play...\n");
                Console.ResetColor();
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                TakeDamage(120);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Heal(14);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                RegenerateShield(250);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                AddLives(1);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Lets say an Enemy Has Died\n We may now Add XP\n");
                Console.ResetColor();
                Console.ReadKey(true);

                AddXPLevelUp(46);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n We have Some XP\n Lets Hit " + XPToNextLevelUp + "\n");
                Console.ResetColor();
                Console.ReadKey(true);

                AddXPLevelUp(XPToNextLevelUp - 46);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Perfect\n Now Lets Prompt Some Errors \n");
                Console.ResetColor();
                Console.ReadKey(true);

                TakeDamage(-10);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Heal(-99);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                RegenerateShield(-145);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                AddLives(-45);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                AddXPLevelUp(-1000);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Good\n Now Lets Test Variable Ranges \n");
                Console.ResetColor();
                Console.ReadKey(true);

                Heal(200);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                RegenerateShield(366);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                AddLives(100);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Almost Done\n Lets Overload XP \n");
                Console.ResetColor();
                Console.ReadKey(true);

                AddXPLevelUp(1000);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Very Good\n Time for the Last Section \n Reseting Stats...");
                Console.ResetColor();
                Console.ReadKey(true);

                ResetGame();
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Now For My Favorite Part\n Overloading Damage\n");
                Console.ResetColor();
                Console.ReadKey(true);

                TakeDamage(200);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Thank You for Your Cooperation\n");
                Console.ResetColor();
                Console.ReadKey(true);

                TakeDamage(200);
                Console.ReadKey(true);

                ShowHUD();
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Goodbye (:\n");
                Console.ResetColor();
                Console.ReadKey(true);

                TakeDamage(200);
                Console.ReadKey(true);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Initializing Next Test\n");
                Console.ResetColor();
                Console.ReadKey(true);
                Console.Clear();
                MakeItStop += 1;
            }
        }

        //Displays the HUD
        static void ShowHUD()
        {
            HealthStatusSet();
            Console.WriteLine("\n Lives: " + Lives + "   Level: " + Level + "   XP: " + XP + "   XP to Next Level: " + (XPToNextLevelUp - XP));
            Console.WriteLine(" ----------------------------------------------------------------");
            Console.WriteLine(" Health: " + Health + "  Shield:  " + Shield);
            Console.WriteLine(" ----------------------------------------------------------------");
            Console.WriteLine(HealthStatus);
        }

        //Takes Shield, Health, and Lives Away Based on Inputed Value Also handles Game Over
        static void TakeDamage(int DamageAmount)
        {
            int TempDamage;
            Console.WriteLine(" Player is about to take (" + DamageAmount + ") Damage");
            if (DamageAmount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - DamageAmount Variable Does not equal a Positive Number");
                Console.ResetColor();
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

                Console.WriteLine(" Player Took (" + DamageAmount + ") Damage");

                if (Health <= 0)
                {
                    Health = MaxHealth;
                    Lives = Lives - 1;

                    if (Lives != 0)
                    {
                        Health = MaxHealth;
                        Shield = MaxShield;
                        Console.WriteLine(" Player Lost a Live (-1)");
                        Console.WriteLine(" Player's Health and Shield are reset to Max");
                    }
                    //Game Over
                    else
                    {
                        Console.WriteLine(" Player Lives have Reached (0)");
                        Console.WriteLine(" Game Over Has Occurred Reseting Game");
                        ResetGame();
                    }
                    
                }
                    
            }
        }

        // Heals your Health Based on Inputed Value
        static void Heal(int HealAmount)
        {
            int TempHealth;
            Console.WriteLine(" Player is about to Heal (" + HealAmount + ") Health");

            if (HealAmount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - HealAmount Variable Does not equal a Positive Number");
                Console.ResetColor();
            }
            else
            {
                TempHealth = Health;
                Health = Health + HealAmount;
                if (Health >= MaxHealth)
                {
                    TempHealth = MaxHealth - TempHealth; 
                    Health = MaxHealth;
                    Console.WriteLine(" Player Healed (" + TempHealth + ") Health");
                }
                else
                {
                    Console.WriteLine(" Player Healed (" + HealAmount + ") Health");
                }
                
            }
            
        }

        // Regenerates your Shield Based on Inputed Value
        static void RegenerateShield(int RegenShieldAmount)
        {
            int TempShield;
            Console.WriteLine(" Player is about to Regenerate (" + RegenShieldAmount + ") Shield");

            if (RegenShieldAmount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - RegenShieldAmount Variable Does not equal a Positive Number");
                Console.ResetColor();
            }
            else
            {
                TempShield = Shield;
                Shield = Shield + RegenShieldAmount;
                if (Shield >= MaxShield)
                {
                    TempShield = MaxShield - TempShield;
                    Shield = MaxShield;
                    Console.WriteLine(" Player Regenerated (" + TempShield + ") Shield");
                }
                else
                {
                    Console.WriteLine(" Player Regenerated (" + RegenShieldAmount + ") Shield");
                }
            }
        }

        //Handles XP Gaining and Level ups
        static void AddXPLevelUp(int XPAdded)
        {
            int NumberOfTimesLeveled = 0;
            Console.WriteLine(" Player is about to Receive (" + XPAdded + ") XP");

            if (XPAdded < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - XPAdded Variable Does not equal a Positive Number");
                Console.ResetColor();
            }
            else
            {
                XP += XPAdded;
                Console.WriteLine(" Player gained (" + XPAdded + ") XP");

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
                    Console.WriteLine(" Player gained (" + NumberOfTimesLeveled + ") Levels");
                    Console.WriteLine(" Player gained (" + (NumberOfTimesLeveled * HealthIncreaseOnLvl) + ") Max Health");
                    Console.WriteLine(" Player gained (" + (NumberOfTimesLeveled * ShieldIncreaseOnLvl) + ") Max Shield");
                    Console.WriteLine(" Player's Health and Shield are set to Max");
                }
                    
            }
        }

        //Resets Varibles to Base State
        static void ResetGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Player Stats are about to Reset");

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

            Console.WriteLine(" Player Stats are Successfully Reset");
            Console.ResetColor();
        }

        //Adds Lives Based on inputed Value
        static void AddLives(int AddedLives)
        {
            int TempLives;
            Console.WriteLine(" Player is about to Receive (" + AddedLives + ") Lives");

            if (AddedLives < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - AddedLives Variable Does not equal a Positive Number");
                Console.ResetColor();
            }
            else
            {
                TempLives = Lives;
                Lives += AddedLives;
                if (Lives >= MaxLives)
                {
                    TempLives = MaxLives - TempLives;
                    Lives = MaxLives;
                    Console.WriteLine(" Player Gained (" + TempLives + ") Lives");
                }
                else
                {
                    Console.WriteLine(" Player Gained (" + AddedLives + ") Lives");
                }
            }
        }

        //Sets the Health Status to different Strings based on Health
        static void HealthStatusSet()
        {
            if (Health == MaxHealth)
            {
                HealthStatus = " You're in Perfect Health\n";
            }

            if (Health < MaxHealth && (int)Math.Round(MaxHealth * 0.75) <= Health)
            {
                HealthStatus = " You're feeling Fine\n";
            }

            if ((int)Math.Round(MaxHealth * 0.75) > Health && (int)Math.Round(MaxHealth * 0.5) <= Health)
            {
                HealthStatus = " You're Hurt\n";
            }

            if ((int)Math.Round(MaxHealth * 0.5) > Health && (int)Math.Round(MaxHealth * 0.25) <= Health)
            {
                HealthStatus = " You're Barely Standing\n";
            }

            if ((int)Math.Round(MaxHealth * 0.25) > Health && MaxHealth + 1 <= Health)
            {
                HealthStatus =  " You're Live Hangs in the Balance\n";
            }
        }
    }
}
