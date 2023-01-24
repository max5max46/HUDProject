using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    internal class Program
    {
        static Random RNG = new Random();


        public static Player player = new Player();

        //OverWorld Movement
        public static int tempPlayerX;
        public static int tempPlayerY;

        static bool genaratePlayerSpawn = true;

        public static bool gameOver = false;
        public static bool overworldLoop;
        static public bool mainmenuLoop = true;
        static bool quickRandGen = true;

        static string[] linesToDisplay = new string[5];

        public static char[,] map = new char[,] // dimensions defined by following data:
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


            if (Console.LargestWindowWidth > 99 || Console.LargestWindowHeight > 35)
            {
                Console.WindowHeight = 35;
                Console.WindowWidth = 99;
            }

            Console.CursorVisible = false;

            ShowHUD(true);

            Mainmenu();

            ShowHUD(true);


            while (gameOver == false)
            {
                overworldLoop = true;
                DisplayText("Generating map...", true);
                RandomizeMap();

                while (genaratePlayerSpawn == true)
                {
                    player.y = RNG.Next(0, 24) + 1;
                    player.x = RNG.Next(0, 60) + 2;

                    if (map[player.y - 1, player.x - 2] == '*' || map[player.y - 1, player.x - 2] == '`')
                    {
                        genaratePlayerSpawn = false;
                    }
                }

                DisplayMap();

                tempPlayerX = player.x;
                tempPlayerY = player.y;

                ShowHUD(true);

                int tilesBeforeSpawn = 0;

                while (overworldLoop == true)
                {
                    if (RNG.Next(0, 12) == 9 && tilesBeforeSpawn > 5)
                    {
                        Battle.BattleMain();
                        DisplayMap();
                        tilesBeforeSpawn = 0;
                    }
                    PlayerDraw();
                    OverworldInput();
                    tilesBeforeSpawn++;
                }
            }


        }

        static void Mainmenu()
        {
            Console.SetCursorPosition(18, 6);
            Console.Write("┌                           ┐"); Console.SetCursorPosition(18, 7);
            Console.Write("│ HUDProject (place Holder) │"); Console.SetCursorPosition(18, 8);
            Console.Write("│        Dylan Adams        │"); Console.SetCursorPosition(18, 9);
            Console.Write("└                           ┘");

            Console.SetCursorPosition(3, 17);
            Console.Write("Controls:"); Console.SetCursorPosition(3, 19);
            Console.Write("Move - WASD or Arrow Keys"); Console.SetCursorPosition(3, 20);
            Console.Write("Confirm - Enter/Space/Z"); Console.SetCursorPosition(3, 21);
            Console.Write("Back - Backspace or X"); Console.SetCursorPosition(3, 22);
            Console.Write("Switch Weapon - Q and E"); Console.SetCursorPosition(3, 23);
            Console.Write("Genarate New World - R"); Console.SetCursorPosition(3, 24);
            Console.Write("Quit Game - Escape");

            Console.SetCursorPosition(55, 24); Console.Write("v0.2.2");

            Console.SetCursorPosition(21, 14);
            Console.Write("Press Confirm to Begin");
            while (mainmenuLoop == true)
            {
                MainmenuInput();
            }
        }

        //Displays the HUD
        public static void ShowHUD(bool resetUI)
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
                Console.Write("│ HP:           Coins:         │"); Console.SetCursorPosition(firstWindowPositionX, firstWindowPositionY + 4);
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
                Console.Write(player.level);


                //Display health
                Console.SetCursorPosition(firstWindowPositionX + 6, firstWindowPositionY + 3);
                Console.Write("        ");
                Console.SetCursorPosition(firstWindowPositionX + 6, firstWindowPositionY + 3);
                Console.Write(player.health + "/" + player.maxHealth);

                //Display Coins
                Console.SetCursorPosition(firstWindowPositionX + 23, firstWindowPositionY + 3);
                Console.Write("        ");
                Console.SetCursorPosition(firstWindowPositionX + 23, firstWindowPositionY + 3);
                Console.Write(player.coins);

                //Display XP
                Console.SetCursorPosition(firstWindowPositionX + 6, firstWindowPositionY + 5);
                Console.Write("        ");
                Console.SetCursorPosition(firstWindowPositionX + 6, firstWindowPositionY + 5);
                Console.Write(player.xp);


                //Display XP to level
                Console.SetCursorPosition(firstWindowPositionX + 27, firstWindowPositionY + 5);
                Console.Write("    ");
                Console.SetCursorPosition(firstWindowPositionX + 27, firstWindowPositionY + 5);
                Console.Write(player.xpToNextLevelUp - player.xp);


                //Display Weapon 1
                Console.SetCursorPosition(firstWindowPositionX + 2, firstWindowPositionY + 8);
                Console.Write("-");

                if (player.currentWeapon == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.Write(player.weapons[0]);
                Console.ResetColor();


                //Display Ammo 1
                Console.SetCursorPosition(firstWindowPositionX + 16, firstWindowPositionY + 8);

                if (player.ammoMax[0] != 0)
                    Console.Write(player.ammo[0] + "/" + player.ammoMax[0]);
                else
                    Console.Write("-/-");


                //Display Weapon 2
                Console.SetCursorPosition(firstWindowPositionX + 2, firstWindowPositionY + 9);
                Console.Write("-");

                if (player.currentWeapon == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }

                Console.Write(player.weapons[1]);
                Console.ResetColor();


                //Display Ammo 2
                Console.SetCursorPosition(firstWindowPositionX + 16, firstWindowPositionY + 9);
                if (player.ammoMax[1] != 0)
                    Console.Write(player.ammo[1] + "/" + player.ammoMax[1]);
                else
                    Console.Write("-/-");

            }
        }

        //Draws the player on the overworld
        static void PlayerDraw()
        {
            Console.SetCursorPosition(tempPlayerX, tempPlayerY);
            SetBackgroundColor(tempPlayerY - 1, tempPlayerX - 2);
            Console.Write(map[tempPlayerY - 1, tempPlayerX - 2]);
            Console.ResetColor();

            Console.SetCursorPosition(player.x, player.y);
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
                    if (quickRandGen == false)
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

                    if (quickRandGen == false)
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

                    if (quickRandGen == false)
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

            if (quickRandGen == false)
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

            //Shop Generate
            bool loop = true;
            while (loop == true)
            {
                int xTemp = RNG.Next(0, 60);
                int yTemp = RNG.Next(0, 24);
                if (map[yTemp, xTemp] == '`' || map[yTemp, xTemp] == '*')
                {
                    map[yTemp, xTemp] = '$';
                    loop = false;
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

        //Takes a String and displays it in the UI Display box
        public static void DisplayText(string textToDisplay = "You shouldn't see this", bool clearText = true)
        {

            if (textToDisplay.Length >= 270) return;

            if (clearText == true)
            {
                linesToDisplay = new string[5];
            }

            ClearDisplayBox();

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

            for (int i = 4; i > 0; i--)
            {
                linesToDisplay[i] = linesToDisplay[i - 1];
            }

            linesToDisplay[0] = textToDisplay.Substring(0, lineOne);

            if (textToDisplay.Length > 57 && textToDisplay.Length <= 115)
            {
                linesToDisplay[1] = textToDisplay.Substring(0, lineOne);
                linesToDisplay[0] = textToDisplay.Substring(lineOne + 1, lineTwo - lineOne - 1);
            }

            if (textToDisplay.Length > 115 && textToDisplay.Length <= 173)
            {
                linesToDisplay[2] = textToDisplay.Substring(0, lineOne);
                linesToDisplay[1] = textToDisplay.Substring(lineOne + 1, lineTwo - lineOne - 1);
                linesToDisplay[0] = textToDisplay.Substring(lineTwo + 1, lineThree - lineTwo - 1);
            }

            if (textToDisplay.Length > 173 && textToDisplay.Length <= 231)
            {
                linesToDisplay[3] = textToDisplay.Substring(0, lineOne);
                linesToDisplay[2] = textToDisplay.Substring(lineOne + 1, lineTwo - lineOne - 1);
                linesToDisplay[1] = textToDisplay.Substring(lineTwo + 1, lineThree - lineTwo - 1);
                linesToDisplay[0] = textToDisplay.Substring(lineThree + 1, lineFour - lineThree - 1);
            }

            if (textToDisplay.Length > 231)
            {
                linesToDisplay[4] = textToDisplay.Substring(0, lineOne);
                linesToDisplay[3] = textToDisplay.Substring(lineOne + 1, lineTwo - lineOne - 1);
                linesToDisplay[2] = textToDisplay.Substring(lineTwo + 1, lineThree - lineTwo - 1);
                linesToDisplay[1] = textToDisplay.Substring(lineThree + 1, lineFour - lineThree - 1);
                linesToDisplay[0] = textToDisplay.Substring(lineFour + 1, textToDisplay.Length - lineFour - 1);
            }

            //Console.SetCursorPosition(3, 28); Console.Write(linesToDisplay[0]);
            Console.SetCursorPosition(3, 29); Console.Write(linesToDisplay[1]);
            Console.SetCursorPosition(3, 30); Console.Write(linesToDisplay[2]);
            Console.SetCursorPosition(3, 31); Console.Write(linesToDisplay[3]);
            Console.SetCursorPosition(3, 32); Console.Write(linesToDisplay[4]);

            Console.SetCursorPosition(3, 28);
            for (int i = 0; i < linesToDisplay[0].Length; i++)
            {
                for(int j = 0; j < 7000000; j++)
                {
                    int nothing = 1 + 1;
                }
                Console.Write(linesToDisplay[0][i]);
            }


            Console.ResetColor();
        }

        public static void ShopMain()
        {
            ClearMainBox();
        }
        
        static void ClearMainBox()
        {
            for (int j = 1; j <= 24; j++)
            {
                for (int i = 2; i <= 61; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }
        }

        static void ClearDisplayBox()
        {
            for (int j = 28; j <= 32; j++)
            {
                for (int i = 2; i <= 61; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }
        }

        static void ClearStatusBox()
        {
            for (int j = 1; j <= 24; j++)
            {
                for (int i = 65; i <= 95; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }
        }

        static void OverworldInput()
        {
            tempPlayerX = player.x;
            tempPlayerY = player.y;

            switch (PlayerInput.ReadPlayerInput())
            {
                case "down":
                    if (player.y < map.GetLength(0))
                        player.y++;
                    break;

                case "up":
                    if (player.y > 1)
                        player.y--;
                    break;

                case "right":
                    if (player.x < map.GetLength(1) + 1)
                        player.x++;
                    break;

                case "left":
                    if (player.x > 2)
                        player.x--;
                    break;

                case "confirm":
                    //Unused
                    break;

                case "back":
                    //Unused
                    break;

                case "exit":
                    gameOver = true;
                    overworldLoop = false;
                    return;

                case "reload":
                    overworldLoop = false;
                    return;

                case "cycleRight":
                    if (player.currentWeapon != 1)
                    {
                        player.currentWeapon++;
                        ShowHUD(false);
                    }
                    break;

                case "cycleLeft":
                    if (player.currentWeapon != 0)
                    {
                        player.currentWeapon--;
                        ShowHUD(false);
                    }
                    break;
            }

            //Check if the player can move on to a Specified tile
            if (map[player.y - 1, player.x - 2] == '^' || map[player.y - 1, player.x - 2] == '~')
            {
                player.x = tempPlayerX;
                player.y = tempPlayerY;
            }

            if (map[player.y - 1, player.x - 2] == '$')
            {
                ShopMain();
            }
        }

        static void MainmenuInput()
        {
            switch (PlayerInput.ReadPlayerInput())
            {
                case "down":
                    //Unused
                    break;

                case "up":
                    //Unused
                    break;

                case "right":
                    //Unused
                    break;

                case "left":
                    //Unused
                    break;

                case "confirm":
                    mainmenuLoop = false;
                    break;

                case "back":
                    mainmenuLoop = false;
                    gameOver = true;
                    break;

                case "exit":
                    mainmenuLoop = false;
                    gameOver = true;
                    break;

                case "reload":
                    //Unused
                    break;

                case "cycleRight":
                    //Unused
                    break;

                case "cycleLeft":
                    //Unused
                    break;
            }
        }

        //Sprite Drawing
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

            Console.Write("@──────────────────@"); 
            Console.Write("│     ▄▄▄▄▄▄▄▄     │");
            Console.Write("│    █▀▀████▀▀█    │");
            Console.Write("│    ██ ▄██▄ ██    │");
            Console.Write("│     ▀██████▀     │");
            Console.Write("│      █ ██ █      │");
            Console.Write("│▐▐▐ ▄▄▄ ▄▄ ▄▄▄ ▌▌▌│"); 
            Console.Write("│ ▀▀▄█ ▄▄██▄▄ █▄▀▀ │"); 
            Console.Write("│ ▐▌█ ▀▄▄██▄▄▀ █▐▌ │"); 
            Console.Write("│  ▐▌ ▀▄▄██▄▄▀ ▐▌  │"); 
            Console.Write("│      ▀▄██▄▀      │");
            Console.Write("│      ▄ ██ ▄      │"); 
            Console.Write("│     █▄█▀▀█▄█     │"); 
            Console.Write("│    ▄█      █▄    │");
            Console.Write("│   ▄█        █▄   │");
            Console.Write("│  ▐█          █▌  │");
            Console.Write("│   ▐▌        ▐▌   │");
            Console.Write("│    █        █    │");
            Console.Write("│  ▐▐▐█      ██▐▐  │");
            Console.Write("@──────────────────@");

            Console.Write("▄▄▄▄▄▄▄▄") 5;
            Console.Write("█▀▀████▀▀█") 4;
            Console.Write("██ ▄██▄ ██") 4;
            Console.Write("▀██████▀" 5);
            Console.Write("█ ██ █" 6);
            Console.Write("▐▐▐ ▄▄▄ ▄▄ ▄▄▄ ▌▌▌") 0; 
            Console.Write("▀▀▄█ ▄▄██▄▄ █▄▀▀") 1; 
            Console.Write("▐▌█ ▀▄▄██▄▄▀ █▐▌") 1; 
            Console.Write("▐▌ ▀▄▄██▄▄▀ ▐▌") 2; 
            Console.Write("▀▄██▄▀") 6;
            Console.Write("▄ ██ ▄") 6; 
            Console.Write("█▄█▀▀█▄█" 5); 
            Console.Write("▄█      █▄" 4);
            Console.Write("▄█        █▄" 3);
            Console.Write("▐█          █▌" 2);
            Console.Write("▐▌        ▐▌" 3);
            Console.Write("█        █" 4);
            Console.Write("▐▐▐█      ██▐▐" 2);

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

            */

    }
}
