﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    internal class Program
    {
        static Random RNG = new Random();

        //Heath/Shield System varibles
        static int health;
        static int shield;
        static int maxHealth;
        static int maxShield;
        static string healthStatus;

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
        static int playerX;
        static int playerY;
        static bool genaratePlayerSpawn = true;
        static bool gameOver = false;
        static bool overworldLoop;

        //Battle Menu
        static int selectedBattleOption = 0;
        static string[] battleOptions = new string[6];
        static int battleState;


        static int[,] currentBattleEnemys = new int[3, 10];

        //Enemies

        static int[,] enemyIndex = new int[10,10];
        static string[] enemyNames = new string[10];

        static char[,] map = new char[,] // dimensions defined by following data:
            {
                {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','~','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
                {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            };




        //https://www.meridianoutpost.com/resources/articles/ASCII-Extended-Code-reference-chart.php


        static void Main(string[] args)
        {
            int slimeX;
            int slimeY;

            if (Console.LargestWindowWidth > 99 || Console.LargestWindowHeight > 35)
            {
                Console.WindowHeight = 35;
                Console.WindowWidth = 99;
            }

            Console.CursorVisible = false;

            ResetGame();
            ShowHUD(true);

            Console.SetCursorPosition(18, 6);
            Console.Write("┌                           ┐"); Console.SetCursorPosition(18, 7);
            Console.Write("│ HUDProject (place Holder) │"); Console.SetCursorPosition(18, 8);
            Console.Write("│        Dylan Adams        │"); Console.SetCursorPosition(18, 9);
            Console.Write("└                           ┘");

            Console.SetCursorPosition(3, 19);
            Console.Write("Controls:"); Console.SetCursorPosition(3, 21);
            Console.Write("Move - WASD or Arrow Keys"); Console.SetCursorPosition(3, 22);
            Console.Write("Switch Weapon - Q and E"); Console.SetCursorPosition(3, 23);
            Console.Write("Genarate New World - R"); Console.SetCursorPosition(3, 24);
            Console.Write("Quit Game - Escape");

            Console.SetCursorPosition(20, 14);
            Console.Write("Press any Button to Begin");
            Console.ReadKey(true);

            //ShowHUD(true);

            //BattleMain();
            /*
            ShowHUD(true);
            

            while (gameOver == false)
            {
                BattlePlayerInput();
                DisplayBattle();
                if (BattleState == 2)
                {

                }
            }
            */

            while (gameOver == false)
            {
                ResetGame();
                DisplayText("Generating map...");
                RandomizeMap();

                while (genaratePlayerSpawn == true)
                {
                    playerY = RNG.Next(0, 24) + 1;
                    playerX = RNG.Next(0, 60) + 2;

                    if (map[playerY - 1, playerX - 2] == '*' || map[playerY - 1, playerX - 2] == '`')
                    {
                        genaratePlayerSpawn = false;
                    }
                }

                DisplayMap();

                tempPlayerX = playerX;
                tempPlayerY = playerY;

                ShowHUD(true);
                SetHealthStatus();
                DisplayText(healthStatus);


                while (overworldLoop == true)
                {
                    PlayerDraw();
                    OverWorldPlayerInput();
                }
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
                //Map Window
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
                Console.WriteLine(" Player Lives have Reached (0)");
                Console.WriteLine(" Game Over Has Occurred Reseting Game");
                ResetGame();
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

            maxHealth = 40;
            maxShield = 5;
            health = maxHealth;
            shield = maxShield;

            level = 1;
            XP = 0;
            XPToNextLevelUp = 100;
            healthIncreaseOnLvl = 2;
            shieldIncreaseOnLvl = 1;

            currentWeapon = 0;

            overworldLoop = true;
            genaratePlayerSpawn = true;

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

            battleOptions[0] = "Attack";
            battleOptions[1] = "N/a";
            battleOptions[2] = "Run";
            battleOptions[3] = "Enemy 1";
            battleOptions[4] = "Enemy 2";
            battleOptions[5] = "Enemy 3";

            //Enemies defined

            /*Index values for speific Enemies goes as follows

            Green Slimes

            0 - Health
            1 - Attack



            */
            //No Enemy Index 0
            enemyNames[0] = "none";
            enemyIndex[0, 0] = 0;
            enemyIndex[0, 1] = 0;

            //Green Slime Index 1
            enemyNames[1] = "Green Slime";
            enemyIndex[1, 0] = 10;
            enemyIndex[1, 1] = 3;

            //Skeleton Index 2
            enemyNames[2] = "Skeleton";
            enemyIndex[2, 0] = 7;
            enemyIndex[2, 1] = 5;

            //Console.WriteLine(" Player Stats are Successfully Reset");
            //Console.ResetColor();

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

        //Game Based on inputs
        static void OverWorldPlayerInput()
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            tempPlayerX = playerX;
            tempPlayerY = playerY;

            if ((keyInfo.KeyChar == 's' && playerY < map.GetLength(0)) || (keyInfo.Key == ConsoleKey.DownArrow && playerY < map.GetLength(0)))
                playerY++;
            if ((keyInfo.KeyChar == 'w' && playerY > 1) || (keyInfo.Key == ConsoleKey.UpArrow && playerY > 1))
                playerY--;
            if ((keyInfo.KeyChar == 'a' && playerX > 2) || (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 2))
                playerX--;
            if ((keyInfo.KeyChar == 'd' && playerX < map.GetLength(1) + 1) || (keyInfo.Key == ConsoleKey.RightArrow && playerX < map.GetLength(1) + 1))
                playerX++;

            if (map[playerY - 1,playerX - 2] == '^' || map[playerY - 1, playerX - 2] == '~')
            {
                playerX = tempPlayerX;
                playerY = tempPlayerY;
            }

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                gameOver = true;
                overworldLoop = false;
            }

            if (keyInfo.KeyChar == 'r')
            {
                overworldLoop = false;
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

        //Draws the player on the overworld
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

        //Genarate a New Map
        static void RandomizeMap()
        {
            int numberOfSeedsTree = RNG.Next(5, 10);
            int numberOfGenTree = RNG.Next(6, 15);

            int numberOfSeedsWater = RNG.Next(0, 3);
            int numberOfGenWater = RNG.Next(9, 16);

            int numberOfSeedsMount = RNG.Next(0, 5);
            int numberOfGenMount = RNG.Next(6, 11);

            int chanceToGrowMin = 45;
            int chanceToGrowMax = 70;

            int K;
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    map[j, i] = '`';
                }
            }

            if (numberOfSeedsTree != 0)
            {
                for (int i = 0; i < numberOfSeedsTree; i++)
                {
                    map[RNG.Next(0, 24), RNG.Next(0, 60)] = '*';
                }

                for (int t = 0; t < numberOfGenTree; t++)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 24; j++)
                        {
                            if (map[j, i] == '*')
                            {


                                if ((j - 1) != -1)
                                {
                                    if (map[j - 1, i] == '`')
                                    {
                                        if (RNG.Next(1, 101) < RNG.Next(chanceToGrowMin, chanceToGrowMax))
                                        {
                                            map[j - 1, i] = 'o';
                                        }
                                    }
                                }

                                if ((j + 1) != 24)
                                {
                                    if (map[j + 1, i] == '`')
                                    {
                                        if (RNG.Next(1, 101) < RNG.Next(chanceToGrowMin, chanceToGrowMax))
                                        {
                                            map[j + 1, i] = 'o';
                                        }
                                    }
                                }

                                if ((i - 1) != -1)
                                {
                                    if (map[j, i - 1] == '`')
                                    {
                                        if (RNG.Next(1, 101) < RNG.Next(chanceToGrowMin, chanceToGrowMax))
                                        {
                                            map[j, i - 1] = 'o';
                                        }
                                    }
                                }

                                if ((i + 1) != 60)
                                {
                                    if (map[j, i + 1] == '`')
                                    {
                                        if (RNG.Next(1, 101) < RNG.Next(chanceToGrowMin, chanceToGrowMax))
                                        {
                                            map[j, i + 1] = 'o';
                                        }
                                    }
                                }


                            }
                        }
                    }
                    DisplayMap();
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 24; j++)
                        {
                            if (map[j, i] == 'o')
                            {
                                map[j, i] = '*';
                            }
                        }
                    }
                }
            }

            


            if (numberOfSeedsWater != 0)
            {
                for (int i = 0; i < numberOfSeedsWater; i++)
                {
                    map[RNG.Next(0, 24), RNG.Next(0, 60)] = '~';
                }


                for (int t = 0; t < numberOfGenWater; t++)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 24; j++)
                        {
                            if (map[j, i] == '~')
                            {


                                if ((j - 1) != -1)
                                {
                                    if (map[j - 1, i] == '`' || map[j - 1, i] == '*')
                                    {
                                        if (RNG.Next(1, 101) < 50)
                                        {
                                            map[j - 1, i] = 'o';
                                        }
                                    }
                                }

                                if ((j + 1) != 24)
                                {
                                    if (map[j + 1, i] == '`' || map[j + 1, i] == '*')
                                    {
                                        if (RNG.Next(1, 101) < 50)
                                        {
                                            map[j + 1, i] = 'o';
                                        }
                                    }
                                }

                                if ((i - 1) != -1)
                                {
                                    if (map[j, i - 1] == '`' || map[j, i - 1] == '*')
                                    {
                                        if (RNG.Next(1, 101) < 50)
                                        {
                                            map[j, i - 1] = 'o';
                                        }
                                    }
                                }

                                if ((i + 1) != 60)
                                {
                                    if (map[j, i + 1] == '`' || map[j, i + 1] == '*')
                                    {
                                        if (RNG.Next(1, 101) < 50)
                                        {
                                            map[j, i + 1] = 'o';
                                        }
                                    }
                                }


                            }
                        }
                    }
                    DisplayMap();
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 24; j++)
                        {
                            if (map[j, i] == 'o')
                            {
                                map[j, i] = '~';
                            }
                        }
                    }
                }
            }


            if (numberOfSeedsMount != 0)
            {

                for (int i = 0; i < numberOfSeedsMount; i++)
                {
                    map[RNG.Next(0, 24), RNG.Next(0, 60)] = '^';
                }


                for (int t = 0; t < numberOfGenMount; t++)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 24; j++)
                        {
                            if (map[j, i] == '^')
                            {


                                if ((j - 1) != -1)
                                {
                                    if (map[j - 1, i] == '`' || map[j - 1, i] == '*' || map[j - 1, i] == '~')
                                    {
                                        if (RNG.Next(1, 101) < 50)
                                        {
                                            map[j - 1, i] = 'o';
                                        }
                                    }
                                }

                                if ((j + 1) != 24)
                                {
                                    if (map[j + 1, i] == '`' || map[j + 1, i] == '*' || map[j + 1, i] == '~')
                                    {
                                        if (RNG.Next(1, 101) < 50)
                                        {
                                            map[j + 1, i] = 'o';
                                        }
                                    }
                                }

                                if ((i - 1) != -1)
                                {
                                    if (map[j, i - 1] == '`' || map[j, i - 1] == '*' || map[j, i - 1] == '~')
                                    {
                                        if (RNG.Next(1, 101) < 50)
                                        {
                                            map[j, i - 1] = 'o';
                                        }
                                    }
                                }

                                if ((i + 1) != 60)
                                {
                                    if (map[j, i + 1] == '`' || map[j, i + 1] == '*' || map[j, i + 1] == '~')
                                    {
                                        if (RNG.Next(1, 101) < 50)
                                        {
                                            map[j, i + 1] = 'o';
                                        }
                                    }
                                }


                            }
                        }
                    }
                    DisplayMap();
                    for (int i = 0; i < 60; i++)
                    {
                        for (int j = 0; j < 24; j++)
                        {
                            if (map[j, i] == 'o')
                            {
                                map[j, i] = '^';
                            }
                        }
                    }
                }
            }
            

            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (map[j, i] == '~')
                    {


                        if ((j - 1) != -1)
                        {
                            if (map[j - 1, i] == '`' || map[j - 1, i] == '*')
                            {
                                map[j - 1, i] = 'o';
                            }
                        }

                        if ((j + 1) != 24)
                        {
                            if (map[j + 1, i] == '`' || map[j + 1, i] == '*')
                            {
                                map[j + 1, i] = 'o';
                            }
                        }

                        if ((i - 1) != -1)
                        {
                            if (map[j, i - 1] == '`' || map[j, i - 1] == '*')
                            {
                                map[j, i - 1] = 'o';
                            }
                        }

                        if ((i + 1) != 60)
                        {
                            if (map[j, i + 1] == '`' || map[j, i + 1] == '*')
                            {
                                map[j, i + 1] = 'o';
                            }
                        }


                    }
                }
            }
            DisplayMap();
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (map[j, i] == 'o')
                    {
                        map[j, i] = '+';
                    }
                }
            }
        }

        //Prints map in main UI Box
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
        }

        //selects Color for tiles on overworld
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

                case '+':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;

            }
        }

        //Takes a String and displays it in the UI text box
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

        //Game Based on inputs
        static void BattlePlayerInput()
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            if (battleState == 0)
            {
                if (keyInfo.KeyChar == 'a' && selectedBattleOption != 0)
                    selectedBattleOption--;
                if (keyInfo.KeyChar == 'd' && selectedBattleOption != 2)
                    selectedBattleOption++;

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedBattleOption == 0)
                    {
                        selectedBattleOption = 4;
                        battleState = 1;
                    }



                    return;
                }
            }

            if (battleState == 1)
            {
                
                if (keyInfo.KeyChar == 'a' && selectedBattleOption != 3)
                    selectedBattleOption--;
                if (keyInfo.KeyChar == 'd' && selectedBattleOption != 5)
                    selectedBattleOption++;

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    battleState = 2;
                    return;
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    selectedBattleOption = 0;
                    battleState = 0;
                    return;
                }
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

        static void DisplayBattle(bool willDrawEnemies)
        {
            
            for (int j = 28; j <= 32; j++)
            {
                for (int i = 2; i <= 61; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }

            //Bottom Window Draw

            switch (battleState)
            {

                case 0:
                    //Attack
                    Console.SetCursorPosition(3, 30);
                    if (selectedBattleOption == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[0]);
                    Console.ResetColor();

                    //N/a
                    Console.SetCursorPosition(15, 30);
                    if (selectedBattleOption == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[1]);
                    Console.ResetColor();

                    //Run
                    Console.SetCursorPosition(27, 30);
                    if (selectedBattleOption == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[2]);
                    Console.ResetColor();
                    break;

                case 1:
                    //Enemy 2
                    Console.SetCursorPosition(3, 30);
                    if (selectedBattleOption == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[3]);
                    Console.ResetColor();

                    //Enemy 1
                    Console.SetCursorPosition(15, 30);
                    if (selectedBattleOption == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[4]);
                    Console.ResetColor();

                    //Enemy 3
                    Console.SetCursorPosition(27, 30);
                    if (selectedBattleOption == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[5]);
                    Console.ResetColor();
                    break;

                case 2:
                    DisplayText("The Player Attacks the " + "");
                    break;
            }

            //Top Window Draw
            if (willDrawEnemies == true)
            {
                if (currentBattleEnemys[0, 0] >= 1)
                {
                    Console.SetCursorPosition(3, 10);
                    Console.Write(enemyNames[currentBattleEnemys[0, 0]]);
                }

                if (currentBattleEnemys[1, 0] >= 1)
                {
                    Console.SetCursorPosition(15, 10);
                    Console.Write(enemyNames[currentBattleEnemys[1, 0]]);
                }
                if (currentBattleEnemys[2, 0] >= 1)
                {
                    Console.SetCursorPosition(33, 10);
                    Console.Write(enemyNames[currentBattleEnemys[2, 0]]);
                }
            }


            /*
            //18*18
            Console.Write("@────────────────────────────────────────────────────────────@"); 
            Console.Write("│                                                            │"); 
            Console.Write("│                                                            │"); 
            Console.Write("│   	▌▐ █  ▄ ▀                                               │"); 
            Console.Write("│                                                            │"); 
            Console.Write("│        ▄▄▄▄▄▄▄                                             │"); 
            Console.Write("│     ▄█▀▀     ▀▀█▄                                          │"); 
            Console.Write("│    █▀           ▀█                                         │"); 
            Console.Write("│    █   ▄▄   ▄▄   █                                         │"); 
            Console.Write("│    █▄ ▄       ▄ ▄█                                         │");
            Console.Write("│     ▀█▄▄▄▄▄▄▄▄▄█▀                                          │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │"); 
            Console.Write("│                                                            │"); 
            Console.Write("│                                                            │"); 
            Console.Write("│                                                            │"); 
            Console.Write("│                                                            │");
            Console.Write("│                                                            │"); 
            Console.Write("│                                                            │"); 
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("@────────────────────────────────────────────────────────────@");

            Console.Write("@────────────────────────────────────────────────────────────@");
            Console.Write("│ A Battle Rages On!                                         │");
            Console.Write("│                                                            │");
            Console.Write("│ Attack     Reload      Run                                 │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("@────────────────────────────────────────────────────────────@");


            Console.Write("@────────────────────────────────────────────────────────────@");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("│                                                            │");
            Console.Write("@────────────────────────────────────────────────────────────@");

            //Green Slime
            {
                int slimeX = 10;
                int slimeY = 5;

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.SetCursorPosition(slimeX + 4, slimeY); Console.Write("▄▄▄▄▄▄▄");
                Console.SetCursorPosition(slimeX + 1, slimeY + 1); Console.Write("▄           ▄");
                Console.SetCursorPosition(slimeX + 1, slimeY + 5); Console.Write("▀           ▀");

                Console.BackgroundColor = ConsoleColor.Green;

                Console.SetCursorPosition(slimeX + 2, slimeY + 1); Console.Write("█▀▀     ▀▀█");
                Console.SetCursorPosition(slimeX, slimeY + 2); Console.Write("█▀   ▄   ▄   ▀█");
                Console.SetCursorPosition(slimeX, slimeY + 3); Console.Write("█    █   █    █");
                Console.SetCursorPosition(slimeX, slimeY + 4); Console.Write("█▄           ▄█");
                Console.SetCursorPosition(slimeX + 2, slimeY + 5); Console.Write("█▄▄▄▄▄▄▄▄▄█");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(slimeX + 2, slimeY + 4); Console.Write("▀▀       ▀▀");

                Console.ResetColor();


                slimeX = 10;
                slimeY = 5;

                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.SetCursorPosition(slimeX + 4, slimeY); Console.Write("▄▄▄▄▄▄▄");
                Console.SetCursorPosition(slimeX + 1, slimeY + 1); Console.Write("▄           ▄");
                Console.SetCursorPosition(slimeX + 1, slimeY + 5); Console.Write("▀           ▀");

                Console.BackgroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(slimeX + 2, slimeY + 1); Console.Write("█▀▀     ▀▀█");
                Console.SetCursorPosition(slimeX, slimeY + 2); Console.Write("█▀           ▀█");
                Console.SetCursorPosition(slimeX, slimeY + 3); Console.Write("█  ▀▀▀   ▀▀▀  █");
                Console.SetCursorPosition(slimeX, slimeY + 4); Console.Write("█▄           ▄█");
                Console.SetCursorPosition(slimeX + 2, slimeY + 5); Console.Write("█▄▄▄▄▄▄▄▄▄█");

                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.SetCursorPosition(slimeX + 2, slimeY + 4); Console.Write("▀▀       ▀▀");

                Console.ResetColor();
            
            }
            */
        }

        static void GenarateBattleEnemies()
        {
            /*
            battleEnemies Defines if there is a Enemy in any of the three battle positions and what enemy they are



            */

            int EnemyIndexValue;

            currentBattleEnemys[0,0] = 1;
            currentBattleEnemys[1,0] = RNG.Next(0,2);
            currentBattleEnemys[2,0] = RNG.Next(0,2);

            if (currentBattleEnemys[0,0] == 1)
            {
                EnemyIndexValue = RNG.Next(1, 3);
                currentBattleEnemys[0, 0] = EnemyIndexValue;
                currentBattleEnemys[0, 1] = enemyIndex[EnemyIndexValue, 0];
                currentBattleEnemys[0, 2] = enemyIndex[EnemyIndexValue, 1];
            }

            if (currentBattleEnemys[1,0] == 1)
            {
                EnemyIndexValue = RNG.Next(1, 3);
                currentBattleEnemys[1, 0] = EnemyIndexValue;
                currentBattleEnemys[1, 1] = enemyIndex[EnemyIndexValue, 0];
                currentBattleEnemys[1, 2] = enemyIndex[EnemyIndexValue, 1];
            }

            if (currentBattleEnemys[2,0] == 1)
            {
                EnemyIndexValue = RNG.Next(1, 3);
                currentBattleEnemys[2, 0] = EnemyIndexValue;
                currentBattleEnemys[2, 1] = enemyIndex[EnemyIndexValue, 0];
                currentBattleEnemys[2, 2] = enemyIndex[EnemyIndexValue, 1];
            }
        }

        static void BattleMain()
        {
            battleState = 69;
            GenarateBattleEnemies();
            DisplayBattle(true);
            DisplayText("Enemy in Positsion 1: " + enemyNames[currentBattleEnemys[0, 0]].ToString() + "   Enemy in Positsion 2: " + enemyNames[currentBattleEnemys[1, 0]] + "   Enemy in Positsion 3: " + enemyNames[currentBattleEnemys[2, 0]]);

            Console.ReadKey(true);

            battleState = 0;

            while (gameOver == false)
            {
                DisplayBattle(false);
                BattlePlayerInput();

                //Attacking Phase
                if (battleState == 2)
                {
                    DisplayText("Player Attacks the " + enemyNames[currentBattleEnemys[selectedBattleOption - 3, 0]] + " Dealing 3 Damage");
                    currentBattleEnemys[selectedBattleOption - 3, 1] = currentBattleEnemys[selectedBattleOption - 3, 1] - 3;
                    
                    Console.ReadKey(true);

                    if (currentBattleEnemys[0, 0] >= 1)
                    {
                        DisplayText("the " + enemyNames[currentBattleEnemys[0, 0]] + "(1) Attacks the Player Dealing " + currentBattleEnemys[0, 2] + " Damage");
                        health = health - currentBattleEnemys[0, 2];
                        ShowHUD(false);
                        Console.ReadKey(true);
                    }

                    if (currentBattleEnemys[1, 0] >= 1)
                    {
                        DisplayText("the " + enemyNames[currentBattleEnemys[1, 0]] + "(2) Attacks the Player Dealing " + currentBattleEnemys[1, 2] + " Damage");
                        health = health - currentBattleEnemys[1, 2];
                        ShowHUD(false);
                        Console.ReadKey(true);
                    }

                    if (currentBattleEnemys[2, 0] >= 1)
                    {
                        DisplayText("the " + enemyNames[currentBattleEnemys[2, 0]] + "(3) Attacks the Player Dealing " + currentBattleEnemys[2, 2] + " Damage");
                        health = health - currentBattleEnemys[2, 2];
                        ShowHUD(false);
                        Console.ReadKey(true);
                    }
                    battleState = 0;
                    selectedBattleOption = 0;
                }
            }
        }

    }
}
