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

        //Battle Menu
        public static int selectedBattleOption = 0;
        public static int selectedBattleEnemy = 0;
        static string[] battleOptions = new string[6];
        public static int battleState;
        static int spriteDrawX;
        static int spriteDrawY;

        static bool battleOver;

        static string[] linesToDisplay = new string[5];

        

        //Enemies
        static Enemy[] battleEnemys = new Enemy[3];
        
        static int[,] enemyIndex = new int[10, 10];
        static string[] enemyNames = new string[10];

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

            ResetGame();
            ShowHUD(true);

            Console.SetCursorPosition(18, 6);
            Console.Write("┌                           ┐"); Console.SetCursorPosition(18, 7);
            Console.Write("│ HUDProject (place Holder) │"); Console.SetCursorPosition(18, 8);
            Console.Write("│        Dylan Adams        │"); Console.SetCursorPosition(18, 9);
            Console.Write("└                           ┘");

            Console.SetCursorPosition(3, 17);
            Console.Write("Controls:"); Console.SetCursorPosition(3, 19);
            Console.Write("Move - WASD or Arrow Keys"); Console.SetCursorPosition(3, 20);
            Console.Write("Confrim - Enter/Space/Z"); Console.SetCursorPosition(3, 21);
            Console.Write("Back - Backspace or X"); Console.SetCursorPosition(3, 22);
            Console.Write("Switch Weapon - Q and E"); Console.SetCursorPosition(3, 23);
            Console.Write("Genarate New World - R"); Console.SetCursorPosition(3, 24);
            Console.Write("Quit Game - Escape");

            Console.SetCursorPosition(55, 24); Console.Write("v0.2");

            Console.SetCursorPosition(20, 14);
            Console.Write("Press any Button to Begin");
            Console.ReadKey(true);

            ShowHUD(true);


            while (gameOver == false)
            {
                ResetGame();
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
                        BattleMain();
                        DisplayMap();
                        tilesBeforeSpawn = 0;
                    }
                    PlayerDraw();
                    PlayerInput.ReadPlayerInput("overworld");
                    tilesBeforeSpawn++;
                }
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
                Console.Write(player.level);


                //Display health
                Console.SetCursorPosition(firstWindowPositionX + 6, firstWindowPositionY + 3);
                Console.Write("        ");
                Console.SetCursorPosition(firstWindowPositionX + 6, firstWindowPositionY + 3);
                Console.Write(player.health + "/" + player.maxHealth);


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

        //Resets Varibles to Base State
        static void ResetGame()
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("\n Player Stats are about to Reset");

            //Variables
            overworldLoop = true;
            genaratePlayerSpawn = true;

            //Array Setup
            battleOptions[0] = "Attack";
            battleOptions[1] = "N/a";
            battleOptions[2] = "Run";
            battleOptions[3] = "Enemy 1";
            battleOptions[4] = "Enemy 2";
            battleOptions[5] = "Enemy 3";


            battleEnemys[0] = new Enemy();
            battleEnemys[1] = new Enemy();
            battleEnemys[2] = new Enemy();

            //Enemies defined

            /*Index values for speific Enemies goes as follows

            Green Slimes

            0 - Health
            1 - Attack
            2 - XP
            3 - Luck



            */
            //No Enemy Index 0
            enemyNames[0] = "none";
            enemyIndex[0, 0] = 0;
            enemyIndex[0, 1] = 0;
            enemyIndex[0, 2] = 0;

            //Green Slime Index 1
            enemyNames[1] = "Green Slime";
            enemyIndex[1, 0] = 10;
            enemyIndex[1, 1] = 3;
            enemyIndex[1, 2] = 20;
            enemyIndex[1, 3] = 15;

            //Skeleton Index 2
            enemyNames[2] = "Skeleton";
            enemyIndex[2, 0] = 7;
            enemyIndex[2, 1] = 5;
            enemyIndex[2, 2] = 25;
            enemyIndex[2, 3] = 10;

            //Console.WriteLine(" Player Stats are Successfully Reset");
            //Console.ResetColor();

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

            bool noDisplay = false;

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

        static void DisplayBattleMain(int whichEnemyIsHurt = 3)
        {
            bool isHurt = false;
            ClearMainBox();
            //Top Window Draw

            //Enemy A (0)
            if (battleEnemys[0].health > 0 && (whichEnemyIsHurt == 3 || whichEnemyIsHurt == 0))
            {
                spriteDrawX = 3;
                spriteDrawY = 19;

                //Check which sprite to draw, then draw
                if (whichEnemyIsHurt == 0)
                    isHurt = true;
                DrawEnemySprites(battleEnemys[0].name, isHurt);
                isHurt = false;

                //Draw Health Bar A (0)
                Console.SetCursorPosition(7, 21);
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 1; i <= 10; i++)
                {
                    if ((double)battleEnemys[0].health / (double)battleEnemys[0].maxHealth < ((double)i * 0.099))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("■");
                }
                Console.ResetColor();
            }

            //Enemy B (1)
            if (battleEnemys[1].health >= 1 && (whichEnemyIsHurt == 3 || whichEnemyIsHurt == 1))
            {
                spriteDrawX = 23;
                spriteDrawY = 22;

                //Check which sprite to draw, then draw
                if (whichEnemyIsHurt == 1)
                    isHurt = true;
                DrawEnemySprites(battleEnemys[1].name, isHurt);
                isHurt = false;

                //Draw Health Bar B (1)
                Console.SetCursorPosition(27, 24);
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 1; i <= 10; i++)
                {
                    if ((double)battleEnemys[1].health / (double)battleEnemys[1].maxHealth < ((double)i * 0.099))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("■");
                }
                Console.ResetColor();
            }

            //Enemy C (2)
            if (battleEnemys[2].health >= 1 && (whichEnemyIsHurt == 3 || whichEnemyIsHurt == 2))
            {
                spriteDrawX = 43;
                spriteDrawY = 19;

                //Check which sprite to draw, then draw
                if (whichEnemyIsHurt == 2)
                    isHurt = true;
                DrawEnemySprites(battleEnemys[2].name, isHurt);
                isHurt = false;

                //Draw Health Bar C (2)
                Console.SetCursorPosition(47, 21);
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 1; i <= 10; i++)
                {
                    if ((double)battleEnemys[2].health / (double)battleEnemys[2].maxHealth < ((double)i * 0.099))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("■");
                }
                Console.ResetColor();
            }
        }

        static void DisplayBattleDisplayBox()
        {

            ClearDisplayBox();

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
                    if (selectedBattleEnemy == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[3]);
                    Console.ResetColor();

                    //Enemy 1
                    Console.SetCursorPosition(15, 30);
                    if (selectedBattleEnemy == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[4]);
                    Console.ResetColor();

                    //Enemy 3
                    Console.SetCursorPosition(27, 30);
                    if (selectedBattleEnemy == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(battleOptions[5]);
                    Console.ResetColor();
                    break;

                case 2:
                    break;
            }
        }
        
        static void GenerateBattleEnemies()
        {
            //battleEnemies Defines if there is a Enemy in any of the three battle positions and what enemy they are
            
            int MaxEnemyIndexValue = 3;
            int EnemyIndexValue;

            //check if no positions get filled
            while (battleEnemys[0].health == 0 && battleEnemys[1].health == 0 && battleEnemys[2].health == 0)
            {
                //Position A (0)
                if (1 == RNG.Next(0, 2))
                {
                    EnemyIndexValue = RNG.Next(1, MaxEnemyIndexValue);
                    battleEnemys[0] = new Enemy(enemyNames[EnemyIndexValue], enemyIndex[EnemyIndexValue, 0], enemyIndex[EnemyIndexValue, 1], enemyIndex[EnemyIndexValue, 2], enemyIndex[EnemyIndexValue, 3]);
                }

                //Position B (1)
                if (1 == RNG.Next(0, 2))
                {
                    EnemyIndexValue = RNG.Next(1, MaxEnemyIndexValue);
                    battleEnemys[1] = new Enemy(enemyNames[EnemyIndexValue], enemyIndex[EnemyIndexValue, 0], enemyIndex[EnemyIndexValue, 1], enemyIndex[EnemyIndexValue, 2], enemyIndex[EnemyIndexValue, 3]);
                }

                //Position C (2)
                if (1 == RNG.Next(0, 2))
                {
                    EnemyIndexValue = RNG.Next(1, MaxEnemyIndexValue);
                    battleEnemys[2] = new Enemy(enemyNames[EnemyIndexValue], enemyIndex[EnemyIndexValue, 0], enemyIndex[EnemyIndexValue, 1], enemyIndex[EnemyIndexValue, 2], enemyIndex[EnemyIndexValue, 3]);
                }
            }
        }

        static void BattleMain()
        {
            int damageTemp;
            battleEnemys[0] = new Enemy();
            battleEnemys[1] = new Enemy();
            battleEnemys[2] = new Enemy();
            battleOver = false;
            GenerateBattleEnemies();
            battleState = 0;
            DisplayBattleDisplayBox();
            DisplayBattleMain();

            Console.ReadKey(true);

            while (battleOver == false)
            {
                DisplayBattleDisplayBox();
                PlayerInput.ReadPlayerInput("battle");

                //Attacking Phase
                if (battleState == 2)
                {
                    //Checking if player Targeted nothing
                    if (battleEnemys[selectedBattleEnemy].health != 0)
                    {
                        //Enemy takes damage
                        damageTemp = player.DealDamage();
                        battleEnemys[selectedBattleEnemy].TakeDamage(damageTemp);
                        DisplayText("Player Attacks the " + battleEnemys[selectedBattleEnemy].name + "(" + (selectedBattleEnemy + 1) + ") Dealing " + damageTemp + " Damage", true);
                        DisplayBattleMain(selectedBattleEnemy);

                        //if enemy dies
                        if (battleEnemys[selectedBattleEnemy].health == 0)
                        {
                            Console.ReadKey(true);
                            DisplayText("The " + battleEnemys[selectedBattleEnemy].name + "(" + (selectedBattleEnemy + 1) + ") is Defeated", false);

                            //Checking to see if all enemies are dead
                            if (battleEnemys[0].health == 0 && battleEnemys[1].health == 0 && battleEnemys[2].health == 0)
                                battleState = 5;
                        }
                    }
                    else
                    {
                        DisplayText("the Player tired to Attack, But aimed for nothing", true);
                    }

                    if (battleState != 5)
                        battleState = 4;

                    Console.ReadKey(true);
                    DisplayBattleMain();
                }

                //Running away
                if (battleState == 3)
                {
                    DisplayText("You Try to Run Away", true);
                    Console.ReadKey(true);
                    if (RNG.Next(1,3) == 2)
                    {
                        DisplayText("You Got Away!!!", false);
                        Console.ReadKey(true);
                        battleOver = true;
                    }
                    else
                    {
                        DisplayText("But you Failed", false);
                        Console.ReadKey(true);
                        DisplayText("", true);
                        battleState = 4;
                    }
                }

                //Enemys Turn
                if (battleState == 4)
                {
                    
                    if (battleEnemys[0].health != 0)
                    {
                        damageTemp = battleEnemys[0].DealDamage(); 
                        DisplayText("the " + battleEnemys[0].name + "(1) Attacks the Player Dealing " + damageTemp + " Damage",false);
                        player.TakeDamage(damageTemp);
                        ShowHUD(false);
                        Console.ReadKey(true);
                    }

                    if (battleEnemys[1].health != 0)
                    {
                        damageTemp = battleEnemys[1].DealDamage();
                        DisplayText("the " + battleEnemys[1].name + "(2) Attacks the Player Dealing " + damageTemp + " Damage", false);
                        player.TakeDamage(damageTemp);
                        ShowHUD(false);
                        Console.ReadKey(true);
                    }

                    if (battleEnemys[2].health != 0)
                    {
                        damageTemp = battleEnemys[2].DealDamage();
                        DisplayText("the " + battleEnemys[2].name + "(3) Attacks the Player Dealing " + damageTemp + " Damage", false);
                        player.TakeDamage(damageTemp);
                        ShowHUD(false);
                        Console.ReadKey(true);
                    }
                    
                    //Checking if player died
                    if (player.health == 0)
                        battleState = 6;
                    else
                        battleState = 0;
                }

                //Victroy
                if (battleState == 5)
                {
                    if (battleEnemys[0].health == 0)

                    DisplayText("Victory!!!", true);
                    DisplayText("All Enemys have Been defeated", false);
                    DisplayText("You Got " + (battleEnemys[0].xp + battleEnemys[1].xp + battleEnemys[2].xp).ToString() + " XP",false);
                    player.AddXPLevelUp(battleEnemys[0].xp + battleEnemys[1].xp + battleEnemys[2].xp);
                    ShowHUD(false);
                    Console.ReadKey(true);
                    battleOver = true;
                }

                //Gameover
                if (battleState == 6)
                {
                    DisplayText("Healed to full", true);
                    DisplayText("Lets Try Again", false);
                    DisplayText("It would seem you could not handle this adventure", false);
                    Console.ReadKey(true);
                    battleOver = true;
                    player.health = player.maxHealth;
                    ShowHUD(false);
                }
                
            }
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

        static void DrawEnemySprites(string enemyNameToDraw, bool isEnemyHurt)
        {
            switch (enemyNameToDraw)
            {
                case "Green Slime":

                    if (isEnemyHurt == false)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 5); Console.Write("▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 4); Console.Write("▄            ▄");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY); Console.Write("▀            ▀");

                        Console.BackgroundColor = ConsoleColor.Green;

                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 4); Console.Write("█▀▀      ▀▀█");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 3); Console.Write("█▀   ▄    ▄   ▀█");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 2); Console.Write("█    █    █    █");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 1); Console.Write("█▄            ▄█");
                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY); Console.Write("█▄▄▄▄▄▄▄▄▄▄█");

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 1); Console.Write("▀▀        ▀▀");

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 5); Console.Write("▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 4); Console.Write("▄            ▄");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY); Console.Write("▀            ▀");

                        Console.BackgroundColor = ConsoleColor.Green;

                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 4); Console.Write("█▀▀      ▀▀█");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 3); Console.Write("█▀  ▄      ▄  ▀█");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 2); Console.Write("█   ▄▀    ▀▄   █");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 1); Console.Write("█▄            ▄█");
                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY); Console.Write("█▄▄▄▄▄▄▄▄▄▄█");

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 1); Console.Write("▀▀        ▀▀");

                        Console.ResetColor();
                    }
                    
                    break;

                case "Skeleton":

                    if (isEnemyHurt == false)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 17); Console.Write("▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 16); Console.Write("█▀▀████▀▀█");
                        Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 15); Console.Write("██ ▄██▄ ██");
                        Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 14); Console.Write("▀██████▀");
                        Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 13); Console.Write("█ ██ █");
                        Console.SetCursorPosition(spriteDrawX, spriteDrawY - 12);     Console.Write("▐▐▐ ▄▄▄ ▄▄ ▄▄▄ ▌▌▌");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 11); Console.Write("▀▀▄█ ▄▄██▄▄ █▄▀▀");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 10); Console.Write("▐▌█ ▀▄▄██▄▄▀ █▐▌");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 9);  Console.Write("▐▌ ▀▄▄██▄▄▀ ▐▌");
                        Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 8);  Console.Write("▀▄██▄▀");
                        Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 7);  Console.Write("▄ ██ ▄");
                        Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 6);  Console.Write("█▄█▀▀█▄█");
                        Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 5);  Console.Write("▄█      █▄");
                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 4);  Console.Write("▄█        █▄");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 3);  Console.Write("▐█          █▌");
                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 2);  Console.Write("▐▌        ▐▌");
                        Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 1);  Console.Write("█        █");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY);      Console.Write("▐▐▐█      ██▐▐");

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 17); Console.Write("▄▄▄▄▄▄▄▄");
                        Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 16); Console.Write("██▀████▀██");
                        Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 15); Console.Write("██▀▄██▄▀██");
                        Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 14); Console.Write("▀██████▀");
                        Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 13); Console.Write("█ ██ █");
                        Console.SetCursorPosition(spriteDrawX, spriteDrawY - 12);     Console.Write("▐▐▐ ▄▄▄ ▄▄ ▄▄▄ ▌▌▌");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 11); Console.Write("▀▀▄█ ▄▄██▄▄ █▄▀▀");
                        Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 10); Console.Write("▐▌█ ▀▄▄██▄▄▀ █▐▌");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 9);  Console.Write("▐▌ ▀▄▄██▄▄▀ ▐▌");
                        Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 8);  Console.Write("▀▄██▄▀");
                        Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 7);  Console.Write("▄ ██ ▄");
                        Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 6);  Console.Write("█▄█▀▀█▄█");
                        Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 5);  Console.Write("▄█      █▄");
                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 4);  Console.Write("▄█        █▄");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 3);  Console.Write("▐█          █▌");
                        Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 2);  Console.Write("▐▌        ▐▌");
                        Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 1);  Console.Write("█        █");
                        Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY);      Console.Write("▐▐▐█      ██▐▐");

                        Console.ResetColor();
                    }
                    
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
