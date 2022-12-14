/* Program name: Pong NEM
Project file name: PlayerPaddle.cs
Author: Nigel Maynard
Date: 24/8/22
Language: C#
Platform: Microsoft Visual Studio 2022
Purpose: Class work
Description: Assessment game: Pong.
Known Bugs:
Additional Features:
*/

using System.Drawing;

namespace Pong_NEM
{
    public class PlayerPaddle : Paddle
    {
        // Child class of Paddle
        // Class Constructor
        public PlayerPaddle(Rectangle formRectangle, Rectangle scoreBoardRectangle, RandomColor randomColor) : base(formRectangle, scoreBoardRectangle, randomColor)
        {
            paddleSide = formRectangle.Left;
        }
    }
}
