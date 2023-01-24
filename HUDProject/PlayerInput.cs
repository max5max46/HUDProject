using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDProject
{
    internal class PlayerInput
    {
        public static string ReadPlayerInput()
        {
            string simpleInput = "";

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

            return simpleInput;
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

        
    }
}
