using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    internal class PlayerInput
    {
        private static string simpleInput = "";

        public static void ReadPlayerInput(string inputState)
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar == 's' || keyInfo.Key == ConsoleKey.DownArrow)
                simpleInput = "down";

            if (keyInfo.KeyChar == 'w' || keyInfo.Key == ConsoleKey.UpArrow)
                simpleInput = "up";

            if (keyInfo.KeyChar == 'a' || keyInfo.Key == ConsoleKey.LeftArrow)
                simpleInput = "left";

            if (keyInfo.KeyChar == 'd' || keyInfo.Key == ConsoleKey.RightArrow)
                simpleInput = "right";

            if ((keyInfo.Key == ConsoleKey.Enter) || (keyInfo.Key == ConsoleKey.Spacebar) || (keyInfo.Key == ConsoleKey.Z))
                simpleInput = "confirm";

            if ((keyInfo.Key == ConsoleKey.Backspace) || (keyInfo.Key == ConsoleKey.X))
                simpleInput = "back";

            if (keyInfo.Key == ConsoleKey.Escape)
                simpleInput = "exit";

            if (keyInfo.KeyChar == 'r')
                simpleInput = "reload";

            if (keyInfo.KeyChar == 'e')
                simpleInput = "cycleRight";

            if (keyInfo.KeyChar == 'q')
                simpleInput = "cycleLeft";

            switch (inputState)
            {
                case "overworld":
                    Overworld();
                    break;

                case "battle":
                    Battle();
                    break;
            }
        }

        //switch (simpleInput)
        //    {
        //        case "down":

        //            break;

        //        case "up":

        //            break;

        //        case "right":

        //            break;

        //        case "left":

        //            break;

        //        case "confirm":

        //            break;

        //        case "back":

        //            break;

        //        case "exit":

        //            break;

        //        case "reload":

        //            break;

        //        case "cycleRight":

        //            break;

        //        case "cycleLeft":

        //            break;
        //    }

        private static void Overworld()
        {
            Program.tempPlayerX = Program.player.x;
            Program.tempPlayerY = Program.player.y;

            switch (simpleInput)
            {
                case "down":
                    if (Program.player.y < Program.map.GetLength(0))
                        Program.player.y++;
                    break;

                case "up":
                    if (Program.player.y > 1)
                        Program.player.y--;
                    break;

                case "right":
                    if (Program.player.x < Program.map.GetLength(1) + 1)
                        Program.player.x++;
                    break;

                case "left":
                    if (Program.player.x > 2)
                        Program.player.x--;
                    break;

                case "confirm":
                    //Unused
                    break;

                case "back":
                    //Unused
                    break;

                case "exit":
                    Program.gameOver = true;
                    Program.overworldLoop = false;
                    return;

                case "reload":
                    Program.overworldLoop = false;
                    return;

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

            //Check if the player can move on to a Specified tile
            if (Program.map[Program.player.y - 1, Program.player.x - 2] == '^' || Program.map[Program.player.y - 1, Program.player.x - 2] == '~')
            {
                Program.player.x = Program.tempPlayerX;
                Program.player.y = Program.tempPlayerY;
            }
        }

        private static void Battle()
        {
            switch (simpleInput)
            {
                case "down":
                    //Unused
                    break;

                case "up":
                    //Unused
                    break;

                case "right":
                    if (Program.selectedBattleOption != 2 && Program.battleState == 0)
                        Program.selectedBattleOption++;

                    if (Program.selectedBattleEnemy != 2 && Program.battleState == 1)
                        Program.selectedBattleEnemy++;
                    break;

                case "left":
                    if (Program.selectedBattleOption != 0 && Program.battleState == 0)
                        Program.selectedBattleOption--;

                    if (Program.selectedBattleEnemy != 0 && Program.battleState == 1)
                        Program.selectedBattleEnemy--;
                    break;

                case "confirm":
                    if (Program.battleState == 1)
                        Program.battleState = 2;

                    if (Program.battleState == 0)
                    {
                        if (Program.selectedBattleOption == 0)
                            Program.battleState = 1;

                        if (Program.selectedBattleOption == 2)
                            Program.battleState = 3;
                    }
                    return;

                case "back":
                    if (Program.battleState == 1)
                    {
                        Program.battleState = 0;
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
}
