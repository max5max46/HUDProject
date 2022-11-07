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

        //Weapon Arrays and Ints
        static int CurrentWeapon;
        static int[] Ammo = new int[7];
        static int[] AmmoMax = new int[7];
        static string[] Weapons = new string[7];

        //OverWorld Movement
        static int x = 0;
        static int y = 0;
        static bool gameOver = false;

        static void Main(string[] args)
        {
            //ResetGame();

            bool YourStuck = false;
            int MakeItStop = 43;
            


            //while (gameOver == false)
            //{
                //PlayerDraw();
                //PlayerUpdate();
            //}


            


            char[,] map = new char[,] // dimensions defined by following data:
            {
                {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
                {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
                {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
                {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
                {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
                {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            };
            
            for(int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 30; y++)
                {
                    Console.SetCursorPosition(y + 1, x + 1);
                    Console.Write(map[x, y]);
                }
            }
            Console.ReadKey(true);


            while (gameOver == false)
            {
                PlayerDraw();
                PlayerUpdate();
            }




            //Testing
            while (YourStuck == true)

            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Hello Test Subject (" + MakeItStop + ")\n Lets have Some Fun Today (:\n Testing Mode Active\n Loading Normal Play...\n");
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
                Console.WriteLine("\n Cool now we Test Weapons\n BABY!!!!!!! \n");
                Console.ResetColor();
                Console.ReadKey(true);

                Fire();
                Console.ReadKey(true);
                Reload();
                Console.ReadKey(true);
                ShowHUD();
                Console.ReadKey(true);

                Console.WriteLine("\n Switch to Shot gun\n");
                CurrentWeapon = 1;

                ShowHUD();
                Console.ReadKey(true);
                Fire();
                Fire();
                Fire();
                Console.ReadKey(true);
                ShowHUD();
                Console.ReadKey(true);
                Reload();
                Console.ReadKey(true);
                ShowHUD();
                Console.ReadKey(true);

                Console.WriteLine("\n Switch to Minigun\n");
                CurrentWeapon = 3;

                ShowHUD();
                Console.ReadKey(true);
                Reload();
                ShowHUD();
                Console.ReadKey(true);
                Fire();
                Fire();
                Fire();
                Console.ReadKey(true);
                ShowHUD();
                Console.ReadKey(true);
                Reload();
                Console.ReadKey(true);
                ShowHUD();
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
            SetHealthStatus();
            Console.WriteLine("\n #-------------------------------------------------------------------------------#");
            Console.WriteLine("  Lives: " + Lives + "   Level: " + Level + "   XP: " + XP + "   XP to Next Level: " + (XPToNextLevelUp - XP));
            Console.WriteLine(" #-------------------------------------------------------------------------------#");
            Console.WriteLine("  Health: " + Health + "  Shield:  " + Shield + "  Ammo:  " + Ammo[CurrentWeapon] + "/" + AmmoMax[CurrentWeapon]);
            Console.WriteLine(" #-------------------------------------------------------------------------------#");
            Console.WriteLine(" " + HealthStatus + "       Current Weapon: " + Weapons[CurrentWeapon]);
            Console.WriteLine(" #-------------------------------------------------------------------------------#\n");
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
                return;
            }
            TempDamage = DamageAmount - Shield;

            Shield = Shield - DamageAmount;

            if (Shield <= 0)
            {
                Shield = 0;

                if (TempDamage > 0) Health = Health - TempDamage;
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
                return;
            }
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
                return;
            }
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
                return;
            }
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

        //Resets Varibles to Base State
        static void ResetGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Player Stats are about to Reset");

            //Variables

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

            CurrentWeapon = 0;

            //Array Setup
            Weapons[0] = "Sword";
            Weapons[1] = "Double Barrel Shotgun";
            Weapons[2] = "Rail Spike Launcher";
            Weapons[3] = "Minigun";
            Weapons[4] = "Dart Pistol";
            Weapons[5] = "Crossbow";

            AmmoMax[0] = 0;
            AmmoMax[1] = 2;
            AmmoMax[2] = 4;
            AmmoMax[3] = 200;
            AmmoMax[4] = 7;
            AmmoMax[5] = 15;

            Ammo[0] = AmmoMax[0];
            Ammo[1] = AmmoMax[1];
            Ammo[2] = AmmoMax[2];
            Ammo[3] = AmmoMax[3];
            Ammo[4] = AmmoMax[4];
            Ammo[5] = AmmoMax[5];

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
                return;
            }

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

        //Sets the Health Status to different Strings based on Health
        static void SetHealthStatus()
        {
            if (Health == MaxHealth)
            {
                HealthStatus = " You're in Perfect Health";
            }

            if (Health < MaxHealth && (int)Math.Round(MaxHealth * 0.75) <= Health)
            {
                HealthStatus = " You're feeling Fine";
            }

            if ((int)Math.Round(MaxHealth * 0.75) > Health && (int)Math.Round(MaxHealth * 0.5) <= Health)
            {
                HealthStatus = " You're Hurt";
            }

            if ((int)Math.Round(MaxHealth * 0.5) > Health && (int)Math.Round(MaxHealth * 0.25) <= Health)
            {
                HealthStatus = " You're Barely Standing";
            }

            if ((int)Math.Round(MaxHealth * 0.25) > Health && MaxHealth + 1 <= Health)
            {
                HealthStatus =  " You're Life Hangs in the Balance";
            }
        }

        static void Fire()
        {
            

            if (Weapons[CurrentWeapon] == "Sword")
            {
                Console.WriteLine(" Player Swings The (" + Weapons[CurrentWeapon] + ")");
                return;
            }

            Console.WriteLine(" Player is about to Shoot The (" + Weapons[CurrentWeapon] + ")");

            if (Ammo[CurrentWeapon] <= 0)
            {
                Ammo[CurrentWeapon] = 0;
                Console.WriteLine(" Player Could not fire the (" + Weapons[CurrentWeapon] + ") It has no Ammo");
            }
            else
            {
                Ammo[CurrentWeapon] -= 1;
                Console.WriteLine(" Player Fired The (" + Weapons[CurrentWeapon] + ") Losing 1 Ammo");
            }


        }
        static void Reload()
        {
            if (Weapons[CurrentWeapon] == Weapons[0])
            {
                Console.WriteLine(" Player Can't seem to Reload a (" + Weapons[CurrentWeapon] + ")");
                return;
            }

            Console.WriteLine(" Player is about to Reload The (" + Weapons[CurrentWeapon] + ")");

            if (Ammo[CurrentWeapon] == AmmoMax[CurrentWeapon])
            {
                Console.WriteLine(" Player Can't Reload a Full Clip");
            }
            else
            {
                Console.WriteLine(" Player Reloads The (" + Weapons[CurrentWeapon] + ") for (" + (AmmoMax[CurrentWeapon] - Ammo[CurrentWeapon]) + ")");
                Ammo[CurrentWeapon] = AmmoMax[CurrentWeapon];
            }

        }
        static void PlayerUpdate()
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar == 's' && y < Console.WindowHeight -2)
                y++;
            if (keyInfo.KeyChar == 'w' && y > 0)
                y--;
            if (keyInfo.KeyChar == 'a' && x > 0)
                x--;
            if (keyInfo.KeyChar == 'd' && x < Console.WindowWidth -2)
                x++;

            if(keyInfo.Key == ConsoleKey.Escape)
            {
                gameOver = true;
            }

            if (x > Console.WindowWidth)
                x = Console.WindowWidth -2;

            if (y > Console.WindowHeight)
                y = Console.WindowHeight -2;

        }

        static void PlayerDraw()
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }
    }
}
