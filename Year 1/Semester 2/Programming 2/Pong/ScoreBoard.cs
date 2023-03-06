/* Program name: Pong NEM
Project file name: ScoreBoard.cs
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
    public class ScoreBoard
    {
        // Class Variables
        private const string PLAYERSCORE = "You score 1",
            CPUSCORE = "Cpu score 1",
            YOUWIN = "You wins this round",
            YOULOSE = "Cpu wins this round";
        private Rectangle scoreBoardRectangle;
        private Brush brush = Brushes.Blue;

        private int scoreBoardHeight;

        // Gets
        public Rectangle GetScoreBoardRectangle => scoreBoardRectangle;
        public Brush GetScoreBoardBrush => brush;
        public string GetPlayerScore => PLAYERSCORE;
        public string GetCpuScore => CPUSCORE;
        public string GetYouWin => YOUWIN;
        public string GetYouLose => YOULOSE;


        // Class constructor
        public ScoreBoard(Rectangle formRectangle)
        {
            scoreBoardHeight = formRectangle.Height / 6;
            scoreBoardRectangle = new Rectangle(formRectangle.Left, formRectangle.Top, formRectangle.Width, scoreBoardHeight);
        }
    }
}
