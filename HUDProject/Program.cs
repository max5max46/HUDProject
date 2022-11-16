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
        static int health;
        static int shield;
        static int maxHealth;
        static int maxShield;
        static string healthStatus;

        //Lives System varibles
        static int lives;
        static int maxLives;

        //Level up System varibles
        static int level;
        static int XP;
        static int XPToNextLevelUp;
        static int healthIncreaseOnLvl;
        static int shieldIncreaseOnLvl;

        //Weapon Arrays and Ints
        static int currentWeapon;
        static int[] ammo = new int[5];
        static int[] ammoMax = new int[5];
        static string[] weapons = new string[5];

        //OverWorld Movement
        static int tempPlayerX;
        static int tempPlayerY;
        static int playerX = 7;
        static int playerY = 7;
        static bool gameOver = false;

        static char[,] unscaledMap = new char[,] // dimensions defined by following data:
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

        static char[,] map;

        static void Main(string[] args)
        {
            int scale = 1;

            Console.WriteLine("Press Any Button to Begin Test");

            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar != 'p')
            {
                Console.Clear();

                ScaleMap(scale);
                DisplayMap();
                Console.ReadKey(true);

                Console.Clear();

                scale = 2;

                ScaleMap(scale);
                DisplayMap();
                Console.ReadKey(true);

                Console.Clear();

                scale = 3;

                ScaleMap(scale);
                DisplayMap();
                Console.ReadKey(true);

            }

            Console.Clear();
            

            if (Console.LargestWindowWidth > 99 || Console.LargestWindowHeight > 35)
            {
                Console.WindowHeight = 35;
                Console.WindowWidth = 99;
            }

            Console.CursorVisible = false;

            scale = 2;

            ResetGame();

            ScaleMap(scale);
            DisplayMap();

            tempPlayerX = playerX;
            tempPlayerY = playerY;

            ShowHUD(true);
            SetHealthStatus();
            DisplayText(healthStatus);


            while (gameOver == false)
            {
                PlayerDraw();
                PlayerUpdate();
            }
            
        }

        //Displays the HUD
        static void ShowHUD(bool resetUI)
        {
            //SetHealthStatus();

            //Variable set up
            int firstWindowPositionX = 65;
            int firstWindowPositionY = 0;

            int secondWindowPositionX = 1;
            int secondWindowPositionY = 27;

            int thirdWindowPositionX = 65;
            int thirdWindowPositionY = 27;

            //Draws UI Boxes
            if (resetUI == true)
            {
                //Fisrt Window
                Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY);
                //             ....|....|....|....|....|....|....|
                Console.Write("@──────────────────────────────@"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 1);
                Console.Write("│ Level:                       │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 2);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 3);
                Console.Write("│ HP:           SP:            │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 4);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 5);
                Console.Write("│ XP:           XP to Lvl:     │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 6);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 7);
                Console.Write("│ Weapons:      Ammo:          │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 8);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 9);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 10);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 11);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 12);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 13);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 14);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 15);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 16);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 17);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 18);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 19);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 20);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 21);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 22);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 23);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 24);
                Console.Write("│                              │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 25);
                Console.Write("@──────────────────────────────@");

                //Second Window
                Console.SetCursorPosition(secondWindowPositionX, secondWindowPositionY);
                //             ....|....|....|....|....|....|....|....|....|....|....|....|....|
                Console.Write("@────────────────────────────────────────────────────────────@"); Console.SetCursorPosition(secondWindowPositionX, secondWindowPositionY + 1);
                Console.Write("│                                                            │"); Console.SetCursorPosition(secondWindowPositionX, secondWindowPositionY + 2);
                Console.Write("│                                                            │"); Console.SetCursorPosition(secondWindowPositionX, secondWindowPositionY + 3);
                Console.Write("│                                                            │"); Console.SetCursorPosition(secondWindowPositionX, secondWindowPositionY + 4);
                Console.Write("│                                                            │"); Console.SetCursorPosition(secondWindowPositionX, secondWindowPositionY + 5);
                Console.Write("│                                                            │"); Console.SetCursorPosition(secondWindowPositionX, secondWindowPositionY + 6);
                Console.Write("@────────────────────────────────────────────────────────────@");

                //Third Window
                Console.SetCursorPosition(thirdWindowPositionX, thirdWindowPositionY);
                //             ....|....|....|....|....|....|....|
                Console.Write("@──────────────────────────────@"); Console.SetCursorPosition(thirdWindowPositionX, thirdWindowPositionY + 1);
                Console.Write("│                              │"); Console.SetCursorPosition(thirdWindowPositionX, thirdWindowPositionY + 2);
                Console.Write("│                              │"); Console.SetCursorPosition(thirdWindowPositionX, thirdWindowPositionY + 3);
                Console.Write("│                              │"); Console.SetCursorPosition(thirdWindowPositionX, thirdWindowPositionY + 4);
                Console.Write("│                              │"); Console.SetCursorPosition(thirdWindowPositionX, thirdWindowPositionY + 5);
                Console.Write("│                              │"); Console.SetCursorPosition(thirdWindowPositionX, thirdWindowPositionY + 6);
                Console.Write("@──────────────────────────────@");
            }

            //First Window
            {
                //Display Level
                Console.SetCursorPosition(firstWindowPositionX + 9, firstWindowPositionY + 1);
                Console.Write(level);


                //Display health
                Console.SetCursorPosition(firstWindowPositionX + 6, firstWindowPositionY + 3);
                Console.Write(health + "/" + maxHealth);


                //Display shield
                Console.SetCursorPosition(firstWindowPositionX + 20, firstWindowPositionY + 3);
                Console.Write(shield + "/" + maxShield);


                //Display XP
                Console.SetCursorPosition(firstWindowPositionX + 6, firstWindowPositionY + 5);
                Console.Write(XP);


                //Display XP to level
                Console.SetCursorPosition(firstWindowPositionX + 27, firstWindowPositionY + 5);
                Console.Write(XPToNextLevelUp - XP);


                //Display Weapon 1
                Console.SetCursorPosition(firstWindowPositionX + 2, firstWindowPositionY + 8);
                Console.Write("-");

                if (currentWeapon == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.Write(weapons[0]);
                Console.ResetColor();


                //Display Ammo 1
                Console.SetCursorPosition(firstWindowPositionX + 16, firstWindowPositionY + 8);

                if (ammoMax[0] != 0)
                    Console.Write(ammo[0] + "/" + ammoMax[0]);
                else
                    Console.Write("-/-");


                //Display Weapon 2
                Console.SetCursorPosition(firstWindowPositionX + 2, firstWindowPositionY + 9);
                Console.Write("-");

                if (currentWeapon == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.Write(weapons[1]);
                Console.ResetColor();


                //Display Ammo 2
                Console.SetCursorPosition(firstWindowPositionX + 16, firstWindowPositionY + 9);
                if (ammoMax[1] != 0)
                    Console.Write(ammo[1] + "/" + ammoMax[1]);
                else
                    Console.Write("-/-");

            }





            //Console.Write("@────────────────────────────────────────────────────────────@");
            //Console.Write("│ Lives: " + lives + "   Level: " + level + "   XP: " + XP + "   XP to Next Level: " + (XPToNextLevelUp - XP));
            //Console.Write("│#-------------------------------------------------------------------------------#");
            //Console.Write("│ Health: " + health + "  Shield:  " + shield + "  Ammo:  " + ammo[currentWeapon] + "/" + ammoMax[currentWeapon]);
            //Console.Write("│#-------------------------------------------------------------------------------#");
            //Console.Write("│" + healthStatus + "       Current Weapon: " + weapons[currentWeapon]);
            //Console.Write("@────────────────────────────────────────────────────────────@");
        }

        //Takes Shield, Health, and Lives Away Based on Inputed Value Also handles Game Over
        static void TakeDamage(int damageAmount)
        {
            int tempDamage;
            Console.WriteLine(" Player is about to take (" + damageAmount + ") Damage");
            if (damageAmount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - DamageAmount Variable Does not equal a Positive Number");
                Console.ResetColor();
                return;
            }
            tempDamage = damageAmount - shield;

            shield = shield - damageAmount;

            if (shield <= 0)
            {
                shield = 0;

                if (tempDamage > 0) health = health - tempDamage;
            }

            Console.WriteLine(" Player Took (" + damageAmount + ") Damage");

            if (health <= 0)
            {
                health = maxHealth;
                lives = lives - 1;

                if (lives != 0)
                {
                    health = maxHealth;
                    shield = maxShield;
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
        static void Heal(int healAmount)
        {
            int tempHealth;
            Console.WriteLine(" Player is about to Heal (" + healAmount + ") Health");

            if (healAmount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - HealAmount Variable Does not equal a Positive Number");
                Console.ResetColor();
                return;
            }
            tempHealth = health;
            health = health + healAmount;
            if (health >= maxHealth)
            {
                tempHealth = maxHealth - tempHealth;
                health = maxHealth;
                Console.WriteLine(" Player Healed (" + tempHealth + ") Health");
            }
            else
            {
                Console.WriteLine(" Player Healed (" + healAmount + ") Health");
            }

        }

        // Regenerates your Shield Based on Inputed Value
        static void RegenerateShield(int regenShieldAmount)
        {
            int tempShield;
            Console.WriteLine(" Player is about to Regenerate (" + regenShieldAmount + ") Shield");

            if (regenShieldAmount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - RegenShieldAmount Variable Does not equal a Positive Number");
                Console.ResetColor();
                return;
            }
            tempShield = shield;
            shield = shield + regenShieldAmount;
            if (shield >= maxShield)
            {
                tempShield = maxShield - tempShield;
                shield = maxShield;
                Console.WriteLine(" Player Regenerated (" + tempShield + ") Shield");
            }
            else
            {
                Console.WriteLine(" Player Regenerated (" + regenShieldAmount + ") Shield");
            }
        }

        //Handles XP Gaining and Level ups
        static void AddXPLevelUp(int XPAdded)
        {
            int numberOfTimesLeveled = 0;
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
                level += 1;
                maxHealth += healthIncreaseOnLvl;
                health = maxHealth;
                maxShield += shieldIncreaseOnLvl;
                shield = maxShield;
                XP -= XPToNextLevelUp;
                numberOfTimesLeveled += 1;
            }

            if (numberOfTimesLeveled > 0)
            {
                Console.WriteLine(" Player gained (" + numberOfTimesLeveled + ") Levels");
                Console.WriteLine(" Player gained (" + (numberOfTimesLeveled * healthIncreaseOnLvl) + ") Max Health");
                Console.WriteLine(" Player gained (" + (numberOfTimesLeveled * shieldIncreaseOnLvl) + ") Max Shield");
                Console.WriteLine(" Player's Health and Shield are set to Max");
            }
        }

        //Resets Varibles to Base State
        static void ResetGame()
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("\n Player Stats are about to Reset");

            //Variables

            maxHealth = 10;
            maxShield = 5;
            health = maxHealth;
            shield = maxShield;

            lives = 3;
            maxLives = 99;

            level = 1;
            XP = 0;
            XPToNextLevelUp = 100;
            healthIncreaseOnLvl = 2;
            shieldIncreaseOnLvl = 1;

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
            

            //Console.WriteLine(" Player Stats are Successfully Reset");
            //Console.ResetColor();
        }

        //Adds Lives Based on inputed Value
        static void AddLives(int addedLives)
        {
            int tempLives;
            Console.WriteLine(" Player is about to Receive (" + addedLives + ") Lives");

            if (addedLives < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Error - AddedLives Variable Does not equal a Positive Number");
                Console.ResetColor();
                return;
            }

            tempLives = lives;
            lives += addedLives;
            if (lives >= maxLives)
            {
                tempLives = maxLives - tempLives;
                lives = maxLives;
                Console.WriteLine(" Player Gained (" + tempLives + ") Lives");
            }
            else
            {
                Console.WriteLine(" Player Gained (" + addedLives + ") Lives");
            }

        }

        //Sets the Health Status to different Strings based on Health
        static void SetHealthStatus()
        {
            if (health == maxHealth)
            {
                healthStatus = "You're in Perfect Health";
            }

            if (health < maxHealth && (int)Math.Round(maxHealth * 0.75) <= health)
            {
                healthStatus = "You're feeling Fine";
            }

            if ((int)Math.Round(maxHealth * 0.75) > health && (int)Math.Round(maxHealth * 0.5) <= health)
            {
                healthStatus = "You're Hurt";
            }

            if ((int)Math.Round(maxHealth * 0.5) > health && (int)Math.Round(maxHealth * 0.25) <= health)
            {
                healthStatus = "You're Barely Standing";
            }

            if ((int)Math.Round(maxHealth * 0.25) > health && maxHealth + 1 <= health)
            {
                healthStatus = "You're Life Hangs in the Balance";
            }
        }

        //Fire Current Weapon
        static void Fire()
        {
            if (weapons[currentWeapon] == "Sword")
            {
                Console.WriteLine(" Player Swings The (" + weapons[currentWeapon] + ")");
                return;
            }

            Console.WriteLine(" Player is about to Shoot The (" + weapons[currentWeapon] + ")");

            if (ammo[currentWeapon] <= 0)
            {
                ammo[currentWeapon] = 0;
                Console.WriteLine(" Player Could not fire the (" + weapons[currentWeapon] + ") It has no Ammo");
            }
            else
            {
                ammo[currentWeapon] -= 1;
                Console.WriteLine(" Player Fired The (" + weapons[currentWeapon] + ") Losing 1 Ammo");
            }


        }

        //Reload Current Weapon
        static void Reload()
        {
            if (weapons[currentWeapon] == weapons[0])
            {
                Console.WriteLine(" Player Can't seem to Reload a (" + weapons[currentWeapon] + ")");
                return;
            }

            Console.WriteLine(" Player is about to Reload The (" + weapons[currentWeapon] + ")");

            if (ammo[currentWeapon] == ammoMax[currentWeapon])
            {
                Console.WriteLine(" Player Can't Reload a Full Clip");
            }
            else
            {
                Console.WriteLine(" Player Reloads The (" + weapons[currentWeapon] + ") for (" + (ammoMax[currentWeapon] - ammo[currentWeapon]) + ")");
                ammo[currentWeapon] = ammoMax[currentWeapon];
            }

        }

        //Player Update Position Based on inputs
        static void PlayerUpdate()
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            tempPlayerX = playerX;
            tempPlayerY = playerY;

            if (keyInfo.KeyChar == 's' && playerY < map.GetLength(0))
                playerY++;
            if (keyInfo.KeyChar == 'w' && playerY > 1)
                playerY--;
            if (keyInfo.KeyChar == 'a' && playerX > 2)
                playerX--;
            if (keyInfo.KeyChar == 'd' && playerX < map.GetLength(1) + 1)
                playerX++;

            if (map[playerY - 1,playerX - 2] == '^' || map[playerY - 1, playerX - 2] == '~')
            {
                playerX = tempPlayerX;
                playerY = tempPlayerY;
            }

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                gameOver = true;
            }

            if (keyInfo.KeyChar == 'e' && currentWeapon != 1)
            {
                currentWeapon++;
                ShowHUD(false);
            }
                
            if (keyInfo.KeyChar == 'q' && currentWeapon != 0)
            {
                currentWeapon--;
                ShowHUD(false);
            }

        }

        static void PlayerDraw()
        {
            Console.SetCursorPosition(tempPlayerX, tempPlayerY);
            SetBackgroundColor(tempPlayerY - 1, tempPlayerX - 2);
            Console.Write(map[tempPlayerY - 1, tempPlayerX - 2]);
            Console.ResetColor();

            Console.SetCursorPosition(playerX, playerY);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("A");
            Console.ResetColor();
        }

        static void ScaleMap(int scale)
        {
            //Sets Dimensions for (map)
            map = new char[unscaledMap.GetLength(0) * scale, unscaledMap.GetLength(1) * scale];

            //Adds Scaled Characters to New Matrix (map)
            for (int y = 0; y < unscaledMap.GetLength(0); y++)
            {
                for (int x = 0; x < unscaledMap.GetLength(1); x++)
                {
                    for (int h = 0; h < scale; h++)
                    {
                        for (int b = 0; b < scale; b++)
                        {
                            map[(y * scale) + h, (x * scale) + b] = unscaledMap[y, x];
                        }
                    }
                }
            }
        }


        static void DisplayMap()
        {
            //Displays Map
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.SetCursorPosition(x + 2, y + 1);
                    SetBackgroundColor(y, x);
                    Console.Write(map[y, x]);
                    Console.ResetColor();
                }
            }

            //Add Map Border
            for (int borderY = 0; borderY < map.GetLength(0) + 2; borderY++)
            {
                for (int borderX = 1; borderX < map.GetLength(1) + 3; borderX++)
                {
                    if (borderY == 0 || borderX == 1 || borderY == map.GetLength(0) + 1 || borderX == map.GetLength(1) + 2)
                    {
                        if ((borderY == 0 && borderX == 1) || (borderY == map.GetLength(0) + 1 && borderX == 1) || (borderY == 0 && borderX == map.GetLength(1) + 2) || (borderY == map.GetLength(0) + 1 && borderX == map.GetLength(1) + 2))
                        {
                            Console.SetCursorPosition(borderX, borderY);
                            Console.Write("@");
                        }
                        else
                        {
                            if (borderY == 0 || borderY == map.GetLength(0) + 1)
                            {
                                Console.SetCursorPosition(borderX, borderY);
                                Console.Write("─");
                            }
                            else
                            {
                                Console.SetCursorPosition(borderX, borderY);
                                Console.Write("│");
                            }
                        }
                    }
                }
            }



        }

        static void SetBackgroundColor(int y, int x)
        {
            
            switch (map[y, x])
            {
                case '`':
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;

                case '~':
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;

                case '^':
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;

                case '*':
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;

            }
        }

        static void DisplayText(string textToDisplay)
        {
            
            for (int j = 28; j <= 32; j++)
            {
                for(int i = 2; i <= 61; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }

            int lineOne = textToDisplay.Length;
            int lineTwo = textToDisplay.Length;
            int lineThree = textToDisplay.Length;
            int lineFour = textToDisplay.Length;

            if (textToDisplay.Length > 57) 
            {
                for (int i = 57; i >= 0; i--)
                {
                    if (textToDisplay[i] == ' ')
                    {
                        lineOne = i;
                        i = 1;
                    }
                }
            }

            if (textToDisplay.Length > 115)
            {
                for (int i = 57 + lineOne; i >= 0; i--)
                {
                    if (textToDisplay[i] == ' ')
                    {
                        lineTwo = i;
                        i = 1;
                    }
                }
            }

            if (textToDisplay.Length > 173)
            {
                for (int i = 57 + lineTwo; i >= 0; i--)
                {
                    if (textToDisplay[i] == ' ')
                    {
                        lineThree = i;
                        i = 1;
                    }
                }
            }

            if (textToDisplay.Length > 231)
            {
                for (int i = 57 + lineThree; i >= 0; i--)
                {
                    if (textToDisplay[i] == ' ')
                    {
                        lineFour = i;
                        i = 1;
                    }
                }
            }

            Console.SetCursorPosition(3, 28);

            Console.Write(textToDisplay.Substring(0,lineOne)); 
            
            Console.SetCursorPosition(3, 29);

            if (textToDisplay.Length > 57)
                Console.Write(textToDisplay.Substring(lineOne + 1, lineTwo - lineOne - 1));

            Console.SetCursorPosition(3, 30);

            if (textToDisplay.Length > 115)
                Console.Write(textToDisplay.Substring(lineTwo + 1, lineThree - lineTwo - 1));

            Console.SetCursorPosition(3, 31);

            if (textToDisplay.Length > 173)
                Console.Write(textToDisplay.Substring(lineThree + 1, lineFour - lineThree - 1));

            Console.SetCursorPosition(3, 32);

            if (textToDisplay.Length > 231)
                Console.Write(textToDisplay.Substring(lineFour + 1, textToDisplay.Length - lineFour - 1));
        }

    }
}
