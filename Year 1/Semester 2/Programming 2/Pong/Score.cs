/* Program name: Pong NEM
Project file name: Score.cs
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
    public class Score
    {
        // Class Variables
        private const int NAMEOFYPOSITION = 20, SCOREOFYPOSITION = 60;
        private Font font;

        private int score = 0, nameXPosition;
        private string name;
        private bool hasScored;

        // Gets and sets
        public int CurrentScore { get => score; set => score = value; }
        public bool HasScored { get => hasScored; set => hasScored = value; }
        public string GetName => name;
        public int GetScore => score;
        public int GetNameXPosition => nameXPosition;
        public int GetNameOfYPosition => NAMEOFYPOSITION;
        public int GetScoreOfYPosition => SCOREOFYPOSITION;
        public Font GetFont => font;


        // Class Constructor
        public Score(string name, int nameXPosition)
        {
            this.name = name;
            this.nameXPosition = nameXPosition;
            font = new Font("Ariel", 20, FontStyle.Bold);
            hasScored = false;
        }
    }
}
