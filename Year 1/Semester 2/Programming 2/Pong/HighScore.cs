/* Program name: Pong NEM
Project file name: HighScore.cs
Author: Nigel Maynard
Date: 24/8/22
Language: C#
Platform: Microsoft Visual Studio 2022
Purpose: Class work
Description: Assessment game: Pong.
Known Bugs:
Additional Features:
*/

using System;
using System.IO;

namespace Pong_NEM
{
    public class HighScore
    {
        // Class Variables
        private const int MAXSCORELIST = 5;
        private Score playerScore, cpuScore;
        private string[] highScoreArr = new string[5];
        private bool winnerIsPlayer;

        public string[] HighScoreArr => highScoreArr;


        // Class Constructor
        public HighScore(Score playerScore, Score cpuScore)
        {
            this.playerScore = playerScore;
            this.cpuScore = cpuScore;
        }


        // This fills the array form the file
        public void FillArrayFromFile()
        {
            StreamReader sr = new StreamReader(@"../../HighScores.txt");
            int index = 0;
            highScoreArr[index] = makeNewHighScore();
            index++;

            while (index < MAXSCORELIST)
            {
                highScoreArr[index] = sr.ReadLine();
                index++;
            }
            sr.Close();
        }

        // This saves the array to a file
        public void SaveToTXTFile()
        {
            StreamWriter sr = new StreamWriter(@"../../HighScores.txt");

            for (int i = 0; i < highScoreArr.Length; i++)
            {
                sr.WriteLine(highScoreArr[i]);
            }
            sr.Close();
        }

        // This sets the winner and calls the other methods
        public void WhoWon(bool playerWin)
        {
            winnerIsPlayer = playerWin;
            FillArrayFromFile();
            SaveToTXTFile();
        }

        // This creates a new string for the current finished game
        private string makeNewHighScore()
        {
            string winnerName = winnerIsPlayer ? playerScore.GetName : cpuScore.GetName;
            return $"{playerScore.GetName}: {playerScore.GetScore} || {cpuScore.GetName}: {cpuScore.GetScore} || Winner is {winnerName}";
        }
    }
}
