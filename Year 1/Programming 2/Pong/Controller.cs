/* Program name: Pong NEM
Project file name: Controller.cs
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
using System.Drawing;

namespace Pong_NEM
{
    public class Controller
    {
        // Class Variables
        private const int ENDGAMECONDITION = 10;

        private Ball ball;
        private Paddle playerPaddle, cpuPaddle;
        private Screen screen;
        private Score playerScore, cpuScore;
        private ScoreBoard scoreBoard;
        private HighScore highScore;
        private RandomColor randomColor;
        private Menu menu;

        private bool isPaused, isPlayHighScore, isHighScoreRunOnce;
        // Gets and Sets
        public bool IsPlayHighScore { get => isPlayHighScore; set => isPlayHighScore = value; }
        public int GetENDGAMECONDITION => ENDGAMECONDITION;


        // Class Constructor
        public Controller(Graphics bufferGraphics, Random random, Rectangle formRectangle)
        {
            randomColor = new RandomColor(random);
            menu = new Menu();
            scoreBoard = new ScoreBoard(formRectangle);
            playerPaddle = new PlayerPaddle(formRectangle, scoreBoard.GetScoreBoardRectangle, randomColor);
            cpuPaddle = new CpuPaddle(formRectangle, scoreBoard.GetScoreBoardRectangle, randomColor);
            playerScore = new Score("PLAYER", formRectangle.Left + 20);
            cpuScore = new Score("CPU", formRectangle.Right - 100);
            ball = new Ball(formRectangle, formRectangle, scoreBoard.GetScoreBoardRectangle, playerScore, cpuScore, playerPaddle, cpuPaddle, randomColor, random);
            highScore = new HighScore(playerScore, cpuScore);
            screen = new Screen(bufferGraphics, ball, playerPaddle, cpuPaddle, playerScore, cpuScore, scoreBoard, formRectangle, menu, this, highScore);

            isPaused = false;
            isPlayHighScore = false;
            isHighScoreRunOnce = false;
        }


        // This will be called by the timer
        // Will run the display for pausing the game and running the match
        public void RunGame()
        {
            // This runs if highscore isn't going to play, the 2 statments inside can only be run once
            if (!isPlayHighScore)
            {
                if (playerScore.GetScore == ENDGAMECONDITION && !isHighScoreRunOnce)
                {
                    highScore.WhoWon(true);
                    isHighScoreRunOnce = true;
                }
                if (cpuScore.GetScore == ENDGAMECONDITION && !isHighScoreRunOnce)
                {
                    highScore.WhoWon(false);
                    isHighScoreRunOnce = true;
                }
                screen.DisplayScreen(isPaused);
            }

            // This runs if the game is over to display the highscore
            if (isPlayHighScore) screen.HighScores();
        }



        // Tells player paddle to moves paddle up
        public void MovePaddleUp(int up)
        {
            playerPaddle.MoveCpuPaddle(up);
        }

        // Tells player paddle to moves paddle down
        public void MovePaddleDown(int down)
        {
            playerPaddle.MoveCpuPaddle(down);
        }

        // This is called by a keydown to pause or resume the game
        public void PauseGame()
        {
            isPaused = !isPaused;
        }
    }
}
