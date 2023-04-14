using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    internal class Battle
    {
        //Declare RNG
        static Random RNG = new Random();

        //Battle Menu
        static int selectedBattleOption = 0;
        static int selectedBattleEnemy = 0;
        static string[] battleOptions = new string[6];
        static int battleState;
        
        //Enemy Class used to add 3 Enemys
        static Enemy[] battleEnemys = new Enemy[3];
        //Enemy stat Index (holds all stats to be used by Enemy Class)
        static int[,] enemyIndex = new int[10, 10];
        //Enemy name Index (holds all names to be used by Enemy Class)
        static string[] enemyNames = new string[10];

        public Battle()
        {

        }

        public static void BattleMain()
        {

            //Setup

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


            0 - Health
            1 - Attack
            2 - XP
            3 - Luck
            4 - coins


            */
            //No Enemy Index 0
            enemyNames[0] = "none";
            enemyIndex[0, 0] = 0; //Health
            enemyIndex[0, 1] = 0; //Attack
            enemyIndex[0, 2] = 0; //XP to drop
            enemyIndex[0, 3] = 0; //Luck
            enemyIndex[0, 4] = 0; //Coins to drop

            //Green Slime Index 1
            enemyNames[1] = "Green Slime";
            enemyIndex[1, 0] = 10; //Health
            enemyIndex[1, 1] = 3; //Attack
            enemyIndex[1, 2] = 20; //XP to drop
            enemyIndex[1, 3] = 15; //Luck
            enemyIndex[1, 4] = 10; //Coins to drop

            //Skeleton Index 2
            enemyNames[2] = "Skeleton";
            enemyIndex[2, 0] = 7; //Health
            enemyIndex[2, 1] = 5; //Attack
            enemyIndex[2, 2] = 25; //XP to drop
            enemyIndex[2, 3] = 10; //Luck
            enemyIndex[2, 4] = 13; //Coins to drop

            //Variable Declaration
            bool battleLoop = true;
                int damageTemp;

                //Declares 3 New Enemy Variables in the Array battleEnemys
                battleEnemys[0] = new Enemy();
                battleEnemys[1] = new Enemy();
                battleEnemys[2] = new Enemy();

                //Clears MainDisplayBox
                for (int j = 1; j <= 24; j++)
                {
                    for (int i = 2; i <= 61; i++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(' ');
                    }
                }

                //Randomizes then Assigns an Enemy to each of the 3 Enemy Class Variables
                GenerateBattleEnemies();
            

            battleState = 0;
                UpdateTextDisplayBox();
                UpdateMainDisplayBox();

                Console.ReadKey(true);


            //Main Battle Loop
            while (battleLoop)
            {
                
                UpdateTextDisplayBox();
                BattleInput();

                //Attacking Phase
                if (battleState == 2)
                {
                    //Checking if player Targeted nothing
                    if (battleEnemys[selectedBattleEnemy].health != 0)
                    {
                        //Enemy takes damage
                        damageTemp = Program.player.DealDamage();
                        if (damageTemp == 0)
                            Program.DisplayText("Player Attacks the " + battleEnemys[selectedBattleEnemy].name + "(" + (selectedBattleEnemy + 1) + ") But Missed", true);
                        else
                            if (damageTemp == Program.player.attack * 2)
                        {
                            Program.DisplayText("Crit! Player Attacks the " + battleEnemys[selectedBattleEnemy].name + "(" + (selectedBattleEnemy + 1) + ") Dealing " + damageTemp + " Damage", true);
                            battleEnemys[selectedBattleEnemy].TakeDamage(damageTemp);
                            UpdateMainDisplayBox(selectedBattleEnemy);
                        }
                        else
                        {
                            Program.DisplayText("Player Attacks the " + battleEnemys[selectedBattleEnemy].name + "(" + (selectedBattleEnemy + 1) + ") Dealing " + damageTemp + " Damage", true);
                            battleEnemys[selectedBattleEnemy].TakeDamage(damageTemp);
                            UpdateMainDisplayBox(selectedBattleEnemy);
                        }



                        //if enemy dies
                        if (battleEnemys[selectedBattleEnemy].health == 0)
                        {
                            Console.ReadKey(true);
                            Program.DisplayText("The " + battleEnemys[selectedBattleEnemy].name + "(" + (selectedBattleEnemy + 1) + ") is Defeated", false);

                            //Checking to see if all enemies are dead
                            if (battleEnemys[0].health == 0 && battleEnemys[1].health == 0 && battleEnemys[2].health == 0)
                                battleState = 5;
                        }
                    }
                    else
                    {
                        Program.DisplayText("the Player tired to Attack, But aimed for nothing", true);
                    }

                    if (battleState != 5)
                        battleState = 4;

                    Console.ReadKey(true);
                    UpdateMainDisplayBox();
                }

                //Running away
                if (battleState == 3)
                {
                    Program.DisplayText("You Try to Run Away", true);
                    Console.ReadKey(true);
                    if (RNG.Next(1, 101) < 35 + Program.player.luck)
                    {
                        Program.DisplayText("You Got Away!!!", false);
                        Console.ReadKey(true);
                        battleLoop = false;
                    }
                    else
                    {
                        Program.DisplayText("But you Failed", false);
                        Console.ReadKey(true);
                        Program.DisplayText("", true);
                        battleState = 4;
                    }
                }

                //Enemys Turn
                if (battleState == 4)
                {

                    if (battleEnemys[0].health != 0)
                    {
                        damageTemp = battleEnemys[0].DealDamage();
                        Program.DisplayText("the " + battleEnemys[0].name + "(1) Attacks the Player Dealing " + damageTemp + " Damage", false);
                        Program.player.TakeDamage(damageTemp);
                        Program.ShowHUD(false);
                        Console.ReadKey(true);
                    }

                    if (battleEnemys[1].health != 0)
                    {
                        damageTemp = battleEnemys[1].DealDamage();
                        Program.DisplayText("the " + battleEnemys[1].name + "(2) Attacks the Player Dealing " + damageTemp + " Damage", false);
                        Program.player.TakeDamage(damageTemp);
                        Program.ShowHUD(false);
                        Console.ReadKey(true);
                    }

                    if (battleEnemys[2].health != 0)
                    {
                        damageTemp = battleEnemys[2].DealDamage();
                        Program.DisplayText("the " + battleEnemys[2].name + "(3) Attacks the Player Dealing " + damageTemp + " Damage", false);
                        Program.player.TakeDamage(damageTemp);
                        Program.ShowHUD(false);
                        Console.ReadKey(true);
                    }

                    //Checking if player died
                    if (Program.player.health == 0)
                        battleState = 6;
                    else
                        battleState = 0;
                }

                //Victroy
                if (battleState == 5)
                {
                    Program.DisplayText("Victory!!!", true);
                    Program.DisplayText("All Enemys have Been defeated", false);
                    Program.DisplayText("You Got " + (battleEnemys[0].xp + battleEnemys[1].xp + battleEnemys[2].xp).ToString() + " XP", false);
                    Program.DisplayText("You Got " + (battleEnemys[0].coins + battleEnemys[1].coins + battleEnemys[2].coins).ToString() + " Coins", false);
                    Console.ReadKey(true);
                    Program.player.AddXPLevelUp(battleEnemys[0].xp + battleEnemys[1].xp + battleEnemys[2].xp);
                    Program.player.coins += battleEnemys[0].coins + battleEnemys[1].coins + battleEnemys[2].coins;
                    Program.ShowHUD(false);
                    battleLoop = false;
                }

                //Gameover
                if (battleState == 6)
                {
                    Program.DisplayText("Healed to full", true);
                    Program.DisplayText("Lets Try Again", false);
                    Program.DisplayText("It would seem you could not handle this adventure", false);
                    Console.ReadKey(true);
                    battleLoop = false;
                    Program.player.health = Program.player.maxHealth;
                    Program.ShowHUD(false);
                }
            }

            //Private Methods

            //Randomizes then Assigns an Enemy to each of the 3 Enemy Class Variables
            void GenerateBattleEnemies()
            {
                
                int MaxEnemyIndexValue = 3;
                int EnemyIndexValue;

                //check if no positions get filled
                while (battleEnemys[0].health == 0 && battleEnemys[1].health == 0 && battleEnemys[2].health == 0)
                {
                    
                    //Position A (0)
                    if (1 == RNG.Next(0, 2))
                    {
                        
                        EnemyIndexValue = RNG.Next(1, MaxEnemyIndexValue);
                        battleEnemys[0] = new Enemy(enemyNames[EnemyIndexValue], enemyIndex[EnemyIndexValue, 0], enemyIndex[EnemyIndexValue, 1], enemyIndex[EnemyIndexValue, 2], enemyIndex[EnemyIndexValue, 3], enemyIndex[EnemyIndexValue, 4]);
                    }

                    //Position B (1)
                    if (1 == RNG.Next(0, 2))
                    {
                        EnemyIndexValue = RNG.Next(1, MaxEnemyIndexValue);
                        battleEnemys[1] = new Enemy(enemyNames[EnemyIndexValue], enemyIndex[EnemyIndexValue, 0], enemyIndex[EnemyIndexValue, 1], enemyIndex[EnemyIndexValue, 2], enemyIndex[EnemyIndexValue, 3], enemyIndex[EnemyIndexValue, 4]);
                    }

                    //Position C (2)
                    if (1 == RNG.Next(0, 2))
                    {
                        EnemyIndexValue = RNG.Next(1, MaxEnemyIndexValue);
                        battleEnemys[2] = new Enemy(enemyNames[EnemyIndexValue], enemyIndex[EnemyIndexValue, 0], enemyIndex[EnemyIndexValue, 1], enemyIndex[EnemyIndexValue, 2], enemyIndex[EnemyIndexValue, 3], enemyIndex[EnemyIndexValue, 4]);
                    }
                }
                
                return;
            }

            void BattleInput()
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
                        if (selectedBattleOption != 2 && battleState == 0)
                            selectedBattleOption++;

                        if (selectedBattleEnemy != 2 && battleState == 1)
                            selectedBattleEnemy++;
                        break;

                    case "left":
                        if (selectedBattleOption != 0 && battleState == 0)
                            selectedBattleOption--;

                        if (selectedBattleEnemy != 0 && battleState == 1)
                            selectedBattleEnemy--;
                        break;

                    case "confirm":
                        if (battleState == 1)
                            battleState = 2;

                        if (battleState == 0)
                        {
                            if (selectedBattleOption == 0)
                                battleState = 1;

                            if (selectedBattleOption == 2)
                                battleState = 3;
                        }
                        return;

                    case "back":
                        if (battleState == 1)
                        {
                            battleState = 0;
                            return;
                        }
                        break;

                    case "exit":
                        //Unused (Fix)
                        break;

                    case "reload":
                        //Unused
                        break;

                    case "cycleRight":
                        if (Program.player.currentWeapon != 1)
                        {
                            Program.player.currentWeapon++;
                            Program.ShowHUD(false);
                        }
                        break;


                    case "cycleLeft":
                        if (Program.player.currentWeapon != 0)
                        {
                            Program.player.currentWeapon--;
                            Program.ShowHUD(false);
                        }
                        break;
                }
            }

        }

        private static void UpdateMainDisplayBox(int whichEnemyIsHurt = 3)
        {
            bool isHurt = false;
            int spriteDrawX;
            int spriteDrawY;

            //Top Window Draw

            //Enemy A (0)
            if (battleEnemys[0].health > 0)
            {
                if (whichEnemyIsHurt == 3 || whichEnemyIsHurt == 0)
                {
                    for (int j = 2; j <= 21; j++)
                    {
                        for (int i = 3; i <= 20; i++)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write(' ');
                        }
                    }

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
            }
            else
            {
                for (int j = 2; j <= 21; j++)
                {
                    for (int i = 3; i <= 20; i++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(' ');
                    }
                }
            }

            //Enemy B (1)
            if (battleEnemys[1].health >= 1)
            {
                if (whichEnemyIsHurt == 3 || whichEnemyIsHurt == 1)
                {
                    for (int j = 5; j <= 24; j++)
                    {
                        for (int i = 23; i <= 40; i++)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write(' ');
                        }
                    }

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
            }
            else
            {
                for (int j = 5; j <= 24; j++)
                {
                    for (int i = 23; i <= 40; i++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(' ');
                    }
                }
            }

            //Enemy C (2)
            if (battleEnemys[2].health >= 1)
            {
                if (whichEnemyIsHurt == 3 || whichEnemyIsHurt == 2)
                {
                    for (int j = 2; j <= 21; j++)
                    {
                        for (int i = 43; i <= 60; i++)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write(' ');
                        }
                    }

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
            else
            {
                for (int j = 2; j <= 21; j++)
                {
                    for (int i = 43; i <= 60; i++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(' ');
                    }
                }
            }

            //Private Methods
            
            //Draws The Sprites on the Main Display Box
            void DrawEnemySprites(string enemyNameToDraw, bool isEnemyHurt)
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
                            Console.SetCursorPosition(spriteDrawX, spriteDrawY - 12); Console.Write("▐▐▐ ▄▄▄ ▄▄ ▄▄▄ ▌▌▌");
                            Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 11); Console.Write("▀▀▄█ ▄▄██▄▄ █▄▀▀");
                            Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 10); Console.Write("▐▌█ ▀▄▄██▄▄▀ █▐▌");
                            Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 9); Console.Write("▐▌ ▀▄▄██▄▄▀ ▐▌");
                            Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 8); Console.Write("▀▄██▄▀");
                            Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 7); Console.Write("▄ ██ ▄");
                            Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 6); Console.Write("█▄█▀▀█▄█");
                            Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 5); Console.Write("▄█      █▄");
                            Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 4); Console.Write("▄█        █▄");
                            Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 3); Console.Write("▐█          █▌");
                            Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 2); Console.Write("▐▌        ▐▌");
                            Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 1); Console.Write("█        █");
                            Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY); Console.Write("▐▐▐█      ██▐▐");

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
                            Console.SetCursorPosition(spriteDrawX, spriteDrawY - 12); Console.Write("▐▐▐ ▄▄▄ ▄▄ ▄▄▄ ▌▌▌");
                            Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 11); Console.Write("▀▀▄█ ▄▄██▄▄ █▄▀▀");
                            Console.SetCursorPosition(spriteDrawX + 1, spriteDrawY - 10); Console.Write("▐▌█ ▀▄▄██▄▄▀ █▐▌");
                            Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 9); Console.Write("▐▌ ▀▄▄██▄▄▀ ▐▌");
                            Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 8); Console.Write("▀▄██▄▀");
                            Console.SetCursorPosition(spriteDrawX + 6, spriteDrawY - 7); Console.Write("▄ ██ ▄");
                            Console.SetCursorPosition(spriteDrawX + 5, spriteDrawY - 6); Console.Write("█▄█▀▀█▄█");
                            Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 5); Console.Write("▄█      █▄");
                            Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 4); Console.Write("▄█        █▄");
                            Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY - 3); Console.Write("▐█          █▌");
                            Console.SetCursorPosition(spriteDrawX + 3, spriteDrawY - 2); Console.Write("▐▌        ▐▌");
                            Console.SetCursorPosition(spriteDrawX + 4, spriteDrawY - 1); Console.Write("█        █");
                            Console.SetCursorPosition(spriteDrawX + 2, spriteDrawY); Console.Write("▐▐▐█      ██▐▐");

                            Console.ResetColor();
                        }

                        break;
                }
            }
        }

        private static void UpdateTextDisplayBox()
        {
            //Clears Text Display Box
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

                    //Enemy 0
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

                    //Enemy 2
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


        
    }

}
